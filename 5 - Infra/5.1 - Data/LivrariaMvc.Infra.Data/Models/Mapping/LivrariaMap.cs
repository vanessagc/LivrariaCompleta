using System.Data.Entity.ModelConfiguration;

namespace LivrariaMvc.Infra.Data.Models.Mapping
{
    public class LivrariaMap : EntityTypeConfiguration<Livraria>
    {
        public LivrariaMap()
        {
            // Primary Key
            this.HasKey(t => t.LivrariaID);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Autor)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Livraria");
            this.Property(t => t.LivrariaID).HasColumnName("LivrariaID");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Autor).HasColumnName("Autor");
            this.Property(t => t.Preco).HasColumnName("Preco");
            this.Property(t => t.Imagem).HasColumnName("Imagem");
        }
    }
}
