using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LivrariaMvc.Domain.DTO;
using LivrariaMvc.Domain.Models;
using TEntityMvc.Domain.Interfaces.Repository;

namespace LivrariaMvc.Domain.Interfaces.Repository
{
    public interface ILivrariaRepository : IRepository<Livraria>
    {
        Livraria ObterPorId(int id);
        Livraria ObterPorNome(string nome);
        Livraria ObterPorAutor(string autor);
        Paged<Livraria> ObterTodos(string nome, int pageSize, int pageNumber);
        IEnumerable<Livraria> Buscar(Expression<Func<Livraria, bool>> predicate);

    }



}

