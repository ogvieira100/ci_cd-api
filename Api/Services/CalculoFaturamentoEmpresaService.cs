using Api.Data;
using Api.Models;

namespace Api.Services
{
    public interface ICalculoFaturamentoEmpresaService { 


            Task<CalculoFaturamentoEmpresaResponse> CalculoFaturamentoEmpresaResponse(CalculoFaturamentoEmpresaRequest request);

    }
    public class CalculoFaturamentoEmpresaService : ICalculoFaturamentoEmpresaService
    {
        ICalculoFaturamentoEmpresaRepository _repository;


        public CalculoFaturamentoEmpresaService(ICalculoFaturamentoEmpresaRepository repository)
        {
            _repository = repository;   
        }

        public async Task<CalculoFaturamentoEmpresaResponse> CalculoFaturamentoEmpresaResponse(CalculoFaturamentoEmpresaRequest request)
        {
            var response = new CalculoFaturamentoEmpresaResponse(); 
            var fatorConversao =  await _repository.FatorConversaoMovimentacao(request.TipoMovimentacao);
            if (fatorConversao != null)
            { 
                var valorFaturamento = request.Valor * fatorConversao.FatorConversao;
                switch (request.TipoMovimentacao)
                {
                    /*regra de negócio depois do fator*/
                    case ETipoMovimentacao.Entrada:
                         valorFaturamento += 5;    
                        break;
                    case ETipoMovimentacao.Saida:
                         valorFaturamento -= 10;
                        break;
                    default:
                         valorFaturamento += 100;
                        break;
                }
                response.ValorMovimentado = valorFaturamento;   
            }
            return response;
        }
    }
}
