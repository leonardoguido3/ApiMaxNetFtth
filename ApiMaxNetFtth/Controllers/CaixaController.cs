using ApiMaxNetFtth.Domain.Model;
using ApiMaxNetFtth.Filtro;
using ApiMaxNetFtth.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ApiMaxNetFtth.Controllers
{
    [ApiController]
    public class CaixaController : ControllerBase
    {
        // injeção do servico
        private readonly CaixaServico _caixa;
        public CaixaController(CaixaServico caixa)
        {
            _caixa = caixa;
        }

        [HttpPost("caixa")]
        public ActionResult Inserir([FromBody] CaixaModel modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _caixa.Inserir(modelo);
                    return StatusCode(201);
                }
                catch (ValidacaoException erro)
                {
                    return StatusCode(400, erro.Message);
                }
                catch (Exception erro)
                {
                    return StatusCode(500, erro.ToString());
                }
            }
            return StatusCode(415);
        }

        // meotodo GET para buscar todos os funcionarios ou buscar por identificador
        [HttpGet("caixa")]
        public IActionResult ListarTodos([FromQuery] string? nome)
        {
            return StatusCode(200, _caixa.ListarTodos(nome));
        }
        
        // metodo para deletar dados
        [HttpDelete("caixa/{id}")]
        public IActionResult Excluir([FromRoute] int id)
        {
            _caixa.Excluir(id);
            // retornando sucesso
            return StatusCode(200);
        }

        // metodo para obter um cliente
        [HttpGet("caixa/{id}")]
        public IActionResult BuscaEspecifica([FromRoute] int id)
        {
            // retornando sucesso
            return StatusCode(200, _caixa.BuscarEspecifico(id));
        }


    }
}
