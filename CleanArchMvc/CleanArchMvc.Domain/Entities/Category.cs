using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : EntityBase //sealed garante que a classe não pode ser herdada
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "invalid Id value" );
            Id = id;
            ValidateDomain(name);
        }

        public void Update (string name)
        {
            ValidateDomain(name);
        }

        public ICollection<Product> Products{ get; set;}

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required");

            DomainExceptionValidation.When(name.Length < 3, "Name is too short, minimum 3 characters");

            Name = name;
        }
    }
}