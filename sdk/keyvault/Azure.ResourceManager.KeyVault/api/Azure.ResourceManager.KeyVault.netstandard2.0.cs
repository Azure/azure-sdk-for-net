namespace Azure.ResourceManager.KeyVault
{
    public partial class DeletedKeyVaultCollection : Azure.ResourceManager.ArmCollection
    {
        protected DeletedKeyVaultCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.DeletedKeyVaultResource> Get(Azure.Core.AzureLocation location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedKeyVaultResource>> GetAsync(Azure.Core.AzureLocation location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedKeyVaultData : Azure.ResourceManager.Models.ResourceData
    {
        internal DeletedKeyVaultData() { }
        public Azure.ResourceManager.KeyVault.Models.DeletedKeyVaultProperties Properties { get { throw null; } }
    }
    public partial class DeletedKeyVaultResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeletedKeyVaultResource() { }
        public virtual Azure.ResourceManager.KeyVault.DeletedKeyVaultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string vaultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.DeletedKeyVaultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedKeyVaultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PurgeDeleted(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PurgeDeletedAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
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
    public partial class KeyVaultCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.KeyVaultResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.KeyVaultResource>, System.Collections.IEnumerable
    {
        protected KeyVaultCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.KeyVaultResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.KeyVault.Models.KeyVaultCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.KeyVaultResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.KeyVault.Models.KeyVaultCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource> Get(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.KeyVaultResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.KeyVaultResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource>> GetAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KeyVault.KeyVaultResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.KeyVaultResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KeyVault.KeyVaultResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.KeyVaultResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KeyVaultData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public KeyVaultData(Azure.Core.AzureLocation location, Azure.ResourceManager.KeyVault.Models.KeyVaultProperties properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultProperties Properties { get { throw null; } set { } }
    }
    public static partial class KeyVaultExtensions
    {
        public static Azure.Response<Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityResult> CheckKeyVaultNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityResult>> CheckKeyVaultNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.KeyVault.DeletedKeyVaultResource> GetDeletedKeyVault(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedKeyVaultResource>> GetDeletedKeyVaultAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KeyVault.DeletedKeyVaultResource GetDeletedKeyVaultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.DeletedKeyVaultCollection GetDeletedKeyVaults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.KeyVault.DeletedKeyVaultResource> GetDeletedKeyVaults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.KeyVault.DeletedKeyVaultResource> GetDeletedKeyVaultsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource> GetDeletedManagedHsm(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource>> GetDeletedManagedHsmAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KeyVault.DeletedManagedHsmResource GetDeletedManagedHsmResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.DeletedManagedHsmCollection GetDeletedManagedHsms(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource> GetDeletedManagedHsms(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource> GetDeletedManagedHsmsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource> GetKeyVault(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource>> GetKeyVaultAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource GetKeyVaultPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.KeyVaultResource GetKeyVaultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.KeyVaultCollection GetKeyVaults(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.KeyVault.KeyVaultResource> GetKeyVaults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.KeyVault.KeyVaultResource> GetKeyVaultsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource> GetManagedHsm(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource>> GetManagedHsmAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource GetManagedHsmPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.ManagedHsmResource GetManagedHsmResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.ManagedHsmCollection GetManagedHsms(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.KeyVault.ManagedHsmResource> GetManagedHsms(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.KeyVault.ManagedHsmResource> GetManagedHsmsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KeyVaultPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected KeyVaultPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KeyVaultPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public KeyVaultPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class KeyVaultPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KeyVaultPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KeyVaultResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KeyVaultResource() { }
        public virtual Azure.ResourceManager.KeyVault.KeyVaultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> GetKeyVaultPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>> GetKeyVaultPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionCollection GetKeyVaultPrivateEndpointConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkResourceData> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkResourceData> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource> Update(Azure.ResourceManager.KeyVault.Models.KeyVaultPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyParameters> UpdateAccessPolicy(Azure.ResourceManager.KeyVault.Models.AccessPolicyUpdateKind operationKind, Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyParameters keyVaultAccessPolicyParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyParameters>> UpdateAccessPolicyAsync(Azure.ResourceManager.KeyVault.Models.AccessPolicyUpdateKind operationKind, Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyParameters keyVaultAccessPolicyParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource>> UpdateAsync(Azure.ResourceManager.KeyVault.Models.KeyVaultPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
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
}
namespace Azure.ResourceManager.KeyVault.Models
{
    public enum AccessPolicyUpdateKind
    {
        Add = 0,
        Replace = 1,
        Remove = 2,
    }
    public partial class DeletedKeyVaultProperties
    {
        internal DeletedKeyVaultProperties() { }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.DateTimeOffset? DeletionOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public bool? PurgeProtectionEnabled { get { throw null; } }
        public System.DateTimeOffset? ScheduledPurgeOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public Azure.Core.ResourceIdentifier VaultId { get { throw null; } }
    }
    public partial class DeletedManagedHsmProperties
    {
        internal DeletedManagedHsmProperties() { }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.DateTimeOffset? DeletionOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.Core.ResourceIdentifier ManagedHsmId { get { throw null; } }
        public bool? PurgeProtectionEnabled { get { throw null; } }
        public System.DateTimeOffset? ScheduledPurgeOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
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
    public partial class KeyVaultAccessPolicy
    {
        public KeyVaultAccessPolicy(System.Guid tenantId, string objectId, Azure.ResourceManager.KeyVault.Models.IdentityAccessPermissions permissions) { }
        public System.Guid? ApplicationId { get { throw null; } set { } }
        public string ObjectId { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.IdentityAccessPermissions Permissions { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
    }
    public partial class KeyVaultAccessPolicyParameters : Azure.ResourceManager.Models.ResourceData
    {
        public KeyVaultAccessPolicyParameters(Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyProperties properties) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicy> AccessPolicies { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
    }
    public partial class KeyVaultAccessPolicyProperties
    {
        public KeyVaultAccessPolicyProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicy> accessPolicies) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicy> AccessPolicies { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultActionsRequiredMessage : System.IEquatable<Azure.ResourceManager.KeyVault.Models.KeyVaultActionsRequiredMessage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultActionsRequiredMessage(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultActionsRequiredMessage None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.KeyVaultActionsRequiredMessage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.KeyVaultActionsRequiredMessage left, Azure.ResourceManager.KeyVault.Models.KeyVaultActionsRequiredMessage right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.KeyVaultActionsRequiredMessage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.KeyVaultActionsRequiredMessage left, Azure.ResourceManager.KeyVault.Models.KeyVaultActionsRequiredMessage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum KeyVaultCreateMode
    {
        Default = 0,
        Recover = 1,
    }
    public partial class KeyVaultCreateOrUpdateContent
    {
        public KeyVaultCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.KeyVault.Models.KeyVaultProperties properties) { }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class KeyVaultIPRule
    {
        public KeyVaultIPRule(string addressRange) { }
        public string AddressRange { get { throw null; } set { } }
    }
    public partial class KeyVaultNameAvailabilityContent
    {
        public KeyVaultNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
    }
    public partial class KeyVaultNameAvailabilityResult
    {
        internal KeyVaultNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultNameUnavailableReason? Reason { get { throw null; } }
    }
    public enum KeyVaultNameUnavailableReason
    {
        AccountNameInvalid = 0,
        AlreadyExists = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultNetworkRuleAction : System.IEquatable<Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultNetworkRuleAction(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleAction Allow { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleAction left, Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleAction left, Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultNetworkRuleBypassOption : System.IEquatable<Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleBypassOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultNetworkRuleBypassOption(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleBypassOption AzureServices { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleBypassOption None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleBypassOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleBypassOption left, Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleBypassOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleBypassOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleBypassOption left, Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleBypassOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultNetworkRuleSet
    {
        public KeyVaultNetworkRuleSet() { }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleBypassOption? Bypass { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.KeyVaultIPRule> IPRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.KeyVaultVirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
    }
    public partial class KeyVaultPatch
    {
        public KeyVaultPatch() { }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public enum KeyVaultPatchMode
    {
        Default = 0,
        Recover = 1,
    }
    public partial class KeyVaultPatchProperties
    {
        public KeyVaultPatchProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicy> AccessPolicies { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultPatchMode? CreateMode { get { throw null; } set { } }
        public bool? EnabledForDeployment { get { throw null; } set { } }
        public bool? EnabledForDiskEncryption { get { throw null; } set { } }
        public bool? EnabledForTemplateDeployment { get { throw null; } set { } }
        public bool? EnablePurgeProtection { get { throw null; } set { } }
        public bool? EnableRbacAuthorization { get { throw null; } set { } }
        public bool? EnableSoftDelete { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultSku Sku { get { throw null; } set { } }
        public int? SoftDeleteRetentionInDays { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class KeyVaultPrivateEndpointConnectionItemData
    {
        internal KeyVaultPrivateEndpointConnectionItemData() { }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkServiceConnectionState ConnectionState { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
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
    public partial class KeyVaultPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public KeyVaultPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class KeyVaultPrivateLinkServiceConnectionState
    {
        public KeyVaultPrivateLinkServiceConnectionState() { }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultActionsRequiredMessage? ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class KeyVaultProperties
    {
        public KeyVaultProperties(System.Guid tenantId, Azure.ResourceManager.KeyVault.Models.KeyVaultSku sku) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicy> AccessPolicies { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultCreateMode? CreateMode { get { throw null; } set { } }
        public bool? EnabledForDeployment { get { throw null; } set { } }
        public bool? EnabledForDiskEncryption { get { throw null; } set { } }
        public bool? EnabledForTemplateDeployment { get { throw null; } set { } }
        public bool? EnablePurgeProtection { get { throw null; } set { } }
        public bool? EnableRbacAuthorization { get { throw null; } set { } }
        public bool? EnableSoftDelete { get { throw null; } set { } }
        public string HsmPoolResourceId { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionItemData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultSku Sku { get { throw null; } set { } }
        public int? SoftDeleteRetentionInDays { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
        public System.Uri VaultUri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultProvisioningState : System.IEquatable<Azure.ResourceManager.KeyVault.Models.KeyVaultProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultProvisioningState RegisteringDns { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.KeyVaultProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.KeyVaultProvisioningState left, Azure.ResourceManager.KeyVault.Models.KeyVaultProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.KeyVaultProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.KeyVaultProvisioningState left, Azure.ResourceManager.KeyVault.Models.KeyVaultProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class KeyVaultVirtualNetworkRule
    {
        public KeyVaultVirtualNetworkRule(string id) { }
        public string Id { get { throw null; } set { } }
        public bool? IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
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
    public readonly partial struct ManagedHsmNetworkRuleAction : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedHsmNetworkRuleAction(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleAction Allow { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleAction left, Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleAction left, Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleAction right) { throw null; }
        public override string ToString() { throw null; }
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
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.ManagedHsmIPRule> IPRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.ManagedHsmVirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
    }
    public partial class ManagedHsmPrivateEndpointConnectionItemData
    {
        internal ManagedHsmPrivateEndpointConnectionItemData() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedHsmPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedHsmPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedHsmPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedHsmPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
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
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
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
}
