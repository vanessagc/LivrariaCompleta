using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Dapper;
using LivrariaMvc.Domain.DTO;
using LivrariaMvc.Domain.Interfaces.Repository;
using LivrariaMvc.Domain.Models;
using LivrariaMvc.Infra.Data.Context;
using TEntityMvc.Domain.Interfaces.Repository;

namespace LivrariaMvc.Infra.Data.Repository
{

    public class LivrariaRepository : IRepository<Livraria>, ILivrariaRepository
    {
        protected LivrariaEntityContext Db;
        protected DbSet<Livraria> DbSet;

        public LivrariaRepository(LivrariaEntityContext context)
        {
            Db = context;
            DbSet = Db.Set<Livraria>();
        }

        #region Interfaces Members

        public Livraria ObterPorId(int id)
        {
            return Buscar(c => c.LivrariaID == id).FirstOrDefault();
        }
        public Livraria Adicionar(Livraria livraria)
        {
            //db.Livrarias.Add(livraria);
            //db.SaveChanges();

            var objreturn = DbSet.Add(livraria);
            Db.SaveChanges();

            return objreturn;
        }

        public Livraria Atualizar(Livraria livraria)
        {
            var entry = Db.Entry(livraria);
            DbSet.Attach(livraria);
            entry.State = EntityState.Modified;

            // db.Entry(livraria).State = EntityState.Modified;
            Db.SaveChanges();

            return livraria;
        }

        public IEnumerable<Livraria> Buscar(Expression<Func<Livraria, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public Livraria ObterPorAutor(string autor)
        {
            //return Db.Clientes.FirstOrDefault(c => c.CPF == cpf);
            return Buscar(c => c.Autor == autor).FirstOrDefault();
        }
        
        public Livraria ObterPorNome(string nome)
        {
            return Buscar(c => c.Nome == nome).FirstOrDefault();
        }
        public IEnumerable<Livraria> ObterTodos()
        {
            return DbSet.AsEnumerable();
        }
        public Paged<Livraria> ObterTodos(string nome, int pageSize, int pageNumber)
        {

            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Livrarias " +
                      "WHERE (@Nome IS NULL OR Nome LIKE @Nome + '%') " +
                      "ORDER BY [Nome] " +
                      "OFFSET " + pageSize * (pageNumber - 1) + " ROWS " +
                      "FETCH NEXT " + pageSize + " ROWS ONLY " +
                      " " +
                      "SELECT COUNT(LivrariaId) FROM Livrarias " +
                      "WHERE (@Nome IS NULL OR Nome LIKE @Nome + '%') ";

            var multi = cn.QueryMultiple(sql, new { Nome = nome });
            var clientes = multi.Read<Livraria>();
            var total = multi.Read<int>().FirstOrDefault();

            var pagedList = new Paged<Livraria>()
            {
                List = clientes,
                Count = total
            };

            return pagedList;
            
            //return DbSet.ToList(); //Take(t).Skip(s).ToList();
            //return Buscar(c => c.Nome == nome).Take(pageNumber).Skip(pageSize).ToList();

        }
        public void Remover(int id)
        {
            DbSet.Remove(DbSet.Find(id));
            Db.SaveChanges();
        }

        //public IEnumerable<Livraria> Buscar(Expression<Func<Livraria, bool>> predicate)
        //{
        //    IEnumerable<Livraria> list = Db.Livrarias.AsQueryable().Where(predicate);
        //    return null;
        //}

        public int SaveChanges()
        {
            return 0;
        }

        public IEnumerable<Livraria> ObterTodos(string PropertyName)
        {
            IEnumerable<Livraria> list = (IEnumerable<Livraria>)DbSet.AsEnumerable();

            return list;
        }

        #endregion

    }

}
