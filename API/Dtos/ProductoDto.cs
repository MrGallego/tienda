namespace API.Dtos
{
    public class ProductoDto
    {
        public string Nombre { get; set; }
        public string Sku { get; set; }
        public string Descripcion { get; set; }
        public decimal Valor { get; set; }
        public string Imagen { get; set; }
        public TiendaDto Tienda { get; set; }
    }
}
