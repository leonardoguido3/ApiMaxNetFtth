using ApiMaxNetFtth.Repositorio;
using ApiMaxNetFtth.Servico;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMaxNetFtth.Ioc
{
    public class Dependencia
    {
        public static void Registro(IServiceCollection service)
        {
            // repositorios
            service.AddScoped<CaixaRepositorio, CaixaRepositorio>();

            // serviços
            service.AddScoped<CaixaServico, CaixaServico>();

            // filtros
        }
    }
}
