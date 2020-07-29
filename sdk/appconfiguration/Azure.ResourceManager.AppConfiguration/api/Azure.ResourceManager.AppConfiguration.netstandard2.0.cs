namespace Azure.ResourceManager.AppConfiguration
{
    public partial class AppConfigurationManagementClient
    {
        protected AppConfigurationManagementClient() { }
        public AppConfigurationManagementClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.AppConfiguration.AppConfigurationManagementClientOptions options = null) { }
        public AppConfigurationManagementClient(string subscriptionId, System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.AppConfiguration.AppConfigurationManagementClientOptions options = null) { }
        public virtual Azure.ResourceManager.AppConfiguration.ConfigurationStoresOperations ConfigurationStores { get { throw null; } }
        public virtual Azure.ResourceManager.AppConfiguration.Operations Operations { get { throw null; } }
        public virtual Azure.ResourceManager.AppConfiguration.PrivateEndpointConnectionsOperations PrivateEndpointConnections { get { throw null; } }
        public virtual Azure.ResourceManager.AppConfiguration.PrivateLinkResourcesOperations PrivateLinkResources { get { throw null; } }
    }
    public partial class AppConfigurationManagementClientOptions : Azure.Core.ClientOptions
    {
        public AppConfigurationManagementClientOptions() { }
    }
    public partial class ConfigurationStoresCreateOperation : Azure.Operation<Azure.ResourceManager.AppConfiguration.Models.ConfigurationStore>
    {
        internal ConfigurationStoresCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.AppConfiguration.Models.ConfigurationStore Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.AppConfiguration.Models.ConfigurationStore>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.AppConfiguration.Models.ConfigurationStore>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfigurationStoresDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal ConfigurationStoresDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfigurationStoresOperations
    {
        protected ConfigurationStoresOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.Models.ConfigurationStore> Get(string resourceGroupName, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.Models.ConfigurationStore>> GetAsync(string resourceGroupName, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.Models.ConfigurationStore> List(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.Models.ConfigurationStore> ListAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.Models.ConfigurationStore> ListByResourceGroup(string resourceGroupName, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.Models.ConfigurationStore> ListByResourceGroupAsync(string resourceGroupName, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.Models.ApiKey> ListKeys(string resourceGroupName, string configStoreName, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.Models.ApiKey> ListKeysAsync(string resourceGroupName, string configStoreName, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.Models.KeyValue> ListKeyValue(string resourceGroupName, string configStoreName, Azure.ResourceManager.AppConfiguration.Models.ListKeyValueParameters listKeyValueParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.Models.KeyValue>> ListKeyValueAsync(string resourceGroupName, string configStoreName, Azure.ResourceManager.AppConfiguration.Models.ListKeyValueParameters listKeyValueParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.Models.ApiKey> RegenerateKey(string resourceGroupName, string configStoreName, Azure.ResourceManager.AppConfiguration.Models.RegenerateKeyParameters regenerateKeyParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.Models.ApiKey>> RegenerateKeyAsync(string resourceGroupName, string configStoreName, Azure.ResourceManager.AppConfiguration.Models.RegenerateKeyParameters regenerateKeyParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.ConfigurationStoresCreateOperation StartCreate(string resourceGroupName, string configStoreName, Azure.ResourceManager.AppConfiguration.Models.ConfigurationStore configStoreCreationParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.AppConfiguration.ConfigurationStoresCreateOperation> StartCreateAsync(string resourceGroupName, string configStoreName, Azure.ResourceManager.AppConfiguration.Models.ConfigurationStore configStoreCreationParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.ConfigurationStoresDeleteOperation StartDelete(string resourceGroupName, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.AppConfiguration.ConfigurationStoresDeleteOperation> StartDeleteAsync(string resourceGroupName, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.ConfigurationStoresUpdateOperation StartUpdate(string resourceGroupName, string configStoreName, Azure.ResourceManager.AppConfiguration.Models.ConfigurationStoreUpdateParameters configStoreUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.AppConfiguration.ConfigurationStoresUpdateOperation> StartUpdateAsync(string resourceGroupName, string configStoreName, Azure.ResourceManager.AppConfiguration.Models.ConfigurationStoreUpdateParameters configStoreUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfigurationStoresUpdateOperation : Azure.Operation<Azure.ResourceManager.AppConfiguration.Models.ConfigurationStore>
    {
        internal ConfigurationStoresUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.AppConfiguration.Models.ConfigurationStore Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.AppConfiguration.Models.ConfigurationStore>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.AppConfiguration.Models.ConfigurationStore>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class Operations
    {
        protected Operations() { }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.Models.NameAvailabilityStatus> CheckNameAvailability(Azure.ResourceManager.AppConfiguration.Models.CheckNameAvailabilityParameters checkNameAvailabilityParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.Models.NameAvailabilityStatus>> CheckNameAvailabilityAsync(Azure.ResourceManager.AppConfiguration.Models.CheckNameAvailabilityParameters checkNameAvailabilityParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.Models.OperationDefinition> List(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.Models.OperationDefinition> ListAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.AppConfiguration.Models.PrivateEndpointConnection>
    {
        internal PrivateEndpointConnectionsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.AppConfiguration.Models.PrivateEndpointConnection Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.AppConfiguration.Models.PrivateEndpointConnection>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.AppConfiguration.Models.PrivateEndpointConnection>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionsDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal PrivateEndpointConnectionsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionsOperations
    {
        protected PrivateEndpointConnectionsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.Models.PrivateEndpointConnection> Get(string resourceGroupName, string configStoreName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.Models.PrivateEndpointConnection>> GetAsync(string resourceGroupName, string configStoreName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.Models.PrivateEndpointConnection> ListByConfigurationStore(string resourceGroupName, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.Models.PrivateEndpointConnection> ListByConfigurationStoreAsync(string resourceGroupName, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.PrivateEndpointConnectionsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string configStoreName, string privateEndpointConnectionName, Azure.ResourceManager.AppConfiguration.Models.PrivateEndpointConnection privateEndpointConnection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.AppConfiguration.PrivateEndpointConnectionsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string configStoreName, string privateEndpointConnectionName, Azure.ResourceManager.AppConfiguration.Models.PrivateEndpointConnection privateEndpointConnection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.PrivateEndpointConnectionsDeleteOperation StartDelete(string resourceGroupName, string configStoreName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.AppConfiguration.PrivateEndpointConnectionsDeleteOperation> StartDeleteAsync(string resourceGroupName, string configStoreName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkResourcesOperations
    {
        protected PrivateLinkResourcesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.Models.PrivateLinkResource> Get(string resourceGroupName, string configStoreName, string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.Models.PrivateLinkResource>> GetAsync(string resourceGroupName, string configStoreName, string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.Models.PrivateLinkResource> ListByConfigurationStore(string resourceGroupName, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.Models.PrivateLinkResource> ListByConfigurationStoreAsync(string resourceGroupName, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.AppConfiguration.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionsRequired : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.ActionsRequired>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionsRequired(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.ActionsRequired None { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.ActionsRequired Recreate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.ActionsRequired other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.ActionsRequired left, Azure.ResourceManager.AppConfiguration.Models.ActionsRequired right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.ActionsRequired (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.ActionsRequired left, Azure.ResourceManager.AppConfiguration.Models.ActionsRequired right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiKey
    {
        internal ApiKey() { }
        public string ConnectionString { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? ReadOnly { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ApiKeyListResult
    {
        internal ApiKeyListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppConfiguration.Models.ApiKey> Value { get { throw null; } }
    }
    public partial class CheckNameAvailabilityParameters
    {
        public CheckNameAvailabilityParameters(string name) { }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class ConfigurationStore : Azure.ResourceManager.AppConfiguration.Models.Resource
    {
        public ConfigurationStore(string location, Azure.ResourceManager.AppConfiguration.Models.Sku sku) : base (default(string)) { }
        public System.DateTimeOffset? CreationDate { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.EncryptionProperties Encryption { get { throw null; } set { } }
        public string Endpoint { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.ResourceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppConfiguration.Models.PrivateEndpointConnectionReference> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.Sku Sku { get { throw null; } set { } }
    }
    public partial class ConfigurationStoreListResult
    {
        internal ConfigurationStoreListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppConfiguration.Models.ConfigurationStore> Value { get { throw null; } }
    }
    public partial class ConfigurationStoreUpdateParameters
    {
        public ConfigurationStoreUpdateParameters() { }
        public Azure.ResourceManager.AppConfiguration.Models.EncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.ResourceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.Sku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionStatus : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus left, Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus left, Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EncryptionProperties
    {
        public EncryptionProperties() { }
        public Azure.ResourceManager.AppConfiguration.Models.KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityType : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.IdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityType(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.IdentityType None { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.IdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.IdentityType SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.IdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.IdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.IdentityType left, Azure.ResourceManager.AppConfiguration.Models.IdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.IdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.IdentityType left, Azure.ResourceManager.AppConfiguration.Models.IdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyValue
    {
        internal KeyValue() { }
        public string ContentType { get { throw null; } }
        public string ETag { get { throw null; } }
        public string Key { get { throw null; } }
        public string Label { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public bool? Locked { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class KeyVaultProperties
    {
        public KeyVaultProperties() { }
        public string IdentityClientId { get { throw null; } set { } }
        public string KeyIdentifier { get { throw null; } set { } }
    }
    public partial class ListKeyValueParameters
    {
        public ListKeyValueParameters(string key) { }
        public string Key { get { throw null; } }
        public string Label { get { throw null; } set { } }
    }
    public partial class NameAvailabilityStatus
    {
        internal NameAvailabilityStatus() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class OperationDefinition
    {
        internal OperationDefinition() { }
        public Azure.ResourceManager.AppConfiguration.Models.OperationDefinitionDisplay Display { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class OperationDefinitionDisplay
    {
        internal OperationDefinitionDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class OperationDefinitionListResult
    {
        internal OperationDefinitionListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppConfiguration.Models.OperationDefinition> Value { get { throw null; } }
    }
    public partial class PrivateEndpoint
    {
        public PrivateEndpoint() { }
        public string Id { get { throw null; } set { } }
    }
    public partial class PrivateEndpointConnection
    {
        public PrivateEndpointConnection() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.PrivateEndpoint PrivateEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionListResult
    {
        internal PrivateEndpointConnectionListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppConfiguration.Models.PrivateEndpointConnection> Value { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionReference
    {
        public PrivateEndpointConnectionReference() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.PrivateEndpoint PrivateEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class PrivateLinkResource
    {
        internal PrivateLinkResource() { }
        public string GroupId { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class PrivateLinkResourceListResult
    {
        internal PrivateLinkResourceListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppConfiguration.Models.PrivateLinkResource> Value { get { throw null; } }
    }
    public partial class PrivateLinkServiceConnectionState
    {
        public PrivateLinkServiceConnectionState() { }
        public Azure.ResourceManager.AppConfiguration.Models.ActionsRequired? ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.ProvisioningState left, Azure.ResourceManager.AppConfiguration.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.ProvisioningState left, Azure.ResourceManager.AppConfiguration.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.PublicNetworkAccess left, Azure.ResourceManager.AppConfiguration.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.PublicNetworkAccess left, Azure.ResourceManager.AppConfiguration.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegenerateKeyParameters
    {
        public RegenerateKeyParameters() { }
        public string Id { get { throw null; } set { } }
    }
    public partial class Resource
    {
        public Resource(string location) { }
        public string Id { get { throw null; } }
        public string Location { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        public string Type { get { throw null; } }
    }
    public partial class ResourceIdentity
    {
        public ResourceIdentity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.IdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.AppConfiguration.Models.UserIdentity> UserAssignedIdentities { get { throw null; } set { } }
    }
    public partial class Sku
    {
        public Sku(string name) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class UserIdentity
    {
        public UserIdentity() { }
        public string ClientId { get { throw null; } }
        public string PrincipalId { get { throw null; } }
    }
}
