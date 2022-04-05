using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController
    {
        public IActionResult Sucesso(object dados = null, string mensagem = "Requisição completada com sucesso.")
        {
            return new OkObjectResult(new ResponseModel{
                Data = dados,
                Mensagem = mensagem,
                Sucesso = true
            });
        }

        public IActionResult Falha(string mensagem = "Requisição falhou!")
        {
            return new BadRequestObjectResult(new ResponseModel{
                Data = null,
                Mensagem = mensagem
            });
        }

        public class ResponseModel {
            public object Data { get; set; }
            public bool Sucesso { get; set; }
            public string Mensagem { get; set; }
        }
    }
}