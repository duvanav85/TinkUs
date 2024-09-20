using Admin.Commons.Dto;
using Admin.Data.Entities;

namespace Admin.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<TblEmployee>> GetListEmployeeAsync();
    }
}
