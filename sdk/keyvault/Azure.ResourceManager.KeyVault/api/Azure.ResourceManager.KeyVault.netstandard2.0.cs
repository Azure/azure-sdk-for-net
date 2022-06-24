namespace Azure.ResourceManager.KeyVault
{
    public partial class DeletedManagedHsmCollection : Azure.ResourceManager.ArmCollection
    {
        protected DeletedManagedHsmCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource> Get(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource>> GetAsync(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedManagedHsmData : Azure.ResourceManager.Models.ResourceData
    {
        internal DeletedManagedHsmData() { }
        public Azure.ResourceManager.KeyVault.Models.DeletedManagedHsmProperties Properties { get { throw null; } }
    }
    public partial class DeletedManagedHsmResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeletedManagedHsmResource() { }
        public virtual Azure.ResourceManager.KeyVault.DeletedManagedHsmData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PurgeDeleted(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PurgeDeletedAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedVaultCollection : Azure.ResourceManager.ArmCollection
    {
        protected DeletedVaultCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.DeletedVaultResource> Get(Azure.Core.AzureLocation location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedVaultResource>> GetAsync(Azure.Core.AzureLocation location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedVaultData : Azure.ResourceManager.Models.ResourceData
    {
        internal DeletedVaultData() { }
        public Azure.ResourceManager.KeyVault.Models.DeletedVaultProperties Properties { get { throw null; } }
    }
    public partial class DeletedVaultResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeletedVaultResource() { }
        public virtual Azure.ResourceManager.KeyVault.DeletedVaultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string vaultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.DeletedVaultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedVaultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PurgeDeleted(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PurgeDeletedAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class KeyVaultExtensions
    {
        public static Azure.Response<Azure.ResourceManager.KeyVault.Models.VaultNameAvailabilityResult> CheckVaultNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.KeyVault.Models.VaultNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Models.VaultNameAvailabilityResult>> CheckVaultNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.KeyVault.Models.VaultNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource> GetDeletedManagedHsm(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource>> GetDeletedManagedHsmAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KeyVault.DeletedManagedHsmResource GetDeletedManagedHsmResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.DeletedManagedHsmCollection GetDeletedManagedHsms(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource> GetDeletedManagedHsms(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource> GetDeletedManagedHsmsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.KeyVault.DeletedVaultResource> GetDeletedVault(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedVaultResource>> GetDeletedVaultAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KeyVault.DeletedVaultResource GetDeletedVaultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.DeletedVaultCollection GetDeletedVaults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.KeyVault.DeletedVaultResource> GetDeletedVaults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.KeyVault.DeletedVaultResource> GetDeletedVaultsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource> GetManagedHsm(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource>> GetManagedHsmAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource GetManagedHsmPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.ManagedHsmResource GetManagedHsmResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.ManagedHsmCollection GetManagedHsms(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.KeyVault.ManagedHsmResource> GetManagedHsms(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.KeyVault.ManagedHsmResource> GetManagedHsmsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.KeyVault.VaultResource> GetVault(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.VaultResource>> GetVaultAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource GetVaultPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.VaultResource GetVaultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.VaultCollection GetVaults(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.KeyVault.VaultResource> GetVaults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.KeyVault.VaultResource> GetVaultsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedHsmCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.ManagedHsmResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.ManagedHsmResource>, System.Collections.IEnumerable
    {
        protected ManagedHsmCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.ManagedHsmResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.KeyVault.ManagedHsmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.ManagedHsmResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.KeyVault.ManagedHsmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.ManagedHsmResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.ManagedHsmResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KeyVault.ManagedHsmResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.ManagedHsmResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KeyVault.ManagedHsmResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.ManagedHsmResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedHsmData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ManagedHsmData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmSku Sku { get { throw null; } set { } }
    }
    public partial class ManagedHsmPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected ManagedHsmPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedHsmPrivateEndpointConnectionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ManagedHsmPrivateEndpointConnectionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? Etag { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmSku Sku { get { throw null; } set { } }
    }
    public partial class ManagedHsmPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedHsmPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedHsmResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedHsmResource() { }
        public virtual Azure.ResourceManager.KeyVault.ManagedHsmData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> GetManagedHsmPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>> GetManagedHsmPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionCollection GetManagedHsmPrivateEndpointConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkResourceData> GetMHSMPrivateLinkResourcesByManagedHsmResource(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkResourceData> GetMHSMPrivateLinkResourcesByManagedHsmResourceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.ManagedHsmResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.KeyVault.ManagedHsmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.ManagedHsmResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.KeyVault.ManagedHsmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VaultCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.VaultResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.VaultResource>, System.Collections.IEnumerable
    {
        protected VaultCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.VaultResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.KeyVault.Models.VaultCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.VaultResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.KeyVault.Models.VaultCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.VaultResource> Get(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.VaultResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.VaultResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.VaultResource>> GetAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KeyVault.VaultResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.VaultResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KeyVault.VaultResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.VaultResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VaultData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VaultData(Azure.Core.AzureLocation location, Azure.ResourceManager.KeyVault.Models.VaultProperties properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.KeyVault.Models.VaultProperties Properties { get { throw null; } set { } }
    }
    public partial class VaultPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected VaultPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VaultPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public VaultPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.KeyVault.Models.VaultPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.ETag? Etag { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class VaultPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VaultPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VaultResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VaultResource() { }
        public virtual Azure.ResourceManager.KeyVault.VaultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.VaultResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.VaultResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.VaultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.VaultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.Models.VaultPrivateLinkResourceData> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.Models.VaultPrivateLinkResourceData> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource> GetVaultPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionResource>> GetVaultPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.VaultPrivateEndpointConnectionCollection GetVaultPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.VaultResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.VaultResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.VaultResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.VaultResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.VaultResource> Update(Azure.ResourceManager.KeyVault.Models.VaultPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.Models.VaultAccessPolicyParameters> UpdateAccessPolicy(Azure.ResourceManager.KeyVault.Models.AccessPolicyUpdateKind operationKind, Azure.ResourceManager.KeyVault.Models.VaultAccessPolicyParameters vaultAccessPolicyParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Models.VaultAccessPolicyParameters>> UpdateAccessPolicyAsync(Azure.ResourceManager.KeyVault.Models.AccessPolicyUpdateKind operationKind, Azure.ResourceManager.KeyVault.Models.VaultAccessPolicyParameters vaultAccessPolicyParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.VaultResource>> UpdateAsync(Azure.ResourceManager.KeyVault.Models.VaultPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.KeyVault.Models
{
    public enum AccessPolicyUpdateKind
    {
        Add = 0,
        Replace = 1,
        Remove = 2,
    }
    public partial class DeletedManagedHsmProperties
    {
        internal DeletedManagedHsmProperties() { }
        public System.DateTimeOffset? DeletionOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.Core.ResourceIdentifier ManagedHsmId { get { throw null; } }
        public bool? PurgeProtectionEnabled { get { throw null; } }
        public System.DateTimeOffset? ScheduledPurgeOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DeletedVaultProperties
    {
        internal DeletedVaultProperties() { }
        public System.DateTimeOffset? DeletionOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public bool? PurgeProtectionEnabled { get { throw null; } }
        public System.DateTimeOffset? ScheduledPurgeOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public Azure.Core.ResourceIdentifier VaultId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityAccessCertificatePermission : System.IEquatable<Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityAccessCertificatePermission(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission All { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission Backup { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission Create { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission Delete { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission DeleteIssuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission Get { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission GetIssuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission Import { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission List { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission ListIssuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission ManageContacts { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission ManageIssuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission Purge { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission Recover { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission Restore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission SetIssuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission left, Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission left, Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityAccessKeyPermission : System.IEquatable<Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityAccessKeyPermission(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission All { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Backup { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Create { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Decrypt { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Delete { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Encrypt { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Get { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Import { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission List { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Purge { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Recover { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Restore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Sign { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission UnwrapKey { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Update { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Verify { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission WrapKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission left, Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission left, Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IdentityAccessPermissions
    {
        public IdentityAccessPermissions() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission> Certificates { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission> Keys { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission> Secrets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission> Storage { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityAccessSecretPermission : System.IEquatable<Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityAccessSecretPermission(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission All { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission Backup { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission Delete { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission Get { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission List { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission Purge { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission Recover { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission Restore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission Set { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission left, Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission left, Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityAccessStoragePermission : System.IEquatable<Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityAccessStoragePermission(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission All { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission Backup { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission Delete { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission DeleteSas { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission Get { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission GetSas { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission List { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission ListSas { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission Purge { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission Recover { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission RegenerateKey { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission Restore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission Set { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission SetSas { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission left, Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission left, Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedHsmActionsRequiredMessage : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ManagedHsmActionsRequiredMessage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedHsmActionsRequiredMessage(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmActionsRequiredMessage None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ManagedHsmActionsRequiredMessage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ManagedHsmActionsRequiredMessage left, Azure.ResourceManager.KeyVault.Models.ManagedHsmActionsRequiredMessage right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ManagedHsmActionsRequiredMessage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ManagedHsmActionsRequiredMessage left, Azure.ResourceManager.KeyVault.Models.ManagedHsmActionsRequiredMessage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ManagedHsmCreateMode
    {
        Default = 0,
        Recover = 1,
    }
    public partial class ManagedHsmIPRule
    {
        public ManagedHsmIPRule(string addressRange) { }
        public string AddressRange { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedHsmNetworkRuleBypassOption : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleBypassOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedHsmNetworkRuleBypassOption(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleBypassOption AzureServices { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleBypassOption None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleBypassOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleBypassOption left, Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleBypassOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleBypassOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleBypassOption left, Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleBypassOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedHsmNetworkRuleSet
    {
        public ManagedHsmNetworkRuleSet() { }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleBypassOption? Bypass { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.NetworkRuleAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.ManagedHsmIPRule> IPRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.ManagedHsmVirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
    }
    public partial class ManagedHsmPrivateEndpointConnectionItemData
    {
        internal ManagedHsmPrivateEndpointConnectionItemData() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ManagedHsmPrivateLinkResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ManagedHsmPrivateLinkResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmSku Sku { get { throw null; } set { } }
    }
    public partial class ManagedHsmPrivateLinkServiceConnectionState
    {
        public ManagedHsmPrivateLinkServiceConnectionState() { }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmActionsRequiredMessage? ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class ManagedHsmProperties
    {
        public ManagedHsmProperties() { }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmCreateMode? CreateMode { get { throw null; } set { } }
        public bool? EnablePurgeProtection { get { throw null; } set { } }
        public bool? EnableSoftDelete { get { throw null; } set { } }
        public System.Uri HsmUri { get { throw null; } }
        public System.Collections.Generic.IList<string> InitialAdminObjectIds { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionItemData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.DateTimeOffset? ScheduledPurgeOn { get { throw null; } }
        public int? SoftDeleteRetentionInDays { get { throw null; } set { } }
        public string StatusMessage { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedHsmProvisioningState : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedHsmProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState Activated { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState Restoring { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState SecurityDomainRestore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState left, Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState left, Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedHsmPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ManagedHsmPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedHsmPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ManagedHsmPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ManagedHsmPublicNetworkAccess left, Azure.ResourceManager.KeyVault.Models.ManagedHsmPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ManagedHsmPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ManagedHsmPublicNetworkAccess left, Azure.ResourceManager.KeyVault.Models.ManagedHsmPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedHsmSku
    {
        public ManagedHsmSku(Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily family, Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuName name) { }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily Family { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuName Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedHsmSkuFamily : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedHsmSkuFamily(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily B { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily left, Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily left, Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ManagedHsmSkuName
    {
        StandardB1 = 0,
        CustomB32 = 1,
    }
    public partial class ManagedHsmVirtualNetworkRule
    {
        public ManagedHsmVirtualNetworkRule(Azure.Core.ResourceIdentifier subnetId) { }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
    }
    public enum NameAvailabilityReason
    {
        AccountNameInvalid = 0,
        AlreadyExists = 1,
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
    public partial class VaultAccessPolicy
    {
        public VaultAccessPolicy(System.Guid tenantId, string objectId, Azure.ResourceManager.KeyVault.Models.IdentityAccessPermissions permissions) { }
        public System.Guid? ApplicationId { get { throw null; } set { } }
        public string ObjectId { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.IdentityAccessPermissions Permissions { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
    }
    public partial class VaultAccessPolicyParameters : Azure.ResourceManager.Models.ResourceData
    {
        public VaultAccessPolicyParameters(Azure.ResourceManager.KeyVault.Models.VaultAccessPolicyProperties properties) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.VaultAccessPolicy> AccessPolicies { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
    }
    public partial class VaultAccessPolicyProperties
    {
        public VaultAccessPolicyProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.Models.VaultAccessPolicy> accessPolicies) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.VaultAccessPolicy> AccessPolicies { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultActionsRequiredMessage : System.IEquatable<Azure.ResourceManager.KeyVault.Models.VaultActionsRequiredMessage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultActionsRequiredMessage(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.VaultActionsRequiredMessage None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.VaultActionsRequiredMessage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.VaultActionsRequiredMessage left, Azure.ResourceManager.KeyVault.Models.VaultActionsRequiredMessage right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.VaultActionsRequiredMessage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.VaultActionsRequiredMessage left, Azure.ResourceManager.KeyVault.Models.VaultActionsRequiredMessage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum VaultCreateMode
    {
        Default = 0,
        Recover = 1,
    }
    public partial class VaultCreateOrUpdateContent
    {
        public VaultCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.KeyVault.Models.VaultProperties properties) { }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.VaultProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class VaultIPRule
    {
        public VaultIPRule(string addressRange) { }
        public string AddressRange { get { throw null; } set { } }
    }
    public partial class VaultNameAvailabilityContent
    {
        public VaultNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
    }
    public partial class VaultNameAvailabilityResult
    {
        internal VaultNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.NameAvailabilityReason? Reason { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultNetworkRuleBypassOption : System.IEquatable<Azure.ResourceManager.KeyVault.Models.VaultNetworkRuleBypassOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultNetworkRuleBypassOption(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.VaultNetworkRuleBypassOption AzureServices { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.VaultNetworkRuleBypassOption None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.VaultNetworkRuleBypassOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.VaultNetworkRuleBypassOption left, Azure.ResourceManager.KeyVault.Models.VaultNetworkRuleBypassOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.VaultNetworkRuleBypassOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.VaultNetworkRuleBypassOption left, Azure.ResourceManager.KeyVault.Models.VaultNetworkRuleBypassOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VaultNetworkRuleSet
    {
        public VaultNetworkRuleSet() { }
        public Azure.ResourceManager.KeyVault.Models.VaultNetworkRuleBypassOption? Bypass { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.NetworkRuleAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.VaultIPRule> IPRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.VaultVirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
    }
    public partial class VaultPatch
    {
        public VaultPatch() { }
        public Azure.ResourceManager.KeyVault.Models.VaultPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public enum VaultPatchMode
    {
        Default = 0,
        Recover = 1,
    }
    public partial class VaultPatchProperties
    {
        public VaultPatchProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.VaultAccessPolicy> AccessPolicies { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.VaultPatchMode? CreateMode { get { throw null; } set { } }
        public bool? EnabledForDeployment { get { throw null; } set { } }
        public bool? EnabledForDiskEncryption { get { throw null; } set { } }
        public bool? EnabledForTemplateDeployment { get { throw null; } set { } }
        public bool? EnablePurgeProtection { get { throw null; } set { } }
        public bool? EnableRbacAuthorization { get { throw null; } set { } }
        public bool? EnableSoftDelete { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.VaultNetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.VaultSku Sku { get { throw null; } set { } }
        public int? SoftDeleteRetentionInDays { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class VaultPrivateEndpointConnectionItemData
    {
        internal VaultPrivateEndpointConnectionItemData() { }
        public Azure.ResourceManager.KeyVault.Models.VaultPrivateLinkServiceConnectionState ConnectionState { get { throw null; } }
        public Azure.ETag? Etag { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointConnectionProvisioningState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointConnectionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VaultPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public VaultPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class VaultPrivateLinkServiceConnectionState
    {
        public VaultPrivateLinkServiceConnectionState() { }
        public Azure.ResourceManager.KeyVault.Models.VaultActionsRequiredMessage? ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class VaultProperties
    {
        public VaultProperties(System.Guid tenantId, Azure.ResourceManager.KeyVault.Models.VaultSku sku) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.VaultAccessPolicy> AccessPolicies { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.VaultCreateMode? CreateMode { get { throw null; } set { } }
        public bool? EnabledForDeployment { get { throw null; } set { } }
        public bool? EnabledForDiskEncryption { get { throw null; } set { } }
        public bool? EnabledForTemplateDeployment { get { throw null; } set { } }
        public bool? EnablePurgeProtection { get { throw null; } set { } }
        public bool? EnableRbacAuthorization { get { throw null; } set { } }
        public bool? EnableSoftDelete { get { throw null; } set { } }
        public string HsmPoolResourceId { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.VaultNetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.KeyVault.Models.VaultPrivateEndpointConnectionItemData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.VaultProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.VaultSku Sku { get { throw null; } set { } }
        public int? SoftDeleteRetentionInDays { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
        public System.Uri VaultUri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultProvisioningState : System.IEquatable<Azure.ResourceManager.KeyVault.Models.VaultProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.VaultProvisioningState RegisteringDns { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.VaultProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.VaultProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.VaultProvisioningState left, Azure.ResourceManager.KeyVault.Models.VaultProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.VaultProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.VaultProvisioningState left, Azure.ResourceManager.KeyVault.Models.VaultProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VaultSku
    {
        public VaultSku(Azure.ResourceManager.KeyVault.Models.VaultSkuFamily family, Azure.ResourceManager.KeyVault.Models.VaultSkuName name) { }
        public Azure.ResourceManager.KeyVault.Models.VaultSkuFamily Family { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.VaultSkuName Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultSkuFamily : System.IEquatable<Azure.ResourceManager.KeyVault.Models.VaultSkuFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultSkuFamily(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.VaultSkuFamily A { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.VaultSkuFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.VaultSkuFamily left, Azure.ResourceManager.KeyVault.Models.VaultSkuFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.VaultSkuFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.VaultSkuFamily left, Azure.ResourceManager.KeyVault.Models.VaultSkuFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum VaultSkuName
    {
        Standard = 0,
        Premium = 1,
    }
    public partial class VaultVirtualNetworkRule
    {
        public VaultVirtualNetworkRule(string id) { }
        public string Id { get { throw null; } set { } }
        public bool? IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
    }
}
