using DotnetCLI_Crud.data.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using Practica.data;
using Practica.Models;

namespace DotnetCLI_Crud.data.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ProductoContext _context;
        public ProductoRepository(ProductoContext context)
        {
            _context = context;
        }
        // GET all products
        public async Task<IEnumerable<Producto>> GetAll()
        {
            var productos = await _context.Productos.ToListAsync();

            return productos;
        }
        // GET by id
        public async Task<Producto> GetById(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            return producto;
        }
        // CREATE
        public async Task<int> Create(Producto producto)
        {
            producto.FechaDeAlta = DateTime.Now;
            _context.Add(producto);
            return await _context.SaveChangesAsync();
        }
        // UPDATE
        public async Task<int> Update(Producto producto)
        {
            _context.Update(producto);
            // guardamos cambios
            return await _context.SaveChangesAsync();
        }
        // DELETE
        public async Task<int> Delete(Producto producto)
        {
            _context.Productos.Remove(producto);
            return await _context.SaveChangesAsync();
        }

    }
}