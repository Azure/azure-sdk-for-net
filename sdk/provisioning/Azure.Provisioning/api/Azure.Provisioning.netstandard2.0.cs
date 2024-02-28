namespace Azure.Provisioning
{
    public static partial class CdkExtensions
    {
        public static T? GetSingleResourceInScope<T>(this Azure.Provisioning.IConstruct construct) where T : Azure.Provisioning.Resource { throw null; }
        public static T? GetSingleResource<T>(this Azure.Provisioning.IConstruct construct) where T : Azure.Provisioning.Resource { throw null; }
    }
    public abstract partial class Construct : Azure.Provisioning.IConstruct
    {
        protected Construct(Azure.Provisioning.IConstruct? scope, string name, Azure.Provisioning.ConstructScope constructScope = Azure.Provisioning.ConstructScope.ResourceGroup, System.Guid? tenantId = default(System.Guid?), System.Guid? subscriptionId = default(System.Guid?), string? envName = null, Azure.Provisioning.ResourceManager.ResourceGroup? resourceGroup = null) { }
        public Azure.Provisioning.ConstructScope ConstructScope { get { throw null; } }
        public string EnvironmentName { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Provisioning.ResourceManager.ResourceGroup? ResourceGroup { get { throw null; } protected set { } }
        public Azure.Provisioning.ResourceManager.Tenant Root { get { throw null; } }
        public Azure.Provisioning.IConstruct? Scope { get { throw null; } }
        public Azure.Provisioning.ResourceManager.Subscription? Subscription { get { throw null; } }
        public void AddConstruct(Azure.Provisioning.IConstruct construct) { }
        public void AddOutput(Azure.Provisioning.Output output) { }
        public void AddParameter(Azure.Provisioning.Parameter parameter) { }
        public void AddResource(Azure.Provisioning.Resource resource) { }
        public System.Collections.Generic.IEnumerable<Azure.Provisioning.IConstruct> GetConstructs(bool recursive = true) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.Provisioning.Output> GetOutputs(bool recursive = true) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.Provisioning.Parameter> GetParameters(bool recursive = true) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.Provisioning.Resource> GetResources(bool recursive = true) { throw null; }
        protected T UseExistingResource<T>(T? resource, System.Func<T> create) where T : Azure.Provisioning.Resource { throw null; }
    }
    public enum ConstructScope
    {
        ResourceGroup = 0,
        Subscription = 1,
        ManagementGroup = 2,
        Tenant = 3,
    }
    public partial interface IConstruct
    {
        Azure.Provisioning.ConstructScope ConstructScope { get; }
        string EnvironmentName { get; }
        string Name { get; }
        Azure.Provisioning.ResourceManager.ResourceGroup? ResourceGroup { get; }
        Azure.Provisioning.ResourceManager.Tenant Root { get; }
        Azure.Provisioning.IConstruct? Scope { get; }
        Azure.Provisioning.ResourceManager.Subscription? Subscription { get; }
        void AddConstruct(Azure.Provisioning.IConstruct construct);
        void AddOutput(Azure.Provisioning.Output output);
        void AddParameter(Azure.Provisioning.Parameter parameter);
        void AddResource(Azure.Provisioning.Resource resource);
        System.Collections.Generic.IEnumerable<Azure.Provisioning.IConstruct> GetConstructs(bool recursive = true);
        System.Collections.Generic.IEnumerable<Azure.Provisioning.Output> GetOutputs(bool recursive = true);
        System.Collections.Generic.IEnumerable<Azure.Provisioning.Parameter> GetParameters(bool recursive = true);
        System.Collections.Generic.IEnumerable<Azure.Provisioning.Resource> GetResources(bool recursive = true);
    }
    public abstract partial class Infrastructure : Azure.Provisioning.Construct
    {
        public Infrastructure(Azure.Provisioning.ConstructScope constructScope = Azure.Provisioning.ConstructScope.Subscription, System.Guid? tenantId = default(System.Guid?), System.Guid? subscriptionId = default(System.Guid?), string? envName = null, bool useAnonymousResourceGroup = false) : base (default(Azure.Provisioning.IConstruct), default(string), default(Azure.Provisioning.ConstructScope), default(System.Guid?), default(System.Guid?), default(string), default(Azure.Provisioning.ResourceManager.ResourceGroup)) { }
        public void Build(string? outputPath = null) { }
    }
    public partial class Output
    {
        internal Output() { }
        public bool IsLiteral { get { throw null; } }
        public bool IsSecure { get { throw null; } }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Parameter
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Parameter(Azure.Provisioning.Output output) { throw null; }
        public Parameter(string name, string? description = null, object? defaultValue = null, bool isSecure = false) { throw null; }
        public object? DefaultValue { get { throw null; } }
        public string? Description { get { throw null; } }
        public bool IsSecure { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public abstract partial class Resource : System.ClientModel.Primitives.IPersistableModel<Azure.Provisioning.Resource>
    {
        protected Resource(Azure.Provisioning.IConstruct scope, Azure.Provisioning.Resource? parent, string resourceName, Azure.Core.ResourceType resourceType, string version, System.Func<string, object> createProperties) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Provisioning.Resource? Parent { get { throw null; } }
        public Azure.Provisioning.IConstruct Scope { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        protected virtual string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
        Azure.Provisioning.Resource System.ClientModel.Primitives.IPersistableModel<Azure.Provisioning.Resource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Provisioning.Resource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Provisioning.Resource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class Resource<T> : Azure.Provisioning.Resource where T : notnull
    {
        protected Resource(Azure.Provisioning.IConstruct scope, Azure.Provisioning.Resource? parent, string resourceName, Azure.Core.ResourceType resourceType, string version, System.Func<string, T> createProperties) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, object>)) { }
        public T Properties { get { throw null; } }
        public Azure.Provisioning.Output AddOutput(System.Linq.Expressions.Expression<System.Func<T, object?>> propertySelector, string outputName, bool isLiteral = false, bool isSecure = false) { throw null; }
        public void AssignParameter(System.Linq.Expressions.Expression<System.Func<T, object?>> propertySelector, Azure.Provisioning.Parameter parameter) { }
    }
}
namespace Azure.Provisioning.AppConfiguration
{
    public static partial class AppConfigurationExtensions
    {
        public static Azure.Provisioning.AppConfiguration.AppConfigurationStore AddAppConfigurationStore(this Azure.Provisioning.IConstruct construct, string name = "store") { throw null; }
    }
    public partial class AppConfigurationStore : Azure.Provisioning.Resource<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData>
    {
        public AppConfigurationStore(Azure.Provisioning.IConstruct scope, string name = "store", string version = "2023-03-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData>)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
    }
}
namespace Azure.Provisioning.AppService
{
    public partial class AppServicePlan : Azure.Provisioning.Resource<Azure.ResourceManager.AppService.AppServicePlanData>
    {
        public AppServicePlan(Azure.Provisioning.IConstruct scope, string resourceName, string version = "2021-02-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.AppService.AppServicePlanData>)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
    }
    public static partial class AppServicesExtensions
    {
        public static Azure.Provisioning.AppService.AppServicePlan AddAppServicePlan(this Azure.Provisioning.IConstruct construct, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "appServicePlan") { throw null; }
    }
    public partial class WebSite : Azure.Provisioning.Resource<Azure.ResourceManager.AppService.WebSiteData>
    {
        public WebSite(Azure.Provisioning.IConstruct scope, string resourceName, Azure.Provisioning.AppService.AppServicePlan appServicePlan, Azure.Provisioning.AppService.WebSiteRuntime runtime, string runtimeVersion, string version = "2021-02-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.AppService.WebSiteData>)) { }
        public void AddApplicationSetting(string key, Azure.Provisioning.Parameter value) { }
        public void AddApplicationSetting(string key, string value) { }
        public void AddLogConfig(string resourceName) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
    }
    public partial class WebSiteConfigLogs : Azure.Provisioning.Resource<Azure.ResourceManager.AppService.SiteLogsConfigData>
    {
        public WebSiteConfigLogs(Azure.Provisioning.IConstruct scope, string resourceName, Azure.Provisioning.AppService.WebSite? parent = null, string version = "2021-02-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.AppService.SiteLogsConfigData>)) { }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
    public partial class WebSitePublishingCredentialPolicy : Azure.Provisioning.Resource<Azure.ResourceManager.AppService.CsmPublishingCredentialsPoliciesEntityData>
    {
        public WebSitePublishingCredentialPolicy(Azure.Provisioning.IConstruct scope, string resourceName, string version = "2021-02-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.AppService.CsmPublishingCredentialsPoliciesEntityData>)) { }
    }
    public enum WebSiteRuntime
    {
        Node = 0,
        Dotnetcore = 1,
    }
}
namespace Azure.Provisioning.KeyVaults
{
    public partial class KeyVault : Azure.Provisioning.Resource<Azure.ResourceManager.KeyVault.KeyVaultData>
    {
        public KeyVault(Azure.Provisioning.IConstruct scope, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "kv", string version = "2023-02-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.KeyVault.KeyVaultData>)) { }
        public void AddAccessPolicy(Azure.Provisioning.Output output) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
    }
    public static partial class KeyVaultExtensions
    {
        public static Azure.Provisioning.KeyVaults.KeyVault AddKeyVault(this Azure.Provisioning.IConstruct construct, Azure.Provisioning.ResourceManager.ResourceGroup? resourceGroup = null, string name = "kv") { throw null; }
        public static System.Collections.Generic.IEnumerable<Azure.Provisioning.KeyVaults.KeyVaultSecret> GetSecrets(this Azure.Provisioning.IConstruct construct) { throw null; }
    }
    public partial class KeyVaultSecret : Azure.Provisioning.Resource<Azure.ResourceManager.KeyVault.KeyVaultSecretData>
    {
        public KeyVaultSecret(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.Sql.ConnectionString connectionString, string version = "2023-02-01") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.KeyVault.KeyVaultSecretData>)) { }
        public KeyVaultSecret(Azure.Provisioning.IConstruct scope, string name = "kvs", string version = "2023-02-01") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.KeyVault.KeyVaultSecretData>)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
    }
}
namespace Azure.Provisioning.ResourceManager
{
    public partial class ResourceGroup : Azure.Provisioning.Resource<Azure.ResourceManager.Resources.ResourceGroupData>
    {
        public ResourceGroup(Azure.Provisioning.IConstruct scope, string? name = "rg", string version = "2023-07-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.Provisioning.ResourceManager.Subscription? parent = null) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Resources.ResourceGroupData>)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
    public static partial class ResourceManagerExtensions
    {
        public static Azure.Provisioning.ResourceManager.ResourceGroup AddResourceGroup(this Azure.Provisioning.IConstruct construct) { throw null; }
        public static Azure.Provisioning.ResourceManager.ResourceGroup GetOrAddResourceGroup(this Azure.Provisioning.IConstruct construct) { throw null; }
        public static Azure.Provisioning.ResourceManager.Subscription GetOrCreateSubscription(this Azure.Provisioning.IConstruct construct, System.Guid? subscriptionId = default(System.Guid?)) { throw null; }
    }
    public partial class Subscription : Azure.Provisioning.Resource<Azure.ResourceManager.Resources.SubscriptionData>
    {
        public Subscription(Azure.Provisioning.IConstruct scope, System.Guid? guid = default(System.Guid?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Resources.SubscriptionData>)) { }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string? resourceName) { throw null; }
    }
    public partial class Tenant : Azure.Provisioning.Resource<Azure.ResourceManager.Resources.TenantData>
    {
        public Tenant(Azure.Provisioning.IConstruct scope, System.Guid? tenantId = default(System.Guid?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Resources.TenantData>)) { }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
}
namespace Azure.Provisioning.Resources
{
    public partial class DeploymentScript : Azure.Provisioning.Resource<Azure.ResourceManager.Resources.Models.AzureCliScript>
    {
        public DeploymentScript(Azure.Provisioning.IConstruct scope, string resourceName, Azure.Provisioning.Resource database, Azure.Provisioning.Parameter databaseServerName, Azure.Provisioning.Parameter appUserPasswordSecret, Azure.Provisioning.Parameter sqlAdminPasswordSecret, string version = "2020-10-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Resources.Models.AzureCliScript>)) { }
        public DeploymentScript(Azure.Provisioning.IConstruct scope, string resourceName, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ScriptEnvironmentVariable> scriptEnvironmentVariables, string scriptContent, string version = "2020-10-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Resources.Models.AzureCliScript>)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
    }
}
namespace Azure.Provisioning.Sql
{
    public partial class ConnectionString
    {
        public ConnectionString(Azure.Provisioning.Sql.SqlDatabase database, Azure.Provisioning.Parameter password, string userName) { }
        public string Value { get { throw null; } }
    }
    public partial class SqlDatabase : Azure.Provisioning.Resource<Azure.ResourceManager.Sql.SqlDatabaseData>
    {
        public SqlDatabase(Azure.Provisioning.IConstruct scope, Azure.Provisioning.Sql.SqlServer? parent = null, string name = "db", string version = "2022-08-01-preview", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Sql.SqlDatabaseData>)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public Azure.Provisioning.Sql.ConnectionString GetConnectionString(Azure.Provisioning.Parameter passwordSecret, string userName = "appUser") { throw null; }
    }
    public partial class SqlFirewallRule : Azure.Provisioning.Resource<Azure.ResourceManager.Sql.SqlFirewallRuleData>
    {
        public SqlFirewallRule(Azure.Provisioning.IConstruct scope, string name = "fw", string version = "2020-11-01-preview") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Sql.SqlFirewallRuleData>)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
    }
    public partial class SqlServer : Azure.Provisioning.Resource<Azure.ResourceManager.Sql.SqlServerData>
    {
        public SqlServer(Azure.Provisioning.IConstruct scope, string name, string version = "2022-08-01-preview", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Sql.SqlServerData>)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
    }
}
namespace Azure.Provisioning.Storage
{
    public partial class BlobService : Azure.Provisioning.Resource<Azure.ResourceManager.Storage.BlobServiceData>
    {
        public BlobService(Azure.Provisioning.IConstruct scope) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Storage.BlobServiceData>)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
    }
    public partial class StorageAccount : Azure.Provisioning.Resource<Azure.ResourceManager.Storage.StorageAccountData>
    {
        public StorageAccount(Azure.Provisioning.IConstruct scope, Azure.ResourceManager.Storage.Models.StorageKind kind, Azure.ResourceManager.Storage.Models.StorageSkuName sku, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "sa") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Storage.StorageAccountData>)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
    public static partial class StorageExtensions
    {
        public static Azure.Provisioning.Storage.BlobService AddBlobService(this Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.Storage.StorageAccount AddStorageAccount(this Azure.Provisioning.IConstruct scope, Azure.ResourceManager.Storage.Models.StorageKind kind, Azure.ResourceManager.Storage.Models.StorageSkuName sku, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "sa") { throw null; }
    }
}
