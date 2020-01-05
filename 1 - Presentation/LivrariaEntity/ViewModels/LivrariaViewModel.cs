

namespace LivrariaEntity.ViewModels
{
    public partial class LivrariaViewModel
    {
        public int LivrariaID { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public decimal Preco { get; set; }
        public byte[] Imagem { get; set; }
    }
}
