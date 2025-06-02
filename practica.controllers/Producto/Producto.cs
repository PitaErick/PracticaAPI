using Microsoft.Data.SqlClient;
using practica.controllers.Database;
using practica.models.Producto;

namespace practica.controllers.Producto
{
    public class Producto : IProducto
    {
        public SqlHelper SqlHelper { get; set; }

        public async Task ActualizarProducto(ProductoModel model)
        {
            await SqlHelper.EjecutarSpAsync("sp_ActualizarProducto", new[]
            {
                new SqlParameter ("@Id", model.ProductoId),
                new SqlParameter("@Nombre", model.Nombre),
                new SqlParameter("@Precio", model.Precio),
                new SqlParameter("@Descripcion", model.Stock),
                new SqlParameter("@Descripcion", model.Descripcion)
            });
        }

        public async Task EliminarProducto(int productoId)
        {
            await SqlHelper.EjecutarSpAsync("sp_EliminarProducto", new[]
            {
                new SqlParameter ("@Id", productoId)
            });
        }

        public async Task GuardarProducto(ProductoModel model)
        {
            await SqlHelper.EjecutarSpAsync("sp_GuardarProducto", new[]
            {
                new SqlParameter("@Nombre", model.Nombre),
                new SqlParameter("@Precio", model.Precio),
                new SqlParameter("@Stock", model.Stock),
                new SqlParameter("@Descripcion", model.Descripcion)
            });
        }

        public async Task<List<ProductoModel>> ListarProductos()
        {
            return await SqlHelper.ListarAsync<ProductoModel>("sp_ListarProductos");
        }

        public async Task<ProductoModel> ObtenerProducto(int productoId)
        {
            return await SqlHelper.ObtenerAsync<ProductoModel>("sp_ObtenerProducto", new[]
            {
                new SqlParameter("@Id", productoId)
            });
        }
    }
}
