namespace Azure.Provisioning.PostgreSql
{
    public partial class PostgreSqlConnectionString : Azure.Provisioning.ConnectionString
    {
        internal PostgreSqlConnectionString() : base (default(string)) { }
    }
    public partial class PostgreSqlFirewallRule : Azure.Provisioning.Resource<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData>
    {
        public PostgreSqlFirewallRule(Azure.Provisioning.IConstruct scope, string? startIpAddress = null, string? endIpAddress = null, Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServer? parent = null, string name = "fw", string version = "2023-03-01-preview") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData>), default(bool)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.PostgreSql.PostgreSqlFirewallRule FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServer parent) { throw null; }
    }
    public partial class PostgreSqlFlexibleServer : Azure.Provisioning.Resource<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>
    {
        public PostgreSqlFlexibleServer(Azure.Provisioning.IConstruct scope, Azure.Provisioning.Parameter administratorLogin, Azure.Provisioning.Parameter administratorPassword, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku? sku = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion? serverVersion = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability? highAvailability = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption? encryption = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties? backup = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork? network = null, int? storageSizeInGB = default(int?), string? availabilityZone = null, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "postgres", string version = "2023-03-01-preview", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>), default(bool)) { }
        public static Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServer FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
        public Azure.Provisioning.PostgreSql.PostgreSqlConnectionString GetConnectionString(Azure.Provisioning.Parameter administratorLogin, Azure.Provisioning.Parameter administratorPassword) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerConfiguration : Azure.Provisioning.Resource<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData>
    {
        public PostgreSqlFlexibleServerConfiguration(Azure.Provisioning.IConstruct scope, string propertyName, string propertyValue, string propertySource = "user-override", Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServer? parent = null, string name = "config", string version = "2023-03-01-preview") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData>), default(bool)) { }
    }
    public partial class PostgreSqlFlexibleServerDatabase : Azure.Provisioning.Resource<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData>
    {
        public PostgreSqlFlexibleServerDatabase(Azure.Provisioning.IConstruct scope, Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServer? parent = null, string name = "db", string version = "2023-03-01-preview") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData>), default(bool)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerDatabase FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServer? parent) { throw null; }
    }
}
