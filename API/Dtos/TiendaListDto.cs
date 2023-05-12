namespace API.Dtos
{
    public class TiendaListDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaApertura { get; set; }
        public int ProductoId { get; set; }
        public string Producto { get; set; }
    }
}
