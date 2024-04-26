using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S05LaboratorioDSWI_01.Repositorio.DAO;
using Servicios_Proyecto_DSWI.Models;


namespace S05LaboratorioDSWI_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
public class ClienteController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> obtenerClientes()

        {

            var lista = await Task.Run(() => new ClienteDAO().obtenerClientes());
            return Ok(lista);

        }

        [HttpPost]
        public async Task<IActionResult> registrarCliente(Cliente reg) { 

        var mensaje = await Task.Run(() => new ClienteDAO().registrarCliente(reg));
        return Ok(mensaje);

        }

        [HttpPut]
        public async Task<IActionResult> actualizarCliente(Cliente reg) {

            var mensaje = await Task.Run(() => new ClienteDAO().actualizarCliente(reg)); return Ok(mensaje);

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> eliminarCliente(string id) {

            var mensaje =  await Task.Run(() => new ClienteDAO().eliminarCliente(id));
            return Ok(mensaje);

        }


}
}
