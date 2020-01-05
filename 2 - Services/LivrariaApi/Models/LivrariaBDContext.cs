using System.Data.Entity;
using LivrariaApi.Models.Mapping;

namespace LivrariaApi.Models
{
    public partial class LivrariaBDContext : DbContext
    {
        static LivrariaBDContext()
        {
            Database.SetInitializer<LivrariaBDContext>(null);
        }

        public LivrariaBDContext()
            : base("Name=LivrariaBDContext")
        {
        }

        public DbSet<Livraria> Livrarias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LivrariaMap());
        }
    }
}
