namespace Azure.Provisioning.Redis
{
    public partial class RedisCache : Azure.Provisioning.Resource<Azure.ResourceManager.Redis.RedisData>
    {
        public RedisCache(Azure.Provisioning.IConstruct scope, Azure.ResourceManager.Redis.Models.RedisSku? sku = null, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "redis", string version = "2023-08-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Redis.RedisData>), default(bool)) { }
        public static Azure.Provisioning.Redis.RedisCache FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
        public Azure.Provisioning.Redis.RedisCacheConnectionString GetConnectionString(bool useSecondary = false) { throw null; }
    }
    public partial class RedisCacheConnectionString : Azure.Provisioning.ConnectionString
    {
        internal RedisCacheConnectionString() : base (default(string)) { }
    }
}
