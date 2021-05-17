using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Similarity1.Entitiy
{
    public partial class My_Entitiy : DbContext
    {
        public My_Entitiy()
            : base("name=My_Entitiy")
        {
        }

        public virtual DbSet<HOMEWORK> HOMEWORK { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HOMEWORK>()
                .Property(e => e.SIMILARTYRATE)
                .HasPrecision(3, 2);
        }
    }
}
