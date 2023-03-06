using ApiMaxNetFtth.Domain.Model;
using ApiMaxNetFtth.Repositorio.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
            // crio uma variavel que recebe o parametro de insert do banco de dados
            string commandSql = @"INSERT INTO Caixa (Nome, Referencia, Rua, Bairro, Cidade)
                                    VALUES
                                (@nome, @referencia, @rua, @bairro, @cidade);";

            // realizo um using, criando uma variavel recebendo o comando do sql e o modelo de dados a ser iserido
            using (var cmd = new SqlCommand(commandSql, _conn))
            {
                // injeto os parametros para a inserção no banco e executo sem nenhum tipo de retorno
                cmd.Parameters.AddWithValue("@nome", modelo.Nome);
                cmd.Parameters.AddWithValue("@referencia", modelo.Referencia);
                cmd.Parameters.AddWithValue("@rua", modelo.Rua);
                cmd.Parameters.AddWithValue("@bairro", modelo.Bairro);
                cmd.Parameters.AddWithValue("@cidade", modelo.Cidade);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
