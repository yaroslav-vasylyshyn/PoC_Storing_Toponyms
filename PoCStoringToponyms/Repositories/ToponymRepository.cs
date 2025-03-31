using MongoDB.Driver;

public class ToponymRepository : IRepository<Toponym>
{
    private readonly IMongoCollection<Toponym> _collection;

    public ToponymRepository(IMongoDatabase database, string collectionName = "Toponyms")
    {
        _collection = database.GetCollection<Toponym>(collectionName);
    }

    public async Task<IEnumerable<Toponym>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<Toponym?> GetByIdAsync(string id)
    {
        return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task InsertAsync(Toponym entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task InsertManyAsync(IEnumerable<Toponym> entities)
    {
        await _collection.InsertManyAsync(entities);
    }

    public async Task UpdateAsync(Toponym entity)
    {
        await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
