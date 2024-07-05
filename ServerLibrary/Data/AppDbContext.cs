﻿using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace ServerLibrary.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employee { get; set; }

        //General Departments / Department / Branch
        public DbSet<GeneralDepartment> GeneralDepartments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Branch> Branches { get; set; }

        //Country / City / Town
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Town> Towns { get; set; }

        //Authentication / Role / System Roles
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<SystemRole> SystemRoles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RefreshTokenInfo> RefreshTokenInfos { get; set; }

        //Other / Vacation / Saction / Doctor / Overtime
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<VacationType> VacationTypes { get; set; }

        public DbSet<Overtime> Overtimes { get; set; }
        public DbSet<OvertimeType> OvertimeTypes { get; set; }

        public DbSet<Saction> Sactions { get; set; }
        public DbSet<SactionType> SactionTypes { get; set; }

        public DbSet<Doctor> Doctors { get; set; }
    }
}
