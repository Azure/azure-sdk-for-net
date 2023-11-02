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
        public virtual Azure.NullableResponse<Azure.ResourceManager.StorageSync.CloudEndpointResource> GetIfExists(string cloudEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StorageSync.CloudEndpointResource>> GetIfExistsAsync(string cloudEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.StorageSync.StorageSyncGroupResource> GetIfExists(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StorageSync.StorageSyncGroupResource>> GetIfExistsAsync(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerResource> GetIfExists(System.Guid serverId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerResource>> GetIfExistsAsync(System.Guid serverId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.StorageSync.StorageSyncServerEndpointResource> GetIfExists(string serverEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StorageSync.StorageSyncServerEndpointResource>> GetIfExistsAsync(string serverEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> GetIfExists(string storageSyncServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StorageSync.StorageSyncServiceResource>> GetIfExistsAsync(string storageSyncServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageSync.StorageSyncServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.StorageSyncServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageSyncServiceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public StorageSyncServiceData(Azure.Core.AzureLocation location) { }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.StorageSync.StorageSyncWorkflowResource> GetIfExists(string workflowId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StorageSync.StorageSyncWorkflowResource>> GetIfExistsAsync(string workflowId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
namespace Azure.ResourceManager.StorageSync.Mocking
{
    public partial class MockableStorageSyncArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableStorageSyncArmClient() { }
        public virtual Azure.ResourceManager.StorageSync.CloudEndpointResource GetCloudEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StorageSync.StorageSyncGroupResource GetStorageSyncGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource GetStorageSyncPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerResource GetStorageSyncRegisteredServerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StorageSync.StorageSyncServerEndpointResource GetStorageSyncServerEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StorageSync.StorageSyncServiceResource GetStorageSyncServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StorageSync.StorageSyncWorkflowResource GetStorageSyncWorkflowResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableStorageSyncResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableStorageSyncResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> GetStorageSyncService(string storageSyncServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServiceResource>> GetStorageSyncServiceAsync(string storageSyncServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageSync.StorageSyncServiceCollection GetStorageSyncServices() { throw null; }
    }
    public partial class MockableStorageSyncSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableStorageSyncSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.Models.StorageSyncNameAvailabilityResult> CheckStorageSyncNameAvailability(string locationName, Azure.ResourceManager.StorageSync.Models.StorageSyncNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.Models.StorageSyncNameAvailabilityResult>> CheckStorageSyncNameAvailabilityAsync(string locationName, Azure.ResourceManager.StorageSync.Models.StorageSyncNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> GetStorageSyncServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> GetStorageSyncServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.StorageSync.Models
{
    public static partial class ArmStorageSyncModelFactory
    {
        public static Azure.ResourceManager.StorageSync.Models.CloudEndpointAfsShareMetadataCertificatePublicKeys CloudEndpointAfsShareMetadataCertificatePublicKeys(string firstKey = null, string secondKey = null) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationActivity CloudEndpointChangeEnumerationActivity(System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationActivityState? operationState = default(Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationActivityState?), int? statusCode = default(int?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), long? processedFilesCount = default(long?), long? processedDirectoriesCount = default(long?), long? totalFilesCount = default(long?), long? totalDirectoriesCount = default(long?), long? totalSizeInBytes = default(long?), int? progressPercent = default(int?), int? minutesRemaining = default(int?), Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationTotalCountsState? totalCountsState = default(Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationTotalCountsState?), int? deletesProgressPercent = default(int?)) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationStatus CloudEndpointChangeEnumerationStatus(System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.StorageSync.Models.CloudEndpointLastChangeEnumerationStatus lastEnumerationStatus = null, Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationActivity activity = null) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.CloudEndpointCreateOrUpdateContent CloudEndpointCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier storageAccountResourceId = null, string azureFileShareName = null, System.Guid? storageAccountTenantId = default(System.Guid?), string friendlyName = null) { throw null; }
        public static Azure.ResourceManager.StorageSync.CloudEndpointData CloudEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier storageAccountResourceId = null, string azureFileShareName = null, System.Guid? storageAccountTenantId = default(System.Guid?), string partnershipId = null, string friendlyName = null, string isBackupEnabled = null, string provisioningState = null, string lastWorkflowId = null, string lastOperationName = null, Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationStatus changeEnumerationStatus = null) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.CloudEndpointLastChangeEnumerationStatus CloudEndpointLastChangeEnumerationStatus(System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), long? namespaceFilesCount = default(long?), long? namespaceDirectoriesCount = default(long?), long? namespaceSizeInBytes = default(long?), System.DateTimeOffset? nextRunTimestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.CloudEndpointPostBackupResult CloudEndpointPostBackupResult(string cloudEndpointName = null) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.CloudTieringCachePerformance CloudTieringCachePerformance(System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), long? cacheHitBytes = default(long?), long? cacheMissBytes = default(long?), int? cacheHitBytesPercent = default(int?)) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.CloudTieringDatePolicyStatus CloudTieringDatePolicyStatus(System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? tieredFilesMostRecentAccessTimestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.CloudTieringFilesNotTiering CloudTieringFilesNotTiering(System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), long? totalFileCount = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.Models.FilesNotTieringError> errors = null) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.CloudTieringLowDiskMode CloudTieringLowDiskMode(System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.StorageSync.Models.CloudTieringLowDiskModeState? state = default(Azure.ResourceManager.StorageSync.Models.CloudTieringLowDiskModeState?)) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.CloudTieringSpaceSavings CloudTieringSpaceSavings(System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), long? volumeSizeInBytes = default(long?), long? cloudTotalSizeInBytes = default(long?), long? cachedSizeInBytes = default(long?), int? spaceSavingsPercent = default(int?), long? spaceSavingsInBytes = default(long?)) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.CloudTieringVolumeFreeSpacePolicyStatus CloudTieringVolumeFreeSpacePolicyStatus(System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), int? effectiveVolumeFreeSpacePolicy = default(int?), int? currentVolumeFreeSpacePercent = default(int?)) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.FilesNotTieringError FilesNotTieringError(int? errorCode = default(int?), long? fileCount = default(long?)) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.ServerEndpointBackgroundDataDownloadActivity ServerEndpointBackgroundDataDownloadActivity(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), int? percentProgress = default(int?), long? downloadedBytes = default(long?)) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.ServerEndpointCloudTieringStatus ServerEndpointCloudTieringStatus(System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState? health = default(Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState?), System.DateTimeOffset? healthLastUpdatedOn = default(System.DateTimeOffset?), int? lastCloudTieringResult = default(int?), System.DateTimeOffset? lastSuccessTimestamp = default(System.DateTimeOffset?), Azure.ResourceManager.StorageSync.Models.CloudTieringSpaceSavings spaceSavings = null, Azure.ResourceManager.StorageSync.Models.CloudTieringCachePerformance cachePerformance = null, Azure.ResourceManager.StorageSync.Models.CloudTieringFilesNotTiering filesNotTiering = null, Azure.ResourceManager.StorageSync.Models.CloudTieringVolumeFreeSpacePolicyStatus volumeFreeSpacePolicyStatus = null, Azure.ResourceManager.StorageSync.Models.CloudTieringDatePolicyStatus datePolicyStatus = null, Azure.ResourceManager.StorageSync.Models.CloudTieringLowDiskMode lowDiskMode = null) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.ServerEndpointFilesNotSyncingError ServerEndpointFilesNotSyncingError(int? errorCode = default(int?), long? persistentCount = default(long?), long? transientCount = default(long?)) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.ServerEndpointRecallError ServerEndpointRecallError(int? errorCode = default(int?), long? count = default(long?)) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.ServerEndpointRecallStatus ServerEndpointRecallStatus(System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), long? totalRecallErrorsCount = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.Models.ServerEndpointRecallError> recallErrors = null) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncActivityStatus ServerEndpointSyncActivityStatus(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), long? perItemErrorCount = default(long?), long? appliedItemCount = default(long?), long? totalItemCount = default(long?), long? appliedBytes = default(long?), long? totalBytes = default(long?), Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncMode? syncMode = default(Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncMode?), int? sessionMinutesRemaining = default(int?)) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncSessionStatus ServerEndpointSyncSessionStatus(int? lastSyncResult = default(int?), System.DateTimeOffset? lastSyncTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? lastSyncSuccessTimestamp = default(System.DateTimeOffset?), long? lastSyncPerItemErrorCount = default(long?), long? persistentFilesNotSyncingCount = default(long?), long? transientFilesNotSyncingCount = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.Models.ServerEndpointFilesNotSyncingError> filesNotSyncingErrors = null, Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncMode? lastSyncMode = default(Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncMode?)) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncStatus ServerEndpointSyncStatus(Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState? downloadHealth = default(Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState?), Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState? uploadHealth = default(Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState?), Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState? combinedHealth = default(Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState?), Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncActivityState? syncActivity = default(Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncActivityState?), long? totalPersistentFilesNotSyncingCount = default(long?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncSessionStatus uploadStatus = null, Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncSessionStatus downloadStatus = null, Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncActivityStatus uploadActivity = null, Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncActivityStatus downloadActivity = null, Azure.ResourceManager.StorageSync.Models.ServerEndpointOfflineDataTransferState? offlineDataTransferStatus = default(Azure.ResourceManager.StorageSync.Models.ServerEndpointOfflineDataTransferState?), Azure.ResourceManager.StorageSync.Models.ServerEndpointBackgroundDataDownloadActivity backgroundDataDownloadActivity = null) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.StorageSyncGroupCreateOrUpdateContent StorageSyncGroupCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.BinaryData properties = null) { throw null; }
        public static Azure.ResourceManager.StorageSync.StorageSyncGroupData StorageSyncGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? uniqueId = default(System.Guid?), string syncGroupStatus = null) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.StorageSyncNameAvailabilityResult StorageSyncNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.StorageSync.Models.StorageSyncNameUnavailableReason? reason = default(Azure.ResourceManager.StorageSync.Models.StorageSyncNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionData StorageSyncPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.StorageSyncPrivateLinkResource StorageSyncPrivateLinkResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.StorageSyncRegisteredServerCreateOrUpdateContent StorageSyncRegisteredServerCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.BinaryData serverCertificate = null, string agentVersion = null, string serverOSVersion = null, string lastHeartbeat = null, string serverRole = null, System.Guid? clusterId = default(System.Guid?), string clusterName = null, System.Guid? serverId = default(System.Guid?), string friendlyName = null) { throw null; }
        public static Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerData StorageSyncRegisteredServerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.BinaryData serverCertificate = null, string agentVersion = null, Azure.ResourceManager.StorageSync.Models.RegisteredServerAgentVersionStatus? agentVersionStatus = default(Azure.ResourceManager.StorageSync.Models.RegisteredServerAgentVersionStatus?), System.DateTimeOffset? agentVersionExpireOn = default(System.DateTimeOffset?), string serverOSVersion = null, int? serverManagementErrorCode = default(int?), string lastHeartbeat = null, string provisioningState = null, string serverRole = null, System.Guid? clusterId = default(System.Guid?), string clusterName = null, System.Guid? serverId = default(System.Guid?), System.Guid? storageSyncServiceUid = default(System.Guid?), string lastWorkflowId = null, string lastOperationName = null, System.Uri discoveryEndpointUri = null, Azure.Core.AzureLocation? resourceLocation = default(Azure.Core.AzureLocation?), Azure.Core.AzureLocation? serviceLocation = default(Azure.Core.AzureLocation?), string friendlyName = null, System.Uri managementEndpointUri = null, System.Uri monitoringEndpointUri = null, string monitoringConfiguration = null, string serverName = null) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.StorageSyncServerEndpointCreateOrUpdateContent StorageSyncServerEndpointCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string serverLocalPath = null, Azure.ResourceManager.StorageSync.Models.StorageSyncFeatureStatus? cloudTiering = default(Azure.ResourceManager.StorageSync.Models.StorageSyncFeatureStatus?), int? volumeFreeSpacePercent = default(int?), int? tierFilesOlderThanDays = default(int?), string friendlyName = null, Azure.Core.ResourceIdentifier serverResourceId = null, Azure.ResourceManager.StorageSync.Models.StorageSyncFeatureStatus? offlineDataTransfer = default(Azure.ResourceManager.StorageSync.Models.StorageSyncFeatureStatus?), string offlineDataTransferShareName = null, Azure.ResourceManager.StorageSync.Models.InitialDownloadPolicy? initialDownloadPolicy = default(Azure.ResourceManager.StorageSync.Models.InitialDownloadPolicy?), Azure.ResourceManager.StorageSync.Models.LocalCacheMode? localCacheMode = default(Azure.ResourceManager.StorageSync.Models.LocalCacheMode?), Azure.ResourceManager.StorageSync.Models.InitialUploadPolicy? initialUploadPolicy = default(Azure.ResourceManager.StorageSync.Models.InitialUploadPolicy?)) { throw null; }
        public static Azure.ResourceManager.StorageSync.StorageSyncServerEndpointData StorageSyncServerEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string serverLocalPath = null, Azure.ResourceManager.StorageSync.Models.StorageSyncFeatureStatus? cloudTiering = default(Azure.ResourceManager.StorageSync.Models.StorageSyncFeatureStatus?), int? volumeFreeSpacePercent = default(int?), int? tierFilesOlderThanDays = default(int?), string friendlyName = null, Azure.Core.ResourceIdentifier serverResourceId = null, string provisioningState = null, string lastWorkflowId = null, string lastOperationName = null, Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncStatus syncStatus = null, Azure.ResourceManager.StorageSync.Models.StorageSyncFeatureStatus? offlineDataTransfer = default(Azure.ResourceManager.StorageSync.Models.StorageSyncFeatureStatus?), Azure.Core.ResourceIdentifier offlineDataTransferStorageAccountResourceId = null, System.Guid? offlineDataTransferStorageAccountTenantId = default(System.Guid?), string offlineDataTransferShareName = null, Azure.ResourceManager.StorageSync.Models.ServerEndpointCloudTieringStatus cloudTieringStatus = null, Azure.ResourceManager.StorageSync.Models.ServerEndpointRecallStatus recallStatus = null, Azure.ResourceManager.StorageSync.Models.InitialDownloadPolicy? initialDownloadPolicy = default(Azure.ResourceManager.StorageSync.Models.InitialDownloadPolicy?), Azure.ResourceManager.StorageSync.Models.LocalCacheMode? localCacheMode = default(Azure.ResourceManager.StorageSync.Models.LocalCacheMode?), Azure.ResourceManager.StorageSync.Models.InitialUploadPolicy? initialUploadPolicy = default(Azure.ResourceManager.StorageSync.Models.InitialUploadPolicy?), string serverName = null) { throw null; }
        public static Azure.ResourceManager.StorageSync.StorageSyncServiceData StorageSyncServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.StorageSync.Models.IncomingTrafficPolicy? incomingTrafficPolicy = default(Azure.ResourceManager.StorageSync.Models.IncomingTrafficPolicy?), int? storageSyncServiceStatus = default(int?), System.Guid? storageSyncServiceUid = default(System.Guid?), string provisioningState = null, string lastWorkflowId = null, string lastOperationName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionData> privateEndpointConnections = null) { throw null; }
        public static Azure.ResourceManager.StorageSync.StorageSyncWorkflowData StorageSyncWorkflowData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string lastStepName = null, Azure.ResourceManager.StorageSync.Models.StorageSyncWorkflowStatus? status = default(Azure.ResourceManager.StorageSync.Models.StorageSyncWorkflowStatus?), Azure.ResourceManager.StorageSync.Models.StorageSyncOperationDirection? operation = default(Azure.ResourceManager.StorageSync.Models.StorageSyncOperationDirection?), string steps = null, System.Guid? lastOperationId = default(System.Guid?), string commandName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastStatusUpdatedOn = default(System.DateTimeOffset?)) { throw null; }
    }
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
