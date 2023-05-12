﻿namespace API.Dtos
{
    public class TiendaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaApertura { get; set; }
        public ProductoDto Producto { get; set; }
    }
}
