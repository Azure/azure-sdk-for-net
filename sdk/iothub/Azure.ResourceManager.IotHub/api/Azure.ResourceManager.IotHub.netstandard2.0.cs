namespace Azure.ResourceManager.IotHub
{
    public partial class CertificateDescriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.CertificateDescriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.CertificateDescriptionResource>, System.Collections.IEnumerable
    {
        protected CertificateDescriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.CertificateDescriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.IotHub.CertificateDescriptionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.CertificateDescriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.IotHub.CertificateDescriptionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.CertificateDescriptionResource> Get(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.CertificateDescriptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.CertificateDescriptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.CertificateDescriptionResource>> GetAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotHub.CertificateDescriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.CertificateDescriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotHub.CertificateDescriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.CertificateDescriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CertificateDescriptionData : Azure.ResourceManager.Models.ResourceData
    {
        public CertificateDescriptionData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.CertificateProperties Properties { get { throw null; } set { } }
    }
    public partial class CertificateDescriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CertificateDescriptionResource() { }
        public virtual Azure.ResourceManager.IotHub.CertificateDescriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string certificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.CertificateWithNonceDescription> GenerateVerificationCode(string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.CertificateWithNonceDescription>> GenerateVerificationCodeAsync(string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.CertificateDescriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.CertificateDescriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.CertificateDescriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.CertificateDescriptionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.CertificateDescriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.CertificateDescriptionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.CertificateDescriptionResource> Verify(string ifMatch, Azure.ResourceManager.IotHub.Models.CertificateVerificationDescription certificateVerificationBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.CertificateDescriptionResource>> VerifyAsync(string ifMatch, Azure.ResourceManager.IotHub.Models.CertificateVerificationDescription certificateVerificationBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
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
    public partial class GroupIdInformationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.GroupIdInformationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.GroupIdInformationResource>, System.Collections.IEnumerable
    {
        protected GroupIdInformationCollection() { }
        public virtual Azure.Response<bool> Exists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.GroupIdInformationResource> Get(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.GroupIdInformationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.GroupIdInformationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.GroupIdInformationResource>> GetAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotHub.GroupIdInformationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.GroupIdInformationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotHub.GroupIdInformationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.GroupIdInformationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GroupIdInformationData : Azure.ResourceManager.Models.ResourceData
    {
        internal GroupIdInformationData() { }
        public Azure.ResourceManager.IotHub.Models.GroupIdInformationProperties Properties { get { throw null; } }
    }
    public partial class GroupIdInformationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GroupIdInformationResource() { }
        public virtual Azure.ResourceManager.IotHub.GroupIdInformationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string groupId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.GroupIdInformationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.GroupIdInformationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.JobResponse> ExportDevices(Azure.ResourceManager.IotHub.Models.ExportDevicesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.JobResponse>> ExportDevicesAsync(Azure.ResourceManager.IotHub.Models.ExportDevicesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotHub.GroupIdInformationCollection GetAllGroupIdInformation() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.CertificateDescriptionResource> GetCertificateDescription(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.CertificateDescriptionResource>> GetCertificateDescriptionAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotHub.CertificateDescriptionCollection GetCertificateDescriptions() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.Models.EndpointHealthData> GetEndpointHealth(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.Models.EndpointHealthData> GetEndpointHealthAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource> GetEventHubConsumerGroupInfo(string eventHubEndpointName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource>> GetEventHubConsumerGroupInfoAsync(string eventHubEndpointName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoCollection GetEventHubConsumerGroupInfos(string eventHubEndpointName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.GroupIdInformationResource> GetGroupIdInformation(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.GroupIdInformationResource>> GetGroupIdInformationAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource> GetIotHubPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource>> GetIotHubPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionCollection GetIotHubPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.JobResponse> GetJob(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.JobResponse>> GetJobAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.Models.JobResponse> GetJobs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.Models.JobResponse> GetJobsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule> GetKeysForKeyName(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule>> GetKeysForKeyNameAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.Models.IotHubQuotaMetricInfo> GetQuotaMetrics(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.Models.IotHubQuotaMetricInfo> GetQuotaMetricsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.RegistryStatistics> GetStats(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.RegistryStatistics>> GetStatsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.Models.IotHubSkuDescription> GetValidSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.Models.IotHubSkuDescription> GetValidSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.JobResponse> ImportDevices(Azure.ResourceManager.IotHub.Models.ImportDevicesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.JobResponse>> ImportDevicesAsync(Azure.ResourceManager.IotHub.Models.ImportDevicesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ManualFailoverIotHub(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.Models.FailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ManualFailoverIotHubAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.Models.FailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesResult> TestAllRoutes(Azure.ResourceManager.IotHub.Models.TestAllRoutesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesResult>> TestAllRoutesAsync(Azure.ResourceManager.IotHub.Models.TestAllRoutesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubTestRouteResult> TestRoute(Azure.ResourceManager.IotHub.Models.IotHubTestRouteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubTestRouteResult>> TestRouteAsync(Azure.ResourceManager.IotHub.Models.IotHubTestRouteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubDescriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.Models.IotHubDescriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.Models.IotHubDescriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class IotHubExtensions
    {
        public static Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityInfo> CheckNameAvailabilityIotHubResource(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.IotHub.Models.OperationInputs operationInputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityInfo>> CheckNameAvailabilityIotHubResourceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.IotHub.Models.OperationInputs operationInputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IotHub.CertificateDescriptionResource GetCertificateDescriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource GetEventHubConsumerGroupInfoResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotHub.GroupIdInformationResource GetGroupIdInformationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource> GetIotHubDescription(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> GetIotHubDescriptionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IotHub.IotHubDescriptionResource GetIotHubDescriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotHub.IotHubDescriptionCollection GetIotHubDescriptions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IotHub.IotHubDescriptionResource> GetIotHubDescriptions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IotHub.IotHubDescriptionResource> GetIotHubDescriptionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource GetIotHubPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IotHub.Models.UserSubscriptionQuota> GetSubscriptionQuotaResourceProviderCommons(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IotHub.Models.UserSubscriptionQuota> GetSubscriptionQuotaResourceProviderCommonsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public IotHubPrivateEndpointConnectionData(Azure.ResourceManager.IotHub.Models.PrivateEndpointConnectionProperties properties) { }
        public Azure.ResourceManager.IotHub.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
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
}
namespace Azure.ResourceManager.IotHub.Models
{
    public enum AccessRight
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
    public readonly partial struct AuthenticationType : System.IEquatable<Azure.ResourceManager.IotHub.Models.AuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.AuthenticationType IdentityBased { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.AuthenticationType KeyBased { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.AuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.AuthenticationType left, Azure.ResourceManager.IotHub.Models.AuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.AuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.AuthenticationType left, Azure.ResourceManager.IotHub.Models.AuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Capability : System.IEquatable<Azure.ResourceManager.IotHub.Models.Capability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Capability(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.Capability DeviceManagement { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.Capability None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.Capability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.Capability left, Azure.ResourceManager.IotHub.Models.Capability right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.Capability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.Capability left, Azure.ResourceManager.IotHub.Models.Capability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CertificateProperties
    {
        public CertificateProperties() { }
        public string Certificate { get { throw null; } set { } }
        public System.DateTimeOffset? Created { get { throw null; } }
        public System.DateTimeOffset? Expiry { get { throw null; } }
        public bool? IsVerified { get { throw null; } set { } }
        public string Subject { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        public System.DateTimeOffset? Updated { get { throw null; } }
    }
    public partial class CertificatePropertiesWithNonce
    {
        internal CertificatePropertiesWithNonce() { }
        public string Certificate { get { throw null; } }
        public System.DateTimeOffset? Created { get { throw null; } }
        public System.DateTimeOffset? Expiry { get { throw null; } }
        public bool? IsVerified { get { throw null; } }
        public string Subject { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        public System.DateTimeOffset? Updated { get { throw null; } }
        public string VerificationCode { get { throw null; } }
    }
    public partial class CertificateVerificationDescription
    {
        public CertificateVerificationDescription() { }
        public string Certificate { get { throw null; } set { } }
    }
    public partial class CertificateWithNonceDescription : Azure.ResourceManager.Models.ResourceData
    {
        internal CertificateWithNonceDescription() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.CertificatePropertiesWithNonce Properties { get { throw null; } }
    }
    public partial class CloudToDeviceProperties
    {
        public CloudToDeviceProperties() { }
        public System.TimeSpan? DefaultTtlAsIso8601 { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.FeedbackProperties Feedback { get { throw null; } set { } }
        public int? MaxDeliveryCount { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DefaultAction : System.IEquatable<Azure.ResourceManager.IotHub.Models.DefaultAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefaultAction(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.DefaultAction Allow { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.DefaultAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.DefaultAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.DefaultAction left, Azure.ResourceManager.IotHub.Models.DefaultAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.DefaultAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.DefaultAction left, Azure.ResourceManager.IotHub.Models.DefaultAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EndpointHealthData
    {
        internal EndpointHealthData() { }
        public string EndpointId { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.EndpointHealthStatus? HealthStatus { get { throw null; } }
        public string LastKnownError { get { throw null; } }
        public System.DateTimeOffset? LastKnownErrorOn { get { throw null; } }
        public System.DateTimeOffset? LastSendAttemptOn { get { throw null; } }
        public System.DateTimeOffset? LastSuccessfulSendAttemptOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointHealthStatus : System.IEquatable<Azure.ResourceManager.IotHub.Models.EndpointHealthStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointHealthStatus(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.EndpointHealthStatus Dead { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.EndpointHealthStatus Degraded { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.EndpointHealthStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.EndpointHealthStatus Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.EndpointHealthStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.EndpointHealthStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.EndpointHealthStatus left, Azure.ResourceManager.IotHub.Models.EndpointHealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.EndpointHealthStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.EndpointHealthStatus left, Azure.ResourceManager.IotHub.Models.EndpointHealthStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnrichmentProperties
    {
        public EnrichmentProperties(string key, string value, System.Collections.Generic.IEnumerable<string> endpointNames) { }
        public System.Collections.Generic.IList<string> EndpointNames { get { throw null; } }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class EventHubConsumerGroupInfoCreateOrUpdateContent
    {
        public EventHubConsumerGroupInfoCreateOrUpdateContent(Azure.ResourceManager.IotHub.Models.EventHubConsumerGroupName properties) { }
        public string EventHubConsumerGroupName { get { throw null; } }
    }
    public partial class EventHubConsumerGroupName
    {
        public EventHubConsumerGroupName(string name) { }
        public string Name { get { throw null; } }
    }
    public partial class EventHubProperties
    {
        public EventHubProperties() { }
        public string Endpoint { get { throw null; } }
        public int? PartitionCount { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> PartitionIds { get { throw null; } }
        public string Path { get { throw null; } }
        public long? RetentionTimeInDays { get { throw null; } set { } }
    }
    public partial class ExportDevicesContent
    {
        public ExportDevicesContent(System.Uri exportBlobContainerUri, bool excludeKeys) { }
        public Azure.ResourceManager.IotHub.Models.AuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string ConfigurationsBlobName { get { throw null; } set { } }
        public bool ExcludeKeys { get { throw null; } }
        public System.Uri ExportBlobContainerUri { get { throw null; } }
        public string ExportBlobName { get { throw null; } set { } }
        public bool? IncludeConfigurations { get { throw null; } set { } }
        public string UserAssignedIdentity { get { throw null; } set { } }
    }
    public partial class FailoverContent
    {
        public FailoverContent(string failoverRegion) { }
        public string FailoverRegion { get { throw null; } }
    }
    public partial class FallbackRouteProperties
    {
        public FallbackRouteProperties(Azure.ResourceManager.IotHub.Models.RoutingSource source, System.Collections.Generic.IEnumerable<string> endpointNames, bool isEnabled) { }
        public string Condition { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EndpointNames { get { throw null; } }
        public bool IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.RoutingSource Source { get { throw null; } set { } }
    }
    public partial class FeedbackProperties
    {
        public FeedbackProperties() { }
        public System.TimeSpan? LockDurationAsIso8601 { get { throw null; } set { } }
        public int? MaxDeliveryCount { get { throw null; } set { } }
        public System.TimeSpan? TtlAsIso8601 { get { throw null; } set { } }
    }
    public partial class GroupIdInformationProperties
    {
        internal GroupIdInformationProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class ImportDevicesContent
    {
        public ImportDevicesContent(System.Uri inputBlobContainerUri, System.Uri outputBlobContainerUri) { }
        public Azure.ResourceManager.IotHub.Models.AuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string ConfigurationsBlobName { get { throw null; } set { } }
        public bool? IncludeConfigurations { get { throw null; } set { } }
        public System.Uri InputBlobContainerUri { get { throw null; } }
        public string InputBlobName { get { throw null; } set { } }
        public System.Uri OutputBlobContainerUri { get { throw null; } }
        public string OutputBlobName { get { throw null; } set { } }
        public string UserAssignedIdentity { get { throw null; } set { } }
    }
    public partial class IotHubCapacity
    {
        internal IotHubCapacity() { }
        public long? Default { get { throw null; } }
        public long? Maximum { get { throw null; } }
        public long? Minimum { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubScaleType? ScaleType { get { throw null; } }
    }
    public partial class IotHubDescriptionPatch
    {
        public IotHubDescriptionPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class IotHubLocationDescription
    {
        internal IotHubLocationDescription() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubReplicaRoleType? Role { get { throw null; } }
    }
    public partial class IotHubNameAvailabilityInfo
    {
        internal IotHubNameAvailabilityInfo() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubNameUnavailabilityReason? Reason { get { throw null; } }
    }
    public enum IotHubNameUnavailabilityReason
    {
        Invalid = 0,
        AlreadyExists = 1,
    }
    public partial class IotHubPrivateLinkServiceConnectionState
    {
        public IotHubPrivateLinkServiceConnectionState(Azure.ResourceManager.IotHub.Models.PrivateLinkServiceConnectionStatus status, string description) { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.PrivateLinkServiceConnectionStatus Status { get { throw null; } set { } }
    }
    public partial class IotHubProperties
    {
        public IotHubProperties() { }
        public System.Collections.Generic.IList<string> AllowedFqdnList { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule> AuthorizationPolicies { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.CloudToDeviceProperties CloudToDevice { get { throw null; } set { } }
        public string Comments { get { throw null; } set { } }
        public bool? DisableDeviceSAS { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? DisableModuleSAS { get { throw null; } set { } }
        public bool? EnableDataResidency { get { throw null; } set { } }
        public bool? EnableFileUploadNotifications { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.IotHub.Models.EventHubProperties> EventHubEndpoints { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.Capability? Features { get { throw null; } set { } }
        public string HostName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.IPFilterRule> IPFilterRules { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IotHub.Models.IotHubLocationDescription> Locations { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.IotHub.Models.MessagingEndpointProperties> MessagingEndpoints { get { throw null; } }
        public string MinTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.NetworkRuleSetProperties NetworkRuleSets { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public bool? RestrictOutboundNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.RoutingProperties Routing { get { throw null; } set { } }
        public string State { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.IotHub.Models.StorageEndpointProperties> StorageEndpoints { get { throw null; } }
    }
    public partial class IotHubQuotaMetricInfo
    {
        internal IotHubQuotaMetricInfo() { }
        public long? CurrentValue { get { throw null; } }
        public long? MaxValue { get { throw null; } }
        public string Name { get { throw null; } }
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
    public enum IotHubScaleType
    {
        None = 0,
        Automatic = 1,
        Manual = 2,
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
        public string ResourceType { get { throw null; } }
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
    public partial class IotHubTestAllRoutesResult
    {
        internal IotHubTestAllRoutesResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IotHub.Models.MatchedRoute> Routes { get { throw null; } }
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
        public IotHubTestRouteContent(Azure.ResourceManager.IotHub.Models.RouteProperties route) { }
        public Azure.ResourceManager.IotHub.Models.RoutingMessage Message { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.RouteProperties Route { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.RoutingTwin Twin { get { throw null; } set { } }
    }
    public partial class IotHubTestRouteResult
    {
        internal IotHubTestRouteResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IotHub.Models.RouteCompilationError> DetailsCompilationErrors { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus? Result { get { throw null; } }
    }
    public enum IPFilterActionType
    {
        Accept = 0,
        Reject = 1,
    }
    public partial class IPFilterRule
    {
        public IPFilterRule(string filterName, Azure.ResourceManager.IotHub.Models.IPFilterActionType action, string ipMask) { }
        public Azure.ResourceManager.IotHub.Models.IPFilterActionType Action { get { throw null; } set { } }
        public string FilterName { get { throw null; } set { } }
        public string IPMask { get { throw null; } set { } }
    }
    public partial class JobResponse
    {
        internal JobResponse() { }
        public System.DateTimeOffset? EndTimeUtc { get { throw null; } }
        public string FailureReason { get { throw null; } }
        public string JobId { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.JobType? JobType { get { throw null; } }
        public string ParentJobId { get { throw null; } }
        public System.DateTimeOffset? StartTimeUtc { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.JobStatus? Status { get { throw null; } }
        public string StatusMessage { get { throw null; } }
    }
    public enum JobStatus
    {
        Unknown = 0,
        Enqueued = 1,
        Running = 2,
        Completed = 3,
        Failed = 4,
        Cancelled = 5,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobType : System.IEquatable<Azure.ResourceManager.IotHub.Models.JobType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobType(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.JobType Backup { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.JobType Export { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.JobType FactoryResetDevice { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.JobType FirmwareUpdate { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.JobType Import { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.JobType ReadDeviceProperties { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.JobType RebootDevice { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.JobType Unknown { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.JobType UpdateDeviceConfiguration { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.JobType WriteDeviceProperties { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.JobType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.JobType left, Azure.ResourceManager.IotHub.Models.JobType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.JobType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.JobType left, Azure.ResourceManager.IotHub.Models.JobType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MatchedRoute
    {
        internal MatchedRoute() { }
        public Azure.ResourceManager.IotHub.Models.RouteProperties Properties { get { throw null; } }
    }
    public partial class MessagingEndpointProperties
    {
        public MessagingEndpointProperties() { }
        public System.TimeSpan? LockDurationAsIso8601 { get { throw null; } set { } }
        public int? MaxDeliveryCount { get { throw null; } set { } }
        public System.TimeSpan? TtlAsIso8601 { get { throw null; } set { } }
    }
    public partial class Name
    {
        internal Name() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkRuleIPAction : System.IEquatable<Azure.ResourceManager.IotHub.Models.NetworkRuleIPAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkRuleIPAction(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.NetworkRuleIPAction Allow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.NetworkRuleIPAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.NetworkRuleIPAction left, Azure.ResourceManager.IotHub.Models.NetworkRuleIPAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.NetworkRuleIPAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.NetworkRuleIPAction left, Azure.ResourceManager.IotHub.Models.NetworkRuleIPAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkRuleSetIPRule
    {
        public NetworkRuleSetIPRule(string filterName, string ipMask) { }
        public Azure.ResourceManager.IotHub.Models.NetworkRuleIPAction? Action { get { throw null; } set { } }
        public string FilterName { get { throw null; } set { } }
        public string IPMask { get { throw null; } set { } }
    }
    public partial class NetworkRuleSetProperties
    {
        public NetworkRuleSetProperties(bool applyToBuiltInEventHubEndpoint, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.Models.NetworkRuleSetIPRule> ipRules) { }
        public bool ApplyToBuiltInEventHubEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.DefaultAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.NetworkRuleSetIPRule> IPRules { get { throw null; } }
    }
    public partial class OperationInputs
    {
        public OperationInputs(string name) { }
        public string Name { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionProperties
    {
        public PrivateEndpointConnectionProperties(Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionState connectionState) { }
        public Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateLinkServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.IotHub.Models.PrivateLinkServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateLinkServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.PrivateLinkServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.PrivateLinkServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.PrivateLinkServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.PrivateLinkServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.PrivateLinkServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.PrivateLinkServiceConnectionStatus left, Azure.ResourceManager.IotHub.Models.PrivateLinkServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.PrivateLinkServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.PrivateLinkServiceConnectionStatus left, Azure.ResourceManager.IotHub.Models.PrivateLinkServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.IotHub.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.PublicNetworkAccess left, Azure.ResourceManager.IotHub.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.PublicNetworkAccess left, Azure.ResourceManager.IotHub.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegistryStatistics
    {
        internal RegistryStatistics() { }
        public long? DisabledDeviceCount { get { throw null; } }
        public long? EnabledDeviceCount { get { throw null; } }
        public long? TotalDeviceCount { get { throw null; } }
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
    public partial class RouteProperties
    {
        public RouteProperties(string name, Azure.ResourceManager.IotHub.Models.RoutingSource source, System.Collections.Generic.IEnumerable<string> endpointNames, bool isEnabled) { }
        public string Condition { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EndpointNames { get { throw null; } }
        public bool IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.RoutingSource Source { get { throw null; } set { } }
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
        public Azure.ResourceManager.IotHub.Models.AuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public System.Uri EndpointUri { get { throw null; } set { } }
        public string EntityPath { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public string UserAssignedIdentity { get { throw null; } set { } }
    }
    public partial class RoutingMessage
    {
        public RoutingMessage() { }
        public System.Collections.Generic.IDictionary<string, string> AppProperties { get { throw null; } }
        public string Body { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SystemProperties { get { throw null; } }
    }
    public partial class RoutingProperties
    {
        public RoutingProperties() { }
        public Azure.ResourceManager.IotHub.Models.RoutingEndpoints Endpoints { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.EnrichmentProperties> Enrichments { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.FallbackRouteProperties FallbackRoute { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.RouteProperties> Routes { get { throw null; } }
    }
    public partial class RoutingServiceBusQueueEndpointProperties
    {
        public RoutingServiceBusQueueEndpointProperties(string name) { }
        public Azure.ResourceManager.IotHub.Models.AuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public System.Uri EndpointUri { get { throw null; } set { } }
        public string EntityPath { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public string UserAssignedIdentity { get { throw null; } set { } }
    }
    public partial class RoutingServiceBusTopicEndpointProperties
    {
        public RoutingServiceBusTopicEndpointProperties(string name) { }
        public Azure.ResourceManager.IotHub.Models.AuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public System.Uri EndpointUri { get { throw null; } set { } }
        public string EntityPath { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public string UserAssignedIdentity { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoutingSource : System.IEquatable<Azure.ResourceManager.IotHub.Models.RoutingSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoutingSource(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.RoutingSource DeviceConnectionStateEvents { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.RoutingSource DeviceJobLifecycleEvents { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.RoutingSource DeviceLifecycleEvents { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.RoutingSource DeviceMessages { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.RoutingSource Invalid { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.RoutingSource TwinChangeEvents { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.RoutingSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.RoutingSource left, Azure.ResourceManager.IotHub.Models.RoutingSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.RoutingSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.RoutingSource left, Azure.ResourceManager.IotHub.Models.RoutingSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoutingStorageContainerProperties
    {
        public RoutingStorageContainerProperties(string name, string containerName) { }
        public Azure.ResourceManager.IotHub.Models.AuthenticationType? AuthenticationType { get { throw null; } set { } }
        public int? BatchFrequencyInSeconds { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.RoutingStorageContainerPropertiesEncoding? Encoding { get { throw null; } set { } }
        public System.Uri EndpointUri { get { throw null; } set { } }
        public string FileNameFormat { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public int? MaxChunkSizeInBytes { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public string UserAssignedIdentity { get { throw null; } set { } }
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
        public SharedAccessSignatureAuthorizationRule(string keyName, Azure.ResourceManager.IotHub.Models.AccessRight rights) { }
        public string KeyName { get { throw null; } set { } }
        public string PrimaryKey { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.AccessRight Rights { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
    }
    public partial class StorageEndpointProperties
    {
        public StorageEndpointProperties(string connectionString, string containerName) { }
        public Azure.ResourceManager.IotHub.Models.AuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public System.TimeSpan? SasTtlAsIso8601 { get { throw null; } set { } }
        public string UserAssignedIdentity { get { throw null; } set { } }
    }
    public partial class TestAllRoutesContent
    {
        public TestAllRoutesContent() { }
        public Azure.ResourceManager.IotHub.Models.RoutingMessage Message { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.RoutingSource? RoutingSource { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.RoutingTwin Twin { get { throw null; } set { } }
    }
    public partial class UserSubscriptionQuota
    {
        internal UserSubscriptionQuota() { }
        public int? CurrentValue { get { throw null; } }
        public string Id { get { throw null; } }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.Name Name { get { throw null; } }
        public string Unit { get { throw null; } }
        public string UserSubscriptionQuotaType { get { throw null; } }
    }
}
