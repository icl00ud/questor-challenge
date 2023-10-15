using questor_challenge.DTOs;
using Questor.Services;
using questor_challenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using questor_challenge.Data;
using AutoMapper;

namespace questor_challenge.Services
{
    /// <summary>
    /// Interface for BoletoService.
    /// </summary>
    public interface IBoletoService
    {
        /// <summary>
        /// Creates a new Boleto.
        /// </summary>
        /// <param name="boletoDTO">The DTO containing the Boleto information.</param>
        /// <returns>The newly created Boleto.</returns>
        public Task<ActionResult<Boleto>> CreateBoleto(CreateBoletoDTO boletoDTO);

        /// <summary>
        /// Gets all existing Boletos.
        /// </summary>
        /// <returns>A list of all existing Boletos.</returns>
        public Task<List<ReadBoletoDTO>> GetAllBoletos();

        /// <summary>
        /// Gets a Boleto by its ID.
        /// </summary>
        /// <param name="id">The ID of the Boleto to retrieve.</param>
        /// <returns>The Boleto with the specified ID.</returns>
        public Task<ActionResult<ReadBoletoDTO>> GetBoletoById(int id);
    }

    /// <summary>
    /// Service for managing Boletos.
    /// </summary>
    public class BoletoServices : IBoletoService
    {
        private QuestorContext Context { get; }
        private CommonServices CommonServices { get; }
        private FeeServices FeeServices { get; }
        private IMapper Mapper { get; }

        /// <summary>
        /// Constructor for BoletoServices.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="commonServices">The common services.</param>
        /// <param name="feeServices">The fee services.</param>
        /// <param name="mapper">The mapper.</param>
        public BoletoServices
        (
            QuestorContext context,
            CommonServices commonServices,
            FeeServices feeServices,
            IMapper mapper
        )
        {
            Context = context;
            CommonServices = commonServices;
            FeeServices = feeServices;
            Mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<ActionResult<Boleto>> CreateBoleto(CreateBoletoDTO boletoDTO)
        {
            bool isValidBoleto = ValidateBoleto(boletoDTO);

            if (isValidBoleto)
            {
                Boleto newBoleto = Mapper.Map<Boleto>(boletoDTO);
                Context.Boletos.Add(newBoleto);
                await Context.SaveChangesAsync();
                return newBoleto;
            }
            else
            {
                return new BadRequestResult();
            }
        }

        /// <inheritdoc/>
        public async Task<List<ReadBoletoDTO>> GetAllBoletos()
        {
            DateTime today = DateTime.Now;
            List<Boleto> boletos = await Context.Boletos.ToListAsync();

            if (boletos == null)
                return new List<ReadBoletoDTO>();

            List<Boleto> result = new();

            foreach (Boleto boleto in boletos)
            {
                boleto.Banco = await Context.Bancos.FindAsync(boleto.BankId);

                if (today > boleto.DueDate)
                {
                    TimeSpan difference = today - boleto.DueDate;
                    int pastDays = difference.Days;

                    (double valueWithFee, double fee) = await FeeServices.CalculateDailyFee(boleto, pastDays);

                    boleto.Value = valueWithFee;
                    boleto.Fee = fee;
                }

                result.Add(boleto);
            }

            return Mapper.Map<List<ReadBoletoDTO>>(result);
        }

        /// <inheritdoc/>
        public async Task<ActionResult<ReadBoletoDTO>> GetBoletoById(int id)
        {
            Boleto? boleto = await Context.Boletos.FindAsync(id);

            if (boleto == null)
                return new NotFoundResult();

            DateTime today = DateTime.Now;

            boleto.Banco = await Context.Bancos.FindAsync(boleto.BankId);
            if (today > boleto.DueDate)
            {
                TimeSpan difference = today - boleto.DueDate;
                int pastDays = difference.Days;

                (double valueWithFee, double fee) = await FeeServices.CalculateDailyFee(boleto, pastDays);

                boleto.Value = valueWithFee;
                boleto.Fee = fee;
            }

            return Mapper.Map<ReadBoletoDTO>(boleto);
        }

        /// <summary>
        /// Validates a BoletoDTO.
        /// </summary>
        /// <param name="boletoDTO">The BoletoDTO to validate.</param>
        /// <returns>True if the BoletoDTO is valid, false otherwise.</returns>
        private bool ValidateBoleto(CreateBoletoDTO boletoDTO)
        {

            if (string.IsNullOrEmpty(boletoDTO.PayerIdentification) || (!CommonServices.IsValidCPF(boletoDTO.PayerIdentification) && !CommonServices.IsValidCNPJ(boletoDTO.PayerIdentification)))
                throw new ArgumentException("PayerIdentification is not a valid CPF or CNPJ.");

            if (string.IsNullOrEmpty(boletoDTO.BeneficiaryIdentification) || (!CommonServices.IsValidCPF(boletoDTO.BeneficiaryIdentification) && !CommonServices.IsValidCNPJ(boletoDTO.BeneficiaryIdentification)))
                throw new ArgumentException("BeneficiaryIdentification is not a valid CPF or CNPJ.");

            if (boletoDTO.Value <= 0)
                throw new ArgumentException("Value must be greater than 0.");

            if (string.IsNullOrEmpty(boletoDTO.PayerName))
                throw new ArgumentException("PayerName is required.");

            if (string.IsNullOrEmpty(boletoDTO.BeneficiaryName))
                throw new ArgumentException("BeneficiaryName is required.");

            if (boletoDTO.Observation != null && boletoDTO.Observation.Length > 120)
                throw new ArgumentException("Observation cannot exceed 120 characters.");

            return true;
        }
    }
}