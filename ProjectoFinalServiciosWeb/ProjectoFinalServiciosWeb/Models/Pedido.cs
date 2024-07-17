namespace ProjectoFinalServiciosWeb.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string? Fecha { get; set; }
        public string? Hora { get; set; }
        public string? Estado { get; set; }
        public string? Direccion { get; set; }
        public string? MetodoPago { get; set; }
        public string? Total { get; set; }
        public string? UsuarioId { get; set; }
        public string? ConductorId { get; set; }
    }
}
