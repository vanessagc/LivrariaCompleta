using System.ComponentModel.DataAnnotations;
using System.Web;

namespace LivrariaMvc.Models
{

    public class Livraria
    {
        public int LivrariaID { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public decimal Preco { get; set; }
        public byte[] Imagem { get; set; }
    }

    public class LivrariaViewModels
    {
        public int LivrariaID { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public decimal Preco { get; set; }
        public HttpPostedFileBase Imagem { get; set; }
    }
}