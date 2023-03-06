using ApiMaxNetFtth.Domain.Model;
using ApiMaxNetFtth.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiMaxNetFtth.Servico
{
    public class CaixaServico
    {
        private readonly CaixaRepositorio _repositorio;

        public CaixaServico(CaixaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Inserir(CaixaModel modelo)
        {
            try
            {
                _repositorio.AbrirConexao();
                _repositorio.Inserir(modelo);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
    }
}
