using PolyCalculator.WebAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace PolyCalculator.WebAPI.Services
{
    public class NetPresentValueCalculatorService
    {
        private readonly IMongoCollection<NetPresentValueFixed> _netPresentValueFixed;

        public NetPresentValueCalculatorService(IPolyCalculatorDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _netPresentValueFixed = database.GetCollection<NetPresentValueFixed>("NetPresentValue");
        }

        public List<NetPresentValueFixed> Get() =>
            _netPresentValueFixed.Find(nvp => true).ToList();

        public NetPresentValueFixed Get(string id) =>
            _netPresentValueFixed.Find<NetPresentValueFixed>(nvp => nvp.Id == id).FirstOrDefault();

        public NetPresentValueFixed Create(NetPresentValueFixed netPresentValue)
        {
            _netPresentValueFixed.InsertOne(netPresentValue);
            return netPresentValue;
        }

        public void Update(string id, NetPresentValueFixed netPresentValue) =>   
            _netPresentValueFixed.ReplaceOne(nvp => nvp.Id == id, netPresentValue);
    }
}
