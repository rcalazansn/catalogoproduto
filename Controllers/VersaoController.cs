using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Controllers
{
    public class VersaoController : Controller
    {
        [HttpGet]
        [Route("v1/versao")]
        public string Get()
        {
            return "versao: 1.0";
        }
    }
}