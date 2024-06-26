﻿using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class OvertimeRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Overtime>
    { 

        private static GeneralResponse NotFound() => new(false, "Sorry Overtime not found");
        private static GeneralResponse Success() => new(true, "Process Completed");
        private async Task Commit() => await appDbContext.SaveChangesAsync();

        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.Overtimes.FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (item is null) return NotFound();

            appDbContext.Overtimes.Remove(item);
            await Commit();
            return Success();
        }

        public async Task<List<Overtime>> GetAll() => await appDbContext.Overtimes
    .AsNoTracking()
    .Include(t => t.OvertimeType)
    .ToListAsync();

        public async Task<Overtime> GetById(int id) => await appDbContext.Overtimes
            .FirstOrDefaultAsync(e => e.EmployeeId == id);

        public async Task<GeneralResponse> Insert(Overtime item)
        {
            appDbContext.Overtimes.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Overtime item)
        {
            var obj = await appDbContext.Overtimes.FirstOrDefaultAsync(e => e.EmployeeId == item.EmployeeId);
            if (obj is null) return NotFound();

            obj.StartTime = item.StartTime;
            obj.EndTime = item.EndTime;
            obj.OvertimeTypeId = item.OvertimeTypeId;
            await Commit();
            return Success();
        }


    }
}