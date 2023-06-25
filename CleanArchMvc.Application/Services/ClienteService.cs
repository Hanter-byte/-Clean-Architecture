using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ClienteService : IClienteService
    {
        private IClienteRepository _clienteRepository;
        private IMapper _mapper;
        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task Add(ClienteDTO clienteDTO)
        {
            var clienteEntity = _mapper.Map<Cliente>(clienteDTO);
            await _clienteRepository.CreateAsync(clienteEntity);
        }

        public async Task<ClienteDTO> GetById(int id)
        {
            var clienteEntity = await _clienteRepository.GetByIdAsync(id);
            return _mapper.Map<ClienteDTO>(clienteEntity);
        }

        public async Task<IEnumerable<ClienteDTO>> GetClientes()
        {
            var clienteEntity = await _clienteRepository.GetClientetsAsync();
            return _mapper.Map<IEnumerable<ClienteDTO>>(clienteEntity);
        }

        public async Task Remove(int id)
        {
            var clienteEntity = _clienteRepository.GetByIdAsync(id).Result;
            await _clienteRepository.RemoveAsync(clienteEntity);
        }

        public async Task Update(ClienteDTO cliente)
        {
            var clienteEntity = _mapper.Map<Cliente>(cliente);
            await _clienteRepository.UpdateAsync(clienteEntity);
        }
    }
}