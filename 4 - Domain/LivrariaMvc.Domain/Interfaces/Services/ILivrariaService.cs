using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LivrariaMvc.Domain.DTO;
using LivrariaMvc.Domain.Models;

namespace LivrariaMvc.Domain.Interfaces.Services
{
    public interface ILivrariaService : IDisposable
    {
        Livraria Adicionar(Livraria livraria);
        Livraria ObterPorId(int id);
        Livraria ObterPorNome(string nome);
        Livraria ObterPorAutor(string autor);
        Paged<Livraria> ObterTodos(string nome, int pageSize, int pageNumber);
        IEnumerable<Livraria> ObterTodos();
        IEnumerable<Livraria> ObterTodos(string PropertyName);
        Livraria Atualizar(Livraria livraria);
        void Remover(int id);
        IEnumerable<Livraria> Buscar(Expression<Func<Livraria, bool>> predicate);

        int SaveChanges();

    }



}