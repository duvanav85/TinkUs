using Admin.Data.Entities;
using Admin.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Admin.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TinkContext _context;

        public EmployeeRepository(TinkContext context)
        {
            _context = context;
        }

        public async Task<List<TblEmployee>> GetListEmployeeAsync()
        {

            return await _context.TblEmployees.ToListAsync();
        }

    }
}
