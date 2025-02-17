using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CalculoFaturamentoEmpresaController :  ControllerBase
    {

        readonly ICalculoFaturamentoEmpresaService _calculoFaturamentoEmpresaService;

        public CalculoFaturamentoEmpresaController(ICalculoFaturamentoEmpresaService 
            calculoFaturamentoEmpresaService)
        {
            _calculoFaturamentoEmpresaService = calculoFaturamentoEmpresaService;   
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CalculoFaturamentoEmpresaRequest request)
        {
            try
            {
                var response = await _calculoFaturamentoEmpresaService.CalculoFaturamentoEmpresaResponse(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
           
        }   


    }
}
