using ApiMaxNetFtth.Domain.Model;
using ApiMaxNetFtth.Repositorio.Data;
using Microsoft.Extensions.Configuration;
using Dapper;
using ApiMaxNetFtth.Filtro;

namespace ApiMaxNetFtth.Repositorio
{
    public class CaixaRepositorio : Contexto
    {
        // herdando parametros do Data Contexto para injeção de dependencias
        public CaixaRepositorio(IConfiguration configuration) : base(configuration) { }

        // função de inserção na tabela
        public void Inserir(CaixaModel modelo)
        {
            try
            {
                AbrirConexao();

                string commandSql = @"INSERT INTO Caixa 
                                                (Nome, Referencia, Rua, Bairro, Cidade)
                                           VALUES
                                                (@nome, @referencia, @rua, @bairro, @cidade);";

                
                var rowsAffected = _conn.Execute(commandSql, modelo);

            }
            finally
            {
                FecharConexao();
            }
        }
   
        public List<CaixaModel> ListarTodos(string? nome)
        {
            try
            {
                AbrirConexao();

                string commandSql = @"SELECT 
                                           Id, Nome, Referencia, Rua, Bairro, Cidade
                                        FROM 
                                           Caixa";

                if (!string.IsNullOrWhiteSpace(nome))
                    commandSql += " WHERE Nome LIKE @nome";

                var caixas = _conn.Query<CaixaModel>(commandSql, new { nome });

                return caixas.ToList();
            }
            finally
            {
                FecharConexao();
            }
        }

        // função para deletar um cliente do banco de dados
        public void Excluir(int id)
        {
            try
            {
                AbrirConexao();

                string commandSql = @"DELETE FROM Caixa 
                                       WHERE Id = @id";

                var linhasAfetadas = _conn.Execute(commandSql, new { id });

                if (linhasAfetadas == 0)
                    throw new ValidacaoException($"Nenhum registro afetado para o Id {id}");
            }
            finally
            {
                FecharConexao();
            }

        }

        // função para buscar cliente específico
        public CaixaModel? BuscarEspecifico(int id)
        {
            try
            {
                AbrirConexao();

                string commandSql = @"SELECT 
                                           Id, Nome, Referencia, Rua, Bairro, Cidade 
                                        FROM
                                           Caixa
                                       WHERE 
                                           Id = @id";

                var caixa = _conn.QueryFirstOrDefault<CaixaModel>(commandSql, new { id });

                return caixa;
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
