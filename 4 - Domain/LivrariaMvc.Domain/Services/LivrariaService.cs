using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LivrariaMvc.Domain.DTO;
using LivrariaMvc.Domain.Interfaces.Repository;
using LivrariaMvc.Domain.Interfaces.Services;
using LivrariaMvc.Domain.Models;
using log4net;

namespace LivrariaMvc.Domain.Services
{
    public class LivrariaService : ILivrariaService
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(String));

        private readonly ILivrariaRepository _livrariaRepository;

        public LivrariaService(ILivrariaRepository livrariaRepository)
        {
            _livrariaRepository = livrariaRepository;
            
        }
        

        #region Interface Members

        public Livraria Adicionar(Livraria livraria)
        {
            try { 
                return _livrariaRepository.Adicionar(livraria);
            }
            catch (Exception ex) {
                log.Error(ex);
            }
            return null;
        }

        public Livraria Atualizar(Livraria livraria)
        {
            try
            {
                return _livrariaRepository.Atualizar(livraria);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return null;
        }

        public void Dispose()
        {
            _livrariaRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Livraria ObterPorAutor(string autor)
        {
            return _livrariaRepository.ObterPorAutor(autor);
        }

        public Livraria ObterPorId(int id)
        {
            return _livrariaRepository.ObterPorId(id);
        }

        public Livraria ObterPorNome(string nome)
        {
            return _livrariaRepository.ObterPorNome(nome);
        }

        public Paged<Livraria> ObterTodos(string nome, int pageSize, int pageNumber)
        {
            return _livrariaRepository.ObterTodos(nome,pageSize,pageNumber);
        }
        public IEnumerable<Livraria> ObterTodos()
        {
            return _livrariaRepository.ObterTodos();
        }

        public void Remover(int id)
        {
            _livrariaRepository.Remover(id);
        }

        public IEnumerable<Livraria> ObterTodos(string PropertyName)
        {
            IEnumerable<Livraria> list = _livrariaRepository.ObterTodos(PropertyName);

            return list;
        }

        public IEnumerable<Livraria> Buscar(Expression<Func<Livraria, bool>> predicate)
        {
            return _livrariaRepository.Buscar(predicate);
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
