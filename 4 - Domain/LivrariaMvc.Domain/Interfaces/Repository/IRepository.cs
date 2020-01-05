using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TEntityMvc.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {

        TEntity Adicionar(TEntity livraria);
        IEnumerable<TEntity> ObterTodos();
        IEnumerable<TEntity> ObterTodos(string PropertyName);
        TEntity Atualizar(TEntity livraria);
        void Remover(int id);

        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
