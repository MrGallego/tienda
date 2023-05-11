﻿namespace Core.Entities
{
    public class Tienda : BaseEntity
    {
        public string Nombre { get; set; }
        public DateTime FechaApertura { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
