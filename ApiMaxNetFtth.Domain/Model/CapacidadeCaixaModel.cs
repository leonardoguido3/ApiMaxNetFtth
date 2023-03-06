using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMaxNetFtth.Domain.Model
{
    public class CapacidadeCaixaModel
    {
        public int Id { get; set; }
        public CaixaModel Caixa { get; set; }
        public ClienteModel Cliente { get; set; }
    }
}
