namespace Servicios_Proyecto_DSWI.Models
{
    public class Cliente
    {
        private int  idCliente;
        private string nombre;
        private string apellido;
        private string email;
        private string telefono;

        public Cliente()
        {
            idCliente = 0;
            nombre = "";
            apellido = "";
            email = "";
            telefono = "";
        }

        public Cliente(int idCliente, string nombre, string apellido, string email, string telefono)
        {
            this.idCliente = idCliente;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.telefono = telefono;
        }

        public int  IdCliente { get =>  idCliente; set =>  idCliente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Email { get => email; set => email = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
