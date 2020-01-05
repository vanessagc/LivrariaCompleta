using System;
using System.Collections.Generic;

namespace LivrariaMvc.Infra.Data.Models
{
    public class Livraria
    {
        public int LivrariaID { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public decimal Preco { get; set; }
        public byte[] Imagem { get; set; }
    }
}
