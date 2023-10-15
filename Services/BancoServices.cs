using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using questor_challenge.Data;
using questor_challenge.Data.DTO;

namespace questor_challenge.Services
{
    /// <summary>
    /// Interface for BancoServices.
    /// </summary>
    public interface IBancoServices
    {
        /// <summary>
        /// Get all banks.
        /// </summary>
        /// <returns>List of ReadBancoDTO.</returns>
        public Task<List<ReadBancoDTO>> GetAllBancos();

        /// <summary>
        /// Get bank by id.
        /// </summary>
        /// <param name="id">Bank id.</param>
        /// <returns>Action result of ReadBancoDTO.</returns>
        public Task<ActionResult<ReadBancoDTO>> GetBancoById(int id);

        /// <summary>
        /// Get bank by code.
        /// </summary>
        /// <param name="code">Bank code.</param>
        /// <returns>Action result of ReadBancoDTO.</returns>
        public Task<ActionResult<ReadBancoDTO>> GetBancoByCode(string bankCode);

        /// <summary>
        /// Create a bank.
        /// </summary>
        /// <param name="bancoDTO">CreateBancoDTO object.</param>
        /// <returns>Action result of Bank.</returns>
        public Task<ActionResult<Banco>> CreateBanco(CreateBancoDTO bancoDTO);
    }

    /// <summary>
    /// Implementation of IBancoServices.
    /// </summary>
    public class BancoServices : IBancoServices
    {
        private readonly QuestorContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for BancoServices.
        /// </summary>
        /// <param name="context">QuestorContext object.</param>
        /// <param name="mapper">IMapper object.</param>
        public BancoServices
        (
            QuestorContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<List<ReadBancoDTO>> GetAllBancos()
        {
            List<Banco> bancos = await _context.Bancos.ToListAsync() ?? new List<Banco>();

            return _mapper.Map<List<ReadBancoDTO>>(bancos);
        }

        /// <inheritdoc/>
        public async Task<ActionResult<ReadBancoDTO>> GetBancoById(int id)
        {
            Banco? banco = await _context.Bancos.FindAsync(id);

            return banco == null ? (ActionResult<ReadBancoDTO>)new NotFoundResult() : (ActionResult<ReadBancoDTO>)_mapper.Map<ReadBancoDTO>(banco);
        }

        /// <inheritdoc/>
        public async Task<ActionResult<ReadBancoDTO>> GetBancoByCode(string bankCode)
        {
            Banco? banco = await _context.Bancos.FirstOrDefaultAsync(b => b.Code == bankCode);

            return banco == null ? (ActionResult<ReadBancoDTO>)new NotFoundResult() : (ActionResult<ReadBancoDTO>)_mapper.Map<ReadBancoDTO>(banco);
        }

        /// <inheritdoc/>
        public async Task<ActionResult<Banco>> CreateBanco(CreateBancoDTO bancoDTO)
        {
            Banco newBanco = _mapper.Map<Banco>(bancoDTO);
            _context.Bancos.Add(newBanco);
            await _context.SaveChangesAsync();
            return newBanco;
        }
    }
}