using ApiMaxNetFtth.Domain.Model;
using ApiMaxNetFtth.Repositorio.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                using (var cmd = new SqlCommand(commandSql, _conn))
                {
                    cmd.Parameters.AddWithValue("@nome", modelo.Nome);
                    cmd.Parameters.AddWithValue("@referencia", modelo.Referencia);
                    cmd.Parameters.AddWithValue("@rua", modelo.Rua);
                    cmd.Parameters.AddWithValue("@bairro", modelo.Bairro);
                    cmd.Parameters.AddWithValue("@cidade", modelo.Cidade);
                    cmd.ExecuteNonQuery();
                }
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
                var caixas = new List<CaixaModel>();
                
                AbrirConexao();
                
                string commandSql = @"SELECT 
                                           Id, Nome, Referencia, Rua, Bairro, Cidade
                                        FROM 
                                           Caixa";

                if (!string.IsNullOrWhiteSpace(nome))
                    commandSql += " WHERE Nome LIKE @nome";


                using (var cmd = new SqlCommand(commandSql, _conn))
                {
                    if (!string.IsNullOrWhiteSpace(nome))
                        cmd.Parameters.AddWithValue("@nome", "%" + nome + "%");

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var caixa = new CaixaModel();
                            caixa.Id = Convert.ToInt32(rdr["Id"]);
                            caixa.Nome = Convert.ToString(rdr["Nome"]);
                            caixa.Referencia = Convert.ToString(rdr["Referencia"]);
                            caixa.Rua = Convert.ToString(rdr["Rua"]);
                            caixa.Bairro = Convert.ToString(rdr["Bairro"]);
                            caixa.Cidade = Convert.ToString(rdr["Cidade"]);

                            caixas.Add(caixa);
                        }
                        return caixas;
                    }
                }
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
                                       WHERE 
                                           Id = @id;";

                using (var cmd = new SqlCommand(commandSql, _conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    var linhas = cmd.ExecuteNonQuery();
                    if ( linhas == 0)
                        throw new ValidationException($"Nenhum registro afetado para o Id {id}");
                }
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
                var caixa = new CaixaModel();

                AbrirConexao();
                
                string commandSql = @"SELECT 
                                           Id, Nome, Referencia, Rua, Bairro, Cidade 
                                        FROM
                                           Caixa
                                       WHERE 
                                           Id = @id";

                using (var cmd = new SqlCommand(commandSql, _conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            caixa.Id = Convert.ToInt32(rdr["Id"]);
                            caixa.Nome = Convert.ToString(rdr["Nome"]);
                            caixa.Referencia = Convert.ToString(rdr["Referencia"]);
                            caixa.Rua = Convert.ToString(rdr["Rua"]);
                            caixa.Bairro = Convert.ToString(rdr["Bairro"]);
                            caixa.Cidade = Convert.ToString(rdr["Cidade"]);
                            return caixa;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
