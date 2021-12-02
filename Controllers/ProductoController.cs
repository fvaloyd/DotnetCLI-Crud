using DotnetCLI_Crud.data.Repository.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica.data;
using Practica.Models;

namespace Practica.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoRepository _productoRepo;
        private readonly ProductoContext _context;
        public ProductoController(ProductoContext context, IProductoRepository productoRepo) 
        {
             _context = context;
             _productoRepo = productoRepo;

        }
        public async Task<IActionResult> Index()
        {
            //var productos = await _context.Productos.ToListAsync();
            // trayendo los datos desde el repository
            var productos = await _productoRepo.GetAll();
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
                await _productoRepo.Create(producto);
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
            var producto = await _productoRepo.GetById(id);
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
                await _productoRepo.Update(producto);
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
            var producto = await _productoRepo.GetById(id);

            // validamos que dicho producto no sea nulo
            if (producto == null) NotFound();

            // retornamos la vista con el producto a borrar
            return View(producto);
        }

        // Delete POST:
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var producto = await _productoRepo.GetById(id);
            if(producto != null) await _productoRepo.Delete(producto);
            
            return RedirectToAction(nameof(Index));
        }

    }
}