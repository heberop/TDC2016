using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Acme.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProdutosController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            return new [] 
            {
                new Produto("Bigorna de Aço", "bigorna.gif"),
                new Produto("Patins com Foguete", "patins.jpg"),
                new Produto("Tinta para Túnel (Instantâneo)", "tinta-tunel.png"),
                new Produto("Míssel Alta Velocidade", "missel.jpg")
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Tinta para Túnel Instantâneo";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class Produto
    {
        public Produto(string nome, string imagem)
        {
            this.Nome = nome;
            this.Imagem = imagem;
        }

        public string Imagem { get; private set; }
        public string Nome { get; private set; }
    }
}
