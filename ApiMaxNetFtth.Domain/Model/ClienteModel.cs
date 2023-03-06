using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMaxNetFtth.Domain.Model
{

   public enum Situacao
    {
        Regular = 1,
        Pendencia = 2,
        Reducao = 3,
        Bloqueio = 4,
    }
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Situacao? Conta { get; set; }
        public CaixaModel Caixa { get; set; }
    }
}
