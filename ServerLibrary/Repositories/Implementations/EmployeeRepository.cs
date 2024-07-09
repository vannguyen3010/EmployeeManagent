using BaseLibrary.Entities;
using BaseLibrary.Response;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class EmployeeRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Employee>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.Employee.FindAsync(id);
            if (item is null) return NotFound();
                
            appDbContext.Employee.Remove(item);
            await Commit();
            return Success();
        }

        public async Task<List<Employee>> GetAll()
        {
            var employees = await appDbContext.Employee
                .AsNoTracking()
                .Include(t => t.Town)
                .ThenInclude(b => b.City)
                .ThenInclude(c => c.Country)
                .Include(b => b.Branch)
                .ThenInclude(d => d.Department)
                .ThenInclude(gd => gd.GeneralDepartment)
                .ToListAsync();
            return employees;
        }

        public async Task<Employee> GetById(int id)
        {
            var employees = await appDbContext.Employee
              .Include(t => t.Town)
              .ThenInclude(b => b.City)
              .ThenInclude(c => c.Country)
              .Include(b => b.Branch)
              .ThenInclude(d => d.Department)
              .ThenInclude(gd => gd.GeneralDepartment)
              .FirstOrDefaultAsync(ei => ei.Id == id)!;
            return employees!;
        }

        public async Task<GeneralResponse> Insert(Employee item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Employee already added");

            appDbContext.Employee.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Employee employee)
        {
            var findUser = await appDbContext.Employee.FirstOrDefaultAsync(e => e.Id == employee.Id);
            if (findUser is null) return new GeneralResponse(false, "Employee does not exits");

            findUser.Name = employee.Name;
            findUser.Other = employee.Other;
            findUser.Address = employee.Address;
            findUser.TelephoneNumber = employee.TelephoneNumber;
            findUser.BranchId = employee.BranchId;
            findUser.TownId = employee.TownId;
            findUser.CivilId = employee.CivilId;
            findUser.FileNumber = employee.FileNumber;
            findUser.JobName = employee.JobName;
            findUser.Photo = employee.Photo;

            await appDbContext.SaveChangesAsync();
            await Commit();
            return Success();
        } 
        private static GeneralResponse NotFound() => new(false, "Sorry department not found");
        private static GeneralResponse Success() => new(true, "Process complete");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.Branches.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null ? true : false;
        }
    }
}
