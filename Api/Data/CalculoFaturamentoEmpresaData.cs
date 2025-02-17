using Api.Models;

namespace Api.Data
{
    public interface ICalculoFaturamentoEmpresaRepository
    {

        Task<FatorConversaoDto> FatorConversaoMovimentacao(ETipoMovimentacao eTipoMovimentacao);

    }
    public class CalculoFaturamentoEmpresaRepository : ICalculoFaturamentoEmpresaRepository
    {

        public CalculoFaturamentoEmpresaRepository()
        {

        }

        public async Task<FatorConversaoDto> FatorConversaoMovimentacao(ETipoMovimentacao eTipoMovimentacao)
        {
            /*simulando uma consulta em banco de dados*/
           return await Task.Run(() =>
            {
                switch (eTipoMovimentacao)
                {
                    case ETipoMovimentacao.Entrada:
                        return new FatorConversaoDto() { FatorConversao = 10 };
                    case ETipoMovimentacao.Saida:
                        return new FatorConversaoDto() { FatorConversao = 20 };
                    default:
                        return new FatorConversaoDto() { FatorConversao = 20 };

                }
            });
        }
    }
}
