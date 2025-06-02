namespace practica.models.Producto
{
    public class ProductoModel
    {
        public int? ProductoId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string? Descripcion { get; set; }
    }
}
