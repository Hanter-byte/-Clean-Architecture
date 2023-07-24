using CleanArchMvc.Domain.Validation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Cliente : EntityBase
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Telefone { get; private set; }

        private void ValidateDomain(string nome, string cpf, string telefone)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Name is required");

            DomainExceptionValidation.When(nome.Length < 3, "Name is too short, minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(cpf), "Cpf is required");

            DomainExceptionValidation.When(cpf.Length < 11, "Cpf is invalid");

            DomainExceptionValidation.When(string.IsNullOrEmpty(telefone), "Telefone is required");

            DomainExceptionValidation.When(telefone.Length < 9, "Telefone is invalid");

            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
        }
    }
}