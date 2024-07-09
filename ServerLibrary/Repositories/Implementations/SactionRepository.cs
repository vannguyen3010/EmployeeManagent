using BaseLibrary.Entities;
using BaseLibrary.Response;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class SactionRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Saction>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.Sactions.FirstOrDefaultAsync(x => x.EmployeeId == id);
            if (item is null) return NotFound();

            appDbContext.Sactions.Remove(item);
            await Commit();
            return Success();
        }

        public async Task<List<Saction>> GetAll() => await appDbContext
            .Sactions
            .AsNoTracking()
            .ToListAsync();

        public async Task<Saction> GetById(int id) =>
            await appDbContext.Sactions.FirstOrDefaultAsync(x => x.EmployeeId == id);

        public async Task<GeneralResponse> Insert(Saction item)
        {
            appDbContext.Sactions.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Saction item)
        {
            var obj = await appDbContext.Sactions.FirstOrDefaultAsync(x => x.EmployeeId == item.EmployeeId);
            if (obj is null) return NotFound();
            obj.PunishmentDate = item.PunishmentDate;
            obj.Punishment = item.Punishment;
            obj.Date = item.Date;
            await Commit();
            return Success();
        }
        private static GeneralResponse NotFound() => new(false, "Sorry data not found");
        private static GeneralResponse Success() => new(true, "Process complete");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
    }
}
