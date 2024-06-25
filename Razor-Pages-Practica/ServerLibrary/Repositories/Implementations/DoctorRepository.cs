using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;


namespace ServerLibrary.Repositories.Implementations
{
    public class DoctorRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Doctor>
    {
        private static GeneralResponse NotFound() => new(false, "Sorry Doctor not found");
        private static GeneralResponse Success() => new(true, "Process Completed");
        private async Task Commit() => await appDbContext.SaveChangesAsync();

        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.Doctors.FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (item is null) return NotFound();

            appDbContext.Doctors.Remove(item);
            await Commit();
            return Success();
        }

        public async Task<List<Doctor>> GetAll() => await appDbContext.Doctors
                                        .AsNoTracking()
                                        .ToListAsync();

        public async Task<Doctor> GetById(int id) => await appDbContext.Doctors
            .FirstOrDefaultAsync(e => e.EmployeeId == id);


        public async Task<GeneralResponse> Insert(Doctor item)
        {
            appDbContext.Doctors.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Doctor item)
        {
            var obj = await appDbContext.Doctors.FirstOrDefaultAsync(e => e.EmployeeId == item.EmployeeId);
            if (obj is null) return NotFound();

            obj.MedicalRecommendation = item.MedicalRecommendation;
            obj.MedicalDiagnosis = item.MedicalDiagnosis;
            obj.Date = item.Date;
            await Commit();
            return Success();
        }


    }
}
