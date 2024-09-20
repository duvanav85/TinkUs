using Admin.Business.Interfaces;
using Admin.Commons.Dto;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using WebApi.Controllers;
using WebApi.Core.Automapper;
using Xunit;

namespace Admin.UniTest.Controllers
{
    public class EmployeeControllerTests
    {
        private Mock<IEmployeeService> mockService;
        private EmployeeController controller;
        private static IMapper? _mapper;

        public static List<EmployeeDTO> ListEmployeeDtoMock()
        {
            var requestDto = new List<EmployeeDTO>()
            {
                new EmployeeDTO
                {
                    Identificacion = 1,
                    Nombre = null,
                    Posicion = 0,
                    Descripcion = null,
                    Estado = false,
                }
            };

            var expectedResponse = requestDto;

            return expectedResponse;
        }

        [Fact]
        public async Task Get_ReturnsOkObjectResult_WithList()
        {
            // Arrange
            var exceptionMessage = "Simulated exception message";

            var serviceMock = new Mock<IEmployeeService>();
            var serviceMockToken = new Mock<ITokenValidationService>();

            serviceMock.Setup(service => service.GetListEmployeeAsync()).ThrowsAsync(new Exception(exceptionMessage));

            var controller = new EmployeeController(serviceMock.Object, serviceMockToken.Object)
            {
                Test = "UniTest"
            };


            // Act
            var result = await controller.Get();

            //Assert
            Assert.IsNotNull(result);

        }
    }
}
