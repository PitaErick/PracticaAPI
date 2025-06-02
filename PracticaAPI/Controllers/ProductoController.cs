using Microsoft.AspNetCore.Mvc;
using practica.controllers.Producto;
using practica.models.Producto;

namespace practica.api.Controllers
{
    [Route("api/producto")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly OperadorProducto _operador;

        public ProductoController(OperadorProducto operador)
        {
            _operador = operador;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarProductos()
        {
            var result = await _operador.ListarProductos();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> PostProducto([FromBody]ProductoModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Nombre) || model.Precio <= 0 || model.Stock < 0)
            {
                return BadRequest("Datos del producto inválidos.");
            }
            await _operador.GuardarProducto(model);
            return Ok(model);
        }
        [HttpGet("obtener")]
        public async Task<IActionResult> ObtenerProducto(int productoId)
        {
            var result = await _operador.ObtenerProducto(productoId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
