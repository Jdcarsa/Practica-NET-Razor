﻿

using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class TownRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Town>
    {
        private static GeneralResponse NotFound() => new(false, "Sorry Town not found");
        private static GeneralResponse Success() => new(true, "Process Completed");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var town = await appDbContext.Towns.FindAsync(id);
            if (town is null) return NotFound();

            appDbContext.Towns.Remove(town);
            await Commit();
            return Success();
        }

        public async Task<List<Town>> GetAll()
            => await appDbContext.Towns.AsNoTracking().Include(t => t.City).ToListAsync();


        public async Task<Town> GetById(int id)
             => await appDbContext.Towns.FindAsync(id);


        public async Task<GeneralResponse> Insert(Town item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Town already added");
            appDbContext.Towns.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Town item)
        {
            var town = await appDbContext.Towns.FindAsync(item.Id);
            if (town is null) return NotFound();
            town.Name = item.Name;
            town.cityId = item.cityId;
            await Commit();
            return Success();
        }

        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.Countries.FirstOrDefaultAsync(d => d.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
