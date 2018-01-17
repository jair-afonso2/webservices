using System.Collections.Generic;

namespace WebServicesCidades.Models
{
    public class Cidades
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Estado { get; set; }

        public int Habitantes { get; set; }

        /*public List<Cidades> Listar(){
            return new List<Cidades>(){
                new Cidades{Id=1,Nome="Leme",Estado="SP",Habitantes=154},
                new Cidades{Id=2,Nome="São Paulo",Estado="SP",Habitantes=231},
                new Cidades{Id=3,Nome="Belo Horizonte",Estado="MG",Habitantes=418},
                new Cidades{Id=4,Nome="São Caetano do Sul",Estado="SP",Habitantes=34},
            };
        }*/
    }
}