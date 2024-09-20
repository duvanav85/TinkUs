using AutoMapper;
using Admin.Business.Interfaces;
using Admin.Data.Interfaces;
using Admin.Commons.Dto;

namespace Admin.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository repository;
        private readonly IMapper mapper;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<EmployeeDTO>> GetListEmployeeAsync()
        {
            string errorMessage = string.Empty;
            var data = await this.repository.GetListEmployeeAsync();
            if (data != null)
            {
                return mapper.Map<List<EmployeeDTO>>(data);
            }
            else
            {
                errorMessage = "No se encontro data";
                throw new Exception(errorMessage);
            }
        }
    }
}
