using Microsoft.AspNetCore.Mvc;
using Servicios_Proyecto_DSWI.Models;


namespace S05LaboratorioDSWI_01.Repositorio.Interfaces
{
    public interface ICliente
    {
        IEnumerable<Cliente> obtenerClientes();
        
        string registrarCliente(Cliente reg);

        string actualizarCliente(Cliente reg);
        string eliminarCliente(string id);
    }
}
       
