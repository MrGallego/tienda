namespace API.Dtos
{
    public class ProductoListDto
    {
        public string Nombre { get; set; }
        public string Sku { get; set; }
        public string Descripcion { get; set; }
        public decimal Valor { get; set; }
        public string Imagen { get; set; }
        public int TiendaId { get; set; }
        public string Tienda { get; set; }
    }
}
