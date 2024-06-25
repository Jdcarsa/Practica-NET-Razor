﻿

using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class VacationTypeRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<VacationType>
    {

        private static GeneralResponse NotFound() => new(false, "Sorry VacationTyp not found");
        private static GeneralResponse Success() => new(true, "Process Completed");
        private async Task Commit() => await appDbContext.SaveChangesAsync();

        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.VacationsTypes.FindAsync(id);
            if (item is null) return NotFound();

            appDbContext.VacationsTypes.Remove(item);
            await Commit();
            return Success();
        }

        public async Task<List<VacationType>> GetAll() => await appDbContext.VacationsTypes.AsNoTracking().ToListAsync();

        public async Task<VacationType> GetById(int id) => await appDbContext.VacationsTypes
            .FindAsync(id);

        public async Task<GeneralResponse> Insert(VacationType item)
        {
            if (!await CheckName(item.Name))
            {
                return new GeneralResponse(false, "VacationsTypes already added");
            }
            appDbContext.VacationsTypes.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(VacationType item)
        {
            var obj = await appDbContext.VacationsTypes.FindAsync(item.Id);
            if (obj is null) return NotFound();

            obj.Name = item.Name;
            await Commit();
            return Success();
        }

        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.VacationsTypes.FirstOrDefaultAsync(d => d.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
