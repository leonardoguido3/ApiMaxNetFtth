using ApiMaxNetFtth.Domain.Model;
using ApiMaxNetFtth.Filtro;
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
                _repositorio.Inserir(modelo);
            }
            catch (ValidacaoException error)
            {
                // Tratativa de erro aqui
                Console.WriteLine($"Ocorreu um erro ao tentar inserir a caixa {modelo.Nome}: {error.Message}");
            }
        }

        public List<CaixaModel> ListarTodos(string? nome)
        {
            try
            {
                return _repositorio.ListarTodos(nome);
            }
            catch (ValidacaoException)
            {
                // Tratativa de erro aqui
                return new List<CaixaModel>();
            }

        }
        public bool Excluir(int id)
        {
            try
            {
                _repositorio.Excluir(id);
                return true;
            }
            catch (ValidacaoException)
            {
                return false;
            }

        }
        public CaixaModel BuscarEspecifico(int id)
        {
            try
            {
                return _repositorio.BuscarEspecifico(id);
            }
            catch (ValidacaoException)
            {
                return new CaixaModel();
            }
            
        }

    }
}
