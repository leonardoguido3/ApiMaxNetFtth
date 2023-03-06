using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMaxNetFtth.Repositorio.Data
{
    public class Contexto
    {
        // criando uma variavel readonly interna injetando SQLConnection para acesso dentro da aplicação
        internal readonly SqlConnection _conn;

        // criando construtor que vai receber a injecao de dependencia
        public Contexto(IConfiguration configuration)
        {
            // construção do banco de dados developer
            _conn = new SqlConnection(configuration["DataBaseDev"]);
        }

        // função para abertura da conexão com o banco de dados
        public void AbrirConexao() { _conn.Open(); }

        // função para fechar conexão com o banco de dados
        public void FecharConexao() { _conn.Close(); }
    }
}
