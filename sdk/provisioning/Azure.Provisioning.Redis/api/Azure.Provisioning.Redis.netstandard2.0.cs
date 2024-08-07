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
    public partial class RedisFirewallRule : Azure.Provisioning.Resource<Azure.ResourceManager.Redis.RedisFirewallRuleData>
    {
        public RedisFirewallRule(Azure.Provisioning.IConstruct scope, string? startIpAddress = null, string? endIpAddress = null, Azure.Provisioning.Redis.RedisCache? parent = null, string name = "fw", string version = "2023-08-01") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Redis.RedisFirewallRuleData>), default(bool)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.Redis.RedisFirewallRule FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.Redis.RedisCache parent) { throw null; }
    }
}
