using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogin.Entities
{
    public class login
    {
        public string user { get; set; }
        public string senha { get; set; }
        public string perfil { get; set; }
        public string nome { get; set; }
        public string rua { get; set; }
        public string cidade { get; set; }
        public string cep { get; set; }
        public string cpf { get; set; }
        public DateTime nascimento { get; set; }
        public int id_login { get; set; }
    }
}
