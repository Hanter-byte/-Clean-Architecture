using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "The CPF is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [Display(Name = "Cpf")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "The Telefone is Required")]
        [MinLength(9)]
        [MaxLength(9)]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }
    }
}