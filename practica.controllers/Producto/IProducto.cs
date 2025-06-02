using practica.controllers.Database;
using practica.models.Producto;

namespace practica.controllers.Producto
{
    public interface IProducto
    {
        SqlHelper SqlHelper { get; set; }
        Task GuardarProducto(ProductoModel model);
        Task ActualizarProducto(ProductoModel model);
        Task EliminarProducto(int productoId);
        Task<List<ProductoModel>> ListarProductos();
        Task<ProductoModel> ObtenerProducto(int productoId);
    }
}
