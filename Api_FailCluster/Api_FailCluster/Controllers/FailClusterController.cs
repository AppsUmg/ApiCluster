using Api_FailCluster.Clases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_FailCluster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FailClusterController : ControllerBase
    {
        [HttpPost]
        public ActionResult setTransferencia(decimal Monto, string Cuenta_Origen, string Cuenta_Destino)
        {
            return this.Content(ClsApi.setTrasnferencia(Monto,Cuenta_Origen,Cuenta_Destino), "application/json", System.Text.Encoding.UTF8);

        }

        [HttpGet]
        public ActionResult getSaldo(string id_cuenta)
        {
            return this.Content(ClsApi.getSaldo(id_cuenta), "application/json", System.Text.Encoding.UTF8);
        }

















    }
}
