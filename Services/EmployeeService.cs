using TestApp1.Models;
using MongoDB.Driver;
using TestApp1.Models;

namespace TestApp1.Services
{
    public class EmployeeService
    {
        private readonly IMongoCollection<TestData> _employeeCollection;

        public EmployeeService(IConfiguration configuration)
        {
            var settings = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _employeeCollection = database.GetCollection<TestData>(settings.EmployeeCollectionName);
        }

        public List<TestData> GetAll()
        {
            return _employeeCollection.Find(_ => true).ToList();
        }

        public TestData? GetById(string id)
        {
            return _employeeCollection.Find(x => x.Id == id).FirstOrDefault();
        }

        public void Create(TestData emp)
        {
            _employeeCollection.InsertOne(emp);
        }

        public void Update(string id, TestData emp)
        {
            _employeeCollection.ReplaceOne(x => x.Id == id, emp);
        }

        public void Delete(string id)
        {
            _employeeCollection.DeleteOne(x => x.Id == id);
        }
    }
}
