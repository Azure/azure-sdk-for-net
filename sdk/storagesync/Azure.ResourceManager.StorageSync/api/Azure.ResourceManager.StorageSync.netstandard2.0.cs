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
        public string BackupEnabled { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationStatus ChangeEnumerationStatus { get { throw null; } }
        public string FriendlyName { get { throw null; } set { } }
        public string LastOperationName { get { throw null; } set { } }
        public string LastWorkflowId { get { throw null; } set { } }
        public string PartnershipId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
        public string StorageAccountResourceId { get { throw null; } set { } }
        public string StorageAccountTenantId { get { throw null; } set { } }
    }
    public partial class CloudEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudEndpointResource() { }
        public virtual Azure.ResourceManager.StorageSync.CloudEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageSyncServiceName, string syncGroupName, string cloudEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.CloudEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.CloudEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.Models.PostBackupResponse> PostBackup(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.BackupRequest backupRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.Models.PostBackupResponse>> PostBackupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.BackupRequest backupRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PostRestore(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.PostRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PostRestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.PostRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PreBackup(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.BackupRequest backupRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PreBackupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.BackupRequest backupRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PreRestore(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.PreRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PreRestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.PreRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Restoreheartbeat(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RestoreheartbeatAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TriggerChangeDetection(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.TriggerChangeDetectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerChangeDetectionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.TriggerChangeDetectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.CloudEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.CloudEndpointCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.CloudEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.CloudEndpointCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RegisteredServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageSync.RegisteredServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.RegisteredServerResource>, System.Collections.IEnumerable
    {
        protected RegisteredServerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.RegisteredServerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverId, Azure.ResourceManager.StorageSync.Models.RegisteredServerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.RegisteredServerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverId, Azure.ResourceManager.StorageSync.Models.RegisteredServerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.RegisteredServerResource> Get(string serverId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageSync.RegisteredServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageSync.RegisteredServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.RegisteredServerResource>> GetAsync(string serverId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageSync.RegisteredServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageSync.RegisteredServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageSync.RegisteredServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.RegisteredServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RegisteredServerData : Azure.ResourceManager.Models.ResourceData
    {
        public RegisteredServerData() { }
        public string AgentVersion { get { throw null; } set { } }
        public System.DateTimeOffset? AgentVersionExpirationOn { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.RegisteredServerAgentVersionStatus? AgentVersionStatus { get { throw null; } }
        public string ClusterId { get { throw null; } set { } }
        public string ClusterName { get { throw null; } set { } }
        public System.Uri DiscoveryEndpointUri { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string LastHeartBeat { get { throw null; } set { } }
        public string LastOperationName { get { throw null; } set { } }
        public string LastWorkflowId { get { throw null; } set { } }
        public System.Uri ManagementEndpointUri { get { throw null; } set { } }
        public string MonitoringConfiguration { get { throw null; } set { } }
        public System.Uri MonitoringEndpointUri { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
        public string ResourceLocation { get { throw null; } set { } }
        public string ServerCertificate { get { throw null; } set { } }
        public string ServerId { get { throw null; } set { } }
        public int? ServerManagementErrorCode { get { throw null; } set { } }
        public string ServerName { get { throw null; } }
        public string ServerOSVersion { get { throw null; } set { } }
        public string ServerRole { get { throw null; } set { } }
        public string ServiceLocation { get { throw null; } set { } }
        public string StorageSyncServiceUid { get { throw null; } set { } }
    }
    public partial class RegisteredServerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RegisteredServerResource() { }
        public virtual Azure.ResourceManager.StorageSync.RegisteredServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageSyncServiceName, string serverId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.RegisteredServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.RegisteredServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TriggerRollover(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.TriggerRolloverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerRolloverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.TriggerRolloverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.RegisteredServerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.RegisteredServerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.RegisteredServerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.RegisteredServerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageSync.ServerEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.ServerEndpointResource>, System.Collections.IEnumerable
    {
        protected ServerEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.ServerEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverEndpointName, Azure.ResourceManager.StorageSync.Models.ServerEndpointCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.ServerEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverEndpointName, Azure.ResourceManager.StorageSync.Models.ServerEndpointCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.ServerEndpointResource> Get(string serverEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageSync.ServerEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageSync.ServerEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.ServerEndpointResource>> GetAsync(string serverEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageSync.ServerEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageSync.ServerEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageSync.ServerEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.ServerEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerEndpointData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerEndpointData() { }
        public Azure.ResourceManager.StorageSync.Models.FeatureStatus? CloudTiering { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointCloudTieringStatus CloudTieringStatus { get { throw null; } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.InitialDownloadPolicy? InitialDownloadPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.InitialUploadPolicy? InitialUploadPolicy { get { throw null; } set { } }
        public string LastOperationName { get { throw null; } }
        public string LastWorkflowId { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.LocalCacheMode? LocalCacheMode { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.FeatureStatus? OfflineDataTransfer { get { throw null; } set { } }
        public string OfflineDataTransferShareName { get { throw null; } set { } }
        public string OfflineDataTransferStorageAccountResourceId { get { throw null; } }
        public string OfflineDataTransferStorageAccountTenantId { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointRecallStatus RecallStatus { get { throw null; } }
        public string ServerLocalPath { get { throw null; } set { } }
        public string ServerName { get { throw null; } }
        public string ServerResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncStatus SyncStatus { get { throw null; } }
        public int? TierFilesOlderThanDays { get { throw null; } set { } }
        public int? VolumeFreeSpacePercent { get { throw null; } set { } }
    }
    public partial class ServerEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerEndpointResource() { }
        public virtual Azure.ResourceManager.StorageSync.ServerEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageSyncServiceName, string syncGroupName, string serverEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.ServerEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.ServerEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RecallAction(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.RecallActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RecallActionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.RecallActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.ServerEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.ServerEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.ServerEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.ServerEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class StorageSyncExtensions
    {
        public static Azure.Response<Azure.ResourceManager.StorageSync.Models.CheckNameAvailabilityResult> CheckNameAvailabilityStorageSyncService(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, Azure.ResourceManager.StorageSync.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityStorageSyncServiceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, Azure.ResourceManager.StorageSync.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StorageSync.CloudEndpointResource GetCloudEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StorageSync.RegisteredServerResource GetRegisteredServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StorageSync.ServerEndpointResource GetServerEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource GetStorageSyncPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> GetStorageSyncService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageSyncServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServiceResource>> GetStorageSyncServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageSyncServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StorageSync.StorageSyncServiceResource GetStorageSyncServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StorageSync.StorageSyncServiceCollection GetStorageSyncServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> GetStorageSyncServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> GetStorageSyncServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StorageSync.SyncGroupResource GetSyncGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StorageSync.WorkflowResource GetWorkflowResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.StorageSync.Models.LocationOperationStatus> LocationOperationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.Models.LocationOperationStatus>> LocationOperationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public string StorageSyncServiceUid { get { throw null; } }
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
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.RegisteredServerResource> GetRegisteredServer(string serverId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.RegisteredServerResource>> GetRegisteredServerAsync(string serverId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageSync.RegisteredServerCollection GetRegisteredServers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource> GetStorageSyncPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionResource>> GetStorageSyncPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionCollection GetStorageSyncPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.SyncGroupResource> GetSyncGroup(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.SyncGroupResource>> GetSyncGroupAsync(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageSync.SyncGroupCollection GetSyncGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.WorkflowResource> GetWorkflow(string workflowId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.WorkflowResource>> GetWorkflowAsync(string workflowId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageSync.WorkflowCollection GetWorkflows() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.StorageSyncServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.StorageSyncServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.StorageSyncServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.StorageSyncServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.StorageSyncServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SyncGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageSync.SyncGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.SyncGroupResource>, System.Collections.IEnumerable
    {
        protected SyncGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.SyncGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string syncGroupName, Azure.ResourceManager.StorageSync.Models.SyncGroupCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.SyncGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string syncGroupName, Azure.ResourceManager.StorageSync.Models.SyncGroupCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.SyncGroupResource> Get(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageSync.SyncGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageSync.SyncGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.SyncGroupResource>> GetAsync(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageSync.SyncGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageSync.SyncGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageSync.SyncGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.SyncGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SyncGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public SyncGroupData() { }
        public string SyncGroupStatus { get { throw null; } }
        public string UniqueId { get { throw null; } }
    }
    public partial class SyncGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SyncGroupResource() { }
        public virtual Azure.ResourceManager.StorageSync.SyncGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageSyncServiceName, string syncGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.SyncGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.SyncGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.CloudEndpointResource> GetCloudEndpoint(string cloudEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.CloudEndpointResource>> GetCloudEndpointAsync(string cloudEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageSync.CloudEndpointCollection GetCloudEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.ServerEndpointResource> GetServerEndpoint(string serverEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.ServerEndpointResource>> GetServerEndpointAsync(string serverEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageSync.ServerEndpointCollection GetServerEndpoints() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.SyncGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.SyncGroupCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageSync.SyncGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageSync.Models.SyncGroupCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkflowCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageSync.WorkflowResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.WorkflowResource>, System.Collections.IEnumerable
    {
        protected WorkflowCollection() { }
        public virtual Azure.Response<bool> Exists(string workflowId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workflowId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.WorkflowResource> Get(string workflowId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageSync.WorkflowResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageSync.WorkflowResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.WorkflowResource>> GetAsync(string workflowId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageSync.WorkflowResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageSync.WorkflowResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageSync.WorkflowResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageSync.WorkflowResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkflowData : Azure.ResourceManager.Models.ResourceData
    {
        public WorkflowData() { }
        public string CommandName { get { throw null; } }
        public System.DateTimeOffset? CreatedTimestamp { get { throw null; } }
        public string LastOperationId { get { throw null; } set { } }
        public System.DateTimeOffset? LastStatusTimestamp { get { throw null; } }
        public string LastStepName { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.OperationDirection? Operation { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.WorkflowStatus? Status { get { throw null; } set { } }
        public string Steps { get { throw null; } set { } }
    }
    public partial class WorkflowResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkflowResource() { }
        public virtual Azure.ResourceManager.StorageSync.WorkflowData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Abort(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AbortAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageSyncServiceName, string workflowId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageSync.WorkflowResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageSync.WorkflowResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.StorageSync.Models
{
    public partial class BackupRequest
    {
        public BackupRequest() { }
        public string AzureFileShare { get { throw null; } set { } }
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
    public partial class CheckNameAvailabilityContent
    {
        public CheckNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.Type ResourceType { get { throw null; } }
    }
    public partial class CheckNameAvailabilityResult
    {
        internal CheckNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.NameAvailabilityReason? Reason { get { throw null; } }
    }
    public partial class CloudEndpointChangeEnumerationActivity
    {
        internal CloudEndpointChangeEnumerationActivity() { }
        public int? DeletesProgressPercent { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedTimestamp { get { throw null; } }
        public int? MinutesRemaining { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationActivityState? OperationState { get { throw null; } }
        public long? ProcessedDirectoriesCount { get { throw null; } }
        public long? ProcessedFilesCount { get { throw null; } }
        public int? ProgressPercent { get { throw null; } }
        public System.DateTimeOffset? StartedTimestamp { get { throw null; } }
        public int? StatusCode { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.CloudEndpointChangeEnumerationTotalCountsState? TotalCountsState { get { throw null; } }
        public long? TotalDirectoriesCount { get { throw null; } }
        public long? TotalFilesCount { get { throw null; } }
        public long? TotalSizeBytes { get { throw null; } }
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
        public System.DateTimeOffset? LastUpdatedTimestamp { get { throw null; } }
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
        public string StorageAccountResourceId { get { throw null; } set { } }
        public string StorageAccountTenantId { get { throw null; } set { } }
    }
    public partial class CloudEndpointLastChangeEnumerationStatus
    {
        internal CloudEndpointLastChangeEnumerationStatus() { }
        public System.DateTimeOffset? CompletedTimestamp { get { throw null; } }
        public long? NamespaceDirectoriesCount { get { throw null; } }
        public long? NamespaceFilesCount { get { throw null; } }
        public long? NamespaceSizeBytes { get { throw null; } }
        public System.DateTimeOffset? NextRunTimestamp { get { throw null; } }
        public System.DateTimeOffset? StartedTimestamp { get { throw null; } }
    }
    public partial class CloudTieringCachePerformance
    {
        internal CloudTieringCachePerformance() { }
        public long? CacheHitBytes { get { throw null; } }
        public int? CacheHitBytesPercent { get { throw null; } }
        public long? CacheMissBytes { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedTimestamp { get { throw null; } }
    }
    public partial class CloudTieringDatePolicyStatus
    {
        internal CloudTieringDatePolicyStatus() { }
        public System.DateTimeOffset? LastUpdatedTimestamp { get { throw null; } }
        public System.DateTimeOffset? TieredFilesMostRecentAccessTimestamp { get { throw null; } }
    }
    public partial class CloudTieringFilesNotTiering
    {
        internal CloudTieringFilesNotTiering() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StorageSync.Models.FilesNotTieringError> Errors { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedTimestamp { get { throw null; } }
        public long? TotalFileCount { get { throw null; } }
    }
    public partial class CloudTieringSpaceSavings
    {
        internal CloudTieringSpaceSavings() { }
        public long? CachedSizeBytes { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedTimestamp { get { throw null; } }
        public long? SpaceSavingsBytes { get { throw null; } }
        public int? SpaceSavingsPercent { get { throw null; } }
        public long? TotalSizeCloudBytes { get { throw null; } }
        public long? VolumeSizeBytes { get { throw null; } }
    }
    public partial class CloudTieringVolumeFreeSpacePolicyStatus
    {
        internal CloudTieringVolumeFreeSpacePolicyStatus() { }
        public int? CurrentVolumeFreeSpacePercent { get { throw null; } }
        public int? EffectiveVolumeFreeSpacePolicy { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedTimestamp { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FeatureStatus : System.IEquatable<Azure.ResourceManager.StorageSync.Models.FeatureStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FeatureStatus(string value) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.FeatureStatus Off { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.FeatureStatus On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageSync.Models.FeatureStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageSync.Models.FeatureStatus left, Azure.ResourceManager.StorageSync.Models.FeatureStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageSync.Models.FeatureStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageSync.Models.FeatureStatus left, Azure.ResourceManager.StorageSync.Models.FeatureStatus right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class LocationOperationStatus
    {
        internal LocationOperationStatus() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.StorageSyncApiError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public enum NameAvailabilityReason
    {
        Invalid = 0,
        AlreadyExists = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationDirection : System.IEquatable<Azure.ResourceManager.StorageSync.Models.OperationDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationDirection(string value) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.OperationDirection Cancel { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.OperationDirection Do { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.OperationDirection Undo { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageSync.Models.OperationDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageSync.Models.OperationDirection left, Azure.ResourceManager.StorageSync.Models.OperationDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageSync.Models.OperationDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageSync.Models.OperationDirection left, Azure.ResourceManager.StorageSync.Models.OperationDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostBackupResponse
    {
        internal PostBackupResponse() { }
        public string CloudEndpointName { get { throw null; } }
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
    public partial class RegisteredServerCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public RegisteredServerCreateOrUpdateContent() { }
        public string AgentVersion { get { throw null; } set { } }
        public string ClusterId { get { throw null; } set { } }
        public string ClusterName { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string LastHeartBeat { get { throw null; } set { } }
        public string ServerCertificate { get { throw null; } set { } }
        public string ServerId { get { throw null; } set { } }
        public string ServerOSVersion { get { throw null; } set { } }
        public string ServerRole { get { throw null; } set { } }
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
        public System.DateTimeOffset? StartedTimestamp { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class ServerEndpointCloudTieringStatus
    {
        internal ServerEndpointCloudTieringStatus() { }
        public Azure.ResourceManager.StorageSync.Models.CloudTieringCachePerformance CachePerformance { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.CloudTieringDatePolicyStatus DatePolicyStatus { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.CloudTieringFilesNotTiering FilesNotTiering { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState? Health { get { throw null; } }
        public System.DateTimeOffset? HealthLastUpdatedTimestamp { get { throw null; } }
        public int? LastCloudTieringResult { get { throw null; } }
        public System.DateTimeOffset? LastSuccessTimestamp { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedTimestamp { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.CloudTieringSpaceSavings SpaceSavings { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.CloudTieringVolumeFreeSpacePolicyStatus VolumeFreeSpacePolicyStatus { get { throw null; } }
    }
    public partial class ServerEndpointCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public ServerEndpointCreateOrUpdateContent() { }
        public Azure.ResourceManager.StorageSync.Models.FeatureStatus? CloudTiering { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.InitialDownloadPolicy? InitialDownloadPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.InitialUploadPolicy? InitialUploadPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.LocalCacheMode? LocalCacheMode { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.FeatureStatus? OfflineDataTransfer { get { throw null; } set { } }
        public string OfflineDataTransferShareName { get { throw null; } set { } }
        public string ServerLocalPath { get { throw null; } set { } }
        public string ServerResourceId { get { throw null; } set { } }
        public int? TierFilesOlderThanDays { get { throw null; } set { } }
        public int? VolumeFreeSpacePercent { get { throw null; } set { } }
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
    public partial class ServerEndpointPatch
    {
        public ServerEndpointPatch() { }
        public Azure.ResourceManager.StorageSync.Models.FeatureStatus? CloudTiering { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.LocalCacheMode? LocalCacheMode { get { throw null; } set { } }
        public Azure.ResourceManager.StorageSync.Models.FeatureStatus? OfflineDataTransfer { get { throw null; } set { } }
        public string OfflineDataTransferShareName { get { throw null; } set { } }
        public int? TierFilesOlderThanDays { get { throw null; } set { } }
        public int? VolumeFreeSpacePercent { get { throw null; } set { } }
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
        public System.DateTimeOffset? LastUpdatedTimestamp { get { throw null; } }
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
        public System.DateTimeOffset? LastUpdatedTimestamp { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointOfflineDataTransferState? OfflineDataTransferStatus { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncActivityState? SyncActivity { get { throw null; } }
        public long? TotalPersistentFilesNotSyncingCount { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncActivityStatus UploadActivity { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointHealthState? UploadHealth { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.ServerEndpointSyncSessionStatus UploadStatus { get { throw null; } }
    }
    public partial class StorageSyncApiError
    {
        internal StorageSyncApiError() { }
        public string Code { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.StorageSyncErrorDetails Details { get { throw null; } }
        public Azure.ResourceManager.StorageSync.Models.StorageSyncInnerErrorDetails Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class StorageSyncErrorDetails
    {
        internal StorageSyncErrorDetails() { }
        public string Code { get { throw null; } }
        public string ExceptionType { get { throw null; } }
        public string HashedMessage { get { throw null; } }
        public string HttpErrorCode { get { throw null; } }
        public string HttpMethod { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Uri RequestUri { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class StorageSyncInnerErrorDetails
    {
        internal StorageSyncInnerErrorDetails() { }
        public string CallStack { get { throw null; } }
        public string InnerException { get { throw null; } }
        public string InnerExceptionCallStack { get { throw null; } }
        public string Message { get { throw null; } }
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
    public partial class SyncGroupCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public SyncGroupCreateOrUpdateContent() { }
        public System.BinaryData Properties { get { throw null; } set { } }
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
        public string ServerCertificate { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Type : System.IEquatable<Azure.ResourceManager.StorageSync.Models.Type>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Type(string value) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.Type MicrosoftStorageSyncStorageSyncServices { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageSync.Models.Type other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageSync.Models.Type left, Azure.ResourceManager.StorageSync.Models.Type right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageSync.Models.Type (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageSync.Models.Type left, Azure.ResourceManager.StorageSync.Models.Type right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkflowStatus : System.IEquatable<Azure.ResourceManager.StorageSync.Models.WorkflowStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkflowStatus(string value) { throw null; }
        public static Azure.ResourceManager.StorageSync.Models.WorkflowStatus Aborted { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.WorkflowStatus Active { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.WorkflowStatus Expired { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.WorkflowStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.StorageSync.Models.WorkflowStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageSync.Models.WorkflowStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageSync.Models.WorkflowStatus left, Azure.ResourceManager.StorageSync.Models.WorkflowStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageSync.Models.WorkflowStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageSync.Models.WorkflowStatus left, Azure.ResourceManager.StorageSync.Models.WorkflowStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
