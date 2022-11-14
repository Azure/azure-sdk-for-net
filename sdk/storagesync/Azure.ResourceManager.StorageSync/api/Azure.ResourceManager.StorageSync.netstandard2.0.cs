namespace Azure.ResourceManager.StorageSync
{
    public partial class CloudEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageSync.CloudEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.CloudEndpointResource>, System.Collections.IEnumerable
    {
        protected CloudEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.CloudEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cloudEndpointName, Azure.ResourceManager.StorageSync.Models.CloudEndpointCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.CloudEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cloudEndpointName, Azure.ResourceManager.StorageSync.Models.CloudEndpointCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cloudEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cloudEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.CloudEndpointResource> Get(string cloudEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageSync.CloudEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageSync.CloudEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.CloudEndpointResource>> GetAsync(string cloudEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageSync.CloudEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageSync.CloudEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageSync.CloudEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.CloudEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CloudEndpointData : Azure.ResourceManager.Models.ResourceData
    {
        public CloudEndpointData() { }
        public string AzureFileShareName { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationStatus ChangeEnumerationStatus { get { throw null; } }
        public string FriendlyName { get { throw null; } set { } }
        public string IsBackupEnabled { get { throw null; } }
        public string LastOperationName { get { throw null; } set { } }
        public string LastWorkflowId { get { throw null; } set { } }
        public string PartnershipId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountResourceId { get { throw null; } set { } }
        public System.Guid? StorageAccountTenantId { get { throw null; } set { } }
    }
    public partial class CloudEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudEndpointResource() { }
        public virtual Azure.ResourceManager.StorageSync.CloudEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.Models.CloudEndpointAfsShareMetadataCertificatePublicKeys> AfsShareMetadataCertificatePublicKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.Models.CloudEndpointAfsShareMetadataCertificatePublicKeys>> AfsShareMetadataCertificatePublicKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageSyncServiceName, string syncGroupName, string cloudEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.CloudEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.CloudEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.Models.CloudEndpointPostBackupResult> PostBackup(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.CloudEndpointBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.Models.CloudEndpointPostBackupResult>> PostBackupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.CloudEndpointBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PostRestore(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.PostRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PostRestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.PostRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PreBackup(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.CloudEndpointBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PreBackupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.CloudEndpointBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PreRestore(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.PreRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PreRestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.PreRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RestoreHeartbeat(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RestoreHeartbeatAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TriggerChangeDetection(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.TriggerChangeDetectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerChangeDetectionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.TriggerChangeDetectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.CloudEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.CloudEndpointCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.CloudEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.CloudEndpointCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class StorageSyncExtensions
    {
        public static Azure.Response<Azure.ResourceManager.StorageSync.Models.StorageSyncNameAvailabilityResult> CheckStorageSyncNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, Azure.ResourceManager.StorageSync.Models.StorageSyncNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.Models.StorageSyncNameAvailabilityResult>> CheckStorageSyncNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, Azure.ResourceManager.StorageSync.Models.StorageSyncNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StorageSync.CloudEndpointResource GetCloudEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StorageSync.StorageSyncGroupResource GetStorageSyncGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource GetStorageSyncPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerResource GetStorageSyncRegisteredServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StorageSync.StorageSyncServerEndpointResource GetStorageSyncServerEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> GetStorageSyncService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageSyncServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServiceResource>> GetStorageSyncServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageSyncServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StorageSync.StorageSyncServiceResource GetStorageSyncServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StorageSync.StorageSyncServiceCollection GetStorageSyncServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> GetStorageSyncServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> GetStorageSyncServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StorageSync.StorageSyncWorkflowResource GetStorageSyncWorkflowResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class StorageSyncGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageSync.StorageSyncGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.StorageSyncGroupResource>, System.Collections.IEnumerable
    {
        protected StorageSyncGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.StorageSyncGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string syncGroupName, Azure.ResourceManager.StorageSync.Models.StorageSyncGroupCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.StorageSyncGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string syncGroupName, Azure.ResourceManager.StorageSync.Models.StorageSyncGroupCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncGroupResource> Get(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageSync.StorageSyncGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageSync.StorageSyncGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncGroupResource>> GetAsync(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageSync.StorageSyncGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageSync.StorageSyncGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageSync.StorageSyncGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.StorageSyncGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageSyncGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public StorageSyncGroupData() { }
        public string SyncGroupStatus { get { throw null; } }
        public System.Guid? UniqueId { get { throw null; } }
    }
    public partial class StorageSyncGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageSyncGroupResource() { }
        public virtual Azure.ResourceManager.StorageSync.StorageSyncGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageSyncServiceName, string syncGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.CloudEndpointResource> GetCloudEndpoint(string cloudEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.CloudEndpointResource>> GetCloudEndpointAsync(string cloudEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageSync.CloudEndpointCollection GetCloudEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServerEndpointResource> GetStorageSyncServerEndpoint(string serverEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServerEndpointResource>> GetStorageSyncServerEndpointAsync(string serverEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageSync.StorageSyncServerEndpointCollection GetStorageSyncServerEndpoints() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.StorageSyncGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.StorageSyncGroupCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.StorageSyncGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.StorageSyncGroupCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageSyncPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected StorageSyncPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageSyncPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public StorageSyncPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class StorageSyncPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageSyncPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageSyncServiceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageSyncRegisteredServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerResource>, System.Collections.IEnumerable
    {
        protected StorageSyncRegisteredServerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, System.Guid serverId, Azure.ResourceManager.StorageSync.Models.StorageSyncRegisteredServerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, System.Guid serverId, Azure.ResourceManager.StorageSync.Models.StorageSyncRegisteredServerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(System.Guid serverId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Guid serverId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerResource> Get(System.Guid serverId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerResource>> GetAsync(System.Guid serverId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageSyncRegisteredServerData : Azure.ResourceManager.Models.ResourceData
    {
        public StorageSyncRegisteredServerData() { }
        public string AgentVersion { get { throw null; } set { } }
        public System.DateTimeOffset? AgentVersionExpireOn { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.RegisteredServerAgentVersionStatus? AgentVersionStatus { get { throw null; } }
        public System.Guid? ClusterId { get { throw null; } set { } }
        public string ClusterName { get { throw null; } set { } }
        public System.Uri DiscoveryEndpointUri { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string LastHeartbeat { get { throw null; } set { } }
        public string LastOperationName { get { throw null; } set { } }
        public string LastWorkflowId { get { throw null; } set { } }
        public System.Uri ManagementEndpointUri { get { throw null; } set { } }
        public string MonitoringConfiguration { get { throw null; } set { } }
        public System.Uri MonitoringEndpointUri { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
        public Azure.Core.AzureLocation? ResourceLocation { get { throw null; } set { } }
        public System.BinaryData ServerCertificate { get { throw null; } set { } }
        public System.Guid? ServerId { get { throw null; } set { } }
        public int? ServerManagementErrorCode { get { throw null; } set { } }
        public string ServerName { get { throw null; } }
        public string ServerOSVersion { get { throw null; } set { } }
        public string ServerRole { get { throw null; } set { } }
        public Azure.Core.AzureLocation? ServiceLocation { get { throw null; } set { } }
        public System.Guid? StorageSyncServiceUid { get { throw null; } set { } }
    }
    public partial class StorageSyncRegisteredServerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageSyncRegisteredServerResource() { }
        public virtual Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageSyncServiceName, System.Guid serverId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TriggerRollover(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.TriggerRolloverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerRolloverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.TriggerRolloverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.StorageSyncRegisteredServerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.StorageSyncRegisteredServerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageSyncServerEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageSync.StorageSyncServerEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.StorageSyncServerEndpointResource>, System.Collections.IEnumerable
    {
        protected StorageSyncServerEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.StorageSyncServerEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverEndpointName, Azure.ResourceManager.StorageSync.Models.StorageSyncServerEndpointCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.StorageSyncServerEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverEndpointName, Azure.ResourceManager.StorageSync.Models.StorageSyncServerEndpointCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServerEndpointResource> Get(string serverEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageSync.StorageSyncServerEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageSync.StorageSyncServerEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServerEndpointResource>> GetAsync(string serverEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageSync.StorageSyncServerEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageSync.StorageSyncServerEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageSync.StorageSyncServerEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.StorageSyncServerEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageSyncServerEndpointData : Azure.ResourceManager.Models.ResourceData
    {
        public StorageSyncServerEndpointData() { }
        public Azure.ResourceManager.StorageSync.Models.StorageSyncFeatureStatus? CloudTiering { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointCloudTieringStatus CloudTieringStatus { get { throw null; } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.InitialDownloadPolicy? InitialDownloadPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.InitialUploadPolicy? InitialUploadPolicy { get { throw null; } set { } }
        public string LastOperationName { get { throw null; } }
        public string LastWorkflowId { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.LocalCacheMode? LocalCacheMode { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.StorageSyncFeatureStatus? OfflineDataTransfer { get { throw null; } set { } }
        public string OfflineDataTransferShareName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier OfflineDataTransferStorageAccountResourceId { get { throw null; } }
        public System.Guid? OfflineDataTransferStorageAccountTenantId { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointRecallStatus RecallStatus { get { throw null; } }
        public string ServerLocalPath { get { throw null; } set { } }
        public string ServerName { get { throw null; } }
        public Azure.Core.ResourceIdentifier ServerResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncStatus SyncStatus { get { throw null; } }
        public int? TierFilesOlderThanDays { get { throw null; } set { } }
        public int? VolumeFreeSpacePercent { get { throw null; } set { } }
    }
    public partial class StorageSyncServerEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageSyncServerEndpointResource() { }
        public virtual Azure.ResourceManager.StorageSync.StorageSyncServerEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageSyncServiceName, string syncGroupName, string serverEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServerEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServerEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RecallAction(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.RecallActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RecallActionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.RecallActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.StorageSyncServerEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.StorageSyncServerEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.StorageSyncServerEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.StorageSyncServerEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageSyncServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageSync.StorageSyncServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.StorageSyncServiceResource>, System.Collections.IEnumerable
    {
        protected StorageSyncServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageSyncServiceName, Azure.ResourceManager.StorageSync.Models.StorageSyncServiceCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.StorageSyncServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageSyncServiceName, Azure.ResourceManager.StorageSync.Models.StorageSyncServiceCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageSyncServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageSyncServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> Get(string storageSyncServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServiceResource>> GetAsync(string storageSyncServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageSync.StorageSyncServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.StorageSyncServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageSyncServiceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public StorageSyncServiceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.StorageSync.Models.IncomingTrafficPolicy? IncomingTrafficPolicy { get { throw null; } set { } }
        public string LastOperationName { get { throw null; } }
        public string LastWorkflowId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public int? StorageSyncServiceStatus { get { throw null; } }
        public System.Guid? StorageSyncServiceUid { get { throw null; } }
    }
    public partial class StorageSyncServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageSyncServiceResource() { }
        public virtual Azure.ResourceManager.StorageSync.StorageSyncServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageSyncServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateLinkResource> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateLinkResource> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncGroupResource> GetStorageSyncGroup(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncGroupResource>> GetStorageSyncGroupAsync(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageSync.StorageSyncGroupCollection GetStorageSyncGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource> GetStorageSyncPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource>> GetStorageSyncPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionCollection GetStorageSyncPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerResource> GetStorageSyncRegisteredServer(System.Guid serverId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerResource>> GetStorageSyncRegisteredServerAsync(System.Guid serverId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerCollection GetStorageSyncRegisteredServers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncWorkflowResource> GetStorageSyncWorkflow(string workflowId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncWorkflowResource>> GetStorageSyncWorkflowAsync(string workflowId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageSync.StorageSyncWorkflowCollection GetStorageSyncWorkflows() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.StorageSyncServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.StorageSyncServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.StorageSyncServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageSyncWorkflowCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageSync.StorageSyncWorkflowResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.StorageSyncWorkflowResource>, System.Collections.IEnumerable
    {
        protected StorageSyncWorkflowCollection() { }
        public virtual Azure.Response<bool> Exists(string workflowId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workflowId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncWorkflowResource> Get(string workflowId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageSync.StorageSyncWorkflowResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageSync.StorageSyncWorkflowResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncWorkflowResource>> GetAsync(string workflowId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageSync.StorageSyncWorkflowResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageSync.StorageSyncWorkflowResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageSync.StorageSyncWorkflowResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.StorageSyncWorkflowResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageSyncWorkflowData : Azure.ResourceManager.Models.ResourceData
    {
        public StorageSyncWorkflowData() { }
        public string CommandName { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Guid? LastOperationId { get { throw null; } set { } }
        public System.DateTimeOffset? LastStatusUpdatedOn { get { throw null; } }
        public string LastStepName { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.StorageSyncOperationDirection? Operation { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.StorageSyncWorkflowStatus? Status { get { throw null; } set { } }
        public string Steps { get { throw null; } set { } }
    }
    public partial class StorageSyncWorkflowResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageSyncWorkflowResource() { }
        public virtual Azure.ResourceManager.StorageSync.StorageSyncWorkflowData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Abort(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AbortAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageSyncServiceName, string workflowId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncWorkflowResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncWorkflowResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.StorageSync.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDetectionMode : System.IEquatable<Azure.ResourceManager.StorageSync.Models.ChangeDetectionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDetectionMode(string value) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.ChangeDetectionMode Default { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.ChangeDetectionMode Recursive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageSync.Models.ChangeDetectionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageSync.Models.ChangeDetectionMode left, Azure.ResourceManager.StorageSync.Models.ChangeDetectionMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageSync.Models.ChangeDetectionMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageSync.Models.ChangeDetectionMode left, Azure.ResourceManager.StorageSync.Models.ChangeDetectionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CloudEndpointAfsShareMetadataCertificatePublicKeys
    {
        internal CloudEndpointAfsShareMetadataCertificatePublicKeys() { }
        public string FirstKey { get { throw null; } }
        public string SecondKey { get { throw null; } }
    }
    public partial class CloudEndpointBackupContent
    {
        public CloudEndpointBackupContent() { }
        public string AzureFileShare { get { throw null; } set { } }
    }
    public partial class CloudEndpointChangeEnumerationActivity
    {
        internal CloudEndpointChangeEnumerationActivity() { }
        public int? DeletesProgressPercent { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public int? MinutesRemaining { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationActivityState? OperationState { get { throw null; } }
        public long? ProcessedDirectoriesCount { get { throw null; } }
        public long? ProcessedFilesCount { get { throw null; } }
        public int? ProgressPercent { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public int? StatusCode { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationTotalCountsState? TotalCountsState { get { throw null; } }
        public long? TotalDirectoriesCount { get { throw null; } }
        public long? TotalFilesCount { get { throw null; } }
        public long? TotalSizeInBytes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudEndpointChangeEnumerationActivityState : System.IEquatable<Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationActivityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudEndpointChangeEnumerationActivityState(string value) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationActivityState EnumerationInProgress { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationActivityState InitialEnumerationInProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationActivityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationActivityState left, Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationActivityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationActivityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationActivityState left, Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationActivityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CloudEndpointChangeEnumerationStatus
    {
        internal CloudEndpointChangeEnumerationStatus() { }
        public Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationActivity Activity { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.CloudEndpointLastChangeEnumerationStatus LastEnumerationStatus { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudEndpointChangeEnumerationTotalCountsState : System.IEquatable<Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationTotalCountsState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudEndpointChangeEnumerationTotalCountsState(string value) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationTotalCountsState Calculating { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationTotalCountsState Final { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationTotalCountsState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationTotalCountsState left, Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationTotalCountsState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationTotalCountsState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationTotalCountsState left, Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationTotalCountsState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CloudEndpointCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public CloudEndpointCreateOrUpdateContent() { }
        public string AzureFileShareName { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountResourceId { get { throw null; } set { } }
        public System.Guid? StorageAccountTenantId { get { throw null; } set { } }
    }
    public partial class CloudEndpointLastChangeEnumerationStatus
    {
        internal CloudEndpointLastChangeEnumerationStatus() { }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public long? NamespaceDirectoriesCount { get { throw null; } }
        public long? NamespaceFilesCount { get { throw null; } }
        public long? NamespaceSizeInBytes { get { throw null; } }
        public System.DateTimeOffset? NextRunTimestamp { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
    }
    public partial class CloudEndpointPostBackupResult
    {
        internal CloudEndpointPostBackupResult() { }
        public string CloudEndpointName { get { throw null; } }
    }
    public partial class CloudTieringCachePerformance
    {
        internal CloudTieringCachePerformance() { }
        public long? CacheHitBytes { get { throw null; } }
        public int? CacheHitBytesPercent { get { throw null; } }
        public long? CacheMissBytes { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
    }
    public partial class CloudTieringDatePolicyStatus
    {
        internal CloudTieringDatePolicyStatus() { }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public System.DateTimeOffset? TieredFilesMostRecentAccessTimestamp { get { throw null; } }
    }
    public partial class CloudTieringFilesNotTiering
    {
        internal CloudTieringFilesNotTiering() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StorageSync.Models.FilesNotTieringError> Errors { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public long? TotalFileCount { get { throw null; } }
    }
    public partial class CloudTieringLowDiskMode
    {
        internal CloudTieringLowDiskMode() { }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.CloudTieringLowDiskModeState? State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudTieringLowDiskModeState : System.IEquatable<Azure.ResourceManager.StorageSync.Models.CloudTieringLowDiskModeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudTieringLowDiskModeState(string value) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.CloudTieringLowDiskModeState Disabled { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.CloudTieringLowDiskModeState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageSync.Models.CloudTieringLowDiskModeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageSync.Models.CloudTieringLowDiskModeState left, Azure.ResourceManager.StorageSync.Models.CloudTieringLowDiskModeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageSync.Models.CloudTieringLowDiskModeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageSync.Models.CloudTieringLowDiskModeState left, Azure.ResourceManager.StorageSync.Models.CloudTieringLowDiskModeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CloudTieringSpaceSavings
    {
        internal CloudTieringSpaceSavings() { }
        public long? CachedSizeInBytes { get { throw null; } }
        public long? CloudTotalSizeInBytes { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public long? SpaceSavingsInBytes { get { throw null; } }
        public int? SpaceSavingsPercent { get { throw null; } }
        public long? VolumeSizeInBytes { get { throw null; } }
    }
    public partial class CloudTieringVolumeFreeSpacePolicyStatus
    {
        internal CloudTieringVolumeFreeSpacePolicyStatus() { }
        public int? CurrentVolumeFreeSpacePercent { get { throw null; } }
        public int? EffectiveVolumeFreeSpacePolicy { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
    }
    public partial class FilesNotTieringError
    {
        internal FilesNotTieringError() { }
        public int? ErrorCode { get { throw null; } }
        public long? FileCount { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IncomingTrafficPolicy : System.IEquatable<Azure.ResourceManager.StorageSync.Models.IncomingTrafficPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IncomingTrafficPolicy(string value) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.IncomingTrafficPolicy AllowAllTraffic { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.IncomingTrafficPolicy AllowVirtualNetworksOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageSync.Models.IncomingTrafficPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageSync.Models.IncomingTrafficPolicy left, Azure.ResourceManager.StorageSync.Models.IncomingTrafficPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageSync.Models.IncomingTrafficPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageSync.Models.IncomingTrafficPolicy left, Azure.ResourceManager.StorageSync.Models.IncomingTrafficPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InitialDownloadPolicy : System.IEquatable<Azure.ResourceManager.StorageSync.Models.InitialDownloadPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InitialDownloadPolicy(string value) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.InitialDownloadPolicy AvoidTieredFiles { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.InitialDownloadPolicy NamespaceOnly { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.InitialDownloadPolicy NamespaceThenModifiedFiles { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageSync.Models.InitialDownloadPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageSync.Models.InitialDownloadPolicy left, Azure.ResourceManager.StorageSync.Models.InitialDownloadPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageSync.Models.InitialDownloadPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageSync.Models.InitialDownloadPolicy left, Azure.ResourceManager.StorageSync.Models.InitialDownloadPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InitialUploadPolicy : System.IEquatable<Azure.ResourceManager.StorageSync.Models.InitialUploadPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InitialUploadPolicy(string value) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.InitialUploadPolicy Merge { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.InitialUploadPolicy ServerAuthoritative { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageSync.Models.InitialUploadPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageSync.Models.InitialUploadPolicy left, Azure.ResourceManager.StorageSync.Models.InitialUploadPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageSync.Models.InitialUploadPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageSync.Models.InitialUploadPolicy left, Azure.ResourceManager.StorageSync.Models.InitialUploadPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LocalCacheMode : System.IEquatable<Azure.ResourceManager.StorageSync.Models.LocalCacheMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LocalCacheMode(string value) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.LocalCacheMode DownloadNewAndModifiedFiles { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.LocalCacheMode UpdateLocallyCachedFiles { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageSync.Models.LocalCacheMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageSync.Models.LocalCacheMode left, Azure.ResourceManager.StorageSync.Models.LocalCacheMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageSync.Models.LocalCacheMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageSync.Models.LocalCacheMode left, Azure.ResourceManager.StorageSync.Models.LocalCacheMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostRestoreContent
    {
        public PostRestoreContent() { }
        public System.Uri AzureFileShareUri { get { throw null; } set { } }
        public string FailedFileList { get { throw null; } set { } }
        public string Partition { get { throw null; } set { } }
        public string ReplicaGroup { get { throw null; } set { } }
        public string RequestId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StorageSync.Models.RestoreFileSpec> RestoreFileSpec { get { throw null; } }
        public System.Uri SourceAzureFileShareUri { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class PreRestoreContent
    {
        public PreRestoreContent() { }
        public System.Uri AzureFileShareUri { get { throw null; } set { } }
        public string BackupMetadataPropertyBag { get { throw null; } set { } }
        public string Partition { get { throw null; } set { } }
        public int? PauseWaitForSyncDrainTimePeriodInSeconds { get { throw null; } set { } }
        public string ReplicaGroup { get { throw null; } set { } }
        public string RequestId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StorageSync.Models.RestoreFileSpec> RestoreFileSpec { get { throw null; } }
        public System.Uri SourceAzureFileShareUri { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class RecallActionContent
    {
        public RecallActionContent() { }
        public string Pattern { get { throw null; } set { } }
        public string RecallPath { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegisteredServerAgentVersionStatus : System.IEquatable<Azure.ResourceManager.StorageSync.Models.RegisteredServerAgentVersionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegisteredServerAgentVersionStatus(string value) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.RegisteredServerAgentVersionStatus Blocked { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.RegisteredServerAgentVersionStatus Expired { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.RegisteredServerAgentVersionStatus NearExpiry { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.RegisteredServerAgentVersionStatus Ok { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageSync.Models.RegisteredServerAgentVersionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageSync.Models.RegisteredServerAgentVersionStatus left, Azure.ResourceManager.StorageSync.Models.RegisteredServerAgentVersionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageSync.Models.RegisteredServerAgentVersionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageSync.Models.RegisteredServerAgentVersionStatus left, Azure.ResourceManager.StorageSync.Models.RegisteredServerAgentVersionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestoreFileSpec
    {
        public RestoreFileSpec() { }
        public bool? IsDirectory { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class ServerEndpointBackgroundDataDownloadActivity
    {
        internal ServerEndpointBackgroundDataDownloadActivity() { }
        public long? DownloadedBytes { get { throw null; } }
        public int? PercentProgress { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class ServerEndpointCloudTieringStatus
    {
        internal ServerEndpointCloudTieringStatus() { }
        public Azure.ResourceManager.StorageSync.Models.CloudTieringCachePerformance CachePerformance { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.CloudTieringDatePolicyStatus DatePolicyStatus { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.CloudTieringFilesNotTiering FilesNotTiering { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState? Health { get { throw null; } }
        public System.DateTimeOffset? HealthLastUpdatedOn { get { throw null; } }
        public int? LastCloudTieringResult { get { throw null; } }
        public System.DateTimeOffset? LastSuccessTimestamp { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.CloudTieringLowDiskMode LowDiskMode { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.CloudTieringSpaceSavings SpaceSavings { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.CloudTieringVolumeFreeSpacePolicyStatus VolumeFreeSpacePolicyStatus { get { throw null; } }
    }
    public partial class ServerEndpointFilesNotSyncingError
    {
        internal ServerEndpointFilesNotSyncingError() { }
        public int? ErrorCode { get { throw null; } }
        public long? PersistentCount { get { throw null; } }
        public long? TransientCount { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerEndpointHealthState : System.IEquatable<Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerEndpointHealthState(string value) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState Error { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState Healthy { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState left, Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState left, Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerEndpointOfflineDataTransferState : System.IEquatable<Azure.ResourceManager.StorageSync.Models.ServerEndpointOfflineDataTransferState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerEndpointOfflineDataTransferState(string value) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.ServerEndpointOfflineDataTransferState Complete { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.ServerEndpointOfflineDataTransferState InProgress { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.ServerEndpointOfflineDataTransferState NotRunning { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.ServerEndpointOfflineDataTransferState Stopping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageSync.Models.ServerEndpointOfflineDataTransferState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageSync.Models.ServerEndpointOfflineDataTransferState left, Azure.ResourceManager.StorageSync.Models.ServerEndpointOfflineDataTransferState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageSync.Models.ServerEndpointOfflineDataTransferState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageSync.Models.ServerEndpointOfflineDataTransferState left, Azure.ResourceManager.StorageSync.Models.ServerEndpointOfflineDataTransferState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerEndpointRecallError
    {
        internal ServerEndpointRecallError() { }
        public long? Count { get { throw null; } }
        public int? ErrorCode { get { throw null; } }
    }
    public partial class ServerEndpointRecallStatus
    {
        internal ServerEndpointRecallStatus() { }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StorageSync.Models.ServerEndpointRecallError> RecallErrors { get { throw null; } }
        public long? TotalRecallErrorsCount { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerEndpointSyncActivityState : System.IEquatable<Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncActivityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerEndpointSyncActivityState(string value) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncActivityState Download { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncActivityState Upload { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncActivityState UploadAndDownload { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncActivityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncActivityState left, Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncActivityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncActivityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncActivityState left, Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncActivityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerEndpointSyncActivityStatus
    {
        internal ServerEndpointSyncActivityStatus() { }
        public long? AppliedBytes { get { throw null; } }
        public long? AppliedItemCount { get { throw null; } }
        public long? PerItemErrorCount { get { throw null; } }
        public int? SessionMinutesRemaining { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncMode? SyncMode { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public long? TotalBytes { get { throw null; } }
        public long? TotalItemCount { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerEndpointSyncMode : System.IEquatable<Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerEndpointSyncMode(string value) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncMode InitialFullDownload { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncMode InitialUpload { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncMode NamespaceDownload { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncMode Regular { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncMode SnapshotUpload { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncMode left, Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncMode left, Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerEndpointSyncSessionStatus
    {
        internal ServerEndpointSyncSessionStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StorageSync.Models.ServerEndpointFilesNotSyncingError> FilesNotSyncingErrors { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncMode? LastSyncMode { get { throw null; } }
        public long? LastSyncPerItemErrorCount { get { throw null; } }
        public int? LastSyncResult { get { throw null; } }
        public System.DateTimeOffset? LastSyncSuccessTimestamp { get { throw null; } }
        public System.DateTimeOffset? LastSyncTimestamp { get { throw null; } }
        public long? PersistentFilesNotSyncingCount { get { throw null; } }
        public long? TransientFilesNotSyncingCount { get { throw null; } }
    }
    public partial class ServerEndpointSyncStatus
    {
        internal ServerEndpointSyncStatus() { }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointBackgroundDataDownloadActivity BackgroundDataDownloadActivity { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState? CombinedHealth { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncActivityStatus DownloadActivity { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState? DownloadHealth { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncSessionStatus DownloadStatus { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointOfflineDataTransferState? OfflineDataTransferStatus { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncActivityState? SyncActivity { get { throw null; } }
        public long? TotalPersistentFilesNotSyncingCount { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncActivityStatus UploadActivity { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState? UploadHealth { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncSessionStatus UploadStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageSyncFeatureStatus : System.IEquatable<Azure.ResourceManager.StorageSync.Models.StorageSyncFeatureStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageSyncFeatureStatus(string value) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.StorageSyncFeatureStatus Off { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.StorageSyncFeatureStatus On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageSync.Models.StorageSyncFeatureStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageSync.Models.StorageSyncFeatureStatus left, Azure.ResourceManager.StorageSync.Models.StorageSyncFeatureStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageSync.Models.StorageSyncFeatureStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageSync.Models.StorageSyncFeatureStatus left, Azure.ResourceManager.StorageSync.Models.StorageSyncFeatureStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageSyncGroupCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public StorageSyncGroupCreateOrUpdateContent() { }
        public System.BinaryData Properties { get { throw null; } set { } }
    }
    public partial class StorageSyncNameAvailabilityContent
    {
        public StorageSyncNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.StorageSyncResourceType ResourceType { get { throw null; } }
    }
    public partial class StorageSyncNameAvailabilityResult
    {
        internal StorageSyncNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.StorageSyncNameUnavailableReason? Reason { get { throw null; } }
    }
    public enum StorageSyncNameUnavailableReason
    {
        Invalid = 0,
        AlreadyExists = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageSyncOperationDirection : System.IEquatable<Azure.ResourceManager.StorageSync.Models.StorageSyncOperationDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageSyncOperationDirection(string value) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.StorageSyncOperationDirection Cancel { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.StorageSyncOperationDirection Do { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.StorageSyncOperationDirection Undo { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageSync.Models.StorageSyncOperationDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageSync.Models.StorageSyncOperationDirection left, Azure.ResourceManager.StorageSync.Models.StorageSyncOperationDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageSync.Models.StorageSyncOperationDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageSync.Models.StorageSyncOperationDirection left, Azure.ResourceManager.StorageSync.Models.StorageSyncOperationDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageSyncPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageSyncPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageSyncPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageSyncPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageSyncPrivateLinkResource : Azure.ResourceManager.Models.ResourceData
    {
        public StorageSyncPrivateLinkResource() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class StorageSyncPrivateLinkServiceConnectionState
    {
        public StorageSyncPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class StorageSyncRegisteredServerCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public StorageSyncRegisteredServerCreateOrUpdateContent() { }
        public string AgentVersion { get { throw null; } set { } }
        public System.Guid? ClusterId { get { throw null; } set { } }
        public string ClusterName { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string LastHeartbeat { get { throw null; } set { } }
        public System.BinaryData ServerCertificate { get { throw null; } set { } }
        public System.Guid? ServerId { get { throw null; } set { } }
        public string ServerOSVersion { get { throw null; } set { } }
        public string ServerRole { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageSyncResourceType : System.IEquatable<Azure.ResourceManager.StorageSync.Models.StorageSyncResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageSyncResourceType(string value) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.StorageSyncResourceType Microsoft_StorageSync_StorageSyncServices { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageSync.Models.StorageSyncResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageSync.Models.StorageSyncResourceType left, Azure.ResourceManager.StorageSync.Models.StorageSyncResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageSync.Models.StorageSyncResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageSync.Models.StorageSyncResourceType left, Azure.ResourceManager.StorageSync.Models.StorageSyncResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageSyncServerEndpointCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public StorageSyncServerEndpointCreateOrUpdateContent() { }
        public Azure.ResourceManager.StorageSync.Models.StorageSyncFeatureStatus? CloudTiering { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.InitialDownloadPolicy? InitialDownloadPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.InitialUploadPolicy? InitialUploadPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.LocalCacheMode? LocalCacheMode { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.StorageSyncFeatureStatus? OfflineDataTransfer { get { throw null; } set { } }
        public string OfflineDataTransferShareName { get { throw null; } set { } }
        public string ServerLocalPath { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ServerResourceId { get { throw null; } set { } }
        public int? TierFilesOlderThanDays { get { throw null; } set { } }
        public int? VolumeFreeSpacePercent { get { throw null; } set { } }
    }
    public partial class StorageSyncServerEndpointPatch
    {
        public StorageSyncServerEndpointPatch() { }
        public Azure.ResourceManager.StorageSync.Models.StorageSyncFeatureStatus? CloudTiering { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.LocalCacheMode? LocalCacheMode { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.StorageSyncFeatureStatus? OfflineDataTransfer { get { throw null; } set { } }
        public string OfflineDataTransferShareName { get { throw null; } set { } }
        public int? TierFilesOlderThanDays { get { throw null; } set { } }
        public int? VolumeFreeSpacePercent { get { throw null; } set { } }
    }
    public partial class StorageSyncServiceCreateOrUpdateContent
    {
        public StorageSyncServiceCreateOrUpdateContent(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.StorageSync.Models.IncomingTrafficPolicy? IncomingTrafficPolicy { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class StorageSyncServicePatch
    {
        public StorageSyncServicePatch() { }
        public Azure.ResourceManager.StorageSync.Models.IncomingTrafficPolicy? IncomingTrafficPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageSyncWorkflowStatus : System.IEquatable<Azure.ResourceManager.StorageSync.Models.StorageSyncWorkflowStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageSyncWorkflowStatus(string value) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.StorageSyncWorkflowStatus Aborted { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.StorageSyncWorkflowStatus Active { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.StorageSyncWorkflowStatus Expired { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.StorageSyncWorkflowStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.StorageSyncWorkflowStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageSync.Models.StorageSyncWorkflowStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageSync.Models.StorageSyncWorkflowStatus left, Azure.ResourceManager.StorageSync.Models.StorageSyncWorkflowStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageSync.Models.StorageSyncWorkflowStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageSync.Models.StorageSyncWorkflowStatus left, Azure.ResourceManager.StorageSync.Models.StorageSyncWorkflowStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TriggerChangeDetectionContent
    {
        public TriggerChangeDetectionContent() { }
        public Azure.ResourceManager.StorageSync.Models.ChangeDetectionMode? ChangeDetectionMode { get { throw null; } set { } }
        public string DirectoryPath { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Paths { get { throw null; } }
    }
    public partial class TriggerRolloverContent
    {
        public TriggerRolloverContent() { }
        public System.BinaryData ServerCertificate { get { throw null; } set { } }
    }
}
