using System;
using Lang.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Lang.Repository
{
    public class Context : DbContext
    {
        public DbSet<WordEntry> Words { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlite("Data Source=lang.db");
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=lang;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WordEntry>(e => 
            {
                e.ToTable("word");
                e.Property(w => w.Id).HasColumnName("id");
                e.Property(w => w.Text).HasColumnName("text");
                e.Property(w => w.Language).HasColumnName("language");
                e.HasKey(w => w.Id);
                e.HasIndex(w => w.Text);
            });
        }
    }
}
