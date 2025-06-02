using practica.controllers.Database;
using practica.models.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica.controllers.Producto
{
    public class OperadorProducto
    {
        private readonly IProducto _productoService;
        private readonly SqlHelper _sqlHelper;
        public OperadorProducto(IProducto productoService, SqlHelper sqlHelper)
        {
            _productoService = productoService;
            _sqlHelper = sqlHelper;
        }
        public async Task GuardarProducto(ProductoModel model)
        {
            try
            {
                await _sqlHelper.IniciarTransaccion();
                _productoService.SqlHelper = _sqlHelper;
                await _productoService.GuardarProducto(model);
                await _sqlHelper.CommitTransaccion();
            }
            catch (Exception ex)
            {
                await _sqlHelper.RollbackTransaccion();
                throw new Exception("Error al guardar el producto", ex);
            }
        }
        public async Task ActualizarProducto(ProductoModel model)
        {
            try
            {
                await _sqlHelper.IniciarTransaccion();
                _productoService.SqlHelper = _sqlHelper;
                await _productoService.ActualizarProducto(model);
                await _sqlHelper.CommitTransaccion();
            }
            catch (Exception ex)
            {
                await _sqlHelper.RollbackTransaccion();
                throw new Exception("Error al actualizar el producto", ex);
            }
        }
        public async Task EliminarProducto(int productoId)
        {
            try
            {
                await _sqlHelper.IniciarTransaccion();
                _productoService.SqlHelper = _sqlHelper;
                await _productoService.EliminarProducto(productoId);
                await _sqlHelper.CommitTransaccion();
            }
            catch (Exception ex)
            {
                await _sqlHelper.RollbackTransaccion();
                throw new Exception("Error al eliminar el producto", ex);
            }
        }
        public async Task<List<ProductoModel>> ListarProductos()
        {
            _productoService.SqlHelper = _sqlHelper;
            return await _productoService.ListarProductos();
        }
        public async Task<ProductoModel> ObtenerProducto(int productoId)
        {
            _productoService.SqlHelper = _sqlHelper;
            return await _productoService.ObtenerProducto(productoId);
        }
    }
}
