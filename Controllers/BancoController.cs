using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using questor_challenge.Services;
using questor_challenge.Data.DTO;

namespace questor_challenge.Controllers
{
    [ApiController]
    public class BancoController : ControllerBase
    {
        private IMapper Mapper { get; }
        private BancoServices Services { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BancoController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="services">The services.</param>
        public BancoController
        (
            IMapper mapper,
            BancoServices services
        )
        {
            Mapper = mapper;
            Services = services;
        }

        /// <summary>
        /// Retrieves all banks.
        /// </summary>
        /// <returns>A list of banks.</returns>
        [HttpGet]
        [Route("/getBancos")]
        public async Task<ActionResult<IEnumerable<ReadBancoDTO>>> GetBancos()
        {
            try
            {
                List<ReadBancoDTO> bancos = await Services.GetAllBancos();
                return Ok(Mapper.Map<IEnumerable<ReadBancoDTO>>(bancos));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a bank by its ID.
        /// </summary>
        /// <param name="id">The ID of the bank to retrieve.</param>
        /// <returns>The bank with the specified ID.</returns>
        [HttpGet]
        [Route("/getBancoById/{id}")]
        public async Task<ActionResult<ReadBancoDTO>> GetBancoById(int id)
        {
            try
            {
                ActionResult<ReadBancoDTO> bank = await Services.GetBancoById(id);
                return bank == null ? (ActionResult<ReadBancoDTO>)NotFound() : (ActionResult<ReadBancoDTO>)Ok(bank.Value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a bank by its Code.
        /// </summary>
        /// <param name="bankCode">The Code of the bank to retrieve.</param>
        /// <returns>The bank with the specified Code.</returns>
        [HttpGet]
        [Route("/getBancoByCode/{bankCode}")]
        public async Task<ActionResult<ReadBancoDTO>> GetBancoByCode(string bankCode)
        {
            try
            {
                ActionResult<ReadBancoDTO> bank = await Services.GetBancoByCode(bankCode);
                return bank == null ? (ActionResult<ReadBancoDTO>)NotFound() : (ActionResult<ReadBancoDTO>)Ok(bank.Value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Creates a new bank.
        /// </summary>
        /// <param name="bankDTO">The DTO containing the information for the new bank.</param>
        /// <returns>The created bank.</returns>
        /// <response code="201">The bank was successfully created.</response>
        /// <response code="400">Bad Request - If there are issues with the request payload.</response>
        [HttpPost]
        [Route("/createBanco")]
        [ProducesResponseType(typeof(Banco), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Banco>> CreateBank([FromBody] CreateBancoDTO bankDTO)
        {
            try
            {
                ActionResult<Banco> newBank = await Services.CreateBanco(bankDTO);
                return CreatedAtAction(nameof(GetBancoById), new { id = newBank.Value.Id }, newBank.Value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}