using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectoFinalServiciosWeb.Models;
using System.Collections.Generic;

namespace ProjectoFinalServiciosWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurisFlashController : ControllerBase
    {
        [HttpGet("listComidas")]
        public ActionResult<IEnumerable<Comida>> GetComidas()
        {
            var comidas = new List<Comida>
            {
                new Comida { Id = 1, Nombre = "Pizza", Descripcion = "Delicious cheese pizza", Precio = "10.99", Categoria = 1 },
                new Comida { Id = 2, Nombre = "Burger", Descripcion = "Juicy beef burger", Precio = "8.99", Categoria = 1 }
            };
            return Ok(comidas);
        }

        [HttpGet("listPedidos")]
        public ActionResult<IEnumerable<Pedido>> GetPedidos()
        {
            var pedidos = new List<Pedido>
            {
                new Pedido { Id = 1, Fecha = "2024-07-16", Hora = "12:00", Estado = "Delivered", Direccion = "123 Main St", MetodoPago = "Credit Card", Total = "19.98", UsuarioId = "1", ConductorId = "1" },
                new Pedido { Id = 2, Fecha = "2024-07-16", Hora = "12:30", Estado = "Pending", Direccion = "456 Elm St", MetodoPago = "PayPal", Total = "15.99", UsuarioId = "2", ConductorId = "2" }
            };
            return Ok(pedidos);
        }

        [HttpGet("listInformacionUsuario")]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            var usuarios = new List<Usuario>
            {
                new Usuario { Id = 1, Nombre = "John", Apellido = "Doe", Correo = "john.doe@example.com", Contrasena = "password", Telefono = "1234567890", Direccion = "123 Main St", MetodoPago = "Credit Card" },
                new Usuario { Id = 2, Nombre = "Jane", Apellido = "Doe", Correo = "jane.doe@example.com", Contrasena = "password", Telefono = "0987654321", Direccion = "456 Elm St", MetodoPago = "PayPal" }
            };
            return Ok(usuarios);
        }

        [HttpGet("listConductores")]
        public ActionResult<IEnumerable<Conductor>> GetConductores()
        {
            var conductores = new List<Conductor>
            {
                new Conductor { Id = 1, Nombre = "Mike", Apellido = "Smith", Telefono = "1112223333", Vehiculo = "Car" },
                new Conductor { Id = 2, Nombre = "Sara", Apellido = "Johnson", Telefono = "4445556666", Vehiculo = "Bike" }
            };
            return Ok(conductores);
        }
    }
}
