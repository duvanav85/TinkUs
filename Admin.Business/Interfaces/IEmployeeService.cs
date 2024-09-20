using Admin.Commons.Dto;

namespace Admin.Business.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDTO>> GetListEmployeeAsync();
    }
}
