using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
        {
            var cliente = await _clienteService.GetClientes();
            if(cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }
        [HttpGet("{id:int}", Name = "GetClienteId")]
        public async Task<ActionResult<ClienteDTO>> Get(int id)
        {
            var cliente = await _clienteService.GetById(id);
            if (cliente == null)
            {
                return NotFound("Cliente not found!");
            }
            return Ok(cliente);
        }
    }
}