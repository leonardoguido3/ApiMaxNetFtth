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
            _repositorio.Inserir(modelo);
        }
        
        public List<CaixaModel> ListarTodos (string? nome)
        {
            return _repositorio.ListarTodos(nome);
        }
        public bool Excluir(int id)
        {
            _repositorio.Excluir(id);
            return true;

        }
        public CaixaModel BuscarEspecifico(int id)
        {
           return _repositorio.BuscarEspecifico(id);
        }

    }
}
