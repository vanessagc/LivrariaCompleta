using LivrariaMvc.Infra.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LivrariaMvc.Tests
{
    [TestClass]
    public class LivrariaTest
    {
        [TestMethod]
        public void TestNome()
        {
            Livraria livraria = new Livraria() {
                Nome = "teste",
                Autor = "teste",
                Preco = 11.11M,
                LivrariaID = 1
                
            };

            Assert.IsFalse(livraria.Nome == "", "Preenchimento de nome é obrigatório.");

        }

        [TestMethod]
        public void TestAutor()
        {
            Livraria livraria = new Livraria()
            {
                Nome = "teste",
                Autor = "teste",
                Preco = 11.11M,
                LivrariaID = 1

            };

            Assert.IsFalse(livraria.Autor == "", "Preenchimento de autor é obrigatório.");

        }

        [TestMethod]
        public void TestPreco()
        {
            Livraria livraria = new Livraria()
            {
                Nome = "teste",
                Autor = "teste",
                Preco = 11.11M,
                LivrariaID = 1

            };

            Assert.IsFalse(livraria.Preco == 0, "Preenchimento de preço deve ser maior que zero.");

        }
    }

}
