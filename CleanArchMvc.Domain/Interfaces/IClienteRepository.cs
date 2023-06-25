using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClientetsAsync();
        Task<Cliente> GetByIdAsync(int id);
        Task<Cliente> CreateAsync(Cliente cliente);
        Task<Cliente> UpdateAsync(Cliente cliente);
        Task<Cliente> RemoveAsync(Cliente cliente);
    }
}