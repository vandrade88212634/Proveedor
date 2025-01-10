using Infraestructura.Entity.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

public class ProveedorRepository
{
    private readonly IMongoCollection<ProveedorEntity> _proveedorCollection;

    public ProveedorRepository(IConfiguration configuration)
    {
        var mongoClient = new MongoClient(configuration["MongoDB:ConnectionString"]);
        var mongoDatabase = mongoClient.GetDatabase(configuration["MongoDB:DatabaseName"]);
        _proveedorCollection = mongoDatabase.GetCollection<ProveedorEntity>("proveedores");
    }

    // Crear un nuevo proveedor
    public async Task CreateAsync(ProveedorEntity proveedor)
    {
        await _proveedorCollection.InsertOneAsync(proveedor);
    }

    // Leer todos los proveedores
    public async Task<List<ProveedorEntity>> GetAllAsync()
    {
        return await _proveedorCollection.Find(_ => true).ToListAsync();
    }

    // Leer un proveedor por ID
    public async Task<ProveedorEntity> GetByIdAsync(int id)
    {
        return await _proveedorCollection.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    // Actualizar un proveedor
    public async Task UpdateAsync(int id, ProveedorEntity proveedor)
    {
        await _proveedorCollection.ReplaceOneAsync(p => p.Id == id, proveedor);
    }

    // Eliminar un proveedor
    public async Task DeleteAsync(int id)
    {
        await _proveedorCollection.DeleteOneAsync(p => p.Id == id);
    }
}
