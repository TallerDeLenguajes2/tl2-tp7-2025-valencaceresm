using Microsoft.AspNetCore.Mvc;
using TP7.Models;
using TP7.Repositorios;
using System.Collections.Generic;

namespace TP7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PresupuestosController : ControllerBase
    {
        private readonly PresupuestosRepository presupuestosRepository;

        public PresupuestosController()
        {
            presupuestosRepository = new PresupuestosRepository();
        }

        // POST /api/Presupuesto
        [HttpPost]
        public ActionResult CrearPresupuesto(Presupuesto nuevoPresupuesto)
        {
            presupuestosRepository.Crear(nuevoPresupuesto);
            return Ok("Presupuesto creado correctamente ✅");
        }

        // GET /api/Presupuesto
        [HttpGet]
        public ActionResult<List<Presupuesto>> ListarPresupuestos()
        {
            var lista = presupuestosRepository.Listar();
            return Ok(lista);
        }

        // GET /api/Presupuesto/{id}
        [HttpGet("{id}")]
        public ActionResult<Presupuesto> ObtenerPresupuesto(int id)
        {
            var presupuesto = presupuestosRepository.ObtenerPorId(id);
            if (presupuesto == null)
                return NotFound($"No se encontró el presupuesto con ID {id}");
            return Ok(presupuesto);
        }

        // POST /api/Presupuesto/{id}/ProductoDetalle
        [HttpPost("{id}/ProductoDetalle")]
        public ActionResult AgregarProductoAlPresupuesto(int id, int idProducto, int cantidad)
        {
            presupuestosRepository.AgregarProducto(id, idProducto, cantidad);
            return Ok($"Producto {idProducto} agregado al presupuesto {id} con cantidad {cantidad} ✅");
        }

        // DELETE /api/Presupuesto/{id}
        [HttpDelete("{id}")]
        public ActionResult EliminarPresupuesto(int id)
        {
            bool eliminado = presupuestosRepository.Eliminar(id);
            if (eliminado)
                return NoContent();
            else
                return NotFound($"No se encontró el presupuesto con ID {id}");
        }
    }
}