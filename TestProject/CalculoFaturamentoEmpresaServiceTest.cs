using Api.Data;
using Api.Models;
using Api.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class CalculoFaturamentoEmpresaServiceTest
    {

        private readonly Mock<ICalculoFaturamentoEmpresaRepository> _mockRepository;
        private readonly CalculoFaturamentoEmpresaService _service;
        public CalculoFaturamentoEmpresaServiceTest()
        {
            _mockRepository = new Mock<ICalculoFaturamentoEmpresaRepository>();
            _service = new CalculoFaturamentoEmpresaService(_mockRepository.Object);
        }

        [Fact]
        public async Task CalculoFaturamentoEmpresaResponse_ReturnsCorrectValueForEntrada()
        {
            // Arrange
            var request = new CalculoFaturamentoEmpresaRequest
            {
                TipoMovimentacao = ETipoMovimentacao.Entrada,
                Valor = 100
            };

            _mockRepository.Setup(repo => repo.FatorConversaoMovimentacao(ETipoMovimentacao.Entrada))
                .ReturnsAsync(new FatorConversaoDto { FatorConversao = 10 });

            // Act
            var response = await _service.CalculoFaturamentoEmpresaResponse(request);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(1100, response.ValorMovimentado); // (100 * 10) + 100
        }

        [Fact]
        public async Task CalculoFaturamentoEmpresaResponse_ReturnsCorrectValueForSaida()
        {
            // Arrange
            var request = new CalculoFaturamentoEmpresaRequest
            {
                TipoMovimentacao = ETipoMovimentacao.Saida,
                Valor = 50
            };

            _mockRepository.Setup(repo => repo.FatorConversaoMovimentacao(ETipoMovimentacao.Saida))
                .ReturnsAsync(new FatorConversaoDto { FatorConversao = 20 });

            // Act
            var response = await _service.CalculoFaturamentoEmpresaResponse(request);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(990, response.ValorMovimentado); // (50 * 20) - 10
        }

     }
}
