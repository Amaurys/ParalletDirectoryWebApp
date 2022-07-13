using Microsoft.EntityFrameworkCore;

namespace ParalletDirectoryWebApp.Models
{
    public partial class ParallelContext : DbContext
    {
        public ParallelContext()
        {             
        }

        public ParallelContext(DbContextOptions<ParallelContext> options) : base(options)
        {            
        }

        public virtual DbSet<Folder> Folders { get; set; }

        public virtual DbSet<TextFile> TextFiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=ParallelTest;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Folder>(entity =>{
                entity.ToTable("Folders");

                entity.Property(e => e.Folderid).HasColumnName("Folderid");

                entity.Property(e => e.Name)
                .IsRequired();

                entity.Property(e => e.Location)
                .IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}