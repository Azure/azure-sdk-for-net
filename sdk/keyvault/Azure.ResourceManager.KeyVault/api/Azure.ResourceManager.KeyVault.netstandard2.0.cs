namespace Azure.ResourceManager.KeyVault
{
    public partial class DeletedManagedHsmCollection : Azure.ResourceManager.ArmCollection
    {
        protected DeletedManagedHsmCollection() { }
        public virtual Azure.Response<bool> Exists(string location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource> Get(string location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource>> GetAsync(string location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string location, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PurgeDeleted(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PurgeDeletedAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedVaultCollection : Azure.ResourceManager.ArmCollection
    {
        protected DeletedVaultCollection() { }
        public virtual Azure.Response<bool> Exists(string location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.DeletedVaultResource> Get(string location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedVaultResource>> GetAsync(string location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string location, string vaultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.DeletedVaultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedVaultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PurgeDeleted(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PurgeDeletedAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class KeyVaultExtensions
    {
        public static Azure.Response<Azure.ResourceManager.KeyVault.Models.CheckNameAvailabilityResult> CheckKeyVaultNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.KeyVault.Models.VaultCheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Models.CheckNameAvailabilityResult>> CheckKeyVaultNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.KeyVault.Models.VaultCheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource> GetDeletedManagedHsm(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource>> GetDeletedManagedHsmAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KeyVault.DeletedManagedHsmResource GetDeletedManagedHsmResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.DeletedManagedHsmCollection GetDeletedManagedHsms(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource> GetDeletedManagedHsms(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource> GetDeletedManagedHsmsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.KeyVault.DeletedVaultResource> GetDeletedVault(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedVaultResource>> GetDeletedVaultAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KeyVault.DeletedVaultResource GetDeletedVaultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.DeletedVaultCollection GetDeletedVaults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.KeyVault.DeletedVaultResource> GetDeletedVaults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.KeyVault.DeletedVaultResource> GetDeletedVaultsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource> GetManagedHsm(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource>> GetManagedHsmAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KeyVault.ManagedHsmResource GetManagedHsmResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.ManagedHsmCollection GetManagedHsms(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.KeyVault.ManagedHsmResource> GetManagedHsms(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.KeyVault.ManagedHsmResource> GetManagedHsmsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource GetMhsmPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource GetPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.KeyVault.VaultResource> GetVault(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.VaultResource>> GetVaultAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ManagedHsmData : Azure.ResourceManager.KeyVault.Models.KeyVaultTrackedResourceData
    {
        public ManagedHsmData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource> GetMhsmPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource>> GetMhsmPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionCollection GetMhsmPrivateEndpointConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.Models.MhsmPrivateLinkResource> GetMhsmPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.Models.MhsmPrivateLinkResource> GetMhsmPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.ManagedHsmResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.KeyVault.ManagedHsmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.ManagedHsmResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.KeyVault.ManagedHsmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MhsmPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected MhsmPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MhsmPrivateEndpointConnectionData : Azure.ResourceManager.KeyVault.Models.KeyVaultTrackedResourceData
    {
        public MhsmPrivateEndpointConnectionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Etag { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.MhsmPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    public partial class MhsmPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MhsmPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.KeyVault.PrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.KeyVault.PrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionData : Azure.ResourceManager.KeyVault.Models.KeyVaultResourceData
    {
        public PrivateEndpointConnectionData() { }
        public string Etag { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    public partial class PrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.KeyVault.PrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.KeyVault.PrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.KeyVault.PrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class VaultData : Azure.ResourceManager.Models.ResourceData
    {
        internal VaultData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.VaultProperties Properties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
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
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource> GetPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionResource>> GetPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.Models.PrivateLinkResource> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.Models.PrivateLinkResource> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class AccessPermissions
    {
        public AccessPermissions() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.CertificatePermission> Certificates { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.KeyPermission> Keys { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.SecretPermission> Secrets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.StoragePermission> Storage { get { throw null; } }
    }
    public partial class AccessPolicyEntry
    {
        public AccessPolicyEntry(System.Guid tenantId, string objectId, Azure.ResourceManager.KeyVault.Models.AccessPermissions permissions) { }
        public System.Guid? ApplicationId { get { throw null; } set { } }
        public string ObjectId { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.AccessPermissions Permissions { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
    }
    public enum AccessPolicyUpdateKind
    {
        Add = 0,
        Replace = 1,
        Remove = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionsRequired : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ActionsRequired>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionsRequired(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ActionsRequired None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ActionsRequired other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ActionsRequired left, Azure.ResourceManager.KeyVault.Models.ActionsRequired right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ActionsRequired (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ActionsRequired left, Azure.ResourceManager.KeyVault.Models.ActionsRequired right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificatePermission : System.IEquatable<Azure.ResourceManager.KeyVault.Models.CertificatePermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificatePermission(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermission All { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermission Backup { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermission Create { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermission Delete { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermission Deleteissuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermission Get { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermission Getissuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermission Import { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermission List { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermission Listissuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermission Managecontacts { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermission Manageissuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermission Purge { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermission Recover { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermission Restore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermission Setissuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermission Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.CertificatePermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.CertificatePermission left, Azure.ResourceManager.KeyVault.Models.CertificatePermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.CertificatePermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.CertificatePermission left, Azure.ResourceManager.KeyVault.Models.CertificatePermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckNameAvailabilityResult
    {
        internal CheckNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.NameAvailabilityReason? Reason { get { throw null; } }
    }
    public enum CreateMode
    {
        Default = 0,
        Recover = 1,
    }
    public partial class DeletedManagedHsmProperties
    {
        internal DeletedManagedHsmProperties() { }
        public System.DateTimeOffset? DeletionOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string MhsmId { get { throw null; } }
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
        public string VaultId { get { throw null; } }
    }
    public partial class IPRule
    {
        public IPRule(string addressRange) { }
        public string AddressRange { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyPermission : System.IEquatable<Azure.ResourceManager.KeyVault.Models.KeyPermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyPermission(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermission All { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermission Backup { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermission Create { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermission Decrypt { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermission Delete { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermission Encrypt { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermission Get { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermission Import { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermission List { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermission Purge { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermission Recover { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermission Restore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermission Sign { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermission UnwrapKey { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermission Update { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermission Verify { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermission WrapKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.KeyPermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.KeyPermission left, Azure.ResourceManager.KeyVault.Models.KeyPermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.KeyPermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.KeyPermission left, Azure.ResourceManager.KeyVault.Models.KeyPermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public KeyVaultResourceData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class KeyVaultSku
    {
        public KeyVaultSku(Azure.ResourceManager.KeyVault.Models.KeyVaultSkuFamily family, Azure.ResourceManager.KeyVault.Models.KeyVaultSkuName name) { }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultSkuFamily Family { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultSkuName Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultSkuFamily : System.IEquatable<Azure.ResourceManager.KeyVault.Models.KeyVaultSkuFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultSkuFamily(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultSkuFamily A { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.KeyVaultSkuFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.KeyVaultSkuFamily left, Azure.ResourceManager.KeyVault.Models.KeyVaultSkuFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.KeyVaultSkuFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.KeyVaultSkuFamily left, Azure.ResourceManager.KeyVault.Models.KeyVaultSkuFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum KeyVaultSkuName
    {
        Standard = 0,
        Premium = 1,
    }
    public partial class KeyVaultTrackedResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public KeyVaultTrackedResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmSku Sku { get { throw null; } set { } }
    }
    public partial class ManagedHsmProperties
    {
        public ManagedHsmProperties() { }
        public Azure.ResourceManager.KeyVault.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public bool? EnablePurgeProtection { get { throw null; } set { } }
        public bool? EnableSoftDelete { get { throw null; } set { } }
        public System.Uri HsmUri { get { throw null; } }
        public System.Collections.Generic.IList<string> InitialAdminObjectIds { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.MhsmNetworkRuleSet NetworkAcls { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.KeyVault.Models.MhsmPrivateEndpointConnectionItem> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.DateTimeOffset? ScheduledPurgeOn { get { throw null; } }
        public int? SoftDeleteRetentionInDays { get { throw null; } set { } }
        public string StatusMessage { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } set { } }
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
    public partial class MhsmIPRule
    {
        public MhsmIPRule(string addressRange) { }
        public string AddressRange { get { throw null; } set { } }
    }
    public partial class MhsmNetworkRuleSet
    {
        public MhsmNetworkRuleSet() { }
        public Azure.ResourceManager.KeyVault.Models.NetworkRuleBypassOptions? Bypass { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.NetworkRuleAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.MhsmIPRule> IPRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> VirtualNetworkRules { get { throw null; } }
    }
    public partial class MhsmPrivateEndpointConnectionItem
    {
        internal MhsmPrivateEndpointConnectionItem() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.MhsmPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class MhsmPrivateLinkResource : Azure.ResourceManager.KeyVault.Models.KeyVaultTrackedResourceData
    {
        public MhsmPrivateLinkResource(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class MhsmPrivateLinkServiceConnectionState
    {
        public MhsmPrivateLinkServiceConnectionState() { }
        public Azure.ResourceManager.KeyVault.Models.ActionsRequired? ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.IPRule> IPRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.VirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionItem
    {
        internal PrivateEndpointConnectionItem() { }
        public string Etag { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } }
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
    public partial class PrivateLinkResource : Azure.ResourceManager.KeyVault.Models.KeyVaultResourceData
    {
        public PrivateLinkResource() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class PrivateLinkServiceConnectionState
    {
        public PrivateLinkServiceConnectionState() { }
        public Azure.ResourceManager.KeyVault.Models.ActionsRequired? ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ProvisioningState Activated { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ProvisioningState Restoring { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ProvisioningState SecurityDomainRestore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ProvisioningState left, Azure.ResourceManager.KeyVault.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ProvisioningState left, Azure.ResourceManager.KeyVault.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.KeyVault.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.PublicNetworkAccess left, Azure.ResourceManager.KeyVault.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.PublicNetworkAccess left, Azure.ResourceManager.KeyVault.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecretPermission : System.IEquatable<Azure.ResourceManager.KeyVault.Models.SecretPermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecretPermission(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermission All { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermission Backup { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermission Delete { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermission Get { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermission List { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermission Purge { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermission Recover { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermission Restore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermission Set { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.SecretPermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.SecretPermission left, Azure.ResourceManager.KeyVault.Models.SecretPermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.SecretPermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.SecretPermission left, Azure.ResourceManager.KeyVault.Models.SecretPermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StoragePermission : System.IEquatable<Azure.ResourceManager.KeyVault.Models.StoragePermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StoragePermission(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermission All { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermission Backup { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermission Delete { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermission Deletesas { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermission Get { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermission Getsas { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermission List { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermission Listsas { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermission Purge { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermission Recover { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermission Regeneratekey { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermission Restore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermission Set { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermission Setsas { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermission Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.StoragePermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.StoragePermission left, Azure.ResourceManager.KeyVault.Models.StoragePermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.StoragePermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.StoragePermission left, Azure.ResourceManager.KeyVault.Models.StoragePermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VaultAccessPolicyParameters : Azure.ResourceManager.Models.ResourceData
    {
        public VaultAccessPolicyParameters(Azure.ResourceManager.KeyVault.Models.VaultAccessPolicyProperties properties) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.AccessPolicyEntry> AccessPolicies { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
    }
    public partial class VaultAccessPolicyProperties
    {
        public VaultAccessPolicyProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.Models.AccessPolicyEntry> accessPolicies) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.AccessPolicyEntry> AccessPolicies { get { throw null; } }
    }
    public partial class VaultCheckNameAvailabilityContent
    {
        public VaultCheckNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class VaultCreateOrUpdateContent
    {
        public VaultCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.KeyVault.Models.VaultProperties properties) { }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.VaultProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class VaultPatch
    {
        public VaultPatch() { }
        public Azure.ResourceManager.KeyVault.Models.VaultPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class VaultPatchProperties
    {
        public VaultPatchProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.AccessPolicyEntry> AccessPolicies { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public bool? EnabledForDeployment { get { throw null; } set { } }
        public bool? EnabledForDiskEncryption { get { throw null; } set { } }
        public bool? EnabledForTemplateDeployment { get { throw null; } set { } }
        public bool? EnablePurgeProtection { get { throw null; } set { } }
        public bool? EnableRbacAuthorization { get { throw null; } set { } }
        public bool? EnableSoftDelete { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.NetworkRuleSet NetworkAcls { get { throw null; } set { } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultSku Sku { get { throw null; } set { } }
        public int? SoftDeleteRetentionInDays { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class VaultProperties
    {
        public VaultProperties(System.Guid tenantId, Azure.ResourceManager.KeyVault.Models.KeyVaultSku sku) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.AccessPolicyEntry> AccessPolicies { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public bool? EnabledForDeployment { get { throw null; } set { } }
        public bool? EnabledForDiskEncryption { get { throw null; } set { } }
        public bool? EnabledForTemplateDeployment { get { throw null; } set { } }
        public bool? EnablePurgeProtection { get { throw null; } set { } }
        public bool? EnableRbacAuthorization { get { throw null; } set { } }
        public bool? EnableSoftDelete { get { throw null; } set { } }
        public string HsmPoolResourceId { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.NetworkRuleSet NetworkAcls { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionItem> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.VaultProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultSku Sku { get { throw null; } set { } }
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
    public partial class VirtualNetworkRule
    {
        public VirtualNetworkRule(string id) { }
        public string Id { get { throw null; } set { } }
        public bool? IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
    }
}
