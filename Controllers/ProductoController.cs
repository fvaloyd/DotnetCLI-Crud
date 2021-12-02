using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica.data;
using Practica.Models;

namespace Practica.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductoContext _context;
        public ProductoController(ProductoContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var productos = await _context.Productos.ToListAsync();
            return View(productos);
        }

        // Create GET:
        public IActionResult Create()
        {
            return View();
        }

        // Create POST:
        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                producto.FechaDeAlta = DateTime.Now;

                /// logica para grabar los datos en la BD
                _context.Add(producto);
                await _context.SaveChangesAsync();

                /// redireccionar al index
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // Edit GET:
        public async Task<IActionResult> Edit(int id)
        {
            //validamos si el id existe
            if (id == 0) NotFound();


            //traemos el producto de la bd que concuerde con el id del querystring
            var producto = await _context.Productos.FindAsync(id);
            //var producto1 = await _context.Productos.FirstOrDefaultAsync(p => p.Id == id);
            //validos si el producto es null
            if (producto == null) NotFound();

            //le mandamos a la vista el producto a editar
            return View(producto);
        }

        // Edit POST:
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            // validamos que los id sean iguales
            if (id != producto.Id) NotFound();
            // validamos que el producto editado es valido
            if (ModelState.IsValid)
            {
                // actualizamos
                _context.Update(producto);
                // guardamos cambios
                await _context.SaveChangesAsync();
                // redireccionamos al index
                return RedirectToAction(nameof(Index));
            }
            // en caso de que no sea valido cargamos la pagina con el producto a editar nuevamente
            return View(producto);
        }
        // Delete GET:
        public async Task<IActionResult> Delete(int id)
        {
            //validamos el id
            if (id == 0) NotFound();

            // optenemos el producto a borrar
            var producto = await _context.Productos.FindAsync(id);

            // validamos que dicho producto no sea nulo
            if (producto == null) NotFound();

            // retornamos la vista con el producto a borrar
            return View(producto);
        }

        // Delete POST:
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

    }
}