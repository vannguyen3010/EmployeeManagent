using BaseLibrary.Entities;
using BaseLibrary.Response;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class SactionTypeRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<SactionType>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.SactionTypes.FindAsync(id);
            if (item is null) return NotFound();

            appDbContext.SactionTypes.Remove(item);
            await Commit();
            return Success();
        }

        public async Task<List<SactionType>> GetAll() => await appDbContext
            .SactionTypes
            .AsNoTracking()
            .ToListAsync();

        public async Task<SactionType> GetById(int id) =>
            await appDbContext.SactionTypes.FindAsync(id);

        public async Task<GeneralResponse> Insert(SactionType item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Sactions Type already added");
            appDbContext.SactionTypes.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(SactionType item)
        {
            var obj = await appDbContext.SactionTypes.FindAsync(item.Id);
            if (obj is null) return NotFound();
            obj.Name = item.Name;
            await Commit();
            return Success(); 
        }
        private static GeneralResponse NotFound() => new(false, "Sorry data not found");
        private static GeneralResponse Success() => new(true, "Process complete");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.SactionTypes.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
