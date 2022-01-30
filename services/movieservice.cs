using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace WebApplication8.services
{
    public class movieservice
    {
        private readonly IMongoCollection<movie> _moviecollection;

        public movieservice(
            IOptions<moviedatabasesettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _moviecollection = mongoDatabase.GetCollection<movie>(
                bookStoreDatabaseSettings.Value.Moviecollectionname);
        }

        public async Task<List<movie>> GetAsync() =>
            await _moviecollection.Find(_ => true).ToListAsync();

        public async Task<movie?> GetAsync(int id) =>
            await _moviecollection.Find(x => x.id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(movie newmovie) =>
            await _moviecollection.InsertOneAsync(newmovie);

     
    }
}

