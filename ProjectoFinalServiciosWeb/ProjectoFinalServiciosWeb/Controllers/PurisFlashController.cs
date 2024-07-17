using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectoFinalServiciosWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectoFinalServiciosWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurisFlashController : ControllerBase
    {
        // Datos de memoria mientras implementamos el SQL.
        private static List<Comida> comidas = new List<Comida>
        {
            new Comida { Id = 1, Nombre = "Pizza", Descripcion = "Delicious cheese pizza", Precio = "10.99", Categoria = 1 },
            new Comida { Id = 2, Nombre = "Burger", Descripcion = "Juicy beef burger", Precio = "8.99", Categoria = 1 }
        };

        private static List<Pedido> pedidos = new List<Pedido>
        {
            new Pedido { Id = 1, Fecha = "2024-07-16", Hora = "12:00", Estado = "Delivered", Direccion = "123 Main St", MetodoPago = "Credit Card", Total = "19.98", UsuarioId = "1", ConductorId = "1" },
            new Pedido { Id = 2, Fecha = "2024-07-16", Hora = "12:30", Estado = "Pending", Direccion = "456 Elm St", MetodoPago = "PayPal", Total = "15.99", UsuarioId = "2", ConductorId = "2" }
        };

        private static List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario { Id = 1, Nombre = "John", Apellido = "Doe", Correo = "john.doe@example.com", Contrasena = "password", Telefono = "1234567890", Direccion = "123 Main St", MetodoPago = "Credit Card" },
            new Usuario { Id = 2, Nombre = "Jane", Apellido = "Doe", Correo = "jane.doe@example.com", Contrasena = "password", Telefono = "0987654321", Direccion = "456 Elm St", MetodoPago = "PayPal" }
        };

        private static List<Conductor> conductores = new List<Conductor>
        {
            new Conductor { Id = 1, Nombre = "Mike", Apellido = "Smith", Telefono = "1112223333", Vehiculo = "Car" },
            new Conductor { Id = 2, Nombre = "Sara", Apellido = "Johnson", Telefono = "4445556666", Vehiculo = "Bike" }
        };

        /*
         *  GET REQUESTS
        */
        [HttpGet("listComidas")]
        public ActionResult<IEnumerable<Comida>> GetComidas()
        {
            return Ok(comidas);
        }

        [HttpGet("listPedidos/{userId}")]
        public ActionResult<IEnumerable<Pedido>> GetPedidos(int userId)
        {
            var userPedidos = pedidos.Where(p => p.UsuarioId == userId.ToString()).ToList();
            if (!userPedidos.Any())
            {
                return NotFound($"No pedidos found for user with ID {userId}");
            }
            return Ok(userPedidos);
        }

        [HttpGet("listInformacionUsuario/{userId}")]
        public ActionResult<Usuario> GetUsuario(int userId)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == userId);
            if (usuario == null)
            {
                return NotFound($"User with ID {userId} not found");
            }
            return Ok(usuario);
        }

        [HttpGet("listConductores/{pedidoId}")]
        public ActionResult<IEnumerable<Conductor>> GetConductores(int pedidoId)
        {
            var pedido = pedidos.FirstOrDefault(p => p.Id == pedidoId);
            if (pedido == null)
            {
                return NotFound($"Pedido with ID {pedidoId} not found");
            }

            return Ok(conductores);
        }

        /*
         *  POST REQUESTS
        */

        [HttpPost("addComida")]
        public ActionResult<Comida> AddComida(Comida comida)
        {
            comidas.Add(comida);
            return Ok(comida);
        }

        [HttpPost("addPedido")]
        public ActionResult<Pedido> AddPedido(Pedido pedido)
        {
            pedidos.Add(pedido);
            return Ok(pedido);
        }

        [HttpPost("SignUpUsuario")]
        public ActionResult<Usuario> AddUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
            return Ok(usuario);
        }

        /*
         *  PUT REQUESTS
        */

        [HttpPut("updateComida/{id}")]
        public ActionResult<Comida> UpdateComida(int id, Comida updatedComida)
        {
            var comida = comidas.FirstOrDefault(c => c.Id == id);
            if (comida == null)
            {
                return NotFound();
            }

            comida.Nombre = updatedComida.Nombre;
            comida.Descripcion = updatedComida.Descripcion;
            comida.Precio = updatedComida.Precio;
            comida.Categoria = updatedComida.Categoria;

            return Ok(comida);
        }

        [HttpPut("updatePedido/{id}")]
        public ActionResult<Pedido> UpdatePedido(int id, Pedido updatedPedido)
        {
            var pedido = pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            pedido.Fecha = updatedPedido.Fecha;
            pedido.Hora = updatedPedido.Hora;
            pedido.Estado = updatedPedido.Estado;
            pedido.Direccion = updatedPedido.Direccion;
            pedido.MetodoPago = updatedPedido.MetodoPago;
            pedido.Total = updatedPedido.Total;
            pedido.UsuarioId = updatedPedido.UsuarioId;
            pedido.ConductorId = updatedPedido.ConductorId;

            return Ok(pedido);
        }

        [HttpPut("updateUsuario/{id}")]
        public ActionResult<Usuario> UpdateUsuario(int id, Usuario updatedUsuario)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Nombre = updatedUsuario.Nombre;
            usuario.Apellido = updatedUsuario.Apellido;
            usuario.Correo = updatedUsuario.Correo;
            usuario.Contrasena = updatedUsuario.Contrasena;
            usuario.Telefono = updatedUsuario.Telefono;
            usuario.Direccion = updatedUsuario.Direccion;
            usuario.MetodoPago = updatedUsuario.MetodoPago;

            return Ok(usuario);
        }

        /*
         *  DELETE REQUESTS
        */

        [HttpDelete("deleteComida/{id}")]
        public ActionResult DeleteComida(int id)
        {
            var comida = comidas.FirstOrDefault(c => c.Id == id);
            if (comida == null)
            {
                return NotFound();
            }

            comidas.Remove(comida);
            return Ok();
        }

        [HttpDelete("deletePedido/{id}")]
        public ActionResult DeletePedido(int id)
        {
            var pedido = pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            pedidos.Remove(pedido);
            return Ok();
        }

        [HttpDelete("deleteUsuario/{id}")]
        public ActionResult DeleteUsuario(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuarios.Remove(usuario);
            return Ok();
        }
    }
}
