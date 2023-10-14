using Microsoft.AspNetCore.Mvc;
using questor_challenge.Data;
using questor_challenge.Models;
using questor_challenge.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace questor_challenge.Controllers
{
    [Route("api/boletos")]
    [ApiController]
    public class BoletoController : ControllerBase
    {
        private readonly QuestorContext _context;
        private readonly IMapper _mapper;

        public BoletoController
        (
            QuestorContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoletoDTO>>> GetBoletos()
        {
            try
            {
                var boletos = await _context.Boletos.ToListAsync();
                var boletosDTO = _mapper.Map<IEnumerable<BoletoDTO>>(boletos);
                return Ok(boletosDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Boleto>> CreateBoleto([FromBody] BoletoDTO boletoDTO)
        {
            try
            {
                Boleto boleto = _mapper.Map<Boleto>(boletoDTO);
                _context.Boletos.Add(boleto);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetBoleto", new { id = boleto.Id }, boleto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}