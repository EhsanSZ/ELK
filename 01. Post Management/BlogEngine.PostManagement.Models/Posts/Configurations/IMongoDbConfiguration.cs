namespace BlogEngine.PostManagement.Models.Posts.Configurations
{
    public interface IMongoDbConfiguration
    {
        string PostCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
