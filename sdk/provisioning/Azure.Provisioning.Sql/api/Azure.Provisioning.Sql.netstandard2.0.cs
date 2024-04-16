namespace Azure.Provisioning.Sql
{
    public partial class SqlDatabase : Azure.Provisioning.Resource<Azure.ResourceManager.Sql.SqlDatabaseData>
    {
        public SqlDatabase(Azure.Provisioning.IConstruct scope, Azure.Provisioning.Sql.SqlServer? parent = null, string name = "db", string version = "2020-11-01-preview", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Sql.SqlDatabaseData>), default(bool)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.Sql.SqlDatabase FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.Sql.SqlServer parent) { throw null; }
        public Azure.Provisioning.Sql.SqlDatabaseConnectionString GetConnectionString(Azure.Provisioning.Parameter passwordSecret, string userName = "appUser") { throw null; }
    }
    public partial class SqlDatabaseConnectionString : Azure.Provisioning.ConnectionString
    {
        internal SqlDatabaseConnectionString() : base (default(string)) { }
    }
    public partial class SqlFirewallRule : Azure.Provisioning.Resource<Azure.ResourceManager.Sql.SqlFirewallRuleData>
    {
        public SqlFirewallRule(Azure.Provisioning.IConstruct scope, Azure.Provisioning.Sql.SqlServer? parent = null, string name = "fw", string version = "2020-11-01-preview") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Sql.SqlFirewallRuleData>), default(bool)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.Sql.SqlFirewallRule FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.Sql.SqlServer parent) { throw null; }
    }
    public partial class SqlServer : Azure.Provisioning.Resource<Azure.ResourceManager.Sql.SqlServerData>
    {
        public SqlServer(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.Parameter? administratorLogin = default(Azure.Provisioning.Parameter?), Azure.Provisioning.Parameter? administratorPassword = default(Azure.Provisioning.Parameter?), Azure.ResourceManager.Sql.Models.ServerExternalAdministrator? administrator = null, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string version = "2020-11-01-preview", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Sql.SqlServerData>), default(bool)) { }
        public static Azure.Provisioning.Sql.SqlServer FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
    public partial class SqlServerAdministrator : Azure.Provisioning.Resource<Azure.ResourceManager.Sql.SqlServerAzureADAdministratorData>
    {
        public SqlServerAdministrator(Azure.Provisioning.IConstruct scope, Azure.Provisioning.Sql.SqlServer? parent = null, string name = "admin", string version = "2020-11-01-preview") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Sql.SqlServerAzureADAdministratorData>), default(bool)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.Sql.SqlServerAdministrator FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.Sql.SqlServer parent) { throw null; }
    }
}
