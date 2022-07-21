namespace Azure.ResourceManager.IoTHub
{
    public partial class EventHubConsumerGroupInfoCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTHub.EventHubConsumerGroupInfoResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTHub.EventHubConsumerGroupInfoResource>, System.Collections.IEnumerable
    {
        protected EventHubConsumerGroupInfoCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTHub.EventHubConsumerGroupInfoResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.IoTHub.Models.EventHubConsumerGroupInfoCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTHub.EventHubConsumerGroupInfoResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.IoTHub.Models.EventHubConsumerGroupInfoCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.EventHubConsumerGroupInfoResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTHub.EventHubConsumerGroupInfoResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTHub.EventHubConsumerGroupInfoResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.EventHubConsumerGroupInfoResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTHub.EventHubConsumerGroupInfoResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTHub.EventHubConsumerGroupInfoResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTHub.EventHubConsumerGroupInfoResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTHub.EventHubConsumerGroupInfoResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventHubConsumerGroupInfoData : Azure.ResourceManager.Models.ResourceData
    {
        internal EventHubConsumerGroupInfoData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Properties { get { throw null; } }
    }
    public partial class EventHubConsumerGroupInfoResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventHubConsumerGroupInfoResource() { }
        public virtual Azure.ResourceManager.IoTHub.EventHubConsumerGroupInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string eventHubEndpointName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.EventHubConsumerGroupInfoResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.EventHubConsumerGroupInfoResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTHub.EventHubConsumerGroupInfoResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTHub.Models.EventHubConsumerGroupInfoCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTHub.EventHubConsumerGroupInfoResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTHub.Models.EventHubConsumerGroupInfoCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IoTHubCertificateDescriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionResource>, System.Collections.IEnumerable
    {
        protected IoTHubCertificateDescriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionResource> Get(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionResource>> GetAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IoTHubCertificateDescriptionData : Azure.ResourceManager.Models.ResourceData
    {
        public IoTHubCertificateDescriptionData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.IoTHub.Models.IoTHubCertificateProperties Properties { get { throw null; } set { } }
    }
    public partial class IoTHubCertificateDescriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IoTHubCertificateDescriptionResource() { }
        public virtual Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string certificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.Models.IoTHubCertificateWithNonceDescription> GenerateVerificationCode(string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.Models.IoTHubCertificateWithNonceDescription>> GenerateVerificationCodeAsync(string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionResource> Verify(string ifMatch, Azure.ResourceManager.IoTHub.Models.IoTHubCertificateVerificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionResource>> VerifyAsync(string ifMatch, Azure.ResourceManager.IoTHub.Models.IoTHubCertificateVerificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotHubDescriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTHub.IotHubDescriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTHub.IotHubDescriptionResource>, System.Collections.IEnumerable
    {
        protected IotHubDescriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTHub.IotHubDescriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.IoTHub.IotHubDescriptionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTHub.IotHubDescriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.IoTHub.IotHubDescriptionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.IotHubDescriptionResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTHub.IotHubDescriptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTHub.IotHubDescriptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.IotHubDescriptionResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTHub.IotHubDescriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTHub.IotHubDescriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTHub.IotHubDescriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTHub.IotHubDescriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotHubDescriptionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public IotHubDescriptionData(Azure.Core.AzureLocation location, Azure.ResourceManager.IoTHub.Models.IotHubSkuInfo sku) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.IoTHub.Models.IotHubProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.IoTHub.Models.IotHubSkuInfo Sku { get { throw null; } set { } }
    }
    public partial class IotHubDescriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotHubDescriptionResource() { }
        public virtual Azure.ResourceManager.IoTHub.IotHubDescriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.IotHubDescriptionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.IotHubDescriptionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTHub.IotHubDescriptionResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTHub.IotHubDescriptionResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.Models.IoTHubJobInfo> ExportDevices(Azure.ResourceManager.IoTHub.Models.ExportDevicesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.Models.IoTHubJobInfo>> ExportDevicesAsync(Azure.ResourceManager.IoTHub.Models.ExportDevicesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.IotHubDescriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointGroupInformationCollection GetAllIoTHubPrivateEndpointGroupInformation() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.IotHubDescriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTHub.Models.IoTHubEndpointHealthInfo> GetEndpointHealth(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTHub.Models.IoTHubEndpointHealthInfo> GetEndpointHealthAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.EventHubConsumerGroupInfoResource> GetEventHubConsumerGroupInfo(string eventHubEndpointName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.EventHubConsumerGroupInfoResource>> GetEventHubConsumerGroupInfoAsync(string eventHubEndpointName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IoTHub.EventHubConsumerGroupInfoCollection GetEventHubConsumerGroupInfos(string eventHubEndpointName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionResource> GetIoTHubCertificateDescription(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionResource>> GetIoTHubCertificateDescriptionAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionCollection GetIoTHubCertificateDescriptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionResource> GetIoTHubPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionResource>> GetIoTHubPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionCollection GetIoTHubPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointGroupInformationResource> GetIoTHubPrivateEndpointGroupInformation(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointGroupInformationResource>> GetIoTHubPrivateEndpointGroupInformationAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.Models.IoTHubJobInfo> GetJob(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.Models.IoTHubJobInfo>> GetJobAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTHub.Models.IoTHubJobInfo> GetJobs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTHub.Models.IoTHubJobInfo> GetJobsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTHub.Models.SharedAccessSignatureAuthorizationRule> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTHub.Models.SharedAccessSignatureAuthorizationRule> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.Models.SharedAccessSignatureAuthorizationRule> GetKeysForKeyName(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.Models.SharedAccessSignatureAuthorizationRule>> GetKeysForKeyNameAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTHub.Models.IotHubQuotaMetricInfo> GetQuotaMetrics(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTHub.Models.IotHubQuotaMetricInfo> GetQuotaMetricsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.Models.IoTHubRegistryStatistics> GetStats(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.Models.IoTHubRegistryStatistics>> GetStatsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTHub.Models.IotHubSkuDescription> GetValidSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTHub.Models.IotHubSkuDescription> GetValidSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.Models.IoTHubJobInfo> ImportDevices(Azure.ResourceManager.IoTHub.Models.IoTHubImportDevicesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.Models.IoTHubJobInfo>> ImportDevicesAsync(Azure.ResourceManager.IoTHub.Models.IoTHubImportDevicesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ManualFailoverIotHub(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTHub.Models.IoTHubFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ManualFailoverIotHubAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTHub.Models.IoTHubFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.IotHubDescriptionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.IotHubDescriptionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.IotHubDescriptionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.IotHubDescriptionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.Models.IoTHubTestAllRoutesResult> TestAllRoutes(Azure.ResourceManager.IoTHub.Models.IoTHubTestAllRoutesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.Models.IoTHubTestAllRoutesResult>> TestAllRoutesAsync(Azure.ResourceManager.IoTHub.Models.IoTHubTestAllRoutesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.Models.IoTHubTestRouteResult> TestRoute(Azure.ResourceManager.IoTHub.Models.IoTHubTestRouteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.Models.IoTHubTestRouteResult>> TestRouteAsync(Azure.ResourceManager.IoTHub.Models.IoTHubTestRouteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTHub.IotHubDescriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTHub.Models.IotHubDescriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTHub.IotHubDescriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTHub.Models.IotHubDescriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class IoTHubExtensions
    {
        public static Azure.Response<Azure.ResourceManager.IoTHub.Models.IotHubNameAvailabilityInfo> CheckNameAvailabilityIotHubResource(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.IoTHub.Models.IoTHubNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.Models.IotHubNameAvailabilityInfo>> CheckNameAvailabilityIotHubResourceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.IoTHub.Models.IoTHubNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IoTHub.EventHubConsumerGroupInfoResource GetEventHubConsumerGroupInfoResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IoTHub.IoTHubCertificateDescriptionResource GetIoTHubCertificateDescriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.IoTHub.IotHubDescriptionResource> GetIotHubDescription(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.IotHubDescriptionResource>> GetIotHubDescriptionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IoTHub.IotHubDescriptionResource GetIotHubDescriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IoTHub.IotHubDescriptionCollection GetIotHubDescriptions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IoTHub.IotHubDescriptionResource> GetIotHubDescriptions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IoTHub.IotHubDescriptionResource> GetIotHubDescriptionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionResource GetIoTHubPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointGroupInformationResource GetIoTHubPrivateEndpointGroupInformationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IoTHub.Models.IoTHubUserSubscriptionQuota> GetIoTHubUserSubscriptionQuota(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IoTHub.Models.IoTHubUserSubscriptionQuota> GetIoTHubUserSubscriptionQuotaAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IoTHubPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected IoTHubPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IoTHubPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public IoTHubPrivateEndpointConnectionData(Azure.ResourceManager.IoTHub.Models.IoTHubPrivateEndpointConnectionProperties properties) { }
        public Azure.ResourceManager.IoTHub.Models.IoTHubPrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
    }
    public partial class IoTHubPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IoTHubPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IoTHubPrivateEndpointGroupInformationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointGroupInformationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointGroupInformationResource>, System.Collections.IEnumerable
    {
        protected IoTHubPrivateEndpointGroupInformationCollection() { }
        public virtual Azure.Response<bool> Exists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointGroupInformationResource> Get(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointGroupInformationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointGroupInformationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointGroupInformationResource>> GetAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointGroupInformationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointGroupInformationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointGroupInformationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointGroupInformationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IoTHubPrivateEndpointGroupInformationData : Azure.ResourceManager.Models.ResourceData
    {
        internal IoTHubPrivateEndpointGroupInformationData() { }
        public Azure.ResourceManager.IoTHub.Models.IoTHubPrivateEndpointGroupInformationProperties Properties { get { throw null; } }
    }
    public partial class IoTHubPrivateEndpointGroupInformationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IoTHubPrivateEndpointGroupInformationResource() { }
        public virtual Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointGroupInformationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string groupId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointGroupInformationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointGroupInformationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.IoTHub.Models
{
    public partial class CloudToDeviceFeedbackQueueProperties
    {
        public CloudToDeviceFeedbackQueueProperties() { }
        public System.TimeSpan? LockDurationAsIso8601 { get { throw null; } set { } }
        public int? MaxDeliveryCount { get { throw null; } set { } }
        public System.TimeSpan? TtlAsIso8601 { get { throw null; } set { } }
    }
    public partial class CloudToDeviceProperties
    {
        public CloudToDeviceProperties() { }
        public System.TimeSpan? DefaultTtlAsIso8601 { get { throw null; } set { } }
        public Azure.ResourceManager.IoTHub.Models.CloudToDeviceFeedbackQueueProperties Feedback { get { throw null; } set { } }
        public int? MaxDeliveryCount { get { throw null; } set { } }
    }
    public partial class EventHubCompatibleEndpointProperties
    {
        public EventHubCompatibleEndpointProperties() { }
        public string Endpoint { get { throw null; } }
        public string EventHubCompatibleName { get { throw null; } }
        public int? PartitionCount { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> PartitionIds { get { throw null; } }
        public long? RetentionTimeInDays { get { throw null; } set { } }
    }
    public partial class EventHubConsumerGroupInfoCreateOrUpdateContent
    {
        public EventHubConsumerGroupInfoCreateOrUpdateContent(string name) { }
        public string Name { get { throw null; } }
    }
    public partial class ExportDevicesContent
    {
        public ExportDevicesContent(System.Uri exportBlobContainerUri, bool excludeKeys) { }
        public Azure.ResourceManager.IoTHub.Models.IoTHubAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string ConfigurationsBlobName { get { throw null; } set { } }
        public bool ExcludeKeys { get { throw null; } }
        public System.Uri ExportBlobContainerUri { get { throw null; } }
        public string ExportBlobName { get { throw null; } set { } }
        public bool? IncludeConfigurations { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IoTHubAuthenticationType : System.IEquatable<Azure.ResourceManager.IoTHub.Models.IoTHubAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IoTHubAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubAuthenticationType IdentityBased { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubAuthenticationType KeyBased { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTHub.Models.IoTHubAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTHub.Models.IoTHubAuthenticationType left, Azure.ResourceManager.IoTHub.Models.IoTHubAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTHub.Models.IoTHubAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTHub.Models.IoTHubAuthenticationType left, Azure.ResourceManager.IoTHub.Models.IoTHubAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IoTHubCapability : System.IEquatable<Azure.ResourceManager.IoTHub.Models.IoTHubCapability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IoTHubCapability(string value) { throw null; }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubCapability DeviceManagement { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubCapability None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTHub.Models.IoTHubCapability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTHub.Models.IoTHubCapability left, Azure.ResourceManager.IoTHub.Models.IoTHubCapability right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTHub.Models.IoTHubCapability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTHub.Models.IoTHubCapability left, Azure.ResourceManager.IoTHub.Models.IoTHubCapability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubCapacity
    {
        internal IotHubCapacity() { }
        public long? Default { get { throw null; } }
        public long? Maximum { get { throw null; } }
        public long? Minimum { get { throw null; } }
        public Azure.ResourceManager.IoTHub.Models.IotHubScaleType? ScaleType { get { throw null; } }
    }
    public partial class IoTHubCertificateProperties
    {
        public IoTHubCertificateProperties() { }
        public System.BinaryData Certificate { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public bool? IsVerified { get { throw null; } set { } }
        public string Subject { get { throw null; } }
        public System.BinaryData Thumbprint { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
    }
    public partial class IoTHubCertificatePropertiesWithNonce
    {
        internal IoTHubCertificatePropertiesWithNonce() { }
        public System.BinaryData Certificate { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public bool? IsVerified { get { throw null; } }
        public string Subject { get { throw null; } }
        public System.BinaryData Thumbprint { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public string VerificationCode { get { throw null; } }
    }
    public partial class IoTHubCertificateVerificationContent
    {
        public IoTHubCertificateVerificationContent() { }
        public System.BinaryData Certificate { get { throw null; } set { } }
    }
    public partial class IoTHubCertificateWithNonceDescription : Azure.ResourceManager.Models.ResourceData
    {
        internal IoTHubCertificateWithNonceDescription() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.IoTHub.Models.IoTHubCertificatePropertiesWithNonce Properties { get { throw null; } }
    }
    public partial class IotHubDescriptionPatch
    {
        public IotHubDescriptionPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class IoTHubEndpointHealthInfo
    {
        internal IoTHubEndpointHealthInfo() { }
        public string EndpointId { get { throw null; } }
        public Azure.ResourceManager.IoTHub.Models.IoTHubEndpointHealthStatus? HealthStatus { get { throw null; } }
        public string LastKnownError { get { throw null; } }
        public System.DateTimeOffset? LastKnownErrorOn { get { throw null; } }
        public System.DateTimeOffset? LastSendAttemptOn { get { throw null; } }
        public System.DateTimeOffset? LastSuccessfulSendAttemptOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IoTHubEndpointHealthStatus : System.IEquatable<Azure.ResourceManager.IoTHub.Models.IoTHubEndpointHealthStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IoTHubEndpointHealthStatus(string value) { throw null; }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubEndpointHealthStatus Dead { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubEndpointHealthStatus Degraded { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubEndpointHealthStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubEndpointHealthStatus Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubEndpointHealthStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTHub.Models.IoTHubEndpointHealthStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTHub.Models.IoTHubEndpointHealthStatus left, Azure.ResourceManager.IoTHub.Models.IoTHubEndpointHealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTHub.Models.IoTHubEndpointHealthStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTHub.Models.IoTHubEndpointHealthStatus left, Azure.ResourceManager.IoTHub.Models.IoTHubEndpointHealthStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IoTHubEnrichmentProperties
    {
        public IoTHubEnrichmentProperties(string key, string value, System.Collections.Generic.IEnumerable<string> endpointNames) { }
        public System.Collections.Generic.IList<string> EndpointNames { get { throw null; } }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class IoTHubFailoverContent
    {
        public IoTHubFailoverContent(string failoverRegion) { }
        public string FailoverRegion { get { throw null; } }
    }
    public partial class IoTHubFallbackRouteProperties
    {
        public IoTHubFallbackRouteProperties(Azure.ResourceManager.IoTHub.Models.IoTHubRoutingSource source, System.Collections.Generic.IEnumerable<string> endpointNames, bool isEnabled) { }
        public string Condition { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EndpointNames { get { throw null; } }
        public bool IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.IoTHub.Models.IoTHubRoutingSource Source { get { throw null; } set { } }
    }
    public partial class IoTHubImportDevicesContent
    {
        public IoTHubImportDevicesContent(System.Uri inputBlobContainerUri, System.Uri outputBlobContainerUri) { }
        public Azure.ResourceManager.IoTHub.Models.IoTHubAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string ConfigurationsBlobName { get { throw null; } set { } }
        public bool? IncludeConfigurations { get { throw null; } set { } }
        public System.Uri InputBlobContainerUri { get { throw null; } }
        public string InputBlobName { get { throw null; } set { } }
        public System.Uri OutputBlobContainerUri { get { throw null; } }
        public string OutputBlobName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
    }
    public enum IoTHubIPFilterActionType
    {
        Accept = 0,
        Reject = 1,
    }
    public partial class IoTHubIPFilterRule
    {
        public IoTHubIPFilterRule(string filterName, Azure.ResourceManager.IoTHub.Models.IoTHubIPFilterActionType action, string ipMask) { }
        public Azure.ResourceManager.IoTHub.Models.IoTHubIPFilterActionType Action { get { throw null; } set { } }
        public string FilterName { get { throw null; } set { } }
        public string IPMask { get { throw null; } set { } }
    }
    public partial class IoTHubJobInfo
    {
        internal IoTHubJobInfo() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string FailureReason { get { throw null; } }
        public string JobId { get { throw null; } }
        public Azure.ResourceManager.IoTHub.Models.IoTHubJobType? JobType { get { throw null; } }
        public string ParentJobId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.IoTHub.Models.IoTHubJobStatus? Status { get { throw null; } }
        public string StatusMessage { get { throw null; } }
    }
    public enum IoTHubJobStatus
    {
        Unknown = 0,
        Enqueued = 1,
        Running = 2,
        Completed = 3,
        Failed = 4,
        Cancelled = 5,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IoTHubJobType : System.IEquatable<Azure.ResourceManager.IoTHub.Models.IoTHubJobType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IoTHubJobType(string value) { throw null; }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubJobType Backup { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubJobType Export { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubJobType FactoryResetDevice { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubJobType FirmwareUpdate { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubJobType Import { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubJobType ReadDeviceProperties { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubJobType RebootDevice { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubJobType Unknown { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubJobType UpdateDeviceConfiguration { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubJobType WriteDeviceProperties { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTHub.Models.IoTHubJobType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTHub.Models.IoTHubJobType left, Azure.ResourceManager.IoTHub.Models.IoTHubJobType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTHub.Models.IoTHubJobType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTHub.Models.IoTHubJobType left, Azure.ResourceManager.IoTHub.Models.IoTHubJobType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubLocationDescription
    {
        internal IotHubLocationDescription() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.IoTHub.Models.IotHubReplicaRoleType? Role { get { throw null; } }
    }
    public partial class IoTHubMatchedRoute
    {
        internal IoTHubMatchedRoute() { }
        public Azure.ResourceManager.IoTHub.Models.RoutingRuleProperties Properties { get { throw null; } }
    }
    public partial class IoTHubNameAvailabilityContent
    {
        public IoTHubNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
    }
    public partial class IotHubNameAvailabilityInfo
    {
        internal IotHubNameAvailabilityInfo() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.IoTHub.Models.IotHubNameUnavailabilityReason? Reason { get { throw null; } }
    }
    public enum IotHubNameUnavailabilityReason
    {
        Invalid = 0,
        AlreadyExists = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IoTHubNetworkRuleIPAction : System.IEquatable<Azure.ResourceManager.IoTHub.Models.IoTHubNetworkRuleIPAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IoTHubNetworkRuleIPAction(string value) { throw null; }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubNetworkRuleIPAction Allow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTHub.Models.IoTHubNetworkRuleIPAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTHub.Models.IoTHubNetworkRuleIPAction left, Azure.ResourceManager.IoTHub.Models.IoTHubNetworkRuleIPAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTHub.Models.IoTHubNetworkRuleIPAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTHub.Models.IoTHubNetworkRuleIPAction left, Azure.ResourceManager.IoTHub.Models.IoTHubNetworkRuleIPAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IoTHubNetworkRuleSetDefaultAction : System.IEquatable<Azure.ResourceManager.IoTHub.Models.IoTHubNetworkRuleSetDefaultAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IoTHubNetworkRuleSetDefaultAction(string value) { throw null; }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubNetworkRuleSetDefaultAction Allow { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubNetworkRuleSetDefaultAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTHub.Models.IoTHubNetworkRuleSetDefaultAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTHub.Models.IoTHubNetworkRuleSetDefaultAction left, Azure.ResourceManager.IoTHub.Models.IoTHubNetworkRuleSetDefaultAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTHub.Models.IoTHubNetworkRuleSetDefaultAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTHub.Models.IoTHubNetworkRuleSetDefaultAction left, Azure.ResourceManager.IoTHub.Models.IoTHubNetworkRuleSetDefaultAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IoTHubNetworkRuleSetIPRule
    {
        public IoTHubNetworkRuleSetIPRule(string filterName, string ipMask) { }
        public Azure.ResourceManager.IoTHub.Models.IoTHubNetworkRuleIPAction? Action { get { throw null; } set { } }
        public string FilterName { get { throw null; } set { } }
        public string IPMask { get { throw null; } set { } }
    }
    public partial class IoTHubNetworkRuleSetProperties
    {
        public IoTHubNetworkRuleSetProperties(bool applyToBuiltInEventHubEndpoint, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTHub.Models.IoTHubNetworkRuleSetIPRule> ipRules) { }
        public bool ApplyToBuiltInEventHubEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.IoTHub.Models.IoTHubNetworkRuleSetDefaultAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTHub.Models.IoTHubNetworkRuleSetIPRule> IPRules { get { throw null; } }
    }
    public partial class IoTHubPrivateEndpointConnectionProperties
    {
        public IoTHubPrivateEndpointConnectionProperties(Azure.ResourceManager.IoTHub.Models.IoTHubPrivateLinkServiceConnectionState connectionState) { }
        public Azure.ResourceManager.IoTHub.Models.IoTHubPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
    }
    public partial class IoTHubPrivateEndpointGroupInformationProperties
    {
        internal IoTHubPrivateEndpointGroupInformationProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredDnsZoneNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
    }
    public partial class IoTHubPrivateLinkServiceConnectionState
    {
        public IoTHubPrivateLinkServiceConnectionState(Azure.ResourceManager.IoTHub.Models.IoTHubPrivateLinkServiceConnectionStatus status, string description) { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.IoTHub.Models.IoTHubPrivateLinkServiceConnectionStatus Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IoTHubPrivateLinkServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.IoTHub.Models.IoTHubPrivateLinkServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IoTHubPrivateLinkServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubPrivateLinkServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubPrivateLinkServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubPrivateLinkServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubPrivateLinkServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTHub.Models.IoTHubPrivateLinkServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTHub.Models.IoTHubPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.IoTHub.Models.IoTHubPrivateLinkServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTHub.Models.IoTHubPrivateLinkServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTHub.Models.IoTHubPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.IoTHub.Models.IoTHubPrivateLinkServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubProperties
    {
        public IotHubProperties() { }
        public System.Collections.Generic.IList<string> AllowedFqdnList { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTHub.Models.SharedAccessSignatureAuthorizationRule> AuthorizationPolicies { get { throw null; } }
        public Azure.ResourceManager.IoTHub.Models.CloudToDeviceProperties CloudToDevice { get { throw null; } set { } }
        public string Comments { get { throw null; } set { } }
        public bool? DisableDeviceSas { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? DisableModuleSas { get { throw null; } set { } }
        public bool? EnableDataResidency { get { throw null; } set { } }
        public bool? EnableFileUploadNotifications { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.IoTHub.Models.EventHubCompatibleEndpointProperties> EventHubEndpoints { get { throw null; } }
        public Azure.ResourceManager.IoTHub.Models.IoTHubCapability? Features { get { throw null; } set { } }
        public string HostName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTHub.Models.IoTHubIPFilterRule> IPFilterRules { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IoTHub.Models.IotHubLocationDescription> Locations { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.IoTHub.Models.MessagingEndpointProperties> MessagingEndpoints { get { throw null; } }
        public string MinTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.IoTHub.Models.IoTHubNetworkRuleSetProperties NetworkRuleSets { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTHub.IoTHubPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IoTHub.Models.IoTHubPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public bool? RestrictOutboundNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.IoTHub.Models.IoTHubRoutingProperties Routing { get { throw null; } set { } }
        public string State { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.IoTHub.Models.IoTHubStorageEndpointProperties> StorageEndpoints { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IoTHubPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.IoTHub.Models.IoTHubPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IoTHubPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTHub.Models.IoTHubPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTHub.Models.IoTHubPublicNetworkAccess left, Azure.ResourceManager.IoTHub.Models.IoTHubPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTHub.Models.IoTHubPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTHub.Models.IoTHubPublicNetworkAccess left, Azure.ResourceManager.IoTHub.Models.IoTHubPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubQuotaMetricInfo
    {
        internal IotHubQuotaMetricInfo() { }
        public long? CurrentValue { get { throw null; } }
        public long? MaxValue { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class IoTHubRegistryStatistics
    {
        internal IoTHubRegistryStatistics() { }
        public long? DisabledDeviceCount { get { throw null; } }
        public long? EnabledDeviceCount { get { throw null; } }
        public long? TotalDeviceCount { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubReplicaRoleType : System.IEquatable<Azure.ResourceManager.IoTHub.Models.IotHubReplicaRoleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubReplicaRoleType(string value) { throw null; }
        public static Azure.ResourceManager.IoTHub.Models.IotHubReplicaRoleType Primary { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IotHubReplicaRoleType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTHub.Models.IotHubReplicaRoleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTHub.Models.IotHubReplicaRoleType left, Azure.ResourceManager.IoTHub.Models.IotHubReplicaRoleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTHub.Models.IotHubReplicaRoleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTHub.Models.IotHubReplicaRoleType left, Azure.ResourceManager.IoTHub.Models.IotHubReplicaRoleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IoTHubRoutingProperties
    {
        public IoTHubRoutingProperties() { }
        public Azure.ResourceManager.IoTHub.Models.RoutingEndpoints Endpoints { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTHub.Models.IoTHubEnrichmentProperties> Enrichments { get { throw null; } }
        public Azure.ResourceManager.IoTHub.Models.IoTHubFallbackRouteProperties FallbackRoute { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTHub.Models.RoutingRuleProperties> Routes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IoTHubRoutingSource : System.IEquatable<Azure.ResourceManager.IoTHub.Models.IoTHubRoutingSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IoTHubRoutingSource(string value) { throw null; }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubRoutingSource DeviceConnectionStateEvents { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubRoutingSource DeviceJobLifecycleEvents { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubRoutingSource DeviceLifecycleEvents { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubRoutingSource DeviceMessages { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubRoutingSource Invalid { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubRoutingSource TwinChangeEvents { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTHub.Models.IoTHubRoutingSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTHub.Models.IoTHubRoutingSource left, Azure.ResourceManager.IoTHub.Models.IoTHubRoutingSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTHub.Models.IoTHubRoutingSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTHub.Models.IoTHubRoutingSource left, Azure.ResourceManager.IoTHub.Models.IoTHubRoutingSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum IotHubScaleType
    {
        None = 0,
        Automatic = 1,
        Manual = 2,
    }
    public enum IoTHubSharedAccessRight
    {
        RegistryRead = 0,
        RegistryWrite = 1,
        ServiceConnect = 2,
        DeviceConnect = 3,
        RegistryReadRegistryWrite = 4,
        RegistryReadServiceConnect = 5,
        RegistryReadDeviceConnect = 6,
        RegistryWriteServiceConnect = 7,
        RegistryWriteDeviceConnect = 8,
        ServiceConnectDeviceConnect = 9,
        RegistryReadRegistryWriteServiceConnect = 10,
        RegistryReadRegistryWriteDeviceConnect = 11,
        RegistryReadServiceConnectDeviceConnect = 12,
        RegistryWriteServiceConnectDeviceConnect = 13,
        RegistryReadRegistryWriteServiceConnectDeviceConnect = 14,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubSku : System.IEquatable<Azure.ResourceManager.IoTHub.Models.IotHubSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubSku(string value) { throw null; }
        public static Azure.ResourceManager.IoTHub.Models.IotHubSku B1 { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IotHubSku B2 { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IotHubSku B3 { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IotHubSku F1 { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IotHubSku S1 { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IotHubSku S2 { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IotHubSku S3 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTHub.Models.IotHubSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTHub.Models.IotHubSku left, Azure.ResourceManager.IoTHub.Models.IotHubSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTHub.Models.IotHubSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTHub.Models.IotHubSku left, Azure.ResourceManager.IoTHub.Models.IotHubSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubSkuDescription
    {
        internal IotHubSkuDescription() { }
        public Azure.ResourceManager.IoTHub.Models.IotHubCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.IoTHub.Models.IotHubSkuInfo Sku { get { throw null; } }
    }
    public partial class IotHubSkuInfo
    {
        public IotHubSkuInfo(Azure.ResourceManager.IoTHub.Models.IotHubSku name) { }
        public long? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.IoTHub.Models.IotHubSku Name { get { throw null; } set { } }
        public Azure.ResourceManager.IoTHub.Models.IotHubSkuTier? Tier { get { throw null; } }
    }
    public enum IotHubSkuTier
    {
        Free = 0,
        Standard = 1,
        Basic = 2,
    }
    public partial class IoTHubStorageEndpointProperties
    {
        public IoTHubStorageEndpointProperties(string connectionString, string containerName) { }
        public Azure.ResourceManager.IoTHub.Models.IoTHubAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public System.TimeSpan? SasTtlAsIso8601 { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
    }
    public partial class IoTHubTestAllRoutesContent
    {
        public IoTHubTestAllRoutesContent() { }
        public Azure.ResourceManager.IoTHub.Models.RoutingMessage Message { get { throw null; } set { } }
        public Azure.ResourceManager.IoTHub.Models.IoTHubRoutingSource? RoutingSource { get { throw null; } set { } }
        public Azure.ResourceManager.IoTHub.Models.RoutingTwin Twin { get { throw null; } set { } }
    }
    public partial class IoTHubTestAllRoutesResult
    {
        internal IoTHubTestAllRoutesResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IoTHub.Models.IoTHubMatchedRoute> Routes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IoTHubTestResultStatus : System.IEquatable<Azure.ResourceManager.IoTHub.Models.IoTHubTestResultStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IoTHubTestResultStatus(string value) { throw null; }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubTestResultStatus False { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubTestResultStatus True { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.IoTHubTestResultStatus Undefined { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTHub.Models.IoTHubTestResultStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTHub.Models.IoTHubTestResultStatus left, Azure.ResourceManager.IoTHub.Models.IoTHubTestResultStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTHub.Models.IoTHubTestResultStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTHub.Models.IoTHubTestResultStatus left, Azure.ResourceManager.IoTHub.Models.IoTHubTestResultStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IoTHubTestRouteContent
    {
        public IoTHubTestRouteContent(Azure.ResourceManager.IoTHub.Models.RoutingRuleProperties route) { }
        public Azure.ResourceManager.IoTHub.Models.RoutingMessage Message { get { throw null; } set { } }
        public Azure.ResourceManager.IoTHub.Models.RoutingRuleProperties Route { get { throw null; } }
        public Azure.ResourceManager.IoTHub.Models.RoutingTwin Twin { get { throw null; } set { } }
    }
    public partial class IoTHubTestRouteResult
    {
        internal IoTHubTestRouteResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IoTHub.Models.RouteCompilationError> DetailsCompilationErrors { get { throw null; } }
        public Azure.ResourceManager.IoTHub.Models.IoTHubTestResultStatus? Result { get { throw null; } }
    }
    public partial class IoTHubTypeName
    {
        internal IoTHubTypeName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class IoTHubUserSubscriptionQuota
    {
        internal IoTHubUserSubscriptionQuota() { }
        public int? CurrentValue { get { throw null; } }
        public string IoTHubTypeId { get { throw null; } }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.IoTHub.Models.IoTHubTypeName Name { get { throw null; } }
        public string Unit { get { throw null; } }
        public string UserSubscriptionQuotaType { get { throw null; } }
    }
    public partial class MessagingEndpointProperties
    {
        public MessagingEndpointProperties() { }
        public System.TimeSpan? LockDurationAsIso8601 { get { throw null; } set { } }
        public int? MaxDeliveryCount { get { throw null; } set { } }
        public System.TimeSpan? TtlAsIso8601 { get { throw null; } set { } }
    }
    public partial class RouteCompilationError
    {
        internal RouteCompilationError() { }
        public Azure.ResourceManager.IoTHub.Models.RouteErrorRange Location { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.IoTHub.Models.RouteErrorSeverity? Severity { get { throw null; } }
    }
    public partial class RouteErrorPosition
    {
        internal RouteErrorPosition() { }
        public int? Column { get { throw null; } }
        public int? Line { get { throw null; } }
    }
    public partial class RouteErrorRange
    {
        internal RouteErrorRange() { }
        public Azure.ResourceManager.IoTHub.Models.RouteErrorPosition End { get { throw null; } }
        public Azure.ResourceManager.IoTHub.Models.RouteErrorPosition Start { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RouteErrorSeverity : System.IEquatable<Azure.ResourceManager.IoTHub.Models.RouteErrorSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RouteErrorSeverity(string value) { throw null; }
        public static Azure.ResourceManager.IoTHub.Models.RouteErrorSeverity Error { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.RouteErrorSeverity Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTHub.Models.RouteErrorSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTHub.Models.RouteErrorSeverity left, Azure.ResourceManager.IoTHub.Models.RouteErrorSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTHub.Models.RouteErrorSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTHub.Models.RouteErrorSeverity left, Azure.ResourceManager.IoTHub.Models.RouteErrorSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoutingEndpoints
    {
        public RoutingEndpoints() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTHub.Models.RoutingEventHubProperties> EventHubs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTHub.Models.RoutingServiceBusQueueEndpointProperties> ServiceBusQueues { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTHub.Models.RoutingServiceBusTopicEndpointProperties> ServiceBusTopics { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTHub.Models.RoutingStorageContainerProperties> StorageContainers { get { throw null; } }
    }
    public partial class RoutingEventHubProperties
    {
        public RoutingEventHubProperties(string name) { }
        public Azure.ResourceManager.IoTHub.Models.IoTHubAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string EntityPath { get { throw null; } set { } }
        public System.Guid? Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
    }
    public partial class RoutingMessage
    {
        public RoutingMessage() { }
        public System.Collections.Generic.IDictionary<string, string> AppProperties { get { throw null; } }
        public string Body { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SystemProperties { get { throw null; } }
    }
    public partial class RoutingRuleProperties
    {
        public RoutingRuleProperties(string name, Azure.ResourceManager.IoTHub.Models.IoTHubRoutingSource source, System.Collections.Generic.IEnumerable<string> endpointNames, bool isEnabled) { }
        public string Condition { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EndpointNames { get { throw null; } }
        public bool IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.IoTHub.Models.IoTHubRoutingSource Source { get { throw null; } set { } }
    }
    public partial class RoutingServiceBusQueueEndpointProperties
    {
        public RoutingServiceBusQueueEndpointProperties(string name) { }
        public Azure.ResourceManager.IoTHub.Models.IoTHubAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string EntityPath { get { throw null; } set { } }
        public System.Guid? Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
    }
    public partial class RoutingServiceBusTopicEndpointProperties
    {
        public RoutingServiceBusTopicEndpointProperties(string name) { }
        public Azure.ResourceManager.IoTHub.Models.IoTHubAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string EntityPath { get { throw null; } set { } }
        public System.Guid? Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
    }
    public partial class RoutingStorageContainerProperties
    {
        public RoutingStorageContainerProperties(string name, string containerName) { }
        public Azure.ResourceManager.IoTHub.Models.IoTHubAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public int? BatchFrequencyInSeconds { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public Azure.ResourceManager.IoTHub.Models.RoutingStorageContainerPropertiesEncoding? Encoding { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string FileNameFormat { get { throw null; } set { } }
        public System.Guid? Id { get { throw null; } set { } }
        public int? MaxChunkSizeInBytes { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoutingStorageContainerPropertiesEncoding : System.IEquatable<Azure.ResourceManager.IoTHub.Models.RoutingStorageContainerPropertiesEncoding>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoutingStorageContainerPropertiesEncoding(string value) { throw null; }
        public static Azure.ResourceManager.IoTHub.Models.RoutingStorageContainerPropertiesEncoding Avro { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.RoutingStorageContainerPropertiesEncoding AvroDeflate { get { throw null; } }
        public static Azure.ResourceManager.IoTHub.Models.RoutingStorageContainerPropertiesEncoding Json { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTHub.Models.RoutingStorageContainerPropertiesEncoding other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTHub.Models.RoutingStorageContainerPropertiesEncoding left, Azure.ResourceManager.IoTHub.Models.RoutingStorageContainerPropertiesEncoding right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTHub.Models.RoutingStorageContainerPropertiesEncoding (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTHub.Models.RoutingStorageContainerPropertiesEncoding left, Azure.ResourceManager.IoTHub.Models.RoutingStorageContainerPropertiesEncoding right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoutingTwin
    {
        public RoutingTwin() { }
        public Azure.ResourceManager.IoTHub.Models.RoutingTwinProperties Properties { get { throw null; } set { } }
        public System.BinaryData Tags { get { throw null; } set { } }
    }
    public partial class RoutingTwinProperties
    {
        public RoutingTwinProperties() { }
        public System.BinaryData Desired { get { throw null; } set { } }
        public System.BinaryData Reported { get { throw null; } set { } }
    }
    public partial class SharedAccessSignatureAuthorizationRule
    {
        public SharedAccessSignatureAuthorizationRule(string keyName, Azure.ResourceManager.IoTHub.Models.IoTHubSharedAccessRight rights) { }
        public string KeyName { get { throw null; } set { } }
        public string PrimaryKey { get { throw null; } set { } }
        public Azure.ResourceManager.IoTHub.Models.IoTHubSharedAccessRight Rights { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
    }
}
