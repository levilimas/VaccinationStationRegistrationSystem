using Microsoft.EntityFrameworkCore;
using VaccinationStationRegistrationSystem.Models;

namespace VaccinationStationRegistrationSystem.Data
{
    public class VaccinationSystemDataContext : DbContext
    {
        public DbSet<VaccinationStation> VaccinationStations { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared;");

    }
}