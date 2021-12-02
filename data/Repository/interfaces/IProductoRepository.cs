using Practica.Models;

namespace DotnetCLI_Crud.data.Repository.interfaces
{
    public interface IProductoRepository
    {
        // GET all
        Task<IEnumerable<Producto>> GetAll();
        // GET by id
        Task<Producto> GetById(int id);
        // CREATE
        Task<int> Create(Producto producto);
        // UPDATE
        Task<int> Update(Producto producto);
        // DELETE
        Task<int> Delete(Producto producto);
    }
}