using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; protected set; }

        //DateTime CreatedDate { get; set; } // Informações que podem ser ultilizadas aqui;
        //DateTime UpdatedDate { get; set; }
        //string CreatedBy { get; set; }
        //public string UpdatedBy { get; set;}
    }
}