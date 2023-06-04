using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        ApplicationDbContext _clienteContext;
        public ClienteRepository(ApplicationDbContext context)
        {
            _clienteContext = context;
        }

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            _clienteContext.Clientes.Add(cliente);
            await _clienteContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _clienteContext.Clientes.FindAsync(id);
        }

        public async Task<IEnumerable<Cliente>> GetClientetsAsync()
        {
            return await _clienteContext.Clientes.ToListAsync();
        }

        public async Task<Cliente> RemoveAsync(Cliente cliente)
        {
            _clienteContext.Clientes.Remove(cliente);
            await _clienteContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> UpdateAsync(Cliente cliente)
        {
            _clienteContext.Clientes.Update(cliente);
            await _clienteContext.SaveChangesAsync();
            return cliente;
        }
    }
}