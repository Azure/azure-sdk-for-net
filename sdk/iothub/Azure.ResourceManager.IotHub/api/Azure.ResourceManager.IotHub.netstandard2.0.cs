namespace Azure.ResourceManager.IotHub
{
    public partial class EventHubConsumerGroupInfoCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource>, System.Collections.IEnumerable
    {
        protected EventHubConsumerGroupInfoCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.IotHub.Models.EventHubConsumerGroupInfoCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.IotHub.Models.EventHubConsumerGroupInfoCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource>.GetEnumerator() { throw null; }
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
        public virtual Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string eventHubEndpointName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.Models.EventHubConsumerGroupInfoCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.Models.EventHubConsumerGroupInfoCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotHubCertificateDescriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource>, System.Collections.IEnumerable
    {
        protected IotHubCertificateDescriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource> Get(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource>> GetAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotHubCertificateDescriptionData : Azure.ResourceManager.Models.ResourceData
    {
        public IotHubCertificateDescriptionData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubCertificateProperties Properties { get { throw null; } set { } }
    }
    public partial class IotHubCertificateDescriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotHubCertificateDescriptionResource() { }
        public virtual Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string certificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubCertificateWithNonceDescription> GenerateVerificationCode(string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubCertificateWithNonceDescription>> GenerateVerificationCodeAsync(string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource> Verify(string ifMatch, Azure.ResourceManager.IotHub.Models.IotHubCertificateVerificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource>> VerifyAsync(string ifMatch, Azure.ResourceManager.IotHub.Models.IotHubCertificateVerificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotHubDescriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.IotHubDescriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.IotHubDescriptionResource>, System.Collections.IEnumerable
    {
        protected IotHubDescriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubDescriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.IotHub.IotHubDescriptionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.IotHub.IotHubDescriptionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.IotHubDescriptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.IotHubDescriptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotHub.IotHubDescriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.IotHubDescriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotHub.IotHubDescriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.IotHubDescriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotHubDescriptionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public IotHubDescriptionData(Azure.Core.AzureLocation location, Azure.ResourceManager.IotHub.Models.IotHubSkuInfo sku) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubSkuInfo Sku { get { throw null; } set { } }
    }
    public partial class IotHubDescriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotHubDescriptionResource() { }
        public virtual Azure.ResourceManager.IotHub.IotHubDescriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubDescriptionResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubJobInfo> ExportDevices(Azure.ResourceManager.IotHub.Models.ExportDevicesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubJobInfo>> ExportDevicesAsync(Azure.ResourceManager.IotHub.Models.ExportDevicesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationCollection GetAllIotHubPrivateEndpointGroupInformation() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthInfo> GetEndpointHealth(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthInfo> GetEndpointHealthAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource> GetEventHubConsumerGroupInfo(string eventHubEndpointName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource>> GetEventHubConsumerGroupInfoAsync(string eventHubEndpointName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoCollection GetEventHubConsumerGroupInfos(string eventHubEndpointName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource> GetIotHubCertificateDescription(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource>> GetIotHubCertificateDescriptionAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotHub.IotHubCertificateDescriptionCollection GetIotHubCertificateDescriptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource> GetIotHubPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource>> GetIotHubPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionCollection GetIotHubPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource> GetIotHubPrivateEndpointGroupInformation(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource>> GetIotHubPrivateEndpointGroupInformationAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubJobInfo> GetJob(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubJobInfo>> GetJobAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.Models.IotHubJobInfo> GetJobs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.Models.IotHubJobInfo> GetJobsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule> GetKeysForKeyName(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule>> GetKeysForKeyNameAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.Models.IotHubQuotaMetricInfo> GetQuotaMetrics(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.Models.IotHubQuotaMetricInfo> GetQuotaMetricsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubRegistryStatistics> GetStats(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubRegistryStatistics>> GetStatsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.Models.IotHubSkuDescription> GetValidSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.Models.IotHubSkuDescription> GetValidSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubJobInfo> ImportDevices(Azure.ResourceManager.IotHub.Models.IotHubImportDevicesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubJobInfo>> ImportDevicesAsync(Azure.ResourceManager.IotHub.Models.IotHubImportDevicesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ManualFailoverIotHub(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.Models.IotHubFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ManualFailoverIotHubAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.Models.IotHubFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesResult> TestAllRoutes(Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesResult>> TestAllRoutesAsync(Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubTestRouteResult> TestRoute(Azure.ResourceManager.IotHub.Models.IotHubTestRouteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubTestRouteResult>> TestRouteAsync(Azure.ResourceManager.IotHub.Models.IotHubTestRouteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubDescriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.Models.IotHubDescriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.Models.IotHubDescriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class IotHubExtensions
    {
        public static Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityResponse> CheckIotHubNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityResponse>> CheckIotHubNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource GetEventHubConsumerGroupInfoResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource GetIotHubCertificateDescriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource> GetIotHubDescription(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> GetIotHubDescriptionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IotHub.IotHubDescriptionResource GetIotHubDescriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotHub.IotHubDescriptionCollection GetIotHubDescriptions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IotHub.IotHubDescriptionResource> GetIotHubDescriptions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IotHub.IotHubDescriptionResource> GetIotHubDescriptionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource GetIotHubPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource GetIotHubPrivateEndpointGroupInformationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IotHub.Models.IotHubUserSubscriptionQuota> GetIotHubUserSubscriptionQuota(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IotHub.Models.IotHubUserSubscriptionQuota> GetIotHubUserSubscriptionQuotaAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotHubPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected IotHubPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotHubPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public IotHubPrivateEndpointConnectionData(Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointConnectionProperties properties) { }
        public Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
    }
    public partial class IotHubPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotHubPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotHubPrivateEndpointGroupInformationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource>, System.Collections.IEnumerable
    {
        protected IotHubPrivateEndpointGroupInformationCollection() { }
        public virtual Azure.Response<bool> Exists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource> Get(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource>> GetAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotHubPrivateEndpointGroupInformationData : Azure.ResourceManager.Models.ResourceData
    {
        internal IotHubPrivateEndpointGroupInformationData() { }
        public Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointGroupInformationProperties Properties { get { throw null; } }
    }
    public partial class IotHubPrivateEndpointGroupInformationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotHubPrivateEndpointGroupInformationResource() { }
        public virtual Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string groupId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.IotHub.Mock
{
    public partial class IotHubDescriptionResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected IotHubDescriptionResourceExtensionClient() { }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityResponse> CheckIotHubNameAvailability(Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityResponse>> CheckIotHubNameAvailabilityAsync(Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.IotHubDescriptionResource> GetIotHubDescriptions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.IotHubDescriptionResource> GetIotHubDescriptionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ResourceGroupResourceExtensionClient() { }
        public virtual Azure.ResourceManager.IotHub.IotHubDescriptionCollection GetIotHubDescriptions() { throw null; }
    }
    public partial class SubscriptionResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected SubscriptionResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.Models.IotHubUserSubscriptionQuota> GetIotHubUserSubscriptionQuota(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.Models.IotHubUserSubscriptionQuota> GetIotHubUserSubscriptionQuotaAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.IotHub.Models
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
        public Azure.ResourceManager.IotHub.Models.CloudToDeviceFeedbackQueueProperties Feedback { get { throw null; } set { } }
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
        public Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string ConfigurationsBlobName { get { throw null; } set { } }
        public bool ExcludeKeys { get { throw null; } }
        public System.Uri ExportBlobContainerUri { get { throw null; } }
        public string ExportBlobName { get { throw null; } set { } }
        public bool? IncludeConfigurations { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubAuthenticationType : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType IdentityBased { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType KeyBased { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType left, Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType left, Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubCapability : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubCapability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubCapability(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubCapability DeviceManagement { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubCapability None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubCapability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubCapability left, Azure.ResourceManager.IotHub.Models.IotHubCapability right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubCapability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubCapability left, Azure.ResourceManager.IotHub.Models.IotHubCapability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubCapacity
    {
        internal IotHubCapacity() { }
        public long? Default { get { throw null; } }
        public long? Maximum { get { throw null; } }
        public long? Minimum { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubScaleType? ScaleType { get { throw null; } }
    }
    public partial class IotHubCertificateProperties
    {
        public IotHubCertificateProperties() { }
        public System.BinaryData Certificate { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public bool? IsVerified { get { throw null; } set { } }
        public string Subject { get { throw null; } }
        public System.BinaryData Thumbprint { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
    }
    public partial class IotHubCertificatePropertiesWithNonce
    {
        internal IotHubCertificatePropertiesWithNonce() { }
        public System.BinaryData Certificate { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public bool? IsVerified { get { throw null; } }
        public string Subject { get { throw null; } }
        public System.BinaryData Thumbprint { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public string VerificationCode { get { throw null; } }
    }
    public partial class IotHubCertificateVerificationContent
    {
        public IotHubCertificateVerificationContent() { }
        public System.BinaryData Certificate { get { throw null; } set { } }
    }
    public partial class IotHubCertificateWithNonceDescription : Azure.ResourceManager.Models.ResourceData
    {
        internal IotHubCertificateWithNonceDescription() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubCertificatePropertiesWithNonce Properties { get { throw null; } }
    }
    public partial class IotHubDescriptionPatch
    {
        public IotHubDescriptionPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class IotHubEndpointHealthInfo
    {
        internal IotHubEndpointHealthInfo() { }
        public string EndpointId { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus? HealthStatus { get { throw null; } }
        public string LastKnownError { get { throw null; } }
        public System.DateTimeOffset? LastKnownErrorOn { get { throw null; } }
        public System.DateTimeOffset? LastSendAttemptOn { get { throw null; } }
        public System.DateTimeOffset? LastSuccessfulSendAttemptOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubEndpointHealthStatus : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubEndpointHealthStatus(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus Dead { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus Degraded { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus left, Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus left, Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubEnrichmentProperties
    {
        public IotHubEnrichmentProperties(string key, string value, System.Collections.Generic.IEnumerable<string> endpointNames) { }
        public System.Collections.Generic.IList<string> EndpointNames { get { throw null; } }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class IotHubFailoverContent
    {
        public IotHubFailoverContent(string failoverRegion) { }
        public string FailoverRegion { get { throw null; } }
    }
    public partial class IotHubFallbackRouteProperties
    {
        public IotHubFallbackRouteProperties(Azure.ResourceManager.IotHub.Models.IotHubRoutingSource source, System.Collections.Generic.IEnumerable<string> endpointNames, bool isEnabled) { }
        public string Condition { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EndpointNames { get { throw null; } }
        public bool IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubRoutingSource Source { get { throw null; } set { } }
    }
    public partial class IotHubImportDevicesContent
    {
        public IotHubImportDevicesContent(System.Uri inputBlobContainerUri, System.Uri outputBlobContainerUri) { }
        public Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string ConfigurationsBlobName { get { throw null; } set { } }
        public bool? IncludeConfigurations { get { throw null; } set { } }
        public System.Uri InputBlobContainerUri { get { throw null; } }
        public string InputBlobName { get { throw null; } set { } }
        public System.Uri OutputBlobContainerUri { get { throw null; } }
        public string OutputBlobName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
    }
    public enum IotHubIPFilterActionType
    {
        Accept = 0,
        Reject = 1,
    }
    public partial class IotHubIPFilterRule
    {
        public IotHubIPFilterRule(string filterName, Azure.ResourceManager.IotHub.Models.IotHubIPFilterActionType action, string ipMask) { }
        public Azure.ResourceManager.IotHub.Models.IotHubIPFilterActionType Action { get { throw null; } set { } }
        public string FilterName { get { throw null; } set { } }
        public string IPMask { get { throw null; } set { } }
    }
    public partial class IotHubJobInfo
    {
        internal IotHubJobInfo() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string FailureReason { get { throw null; } }
        public string JobId { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubJobType? JobType { get { throw null; } }
        public string ParentJobId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubJobStatus? Status { get { throw null; } }
        public string StatusMessage { get { throw null; } }
    }
    public enum IotHubJobStatus
    {
        Unknown = 0,
        Enqueued = 1,
        Running = 2,
        Completed = 3,
        Failed = 4,
        Cancelled = 5,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubJobType : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubJobType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubJobType(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubJobType Backup { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubJobType Export { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubJobType FactoryResetDevice { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubJobType FirmwareUpdate { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubJobType Import { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubJobType ReadDeviceProperties { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubJobType RebootDevice { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubJobType Unknown { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubJobType UpdateDeviceConfiguration { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubJobType WriteDeviceProperties { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubJobType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubJobType left, Azure.ResourceManager.IotHub.Models.IotHubJobType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubJobType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubJobType left, Azure.ResourceManager.IotHub.Models.IotHubJobType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubLocationDescription
    {
        internal IotHubLocationDescription() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubReplicaRoleType? Role { get { throw null; } }
    }
    public partial class IotHubMatchedRoute
    {
        internal IotHubMatchedRoute() { }
        public Azure.ResourceManager.IotHub.Models.RoutingRuleProperties Properties { get { throw null; } }
    }
    public partial class IotHubNameAvailabilityContent
    {
        public IotHubNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
    }
    public partial class IotHubNameAvailabilityResponse
    {
        internal IotHubNameAvailabilityResponse() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubNameUnavailableReason? Reason { get { throw null; } }
    }
    public enum IotHubNameUnavailableReason
    {
        Invalid = 0,
        AlreadyExists = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubNetworkRuleIPAction : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleIPAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubNetworkRuleIPAction(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleIPAction Allow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleIPAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleIPAction left, Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleIPAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleIPAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleIPAction left, Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleIPAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubNetworkRuleSetDefaultAction : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetDefaultAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubNetworkRuleSetDefaultAction(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetDefaultAction Allow { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetDefaultAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetDefaultAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetDefaultAction left, Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetDefaultAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetDefaultAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetDefaultAction left, Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetDefaultAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubNetworkRuleSetIPRule
    {
        public IotHubNetworkRuleSetIPRule(string filterName, string ipMask) { }
        public Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleIPAction? Action { get { throw null; } set { } }
        public string FilterName { get { throw null; } set { } }
        public string IPMask { get { throw null; } set { } }
    }
    public partial class IotHubNetworkRuleSetProperties
    {
        public IotHubNetworkRuleSetProperties(bool applyToBuiltInEventHubEndpoint, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetIPRule> ipRules) { }
        public bool ApplyToBuiltInEventHubEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetDefaultAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetIPRule> IPRules { get { throw null; } }
    }
    public partial class IotHubPrivateEndpointConnectionProperties
    {
        public IotHubPrivateEndpointConnectionProperties(Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionState connectionState) { }
        public Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
    }
    public partial class IotHubPrivateEndpointGroupInformationProperties
    {
        internal IotHubPrivateEndpointGroupInformationProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredDnsZoneNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
    }
    public partial class IotHubPrivateLinkServiceConnectionState
    {
        public IotHubPrivateLinkServiceConnectionState(Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus status, string description) { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubPrivateLinkServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubPrivateLinkServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubProperties
    {
        public IotHubProperties() { }
        public System.Collections.Generic.IList<string> AllowedFqdns { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule> AuthorizationPolicies { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.CloudToDeviceProperties CloudToDevice { get { throw null; } set { } }
        public string Comments { get { throw null; } set { } }
        public bool? DisableDeviceSas { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? DisableModuleSas { get { throw null; } set { } }
        public bool? EnableDataResidency { get { throw null; } set { } }
        public bool? EnableFileUploadNotifications { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.IotHub.Models.EventHubCompatibleEndpointProperties> EventHubEndpoints { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubCapability? Features { get { throw null; } set { } }
        public string HostName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.IotHubIPFilterRule> IPFilterRules { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IotHub.Models.IotHubLocationDescription> Locations { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.IotHub.Models.MessagingEndpointProperties> MessagingEndpoints { get { throw null; } }
        public string MinTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetProperties NetworkRuleSets { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public bool? RestrictOutboundNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubRoutingProperties Routing { get { throw null; } set { } }
        public string State { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.IotHub.Models.IotHubStorageEndpointProperties> StorageEndpoints { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubPublicNetworkAccess left, Azure.ResourceManager.IotHub.Models.IotHubPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubPublicNetworkAccess left, Azure.ResourceManager.IotHub.Models.IotHubPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubQuotaMetricInfo
    {
        internal IotHubQuotaMetricInfo() { }
        public long? CurrentValue { get { throw null; } }
        public long? MaxValue { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class IotHubRegistryStatistics
    {
        internal IotHubRegistryStatistics() { }
        public long? DisabledDeviceCount { get { throw null; } }
        public long? EnabledDeviceCount { get { throw null; } }
        public long? TotalDeviceCount { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubReplicaRoleType : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubReplicaRoleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubReplicaRoleType(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubReplicaRoleType Primary { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubReplicaRoleType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubReplicaRoleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubReplicaRoleType left, Azure.ResourceManager.IotHub.Models.IotHubReplicaRoleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubReplicaRoleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubReplicaRoleType left, Azure.ResourceManager.IotHub.Models.IotHubReplicaRoleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubRoutingProperties
    {
        public IotHubRoutingProperties() { }
        public Azure.ResourceManager.IotHub.Models.RoutingEndpoints Endpoints { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.IotHubEnrichmentProperties> Enrichments { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubFallbackRouteProperties FallbackRoute { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.RoutingRuleProperties> Routes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubRoutingSource : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubRoutingSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubRoutingSource(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubRoutingSource DeviceConnectionStateEvents { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubRoutingSource DeviceJobLifecycleEvents { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubRoutingSource DeviceLifecycleEvents { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubRoutingSource DeviceMessages { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubRoutingSource Invalid { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubRoutingSource TwinChangeEvents { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubRoutingSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubRoutingSource left, Azure.ResourceManager.IotHub.Models.IotHubRoutingSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubRoutingSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubRoutingSource left, Azure.ResourceManager.IotHub.Models.IotHubRoutingSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum IotHubScaleType
    {
        None = 0,
        Automatic = 1,
        Manual = 2,
    }
    public enum IotHubSharedAccessRight
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
    public readonly partial struct IotHubSku : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubSku(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubSku B1 { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubSku B2 { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubSku B3 { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubSku F1 { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubSku S1 { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubSku S2 { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubSku S3 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubSku left, Azure.ResourceManager.IotHub.Models.IotHubSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubSku left, Azure.ResourceManager.IotHub.Models.IotHubSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubSkuDescription
    {
        internal IotHubSkuDescription() { }
        public Azure.ResourceManager.IotHub.Models.IotHubCapacity Capacity { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubSkuInfo Sku { get { throw null; } }
    }
    public partial class IotHubSkuInfo
    {
        public IotHubSkuInfo(Azure.ResourceManager.IotHub.Models.IotHubSku name) { }
        public long? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubSku Name { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubSkuTier? Tier { get { throw null; } }
    }
    public enum IotHubSkuTier
    {
        Free = 0,
        Standard = 1,
        Basic = 2,
    }
    public partial class IotHubStorageEndpointProperties
    {
        public IotHubStorageEndpointProperties(string connectionString, string containerName) { }
        public Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public System.TimeSpan? SasTtlAsIso8601 { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
    }
    public partial class IotHubTestAllRoutesContent
    {
        public IotHubTestAllRoutesContent() { }
        public Azure.ResourceManager.IotHub.Models.RoutingMessage Message { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubRoutingSource? RoutingSource { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.RoutingTwin Twin { get { throw null; } set { } }
    }
    public partial class IotHubTestAllRoutesResult
    {
        internal IotHubTestAllRoutesResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IotHub.Models.IotHubMatchedRoute> Routes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubTestResultStatus : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubTestResultStatus(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus False { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus True { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus Undefined { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus left, Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus left, Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubTestRouteContent
    {
        public IotHubTestRouteContent(Azure.ResourceManager.IotHub.Models.RoutingRuleProperties route) { }
        public Azure.ResourceManager.IotHub.Models.RoutingMessage Message { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.RoutingRuleProperties Route { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.RoutingTwin Twin { get { throw null; } set { } }
    }
    public partial class IotHubTestRouteResult
    {
        internal IotHubTestRouteResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IotHub.Models.RouteCompilationError> DetailsCompilationErrors { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus? Result { get { throw null; } }
    }
    public partial class IotHubTypeName
    {
        internal IotHubTypeName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class IotHubUserSubscriptionQuota
    {
        internal IotHubUserSubscriptionQuota() { }
        public int? CurrentValue { get { throw null; } }
        public string IotHubTypeId { get { throw null; } }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubTypeName Name { get { throw null; } }
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
        public Azure.ResourceManager.IotHub.Models.RouteErrorRange Location { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.RouteErrorSeverity? Severity { get { throw null; } }
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
        public Azure.ResourceManager.IotHub.Models.RouteErrorPosition End { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.RouteErrorPosition Start { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RouteErrorSeverity : System.IEquatable<Azure.ResourceManager.IotHub.Models.RouteErrorSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RouteErrorSeverity(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.RouteErrorSeverity Error { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.RouteErrorSeverity Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.RouteErrorSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.RouteErrorSeverity left, Azure.ResourceManager.IotHub.Models.RouteErrorSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.RouteErrorSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.RouteErrorSeverity left, Azure.ResourceManager.IotHub.Models.RouteErrorSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoutingEndpoints
    {
        public RoutingEndpoints() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.RoutingEventHubProperties> EventHubs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.RoutingServiceBusQueueEndpointProperties> ServiceBusQueues { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.RoutingServiceBusTopicEndpointProperties> ServiceBusTopics { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.RoutingStorageContainerProperties> StorageContainers { get { throw null; } }
    }
    public partial class RoutingEventHubProperties
    {
        public RoutingEventHubProperties(string name) { }
        public Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType? AuthenticationType { get { throw null; } set { } }
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
        public RoutingRuleProperties(string name, Azure.ResourceManager.IotHub.Models.IotHubRoutingSource source, System.Collections.Generic.IEnumerable<string> endpointNames, bool isEnabled) { }
        public string Condition { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EndpointNames { get { throw null; } }
        public bool IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubRoutingSource Source { get { throw null; } set { } }
    }
    public partial class RoutingServiceBusQueueEndpointProperties
    {
        public RoutingServiceBusQueueEndpointProperties(string name) { }
        public Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType? AuthenticationType { get { throw null; } set { } }
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
        public Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType? AuthenticationType { get { throw null; } set { } }
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
        public Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public int? BatchFrequencyInSeconds { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.RoutingStorageContainerPropertiesEncoding? Encoding { get { throw null; } set { } }
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
    public readonly partial struct RoutingStorageContainerPropertiesEncoding : System.IEquatable<Azure.ResourceManager.IotHub.Models.RoutingStorageContainerPropertiesEncoding>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoutingStorageContainerPropertiesEncoding(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.RoutingStorageContainerPropertiesEncoding Avro { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.RoutingStorageContainerPropertiesEncoding AvroDeflate { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.RoutingStorageContainerPropertiesEncoding Json { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.RoutingStorageContainerPropertiesEncoding other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.RoutingStorageContainerPropertiesEncoding left, Azure.ResourceManager.IotHub.Models.RoutingStorageContainerPropertiesEncoding right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.RoutingStorageContainerPropertiesEncoding (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.RoutingStorageContainerPropertiesEncoding left, Azure.ResourceManager.IotHub.Models.RoutingStorageContainerPropertiesEncoding right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoutingTwin
    {
        public RoutingTwin() { }
        public Azure.ResourceManager.IotHub.Models.RoutingTwinProperties Properties { get { throw null; } set { } }
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
        public SharedAccessSignatureAuthorizationRule(string keyName, Azure.ResourceManager.IotHub.Models.IotHubSharedAccessRight rights) { }
        public string KeyName { get { throw null; } set { } }
        public string PrimaryKey { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubSharedAccessRight Rights { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
    }
}
