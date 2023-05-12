namespace API.Dtos
{
    public class TiendaAddUpdateDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaApertura { get; set; }
        public int ProductoId { get; set; }
    }
}
