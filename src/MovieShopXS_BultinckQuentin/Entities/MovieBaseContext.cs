using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MovieShopXS_BultinckQuentin.Entities
{
    public partial class MovieBaseContext : DbContext
    {

        public MovieBaseContext(DbContextOptions<MovieBaseContext> options)
            :base(options)
        {

        }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=LAPTOPQ\SQLEXPRESS01;Database=MovieBase;Trusted_Connection=True;");
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.Property(e => e.Description).HasColumnType("varchar(250)");

                entity.Property(e => e.DirectorId).HasColumnName("DirectorID");

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(128)");

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.DirectorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Movie_Person");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Movie_Genre");
            });

            modelBuilder.Entity<MovieActor>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.ActorId })
                    .HasName("PK_MovieActor");

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.Property(e => e.ActorId).HasColumnName("ActorID");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.MovieActor)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MovieActor_Person");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieActor)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MovieActor_Movie");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(128)");
            });
        }

        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieActor> MovieActor { get; set; }
        public virtual DbSet<Person> Person { get; set; }
    }
}