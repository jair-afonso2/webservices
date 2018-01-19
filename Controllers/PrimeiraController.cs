using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServicesCidades.Models;

namespace WebServicesCidades.Controllers
{
    //Vamos definir a rota para a requisição o serviço
    [Route("api/[controller]")]
    public class PrimeiraController:Controller
    {

        //Cidades cidade = new Cidades();

        DAOCidades dao = new DAOCidades();

        [HttpGet]
        public IEnumerable<Cidades> Get(){
            return dao.Listar();
        }

        [HttpGet("{id}", Name="CidadeAtual")]
        public Cidades GetCidades(int id){
            return dao.Listar().Where(x => x.Id==id).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cidades cidades){
            dao.Cadastro(cidades);
            return CreatedAtRoute("CidadeAtual", new{id=cidades.Id}, cidades);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] Cidades cidades)
        {
           dao.Atualizar(cidades);  
           return CreatedAtRoute("CidadeAtual", new {id=cidades.Id}, cidades);                    

        }

        [HttpDelete("{id}")]
        public bool Deletar(int id)
        {
            return dao.Deletar(id);
        }

    }
}