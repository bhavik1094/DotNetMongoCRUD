namespace TestApp1.Models
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string EmployeeCollectionName { get; set; } = string.Empty;
    }
}
