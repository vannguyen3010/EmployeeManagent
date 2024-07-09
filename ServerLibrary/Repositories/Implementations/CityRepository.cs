﻿using BaseLibrary.Entities;
using BaseLibrary.Response;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Repositories.Implementations
{
    public class CityRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<City>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await appDbContext.Cities.FindAsync(id);
            if (dep is null) return NotFound();

            appDbContext.Cities.Remove(dep);
            await Commit();
            return Success();
        }
        public async Task<List<City>> GetAll() => await appDbContext
            .Cities
            .AsNoTracking()
            .Include(x => x.Country)
            .ToListAsync();
        public async Task<City> GetById(int id) => await appDbContext.Cities.FindAsync(id);
        public async Task<GeneralResponse> Insert(City item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Department already added");
            appDbContext.Cities.Add(item);
            await Commit();
            return Success();
        }
        public async Task<GeneralResponse> Update(City item)
        {
            var city = await appDbContext.Cities.FindAsync(item.Id);
            if (city is null) return NotFound();
            city.Name = item.Name;
            city.CountryId = item.CountryId;
            await Commit();
            return Success();
        }
        private static GeneralResponse NotFound() => new(false, "Sorry department not found");
        private static GeneralResponse Success() => new(true, "Process complete");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.Cities.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
