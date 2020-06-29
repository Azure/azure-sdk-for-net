namespace Azure.ResourceManager.KeyVault
{
    public partial class KeyVaultManagementClient
    {
        protected KeyVaultManagementClient() { }
        public KeyVaultManagementClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.KeyVault.KeyVaultManagementClientOptions options = null) { }
        public KeyVaultManagementClient(string subscriptionId, System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.KeyVault.KeyVaultManagementClientOptions options = null) { }
        public virtual Azure.ResourceManager.KeyVault.Operations Operations { get { throw null; } }
        public virtual Azure.ResourceManager.KeyVault.PrivateEndpointConnectionsOperations PrivateEndpointConnections { get { throw null; } }
        public virtual Azure.ResourceManager.KeyVault.PrivateLinkResourcesOperations PrivateLinkResources { get { throw null; } }
        public virtual Azure.ResourceManager.KeyVault.VaultsOperations Vaults { get { throw null; } }
    }
    public partial class KeyVaultManagementClientOptions : Azure.Core.ClientOptions
    {
        public KeyVaultManagementClientOptions() { }
    }
    public partial class Operations
    {
        protected Operations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.Models.Operation> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.Models.Operation> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionsDeleteOperation : Azure.Operation<Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnection>
    {
        internal PrivateEndpointConnectionsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnection Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnection>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnection>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionsOperations
    {
        protected PrivateEndpointConnectionsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnection> Get(string resourceGroupName, string vaultName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnection>> GetAsync(string resourceGroupName, string vaultName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnection> Put(string resourceGroupName, string vaultName, string privateEndpointConnectionName, Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnection properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnection>> PutAsync(string resourceGroupName, string vaultName, string privateEndpointConnectionName, Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnection properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.PrivateEndpointConnectionsDeleteOperation StartDelete(string resourceGroupName, string vaultName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionsDeleteOperation> StartDeleteAsync(string resourceGroupName, string vaultName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkResourcesOperations
    {
        protected PrivateLinkResourcesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.Models.PrivateLinkResourceListResult> ListByVault(string resourceGroupName, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Models.PrivateLinkResourceListResult>> ListByVaultAsync(string resourceGroupName, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VaultsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.KeyVault.Models.Vault>
    {
        internal VaultsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.KeyVault.Models.Vault Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.KeyVault.Models.Vault>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.KeyVault.Models.Vault>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VaultsOperations
    {
        protected VaultsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.Models.CheckNameAvailabilityResult> CheckNameAvailability(Azure.ResourceManager.KeyVault.Models.VaultCheckNameAvailabilityParameters vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityAsync(Azure.ResourceManager.KeyVault.Models.VaultCheckNameAvailabilityParameters vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.Models.Vault> Get(string resourceGroupName, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Models.Vault>> GetAsync(string resourceGroupName, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.Models.DeletedVault> GetDeleted(string vaultName, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Models.DeletedVault>> GetDeletedAsync(string vaultName, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.Models.Resource> List(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.Models.Resource> ListAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.Models.Vault> ListByResourceGroup(string resourceGroupName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.Models.Vault> ListByResourceGroupAsync(string resourceGroupName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.Models.Vault> ListBySubscription(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.Models.Vault> ListBySubscriptionAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.Models.DeletedVault> ListDeleted(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.Models.DeletedVault> ListDeletedAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.VaultsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string vaultName, Azure.ResourceManager.KeyVault.Models.VaultCreateOrUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.KeyVault.VaultsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string vaultName, Azure.ResourceManager.KeyVault.Models.VaultCreateOrUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.VaultsPurgeDeletedOperation StartPurgeDeleted(string vaultName, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.KeyVault.VaultsPurgeDeletedOperation> StartPurgeDeletedAsync(string vaultName, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.Models.Vault> Update(string resourceGroupName, string vaultName, Azure.ResourceManager.KeyVault.Models.VaultPatchParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.Models.VaultAccessPolicyParameters> UpdateAccessPolicy(string resourceGroupName, string vaultName, Azure.ResourceManager.KeyVault.Models.AccessPolicyUpdateKind operationKind, Azure.ResourceManager.KeyVault.Models.VaultAccessPolicyParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Models.VaultAccessPolicyParameters>> UpdateAccessPolicyAsync(string resourceGroupName, string vaultName, Azure.ResourceManager.KeyVault.Models.AccessPolicyUpdateKind operationKind, Azure.ResourceManager.KeyVault.Models.VaultAccessPolicyParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Models.Vault>> UpdateAsync(string resourceGroupName, string vaultName, Azure.ResourceManager.KeyVault.Models.VaultPatchParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VaultsPurgeDeletedOperation : Azure.Operation<Azure.Response>
    {
        internal VaultsPurgeDeletedOperation() { }
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
}
namespace Azure.ResourceManager.KeyVault.Models
{
    public partial class AccessPolicyEntry
    {
        public AccessPolicyEntry(System.Guid tenantId, string objectId, Azure.ResourceManager.KeyVault.Models.Permissions permissions) { }
        public System.Guid? ApplicationId { get { throw null; } set { } }
        public string ObjectId { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.Permissions Permissions { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
    }
    public enum AccessPolicyUpdateKind
    {
        Add = 0,
        Replace = 1,
        Remove = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificatePermissions : System.IEquatable<Azure.ResourceManager.KeyVault.Models.CertificatePermissions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificatePermissions(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Backup { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Create { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Delete { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Deleteissuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Get { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Getissuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Import { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions List { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Listissuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Managecontacts { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Manageissuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Purge { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Recover { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Restore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Setissuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.CertificatePermissions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.CertificatePermissions left, Azure.ResourceManager.KeyVault.Models.CertificatePermissions right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.CertificatePermissions (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.CertificatePermissions left, Azure.ResourceManager.KeyVault.Models.CertificatePermissions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckNameAvailabilityResult
    {
        internal CheckNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.Reason? Reason { get { throw null; } }
    }
    public enum CreateMode
    {
        Recover = 0,
        Default = 1,
    }
    public partial class DeletedVault
    {
        internal DeletedVault() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.DeletedVaultProperties Properties { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class DeletedVaultListResult
    {
        internal DeletedVaultListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.KeyVault.Models.DeletedVault> Value { get { throw null; } }
    }
    public partial class DeletedVaultProperties
    {
        internal DeletedVaultProperties() { }
        public System.DateTimeOffset? DeletionDate { get { throw null; } }
        public string Location { get { throw null; } }
        public System.DateTimeOffset? ScheduledPurgeDate { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public string VaultId { get { throw null; } }
    }
    public partial class IPRule
    {
        public IPRule(string value) { }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyPermissions : System.IEquatable<Azure.ResourceManager.KeyVault.Models.KeyPermissions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyPermissions(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Backup { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Create { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Decrypt { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Delete { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Encrypt { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Get { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Import { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions List { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Purge { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Recover { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Restore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Sign { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions UnwrapKey { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Update { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Verify { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions WrapKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.KeyPermissions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.KeyPermissions left, Azure.ResourceManager.KeyVault.Models.KeyPermissions right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.KeyPermissions (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.KeyPermissions left, Azure.ResourceManager.KeyVault.Models.KeyPermissions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogSpecification
    {
        internal LogSpecification() { }
        public string BlobDuration { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkRuleAction : System.IEquatable<Azure.ResourceManager.KeyVault.Models.NetworkRuleAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkRuleAction(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.NetworkRuleAction Allow { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.NetworkRuleAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.NetworkRuleAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.NetworkRuleAction left, Azure.ResourceManager.KeyVault.Models.NetworkRuleAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.NetworkRuleAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.NetworkRuleAction left, Azure.ResourceManager.KeyVault.Models.NetworkRuleAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkRuleBypassOptions : System.IEquatable<Azure.ResourceManager.KeyVault.Models.NetworkRuleBypassOptions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkRuleBypassOptions(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.NetworkRuleBypassOptions AzureServices { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.NetworkRuleBypassOptions None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.NetworkRuleBypassOptions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.NetworkRuleBypassOptions left, Azure.ResourceManager.KeyVault.Models.NetworkRuleBypassOptions right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.NetworkRuleBypassOptions (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.NetworkRuleBypassOptions left, Azure.ResourceManager.KeyVault.Models.NetworkRuleBypassOptions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkRuleSet
    {
        public NetworkRuleSet() { }
        public Azure.ResourceManager.KeyVault.Models.NetworkRuleBypassOptions? Bypass { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.NetworkRuleAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.IPRule> IpRules { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.VirtualNetworkRule> VirtualNetworkRules { get { throw null; } set { } }
    }
    public partial class Operation
    {
        internal Operation() { }
        public Azure.ResourceManager.KeyVault.Models.OperationDisplay Display { get { throw null; } }
        public string Name { get { throw null; } }
        public string Origin { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.ServiceSpecification ServiceSpecification { get { throw null; } }
    }
    public partial class OperationDisplay
    {
        internal OperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class OperationListResult
    {
        internal OperationListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.KeyVault.Models.Operation> Value { get { throw null; } }
    }
    public partial class Permissions
    {
        public Permissions() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.CertificatePermissions> Certificates { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.KeyPermissions> Keys { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.SecretPermissions> Secrets { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.StoragePermissions> Storage { get { throw null; } set { } }
    }
    public partial class PrivateEndpoint
    {
        public PrivateEndpoint() { }
        public string Id { get { throw null; } }
    }
    public partial class PrivateEndpointConnection : Azure.ResourceManager.KeyVault.Models.Resource
    {
        public PrivateEndpointConnection() { }
        public Azure.ResourceManager.KeyVault.Models.PrivateEndpoint PrivateEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionItem
    {
        public PrivateEndpointConnectionItem() { }
        public Azure.ResourceManager.KeyVault.Models.PrivateEndpoint PrivateEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateLinkResource : Azure.ResourceManager.KeyVault.Models.Resource
    {
        public PrivateLinkResource() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } set { } }
    }
    public partial class PrivateLinkResourceListResult
    {
        internal PrivateLinkResourceListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.KeyVault.Models.PrivateLinkResource> Value { get { throw null; } }
    }
    public partial class PrivateLinkServiceConnectionState
    {
        public PrivateLinkServiceConnectionState() { }
        public string ActionRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public enum Reason
    {
        AccountNameInvalid = 0,
        AlreadyExists = 1,
    }
    public partial class Resource
    {
        public Resource() { }
        public string Id { get { throw null; } }
        public string Location { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class ResourceListResult
    {
        internal ResourceListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.KeyVault.Models.Resource> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecretPermissions : System.IEquatable<Azure.ResourceManager.KeyVault.Models.SecretPermissions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecretPermissions(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermissions Backup { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermissions Delete { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermissions Get { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermissions List { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermissions Purge { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermissions Recover { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermissions Restore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermissions Set { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.SecretPermissions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.SecretPermissions left, Azure.ResourceManager.KeyVault.Models.SecretPermissions right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.SecretPermissions (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.SecretPermissions left, Azure.ResourceManager.KeyVault.Models.SecretPermissions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceSpecification
    {
        internal ServiceSpecification() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.KeyVault.Models.LogSpecification> LogSpecifications { get { throw null; } }
    }
    public partial class Sku
    {
        public Sku(Azure.ResourceManager.KeyVault.Models.SkuName name) { }
        public string Family { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.SkuName Name { get { throw null; } set { } }
    }
    public enum SkuName
    {
        Standard = 0,
        Premium = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StoragePermissions : System.IEquatable<Azure.ResourceManager.KeyVault.Models.StoragePermissions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StoragePermissions(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Backup { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Delete { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Deletesas { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Get { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Getsas { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions List { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Listsas { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Purge { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Recover { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Regeneratekey { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Restore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Set { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Setsas { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.StoragePermissions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.StoragePermissions left, Azure.ResourceManager.KeyVault.Models.StoragePermissions right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.StoragePermissions (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.StoragePermissions left, Azure.ResourceManager.KeyVault.Models.StoragePermissions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Vault
    {
        internal Vault() { }
        public string Id { get { throw null; } }
        public string Location { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.VaultProperties Properties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class VaultAccessPolicyParameters
    {
        public VaultAccessPolicyParameters(Azure.ResourceManager.KeyVault.Models.VaultAccessPolicyProperties properties) { }
        public string Id { get { throw null; } }
        public string Location { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.VaultAccessPolicyProperties Properties { get { throw null; } set { } }
        public string Type { get { throw null; } }
    }
    public partial class VaultAccessPolicyProperties
    {
        public VaultAccessPolicyProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.Models.AccessPolicyEntry> accessPolicies) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.AccessPolicyEntry> AccessPolicies { get { throw null; } }
    }
    public partial class VaultCheckNameAvailabilityParameters
    {
        public VaultCheckNameAvailabilityParameters(string name) { }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class VaultCreateOrUpdateParameters
    {
        public VaultCreateOrUpdateParameters(string location, Azure.ResourceManager.KeyVault.Models.VaultProperties properties) { }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.VaultProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class VaultListResult
    {
        internal VaultListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.KeyVault.Models.Vault> Value { get { throw null; } }
    }
    public partial class VaultPatchParameters
    {
        public VaultPatchParameters() { }
        public Azure.ResourceManager.KeyVault.Models.VaultPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class VaultPatchProperties
    {
        public VaultPatchProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.AccessPolicyEntry> AccessPolicies { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public bool? EnabledForDeployment { get { throw null; } set { } }
        public bool? EnabledForDiskEncryption { get { throw null; } set { } }
        public bool? EnabledForTemplateDeployment { get { throw null; } set { } }
        public bool? EnablePurgeProtection { get { throw null; } set { } }
        public bool? EnableSoftDelete { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.NetworkRuleSet NetworkAcls { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.Sku Sku { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class VaultProperties
    {
        public VaultProperties(System.Guid tenantId, Azure.ResourceManager.KeyVault.Models.Sku sku) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.AccessPolicyEntry> AccessPolicies { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public bool? EnabledForDeployment { get { throw null; } set { } }
        public bool? EnabledForDiskEncryption { get { throw null; } set { } }
        public bool? EnabledForTemplateDeployment { get { throw null; } set { } }
        public bool? EnablePurgeProtection { get { throw null; } set { } }
        public bool? EnableSoftDelete { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.NetworkRuleSet NetworkAcls { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionItem> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.Sku Sku { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
        public string VaultUri { get { throw null; } set { } }
    }
    public partial class VirtualNetworkRule
    {
        public VirtualNetworkRule(string id) { }
        public string Id { get { throw null; } set { } }
    }
}
