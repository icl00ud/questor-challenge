using questor_challenge.Data.DTO;
using System.ComponentModel.DataAnnotations;

namespace questor_challenge.DTOs
{
    /// <summary>
    /// Data transfer object for creating a new Boleto.
    /// </summary>
    public class CreateBoletoDTO
    {
        /// <summary>
        /// The ID of the bank associated with the Boleto.
        /// </summary>
        [Required(ErrorMessage = "BankId is required.")]
        public int BankId { get; set; }

        /// <summary>
        /// The name of the payer associated with the Boleto.
        /// </summary>
        [Required(ErrorMessage = "PayerName is required.")]
        public string? PayerName { get; set; }

        /// <summary>
        /// The identification number of the payer associated with the Boleto.
        /// </summary>
        [Required(ErrorMessage = "PayerIdentification is required.")]
        public string? PayerIdentification { get; set; }

        /// <summary>
        /// The name of the beneficiary associated with the Boleto.
        /// </summary>
        [Required(ErrorMessage = "BeneficiaryName is required.")]
        public string? BeneficiaryName { get; set; }

        /// <summary>
        /// The identification number of the beneficiary associated with the Boleto.
        /// </summary>
        [Required(ErrorMessage = "BeneficiaryIdentification is required.")]
        public string? BeneficiaryIdentification { get; set; }

        /// <summary>
        /// The value of the Boleto.
        /// </summary>
        [Required(ErrorMessage = "Value is required.")]
        [Range(0, long.MaxValue, ErrorMessage = "Value must be greater than 0.")]
        public double Value { get; set; }

        /// <summary>
        /// The due date of the Boleto.
        /// </summary>
        [Required(ErrorMessage = "DueDate is required.")]
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Optional observation for the Boleto.
        /// </summary>
        [StringLength(120, ErrorMessage = "Observation cannot exceed 120 characters.")]
        public string? Observation { get; set; }
    }

    /// <summary>
    /// Data Transfer Object (DTO) for reading Boleto information.
    /// </summary>
    public class ReadBoletoDTO
    {
        /// <summary>
        /// The ID of the Boleto.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The ID of the Bank associated with the Boleto.
        /// </summary>
        public int BankId { get; set; }

        /// <summary>
        /// The Bank associated with the Boleto.
        /// </summary>
        public ReadBancoDTO? Banco { get; set; }

        /// <summary>
        /// The name of the payer associated with the Boleto.
        /// </summary>
        public string? PayerName { get; set; }

        /// <summary>
        /// The identification number of the payer associated with the Boleto.
        /// </summary>
        public string? PayerIdentification { get; set; }

        /// <summary>
        /// The name of the beneficiary associated with the Boleto.
        /// </summary>
        public string? BeneficiaryName { get; set; }

        /// <summary>
        /// The identification number of the beneficiary associated with the Boleto.
        /// </summary>
        public string? BeneficiaryIdentification { get; set; }

        /// <summary>
        /// The value of the Boleto.
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// The fee associated with the Boleto.
        /// </summary>
        public double Fee { get; set; }

        /// <summary>
        /// The due date of the Boleto.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Any additional observations about the Boleto.
        /// </summary>
        public string? Observation { get; set; }
    }
}