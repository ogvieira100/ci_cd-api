using Api.Controllers;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class CalculoFaturamentoEmpresaControllerTest
    {
        private readonly Mock<ICalculoFaturamentoEmpresaService> _mockService;
        private readonly CalculoFaturamentoEmpresaController _controller;
        public CalculoFaturamentoEmpresaControllerTest()
        {
            _mockService = new Mock<ICalculoFaturamentoEmpresaService>();
            _controller = new CalculoFaturamentoEmpresaController(_mockService.Object);
        }

        [Fact]
        public async Task Post_ReturnsOkResponse_WhenServiceReturnsValidResponse()
        {
            // Arrange
            var request = new CalculoFaturamentoEmpresaRequest
            {
                // Propriedades conforme necessário
            };

            var expectedResponse = new CalculoFaturamentoEmpresaResponse
            {
                // Preencher com valores simulados de resposta
            };

            _mockService.Setup(service => service.CalculoFaturamentoEmpresaResponse(request))
                        .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.Post(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
            Assert.Equal(expectedResponse, okResult.Value);
        }

        [Fact]
        public async Task Post_ReturnsBadRequestResponse_WhenServiceThrowsException()
        {
            // Arrange
            var request = new CalculoFaturamentoEmpresaRequest
            {
                // Propriedades conforme necessário
            };

            _mockService.Setup(service => service.CalculoFaturamentoEmpresaResponse(request))
                        .ThrowsAsync(new Exception("Erro ao calcular faturamento."));

            // Act
            var result = await _controller.Post(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.NotNull(badRequestResult.Value);
            Assert.Equal("Erro ao calcular faturamento.", badRequestResult.Value);
        }

    }
}
