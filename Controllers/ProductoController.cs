using Microsoft.AspNetCore.Mvc;
using TP7.Models;
using TP7.Repositorios;
using System.Collections.Generic;

namespace TP7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBas
    {
        private readonly ProductoRepository productoRepository;

        public ProductosController()
        {
            productoRepository = new ProductoRepository();
        }

        // POST /api/Producto
        [HttpPost]
        public ActionResult CrearProducto(Producto nuevoProducto)
        {
            productoRepository.Crear(nuevoProducto);
            return Ok("Producto creado correctamente ✅");
        }

        // PUT /api/Producto/{id}
        [HttpPut("{id}")]
        public ActionResult ModificarProducto(int id, Producto producto)
        {
            productoRepository.Modificar(id, producto);
            return Ok($"Producto con ID {id} modificado correctamente ✅");
        }

        // GET /api/Producto
        [HttpGet]
        public ActionResult<List<Producto>> ListarProductos()
        {
            var productos = productoRepository.Listar();
            return Ok(productos);
        }

        // GET /api/Producto/{id}
        [HttpGet("{id}")]
        public ActionResult<Producto> ObtenerProducto(int id)
        {
            var producto = productoRepository.ObtenerPorId(id);
            if (producto == null)
                return NotFound($"No se encontró el producto con ID {id}");
            return Ok(producto);
        }

        // DELETE /api/Producto/{id}
        [HttpDelete("{id}")]
        public ActionResult EliminarProducto(int id)
        {
            bool eliminado = productoRepository.Eliminar(id);

            if (eliminado)
                return NoContent();
            else
                return NotFound($"No se encontró el producto con ID {id}");
        }
    }
}