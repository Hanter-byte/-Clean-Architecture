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
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDTO cliente)
        {
            if (cliente == null)
            {
                return BadRequest("Invalid Data");
            }
            await _clienteService.Add(cliente);
            return new CreatedAtRouteResult("GetGategoryId", new { id = cliente.Id }, cliente); //Retorna 201
        }
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ClienteDTO cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }
            if (cliente == null)
            {
                return BadRequest();
            }
            await _clienteService.Update(cliente);
            return Ok(cliente);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ClienteDTO>> Delete(int id)
        {
            var cliente = await _clienteService.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }
            await _clienteService.Remove(id);
            return Ok(cliente);
        }
    }
}