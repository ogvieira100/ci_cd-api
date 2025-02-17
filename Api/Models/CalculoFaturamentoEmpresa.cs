namespace Api.Models
{
    public class CalculoFaturamentoEmpresaRequest
    {
        public ETipoMovimentacao TipoMovimentacao { get; set; }
        public decimal Valor { get; set; }
    }

    public class CalculoFaturamentoEmpresaResponse
    {
        public decimal ValorMovimentado { get; set; }
    }   
    public enum ETipoMovimentacao
    {
        Entrada = 1,
        Saida = 2
    }   
    public class FatorConversaoDto
    {
        public decimal FatorConversao { get; set; }
                
    }
}
