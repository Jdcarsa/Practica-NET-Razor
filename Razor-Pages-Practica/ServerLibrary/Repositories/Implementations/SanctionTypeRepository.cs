

using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class SanctionTypeRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<SactionType>
    {

        private static GeneralResponse NotFound() => new(false, "Sorry SactionType not found");
        private static GeneralResponse Success() => new(true, "Process Completed");
        private async Task Commit() => await appDbContext.SaveChangesAsync();

        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.SanctionTypes.FindAsync(id);
            if (item is null) return NotFound();

            appDbContext.SanctionTypes.Remove(item);
            await Commit();
            return Success();
        }

        public async Task<List<SactionType>> GetAll() => await appDbContext.SanctionTypes.AsNoTracking().ToListAsync();

        public async Task<SactionType> GetById(int id) => await appDbContext.SanctionTypes
            .FindAsync(id);

        public async Task<GeneralResponse> Insert(SactionType item)
        {
            if (!await CheckName(item.Name))
            {
                return new GeneralResponse(false, "SactionType already added");
            }
            appDbContext.SanctionTypes.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(SactionType item)
        {
            var obj = await appDbContext.SanctionTypes.FindAsync(item.Id);
            if (obj is null) return NotFound();

            obj.Name = item.Name;
            await Commit();
            return Success();
        }

        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.SanctionTypes.FirstOrDefaultAsync(d => d.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
