using ContactWebModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MyContactManagerData
{
    public class MyContactManagerDbContext : DbContext
    {
        private static IConfigurationRoot _configuration;

        public DbSet<State> States { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public MyContactManagerDbContext()
        {
            //purposefully empty: Necessary for Scaffold
        }

        public MyContactManagerDbContext(DbContextOptions options)
            : base(options)
        {
            //purposefully empty: sets options appropriatly
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
            var cnstr = _configuration.GetConnectionString("MyContactManager");
            optionsBuilder.UseSqlServer(cnstr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>(x =>
            {
                x.HasData(
                    new State() { Id = 1, Name = "Alabama", Abberviation = "AL"},
                    new State() { Id = 2, Name = "Alska", Abberviation = "AK" },
                    new State() { Id = 3, Name = "Arizona", Abberviation = "AZ" },
                    new State() { Id = 4, Name = "Arkansas", Abberviation = "AL" },
                    new State() { Id = 5, Name = "California", Abberviation = "CA" },
                    new State() { Id = 6, Name = "Colorado", Abberviation = "CO" },
                    new State() { Id = 7, Name = "Connecticut", Abberviation = "CT" },
                    new State() { Id = 8, Name = "Delaware", Abberviation = "DE" },
                    new State() { Id = 9, Name = "Florida", Abberviation = "FL" },
                    new State() { Id = 10, Name = "Georgia", Abberviation = "GA" }

                    );
            });
        }

    }
}