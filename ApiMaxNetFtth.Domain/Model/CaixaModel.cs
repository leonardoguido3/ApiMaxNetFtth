using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMaxNetFtth.Domain.Model
{
    public class CaixaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Referencia { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public List<ClienteModel>? Clientes { get; set;}  
    }
}
