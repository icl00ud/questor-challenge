using Microsoft.AspNetCore.Mvc;
using questor_challenge.Data;
using questor_challenge.Models;
using questor_challenge.DTOs;
using AutoMapper;
using questor_challenge.Services;

namespace questor_challenge.Controllers
{
    [ApiController]
    public class BoletoController : ControllerBase
    {
        private IMapper Mapper { get; }
        private BoletoServices Services { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoletoController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="services">The services.</param>
        public BoletoController
        (
            IMapper mapper,
            BoletoServices services
        )
        {
            Mapper = mapper;
            Services = services;
        }

        /// <summary>
        /// Get all boletos.
        /// </summary>
        /// <returns>List of ReadBoletoDTO.</returns>
        [HttpGet]
        [Route("/getBoletos")]
        public async Task<ActionResult<IEnumerable<ReadBoletoDTO>>> GetBoletos()
        {
            try
            {
                List<ReadBoletoDTO> boletos = await Services.GetAllBoletos();
                return Ok(Mapper.Map<IEnumerable<ReadBoletoDTO>>(boletos));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get boleto by id.
        /// </summary>
        /// <param name="id">Boleto id.</param>
        /// <returns>ReadBoletoDTO instance.</returns>
        [HttpGet]
        [Route("/getBoleto/{id}")]
        public async Task<ActionResult<ReadBoletoDTO>> GetBoletoById(int id)
        {
            try
            {
                ActionResult<ReadBoletoDTO> boleto = await Services.GetBoletoById(id);
                return boleto.Value == null ? (ActionResult<ReadBoletoDTO>)NotFound() : (ActionResult<ReadBoletoDTO>)Ok(boleto.Value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Create a new boleto.
        /// </summary>
        /// <param name="boletoDTO">CreateBoletoDTO instance.</param>
        /// <returns>The created boleto.</returns>
        /// <response code="201">The bank was successfully created.</response>
        /// <response code="400">Bad Request - If there are issues with the request payload.</response>
        [HttpPost]
        [Route("/createBoleto")]
        [ProducesResponseType(typeof(Boleto), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Boleto>> CreateBoleto([FromBody] CreateBoletoDTO boletoDTO)
        {
            try
            {
                ActionResult<Boleto> newBoleto = await Services.CreateBoleto(boletoDTO);
                return CreatedAtAction(nameof(GetBoletoById), new { id = newBoleto.Value.Id }, newBoleto.Value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}