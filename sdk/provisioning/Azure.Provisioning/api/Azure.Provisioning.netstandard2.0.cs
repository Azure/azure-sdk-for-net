namespace Azure.Provisioning
{
    public partial class Configuration
    {
        public Configuration() { }
        public bool UseInteractiveMode { get { throw null; } set { } }
    }
    public abstract partial class ConnectionString
    {
        protected ConnectionString(string value) { }
        public string Value { get { throw null; } }
    }
    public abstract partial class Construct : Azure.Provisioning.IConstruct
    {
        protected Construct(Azure.Provisioning.IConstruct? scope, string name, Azure.Provisioning.ConstructScope constructScope = Azure.Provisioning.ConstructScope.ResourceGroup, System.Guid? tenantId = default(System.Guid?), System.Guid? subscriptionId = default(System.Guid?), string? envName = null, Azure.Provisioning.ResourceManager.ResourceGroup? resourceGroup = null) { }
        public Azure.Provisioning.Configuration? Configuration { get { throw null; } }
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
        Azure.Provisioning.Configuration? Configuration { get; }
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
        public Infrastructure(Azure.Provisioning.ConstructScope constructScope = Azure.Provisioning.ConstructScope.Subscription, System.Guid? tenantId = default(System.Guid?), System.Guid? subscriptionId = default(System.Guid?), string? envName = null, Azure.Provisioning.Configuration? configuration = null) : base (default(Azure.Provisioning.IConstruct), default(string), default(Azure.Provisioning.ConstructScope), default(System.Guid?), default(System.Guid?), default(string), default(Azure.Provisioning.ResourceManager.ResourceGroup)) { }
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
    public static partial class ProvisioningExtensions
    {
        public static T? GetSingleResourceInScope<T>(this Azure.Provisioning.IConstruct construct) where T : Azure.Provisioning.Resource { throw null; }
        public static T? GetSingleResource<T>(this Azure.Provisioning.IConstruct construct) where T : Azure.Provisioning.Resource { throw null; }
    }
    public abstract partial class Resource : System.ClientModel.Primitives.IPersistableModel<Azure.Provisioning.Resource>
    {
        protected Resource(Azure.Provisioning.IConstruct scope, Azure.Provisioning.Resource? parent, string resourceName, Azure.Core.ResourceType resourceType, string version, System.Func<string, object> createProperties) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public bool IsExisting { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Provisioning.Resource? Parent { get { throw null; } }
        public Azure.Provisioning.IConstruct Scope { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        protected virtual string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
        protected virtual string GetBicepName(Azure.Provisioning.Resource resource) { throw null; }
        protected string GetGloballyUniqueName(string resourceName) { throw null; }
        protected virtual bool NeedsParent() { throw null; }
        protected virtual bool NeedsScope() { throw null; }
        Azure.Provisioning.Resource System.ClientModel.Primitives.IPersistableModel<Azure.Provisioning.Resource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Provisioning.Resource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Provisioning.Resource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class Resource<T> : Azure.Provisioning.Resource where T : notnull
    {
        protected Resource(Azure.Provisioning.IConstruct scope, Azure.Provisioning.Resource? parent, string resourceName, Azure.Core.ResourceType resourceType, string version, System.Func<string, T> createProperties) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, object>)) { }
        public T Properties { get { throw null; } }
        public Azure.Provisioning.Output AddOutput(string outputName, System.Linq.Expressions.Expression<System.Func<T, object?>> propertySelector, bool isLiteral = false, bool isSecure = false) { throw null; }
        public Azure.Provisioning.Output AddOutput(string outputName, string formattedString, System.Linq.Expressions.Expression<System.Func<T, object?>> propertySelector, bool isLiteral = false, bool isSecure = false) { throw null; }
        public void AssignProperty(System.Linq.Expressions.Expression<System.Func<T, object?>> propertySelector, Azure.Provisioning.Parameter parameter) { }
        public void AssignProperty(System.Linq.Expressions.Expression<System.Func<T, object?>> propertySelector, string propertyValue) { }
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
        public AppConfigurationStore(Azure.Provisioning.IConstruct scope, string skuName = "free", Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "store", string version = "2023-03-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData>)) { }
        public static Azure.Provisioning.AppConfiguration.AppConfigurationStore FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
}
namespace Azure.Provisioning.ApplicationInsights
{
    public partial class ApplicationInsightsComponent : Azure.Provisioning.Resource<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData>
    {
        public ApplicationInsightsComponent(Azure.Provisioning.IConstruct scope, string kind = "web", string applicationType = "web", Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "appinsights", string version = "2020-02-02", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData>)) { }
        public static Azure.Provisioning.ApplicationInsights.ApplicationInsightsComponent FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
}
namespace Azure.Provisioning.Authorization
{
    public static partial class AuthorizationExtensions
    {
        public static Azure.Provisioning.Authorization.RoleAssignment AssignRole(this Azure.Provisioning.Resource resource, Azure.Provisioning.Authorization.RoleDefinition roleDefinition, System.Guid? principalId = default(System.Guid?), Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType?)) { throw null; }
    }
    public partial class RoleAssignment : Azure.Provisioning.Resource<Azure.ResourceManager.Authorization.RoleAssignmentData>
    {
        internal RoleAssignment() : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Authorization.RoleAssignmentData>)) { }
        protected override string GetBicepName(Azure.Provisioning.Resource resource) { throw null; }
        protected override bool NeedsParent() { throw null; }
        protected override bool NeedsScope() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleDefinition : System.IEquatable<Azure.Provisioning.Authorization.RoleDefinition>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleDefinition(string value) { throw null; }
        public static Azure.Provisioning.Authorization.RoleDefinition AppConfigurationDataOwner { get { throw null; } }
        public static Azure.Provisioning.Authorization.RoleDefinition CognitiveServicesOpenAIContributor { get { throw null; } }
        public static Azure.Provisioning.Authorization.RoleDefinition EventHubsDataOwner { get { throw null; } }
        public static Azure.Provisioning.Authorization.RoleDefinition KeyVaultAdministrator { get { throw null; } }
        public static Azure.Provisioning.Authorization.RoleDefinition SearchIndexDataContributor { get { throw null; } }
        public static Azure.Provisioning.Authorization.RoleDefinition SearchServiceContributor { get { throw null; } }
        public static Azure.Provisioning.Authorization.RoleDefinition ServiceBusDataOwner { get { throw null; } }
        public static Azure.Provisioning.Authorization.RoleDefinition SignalRAppServer { get { throw null; } }
        public static Azure.Provisioning.Authorization.RoleDefinition StorageBlobDataContributor { get { throw null; } }
        public static Azure.Provisioning.Authorization.RoleDefinition StorageQueueDataContributor { get { throw null; } }
        public static Azure.Provisioning.Authorization.RoleDefinition StorageTableDataContributor { get { throw null; } }
        public bool Equals(Azure.Provisioning.Authorization.RoleDefinition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static implicit operator Azure.Provisioning.Authorization.RoleDefinition (string value) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Azure.Provisioning.CognitiveServices
{
    public partial class CognitiveServicesAccount : Azure.Provisioning.Resource<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>
    {
        public CognitiveServicesAccount(Azure.Provisioning.IConstruct scope, string? kind = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku? sku = null, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "cs", string version = "2023-05-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>)) { }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesAccount FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
    public partial class CognitiveServicesAccountDeployment : Azure.Provisioning.Resource<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData>
    {
        public CognitiveServicesAccountDeployment(Azure.Provisioning.IConstruct scope, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel model, Azure.Provisioning.CognitiveServices.CognitiveServicesAccount? parent = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku? sku = null, string name = "cs", string version = "2023-05-01") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData>)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeployment FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.CognitiveServices.CognitiveServicesAccount parent) { throw null; }
    }
}
namespace Azure.Provisioning.CosmosDB
{
    public partial class CosmosDBAccount : Azure.Provisioning.Resource<Azure.ResourceManager.CosmosDB.CosmosDBAccountData>
    {
        public CosmosDBAccount(Azure.Provisioning.IConstruct scope, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKind? kind = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKind?), Azure.ResourceManager.CosmosDB.Models.ConsistencyPolicy? consistencyPolicy = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountOfferType? accountOfferType = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountOfferType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountLocation>? accountLocations = null, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "cosmosDB", string version = "2023-04-15", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.CosmosDB.CosmosDBAccountData>)) { }
        public static Azure.Provisioning.CosmosDB.CosmosDBAccount FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
        public Azure.Provisioning.CosmosDB.CosmosDBAccountConnectionString GetConnectionString(Azure.Provisioning.CosmosDB.CosmosDBKey? key = default(Azure.Provisioning.CosmosDB.CosmosDBKey?)) { throw null; }
    }
    public partial class CosmosDBAccountConnectionString : Azure.Provisioning.ConnectionString
    {
        internal CosmosDBAccountConnectionString() : base (default(string)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBKey : System.IEquatable<Azure.Provisioning.CosmosDB.CosmosDBKey>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBKey(string value) { throw null; }
        public static Azure.Provisioning.CosmosDB.CosmosDBKey PrimaryKey { get { throw null; } }
        public static Azure.Provisioning.CosmosDB.CosmosDBKey PrimaryReadonlyMasterKey { get { throw null; } }
        public static Azure.Provisioning.CosmosDB.CosmosDBKey SecondaryKey { get { throw null; } }
        public static Azure.Provisioning.CosmosDB.CosmosDBKey SecondaryReadonlyMasterKey { get { throw null; } }
        public bool Equals(Azure.Provisioning.CosmosDB.CosmosDBKey other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static implicit operator Azure.Provisioning.CosmosDB.CosmosDBKey (string value) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBSqlDatabase : Azure.Provisioning.Resource<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseData>
    {
        public CosmosDBSqlDatabase(Azure.Provisioning.IConstruct scope, Azure.Provisioning.CosmosDB.CosmosDBAccount? parent = null, Azure.ResourceManager.CosmosDB.Models.ExtendedCosmosDBSqlDatabaseResourceInfo? databaseResourceInfo = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlDatabasePropertiesConfig? propertiesConfig = null, string name = "db", string version = "2023-04-15", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseData>)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.CosmosDB.CosmosDBSqlDatabase FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.CosmosDB.CosmosDBAccount parent) { throw null; }
    }
}
namespace Azure.Provisioning.EventHubs
{
    public partial class EventHub : Azure.Provisioning.Resource<Azure.ResourceManager.EventHubs.EventHubData>
    {
        public EventHub(Azure.Provisioning.IConstruct scope, Azure.Provisioning.EventHubs.EventHubsNamespace? parent = null, string name = "hub", string version = "2021-11-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.EventHubs.EventHubData>)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.EventHubs.EventHub FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.EventHubs.EventHubsNamespace parent) { throw null; }
    }
    public partial class EventHubsConsumerGroup : Azure.Provisioning.Resource<Azure.ResourceManager.EventHubs.EventHubsConsumerGroupData>
    {
        public EventHubsConsumerGroup(Azure.Provisioning.IConstruct scope, Azure.Provisioning.EventHubs.EventHub? parent = null, string name = "cg", string version = "2021-11-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.EventHubs.EventHubsConsumerGroupData>)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.EventHubs.EventHubsConsumerGroup FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.EventHubs.EventHub parent) { throw null; }
    }
    public partial class EventHubsNamespace : Azure.Provisioning.Resource<Azure.ResourceManager.EventHubs.EventHubsNamespaceData>
    {
        public EventHubsNamespace(Azure.Provisioning.IConstruct scope, Azure.ResourceManager.EventHubs.Models.EventHubsSku? sku = null, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "eh", string version = "2021-11-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.EventHubs.EventHubsNamespaceData>)) { }
        public static Azure.Provisioning.EventHubs.EventHubsNamespace FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
}
namespace Azure.Provisioning.KeyVaults
{
    public partial class KeyVault : Azure.Provisioning.Resource<Azure.ResourceManager.KeyVault.KeyVaultData>
    {
        public KeyVault(Azure.Provisioning.IConstruct scope, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "kv", string version = "2022-07-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.KeyVault.KeyVaultData>)) { }
        public void AddAccessPolicy(Azure.Provisioning.Output output) { }
        public static Azure.Provisioning.KeyVaults.KeyVault FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
    public static partial class KeyVaultExtensions
    {
        public static Azure.Provisioning.KeyVaults.KeyVault AddKeyVault(this Azure.Provisioning.IConstruct construct, Azure.Provisioning.ResourceManager.ResourceGroup? resourceGroup = null, string name = "kv") { throw null; }
        public static System.Collections.Generic.IEnumerable<Azure.Provisioning.KeyVaults.KeyVaultSecret> GetSecrets(this Azure.Provisioning.IConstruct construct) { throw null; }
    }
    public partial class KeyVaultSecret : Azure.Provisioning.Resource<Azure.ResourceManager.KeyVault.KeyVaultSecretData>
    {
        public KeyVaultSecret(Azure.Provisioning.IConstruct scope, Azure.Provisioning.KeyVaults.KeyVault? parent = null, string name = "kvs", string version = "2022-07-01") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.KeyVault.KeyVaultSecretData>)) { }
        public KeyVaultSecret(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ConnectionString connectionString, Azure.Provisioning.KeyVaults.KeyVault? parent = null, string version = "2022-07-01") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.KeyVault.KeyVaultSecretData>)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.KeyVaults.KeyVaultSecret FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.KeyVaults.KeyVault parent) { throw null; }
    }
}
namespace Azure.Provisioning.ManagedServiceIdentities
{
    public partial class UserAssignedIdentity : Azure.Provisioning.Resource<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData>
    {
        public UserAssignedIdentity(Azure.Provisioning.IConstruct scope, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "useridentity", string version = "2023-01-31", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData>)) { }
        public static Azure.Provisioning.ManagedServiceIdentities.UserAssignedIdentity FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
}
namespace Azure.Provisioning.OperationalInsights
{
    public partial class OperationalInsightsWorkspace : Azure.Provisioning.Resource<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData>
    {
        public OperationalInsightsWorkspace(Azure.Provisioning.IConstruct scope, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSku? sku = null, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "opinsights", string version = "2022-10-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData>)) { }
        public static Azure.Provisioning.OperationalInsights.OperationalInsightsWorkspace FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
}
namespace Azure.Provisioning.PostgreSql
{
    public partial class PostgreSqlConnectionString : Azure.Provisioning.ConnectionString
    {
        internal PostgreSqlConnectionString() : base (default(string)) { }
    }
    public partial class PostgreSqlFirewallRule : Azure.Provisioning.Resource<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData>
    {
        public PostgreSqlFirewallRule(Azure.Provisioning.IConstruct scope, string? startIpAddress = null, string? endIpAddress = null, Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServer? parent = null, string name = "fw", string version = "2023-03-01-preview") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData>)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.PostgreSql.PostgreSqlFirewallRule FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServer parent) { throw null; }
    }
    public partial class PostgreSqlFlexibleServer : Azure.Provisioning.Resource<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>
    {
        public PostgreSqlFlexibleServer(Azure.Provisioning.IConstruct scope, Azure.Provisioning.Parameter administratorLogin, Azure.Provisioning.Parameter administratorPassword, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku? sku = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion? serverVersion = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability? highAvailability = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption? encryption = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties? backup = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork? network = null, int? storageSizeInGB = default(int?), string? availabilityZone = null, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "postgres", string version = "2023-03-01-preview", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>)) { }
        public static Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServer FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
        public Azure.Provisioning.PostgreSql.PostgreSqlConnectionString GetConnectionString(Azure.Provisioning.Parameter administratorLogin, Azure.Provisioning.Parameter administratorPassword) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerDatabase : Azure.Provisioning.Resource<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData>
    {
        public PostgreSqlFlexibleServerDatabase(Azure.Provisioning.IConstruct scope, Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServer? parent = null, string name = "db", string version = "2023-03-01-preview") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData>)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerDatabase FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServer? parent) { throw null; }
    }
}
namespace Azure.Provisioning.Redis
{
    public partial class RedisCache : Azure.Provisioning.Resource<Azure.ResourceManager.Redis.RedisData>
    {
        public RedisCache(Azure.Provisioning.IConstruct scope, Azure.ResourceManager.Redis.Models.RedisSku? sku = null, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "redis", string version = "2023-08-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Redis.RedisData>)) { }
        public static Azure.Provisioning.Redis.RedisCache FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
        public Azure.Provisioning.Redis.RedisCacheConnectionString GetConnectionString(bool useSecondary = false) { throw null; }
    }
    public partial class RedisCacheConnectionString : Azure.Provisioning.ConnectionString
    {
        internal RedisCacheConnectionString() : base (default(string)) { }
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
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string? resourceName) { throw null; }
    }
}
namespace Azure.Provisioning.Resources
{
    public partial class DeploymentScript : Azure.Provisioning.Resource<Azure.ResourceManager.Resources.Models.AzureCliScript>
    {
        public DeploymentScript(Azure.Provisioning.IConstruct scope, string resourceName, Azure.Provisioning.Resource database, Azure.Provisioning.Parameter databaseServerName, Azure.Provisioning.Parameter appUserPasswordSecret, Azure.Provisioning.Parameter sqlAdminPasswordSecret, string version = "2020-10-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Resources.Models.AzureCliScript>)) { }
        public DeploymentScript(Azure.Provisioning.IConstruct scope, string resourceName, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ScriptEnvironmentVariable> scriptEnvironmentVariables, string scriptContent, string version = "2020-10-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Resources.Models.AzureCliScript>)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.Resources.DeploymentScript FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
    }
}
namespace Azure.Provisioning.Search
{
    public partial class SearchService : Azure.Provisioning.Resource<Azure.ResourceManager.Search.SearchServiceData>
    {
        public SearchService(Azure.Provisioning.IConstruct scope, Azure.ResourceManager.Search.Models.SearchSkuName? sku = default(Azure.ResourceManager.Search.Models.SearchSkuName?), Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "search", string version = "2023-11-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Search.SearchServiceData>)) { }
        public static Azure.Provisioning.Search.SearchService FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
}
namespace Azure.Provisioning.ServiceBus
{
    public partial class ServiceBusNamespace : Azure.Provisioning.Resource<Azure.ResourceManager.ServiceBus.ServiceBusNamespaceData>
    {
        public ServiceBusNamespace(Azure.Provisioning.IConstruct scope, Azure.ResourceManager.ServiceBus.Models.ServiceBusSku? sku = null, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "sb", string version = "2021-11-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.ServiceBus.ServiceBusNamespaceData>)) { }
        public static Azure.Provisioning.ServiceBus.ServiceBusNamespace FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
    public partial class ServiceBusQueue : Azure.Provisioning.Resource<Azure.ResourceManager.ServiceBus.ServiceBusQueueData>
    {
        public ServiceBusQueue(Azure.Provisioning.IConstruct scope, bool? requiresSession = default(bool?), Azure.Provisioning.ServiceBus.ServiceBusNamespace? parent = null, string name = "queue", string version = "2021-11-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.ServiceBus.ServiceBusQueueData>)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.ServiceBus.ServiceBusQueue FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ServiceBus.ServiceBusNamespace parent) { throw null; }
    }
    public partial class ServiceBusSubscription : Azure.Provisioning.Resource<Azure.ResourceManager.ServiceBus.ServiceBusSubscriptionData>
    {
        public ServiceBusSubscription(Azure.Provisioning.IConstruct scope, bool? requiresSession = default(bool?), Azure.Provisioning.ServiceBus.ServiceBusTopic? parent = null, string name = "subscription", string version = "2021-11-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.ServiceBus.ServiceBusSubscriptionData>)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.ServiceBus.ServiceBusSubscription FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ServiceBus.ServiceBusTopic parent) { throw null; }
    }
    public partial class ServiceBusTopic : Azure.Provisioning.Resource<Azure.ResourceManager.ServiceBus.ServiceBusTopicData>
    {
        public ServiceBusTopic(Azure.Provisioning.IConstruct scope, Azure.Provisioning.ServiceBus.ServiceBusNamespace? parent = null, string name = "topic", string version = "2021-11-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.ServiceBus.ServiceBusTopicData>)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.ServiceBus.ServiceBusTopic FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ServiceBus.ServiceBusNamespace parent) { throw null; }
    }
}
namespace Azure.Provisioning.SignalR
{
    public partial class SignalRService : Azure.Provisioning.Resource<Azure.ResourceManager.SignalR.SignalRData>
    {
        public SignalRService(Azure.Provisioning.IConstruct scope, Azure.ResourceManager.SignalR.Models.SignalRResourceSku? sku = null, System.Collections.Generic.IEnumerable<string>? allowedOrigins = null, string serviceMode = "Default", Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "signalr", string version = "2022-02-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.SignalR.SignalRData>)) { }
        public static Azure.Provisioning.SignalR.SignalRService FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
}
namespace Azure.Provisioning.Sql
{
    public partial class SqlDatabase : Azure.Provisioning.Resource<Azure.ResourceManager.Sql.SqlDatabaseData>
    {
        public SqlDatabase(Azure.Provisioning.IConstruct scope, Azure.Provisioning.Sql.SqlServer? parent = null, string name = "db", string version = "2020-11-01-preview", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Sql.SqlDatabaseData>)) { }
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
        public SqlFirewallRule(Azure.Provisioning.IConstruct scope, Azure.Provisioning.Sql.SqlServer? parent = null, string name = "fw", string version = "2020-11-01-preview") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Sql.SqlFirewallRuleData>)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.Sql.SqlFirewallRule FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.Sql.SqlServer parent) { throw null; }
    }
    public partial class SqlServer : Azure.Provisioning.Resource<Azure.ResourceManager.Sql.SqlServerData>
    {
        public SqlServer(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.Parameter? administratorLogin = default(Azure.Provisioning.Parameter?), Azure.Provisioning.Parameter? administratorPassword = default(Azure.Provisioning.Parameter?), Azure.Provisioning.Sql.SqlServerAdministrator? administrator = default(Azure.Provisioning.Sql.SqlServerAdministrator?), Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string version = "2020-11-01-preview", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Sql.SqlServerData>)) { }
        public static Azure.Provisioning.Sql.SqlServer FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerAdministrator
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerAdministrator(Azure.Provisioning.Parameter loginName, Azure.Provisioning.Parameter objectId) { throw null; }
    }
}
namespace Azure.Provisioning.Storage
{
    public partial class BlobService : Azure.Provisioning.Resource<Azure.ResourceManager.Storage.BlobServiceData>
    {
        public BlobService(Azure.Provisioning.IConstruct scope, Azure.Provisioning.Storage.StorageAccount? parent = null, string version = "2022-09-01") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Storage.BlobServiceData>)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.Storage.BlobService FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.Storage.StorageAccount parent) { throw null; }
    }
    public partial class StorageAccount : Azure.Provisioning.Resource<Azure.ResourceManager.Storage.StorageAccountData>
    {
        public StorageAccount(Azure.Provisioning.IConstruct scope, Azure.ResourceManager.Storage.Models.StorageKind kind, Azure.ResourceManager.Storage.Models.StorageSkuName sku, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "sa", string version = "2022-09-01") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Storage.StorageAccountData>)) { }
        public static Azure.Provisioning.Storage.StorageAccount FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
    public static partial class StorageExtensions
    {
        public static Azure.Provisioning.Storage.BlobService AddBlobService(this Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.Storage.StorageAccount AddStorageAccount(this Azure.Provisioning.IConstruct scope, Azure.ResourceManager.Storage.Models.StorageKind kind, Azure.ResourceManager.Storage.Models.StorageSkuName sku, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "sa") { throw null; }
    }
}
