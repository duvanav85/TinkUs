using Admin.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly ITokenValidationService tokenValidationService;
        private readonly ILogger<EmployeeController> _logger;
        private readonly string url;
        public string Test { get; set; } = "";
        private readonly IEmployeeService service;

        public EmployeeController(IEmployeeService service, ITokenValidationService _tokenValidationService) //, 
        {
            this.service = service;
            this.tokenValidationService = _tokenValidationService;
            this.url = "/WorkFlowManagement/ApproveRequest";
            //_logger = logger;
        }

        [HttpGet(Name = "ListaEmpleados")]
        public async Task<IActionResult> Get()
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value ?? User.FindAll(ClaimTypes.Name).FirstOrDefault(x => x.Value.Contains("@"))?.Value;
            var result = await this.tokenValidationService.IsAuthorize(userEmail, this.url);
            if (!result)
            {
                throw new UnauthorizedAccessException();
            }
            var token = Request.Headers.Authorization.ToString();
            if (!this.tokenValidationService.ValidateToken(token))
            {
                throw new Exception("El token no es valido");
            }
            var listEmployee = await service.GetListEmployeeAsync();
            return Ok(listEmployee);
        }
    }
}
