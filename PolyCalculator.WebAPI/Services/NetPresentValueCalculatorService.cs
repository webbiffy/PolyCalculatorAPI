using PolyCalculator.WebAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace PolyCalculator.WebAPI.Services
{
    public class NetPresentValueCalculatorService
    {
        private readonly IMongoCollection<NetPresentValueTransaction> _netPresentValueTransaction;

        public NetPresentValueCalculatorService(IPolyCalculatorDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _netPresentValueTransaction = database.GetCollection<NetPresentValueTransaction>("NetPresentValue");
        }

        public List<NetPresentValueTransaction> Get() =>
            _netPresentValueTransaction.Find(nvp => true).ToList();

        public NetPresentValueTransaction Get(string id) =>
            _netPresentValueTransaction.Find<NetPresentValueTransaction>(nvp => nvp.Id == id).FirstOrDefault();

        public NetPresentValueTransaction Create(NetPresentValueTransaction netPresentValue)
        {
            _netPresentValueTransaction.InsertOne(netPresentValue);
            return netPresentValue;
        }

        public void Update(string id, NetPresentValueTransaction netPresentValue) =>
            _netPresentValueTransaction.ReplaceOne(nvp => nvp.Id == id, netPresentValue);
    }
}
