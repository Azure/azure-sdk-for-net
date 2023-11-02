namespace Azure.ResourceManager.Batch
{
    public partial class BatchAccountCertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchAccountCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchAccountCertificateResource>, System.Collections.IEnumerable
    {
        protected BatchAccountCertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchAccountCertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.Batch.Models.BatchAccountCertificateCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchAccountCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.Batch.Models.BatchAccountCertificateCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource> Get(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.BatchAccountCertificateResource> GetAll(int? maxresults = default(int?), string select = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.BatchAccountCertificateResource> GetAllAsync(int? maxresults = default(int?), string select = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource>> GetAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Batch.BatchAccountCertificateResource> GetIfExists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Batch.BatchAccountCertificateResource>> GetIfExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Batch.BatchAccountCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchAccountCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Batch.BatchAccountCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchAccountCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchAccountCertificateData : Azure.ResourceManager.Models.ResourceData
    {
        public BatchAccountCertificateData() { }
        public Azure.ResponseError DeleteCertificateError { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchAccountCertificateFormat? Format { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState? PreviousProvisioningState { get { throw null; } }
        public System.DateTimeOffset? PreviousProvisioningStateTransitOn { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? ProvisioningStateTransitOn { get { throw null; } }
        public string PublicData { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Please use `ThumbprintString` instead.", false)]
        public System.BinaryData Thumbprint { get { throw null; } set { } }
        public string ThumbprintAlgorithm { get { throw null; } set { } }
        public string ThumbprintString { get { throw null; } set { } }
    }
    public partial class BatchAccountCertificateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BatchAccountCertificateResource() { }
        public virtual Azure.ResourceManager.Batch.BatchAccountCertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource> CancelDeletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource>> CancelDeletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string certificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource> Update(Azure.ResourceManager.Batch.Models.BatchAccountCertificateCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource>> UpdateAsync(Azure.ResourceManager.Batch.Models.BatchAccountCertificateCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchAccountResource>, System.Collections.IEnumerable
    {
        protected BatchAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Batch.Models.BatchAccountCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Batch.Models.BatchAccountCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.BatchAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.BatchAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Batch.BatchAccountResource> GetIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Batch.BatchAccountResource>> GetIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Batch.BatchAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Batch.BatchAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchAccountData : Azure.ResourceManager.Models.ResourceData
    {
        public BatchAccountData() { }
        public string AccountEndpoint { get { throw null; } }
        public int? ActiveJobAndJobScheduleQuota { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.Models.BatchAuthenticationMode> AllowedAuthenticationModes { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageConfiguration AutoStorage { get { throw null; } }
        public int? DedicatedCoreQuota { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.Models.BatchVmFamilyCoreQuota> DedicatedCoreQuotaPerVmFamily { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchAccountEncryptionConfiguration Encryption { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsDedicatedCoreQuotaPerVmFamilyEnforced { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchKeyVaultReference KeyVaultReference { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public int? LowPriorityCoreQuota { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchNetworkProfile NetworkProfile { get { throw null; } set { } }
        public string NodeManagementEndpoint { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchAccountPoolAllocationMode? PoolAllocationMode { get { throw null; } }
        public int? PoolQuota { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class BatchAccountDetectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchAccountDetectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchAccountDetectorResource>, System.Collections.IEnumerable
    {
        protected BatchAccountDetectorCollection() { }
        public virtual Azure.Response<bool> Exists(string detectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string detectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountDetectorResource> Get(string detectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.BatchAccountDetectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.BatchAccountDetectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountDetectorResource>> GetAsync(string detectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Batch.BatchAccountDetectorResource> GetIfExists(string detectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Batch.BatchAccountDetectorResource>> GetIfExistsAsync(string detectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Batch.BatchAccountDetectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchAccountDetectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Batch.BatchAccountDetectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchAccountDetectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchAccountDetectorData : Azure.ResourceManager.Models.ResourceData
    {
        public BatchAccountDetectorData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    public partial class BatchAccountDetectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BatchAccountDetectorResource() { }
        public virtual Azure.ResourceManager.Batch.BatchAccountDetectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string detectorId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountDetectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountDetectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchAccountPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchAccountPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchAccountPoolResource>, System.Collections.IEnumerable
    {
        protected BatchAccountPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchAccountPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.Batch.BatchAccountPoolData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchAccountPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.Batch.BatchAccountPoolData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource> Get(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.BatchAccountPoolResource> GetAll(int? maxresults = default(int?), string select = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.BatchAccountPoolResource> GetAllAsync(int? maxresults = default(int?), string select = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource>> GetAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Batch.BatchAccountPoolResource> GetIfExists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Batch.BatchAccountPoolResource>> GetIfExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Batch.BatchAccountPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchAccountPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Batch.BatchAccountPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchAccountPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchAccountPoolData : Azure.ResourceManager.Models.ResourceData
    {
        public BatchAccountPoolData() { }
        public Azure.ResourceManager.Batch.Models.BatchAccountPoolAllocationState? AllocationState { get { throw null; } }
        public System.DateTimeOffset? AllocationStateTransitionOn { get { throw null; } }
        public System.Collections.Generic.IList<string> ApplicationLicenses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchApplicationPackageReference> ApplicationPackages { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchAccountPoolAutoScaleRun AutoScaleRun { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchCertificateReference> Certificates { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public int? CurrentDedicatedNodes { get { throw null; } }
        public int? CurrentLowPriorityNodes { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.NodeCommunicationMode? CurrentNodeCommunicationMode { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchDeploymentConfiguration DeploymentConfiguration { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.InterNodeCommunicationState? InterNodeCommunication { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchAccountPoolMetadataItem> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchMountConfiguration> MountConfiguration { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchNetworkConfiguration NetworkConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? ProvisioningStateTransitOn { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchResizeOperationStatus ResizeOperationStatus { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchAccountPoolScaleSettings ScaleSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAccountPoolStartTask StartTask { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.NodeCommunicationMode? TargetNodeCommunicationMode { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchNodeFillType? TaskSchedulingNodeFillType { get { throw null; } set { } }
        public int? TaskSlotsPerNode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchUserAccount> UserAccounts { get { throw null; } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class BatchAccountPoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BatchAccountPoolResource() { }
        public virtual Azure.ResourceManager.Batch.BatchAccountPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string poolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource> DisableAutoScale(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource>> DisableAutoScaleAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource> StopResize(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource>> StopResizeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource> Update(Azure.ResourceManager.Batch.BatchAccountPoolData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource>> UpdateAsync(Azure.ResourceManager.Batch.BatchAccountPoolData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BatchAccountResource() { }
        public virtual Azure.ResourceManager.Batch.BatchAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource> GetBatchAccountCertificate(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource>> GetBatchAccountCertificateAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchAccountCertificateCollection GetBatchAccountCertificates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountDetectorResource> GetBatchAccountDetector(string detectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountDetectorResource>> GetBatchAccountDetectorAsync(string detectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchAccountDetectorCollection GetBatchAccountDetectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource> GetBatchAccountPool(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource>> GetBatchAccountPoolAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchAccountPoolCollection GetBatchAccountPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchApplicationResource> GetBatchApplication(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchApplicationResource>> GetBatchApplicationAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchApplicationCollection GetBatchApplications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource> GetBatchPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource>> GetBatchPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionCollection GetBatchPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchPrivateLinkResource> GetBatchPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchPrivateLinkResource>> GetBatchPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchPrivateLinkResourceCollection GetBatchPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.Models.BatchAccountKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.Models.BatchAccountKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.Models.BatchAccountOutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.Models.BatchAccountOutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.Models.BatchAccountKeys> RegenerateKey(Azure.ResourceManager.Batch.Models.BatchAccountRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.Models.BatchAccountKeys>> RegenerateKeyAsync(Azure.ResourceManager.Batch.Models.BatchAccountRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SynchronizeAutoStorageKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SynchronizeAutoStorageKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource> Update(Azure.ResourceManager.Batch.Models.BatchAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource>> UpdateAsync(Azure.ResourceManager.Batch.Models.BatchAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchApplicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchApplicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchApplicationResource>, System.Collections.IEnumerable
    {
        protected BatchApplicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchApplicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.Batch.BatchApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchApplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.Batch.BatchApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchApplicationResource> Get(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.BatchApplicationResource> GetAll(int? maxresults = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.BatchApplicationResource> GetAllAsync(int? maxresults = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchApplicationResource>> GetAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Batch.BatchApplicationResource> GetIfExists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Batch.BatchApplicationResource>> GetIfExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Batch.BatchApplicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchApplicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Batch.BatchApplicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchApplicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchApplicationData : Azure.ResourceManager.Models.ResourceData
    {
        public BatchApplicationData() { }
        public bool? AllowUpdates { get { throw null; } set { } }
        public string DefaultVersion { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
    }
    public partial class BatchApplicationPackageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchApplicationPackageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchApplicationPackageResource>, System.Collections.IEnumerable
    {
        protected BatchApplicationPackageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchApplicationPackageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string versionName, Azure.ResourceManager.Batch.BatchApplicationPackageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchApplicationPackageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string versionName, Azure.ResourceManager.Batch.BatchApplicationPackageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchApplicationPackageResource> Get(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.BatchApplicationPackageResource> GetAll(int? maxresults = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.BatchApplicationPackageResource> GetAllAsync(int? maxresults = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchApplicationPackageResource>> GetAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Batch.BatchApplicationPackageResource> GetIfExists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Batch.BatchApplicationPackageResource>> GetIfExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Batch.BatchApplicationPackageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchApplicationPackageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Batch.BatchApplicationPackageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchApplicationPackageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchApplicationPackageData : Azure.ResourceManager.Models.ResourceData
    {
        public BatchApplicationPackageData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Format { get { throw null; } }
        public System.DateTimeOffset? LastActivatedOn { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchApplicationPackageState? State { get { throw null; } }
        public System.Uri StorageUri { get { throw null; } }
        public System.DateTimeOffset? StorageUriExpireOn { get { throw null; } }
    }
    public partial class BatchApplicationPackageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BatchApplicationPackageResource() { }
        public virtual Azure.ResourceManager.Batch.BatchApplicationPackageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchApplicationPackageResource> Activate(Azure.ResourceManager.Batch.Models.BatchApplicationPackageActivateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchApplicationPackageResource>> ActivateAsync(Azure.ResourceManager.Batch.Models.BatchApplicationPackageActivateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string applicationName, string versionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchApplicationPackageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchApplicationPackageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchApplicationPackageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Batch.BatchApplicationPackageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchApplicationPackageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Batch.BatchApplicationPackageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchApplicationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BatchApplicationResource() { }
        public virtual Azure.ResourceManager.Batch.BatchApplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string applicationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchApplicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchApplicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchApplicationPackageResource> GetBatchApplicationPackage(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchApplicationPackageResource>> GetBatchApplicationPackageAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchApplicationPackageCollection GetBatchApplicationPackages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchApplicationResource> Update(Azure.ResourceManager.Batch.BatchApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchApplicationResource>> UpdateAsync(Azure.ResourceManager.Batch.BatchApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class BatchExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Batch.Models.BatchNameAvailabilityResult> CheckBatchNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.Batch.Models.BatchNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.Models.BatchNameAvailabilityResult>> CheckBatchNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.Batch.Models.BatchNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource> GetBatchAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource>> GetBatchAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Batch.BatchAccountCertificateResource GetBatchAccountCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Batch.BatchAccountDetectorResource GetBatchAccountDetectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Batch.BatchAccountPoolResource GetBatchAccountPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Batch.BatchAccountResource GetBatchAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Batch.BatchAccountCollection GetBatchAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Batch.BatchAccountResource> GetBatchAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Batch.BatchAccountResource> GetBatchAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Batch.BatchApplicationPackageResource GetBatchApplicationPackageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Batch.BatchApplicationResource GetBatchApplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource GetBatchPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Batch.BatchPrivateLinkResource GetBatchPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Batch.Models.BatchLocationQuota> GetBatchQuotas(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.Models.BatchLocationQuota>> GetBatchQuotasAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Batch.Models.BatchSupportedSku> GetBatchSupportedCloudServiceSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, int? maxresults = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Batch.Models.BatchSupportedSku> GetBatchSupportedCloudServiceSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, int? maxresults = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Batch.Models.BatchSupportedSku> GetBatchSupportedVirtualMachineSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, int? maxresults = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Batch.Models.BatchSupportedSku> GetBatchSupportedVirtualMachineSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, int? maxresults = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected BatchPrivateEndpointConnectionCollection() { }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource> GetAll(int? maxresults = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource> GetAllAsync(int? maxresults = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public BatchPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Batch.Models.BatchPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class BatchPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BatchPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BatchPrivateLinkResource() { }
        public virtual Azure.ResourceManager.Batch.BatchPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected BatchPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchPrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.BatchPrivateLinkResource> GetAll(int? maxresults = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.BatchPrivateLinkResource> GetAllAsync(int? maxresults = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchPrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Batch.BatchPrivateLinkResource> GetIfExists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Batch.BatchPrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Batch.BatchPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Batch.BatchPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public BatchPrivateLinkResourceData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
}
namespace Azure.ResourceManager.Batch.Mocking
{
    public partial class MockableBatchArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableBatchArmClient() { }
        public virtual Azure.ResourceManager.Batch.BatchAccountCertificateResource GetBatchAccountCertificateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchAccountDetectorResource GetBatchAccountDetectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchAccountPoolResource GetBatchAccountPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchAccountResource GetBatchAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchApplicationPackageResource GetBatchApplicationPackageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchApplicationResource GetBatchApplicationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource GetBatchPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchPrivateLinkResource GetBatchPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableBatchResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableBatchResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource> GetBatchAccount(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource>> GetBatchAccountAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchAccountCollection GetBatchAccounts() { throw null; }
    }
    public partial class MockableBatchSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableBatchSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Batch.Models.BatchNameAvailabilityResult> CheckBatchNameAvailability(Azure.Core.AzureLocation locationName, Azure.ResourceManager.Batch.Models.BatchNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.Models.BatchNameAvailabilityResult>> CheckBatchNameAvailabilityAsync(Azure.Core.AzureLocation locationName, Azure.ResourceManager.Batch.Models.BatchNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.BatchAccountResource> GetBatchAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.BatchAccountResource> GetBatchAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.Models.BatchLocationQuota> GetBatchQuotas(Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.Models.BatchLocationQuota>> GetBatchQuotasAsync(Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.Models.BatchSupportedSku> GetBatchSupportedCloudServiceSkus(Azure.Core.AzureLocation locationName, int? maxresults = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.Models.BatchSupportedSku> GetBatchSupportedCloudServiceSkusAsync(Azure.Core.AzureLocation locationName, int? maxresults = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.Models.BatchSupportedSku> GetBatchSupportedVirtualMachineSkus(Azure.Core.AzureLocation locationName, int? maxresults = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.Models.BatchSupportedSku> GetBatchSupportedVirtualMachineSkusAsync(Azure.Core.AzureLocation locationName, int? maxresults = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Batch.Models
{
    public static partial class ArmBatchModelFactory
    {
        public static Azure.ResourceManager.Batch.Models.BatchAccountCertificateCreateOrUpdateContent BatchAccountCertificateCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string thumbprintAlgorithm = null, string thumbprintString = null, Azure.ResourceManager.Batch.Models.BatchAccountCertificateFormat? format = default(Azure.ResourceManager.Batch.Models.BatchAccountCertificateFormat?), System.BinaryData data = null, string password = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.Batch.BatchAccountCertificateData BatchAccountCertificateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string thumbprintAlgorithm = null, string thumbprintString = null, Azure.ResourceManager.Batch.Models.BatchAccountCertificateFormat? format = default(Azure.ResourceManager.Batch.Models.BatchAccountCertificateFormat?), Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState? provisioningState = default(Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState?), System.DateTimeOffset? provisioningStateTransitOn = default(System.DateTimeOffset?), Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState? previousProvisioningState = default(Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState?), System.DateTimeOffset? previousProvisioningStateTransitOn = default(System.DateTimeOffset?), string publicData = null, Azure.ResponseError deleteCertificateError = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.Batch.BatchAccountData BatchAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string accountEndpoint = null, string nodeManagementEndpoint = null, Azure.ResourceManager.Batch.Models.BatchProvisioningState? provisioningState = default(Azure.ResourceManager.Batch.Models.BatchProvisioningState?), Azure.ResourceManager.Batch.Models.BatchAccountPoolAllocationMode? poolAllocationMode = default(Azure.ResourceManager.Batch.Models.BatchAccountPoolAllocationMode?), Azure.ResourceManager.Batch.Models.BatchKeyVaultReference keyVaultReference = null, Azure.ResourceManager.Batch.Models.BatchPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Batch.Models.BatchPublicNetworkAccess?), Azure.ResourceManager.Batch.Models.BatchNetworkProfile networkProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageConfiguration autoStorage = null, Azure.ResourceManager.Batch.Models.BatchAccountEncryptionConfiguration encryption = null, int? dedicatedCoreQuota = default(int?), int? lowPriorityCoreQuota = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchVmFamilyCoreQuota> dedicatedCoreQuotaPerVmFamily = null, bool? isDedicatedCoreQuotaPerVmFamilyEnforced = default(bool?), int? poolQuota = default(int?), int? activeJobAndJobScheduleQuota = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchAuthenticationMode> allowedAuthenticationModes = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Batch.BatchAccountDetectorData BatchAccountDetectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string value = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchAccountEndpointDependency BatchAccountEndpointDependency(string domainName = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchEndpointDetail> endpointDetails = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchAccountKeys BatchAccountKeys(string accountName = null, string primary = null, string secondary = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchAccountOutboundEnvironmentEndpoint BatchAccountOutboundEnvironmentEndpoint(string category = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchAccountEndpointDependency> endpoints = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchAccountPoolAutoScaleRun BatchAccountPoolAutoScaleRun(System.DateTimeOffset evaluationOn = default(System.DateTimeOffset), string results = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Batch.BatchAccountPoolData BatchAccountPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string displayName = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState? provisioningState = default(Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState?), System.DateTimeOffset? provisioningStateTransitOn = default(System.DateTimeOffset?), Azure.ResourceManager.Batch.Models.BatchAccountPoolAllocationState? allocationState = default(Azure.ResourceManager.Batch.Models.BatchAccountPoolAllocationState?), System.DateTimeOffset? allocationStateTransitionOn = default(System.DateTimeOffset?), string vmSize = null, Azure.ResourceManager.Batch.Models.BatchDeploymentConfiguration deploymentConfiguration = null, int? currentDedicatedNodes = default(int?), int? currentLowPriorityNodes = default(int?), Azure.ResourceManager.Batch.Models.BatchAccountPoolScaleSettings scaleSettings = null, Azure.ResourceManager.Batch.Models.BatchAccountPoolAutoScaleRun autoScaleRun = null, Azure.ResourceManager.Batch.Models.InterNodeCommunicationState? interNodeCommunication = default(Azure.ResourceManager.Batch.Models.InterNodeCommunicationState?), Azure.ResourceManager.Batch.Models.BatchNetworkConfiguration networkConfiguration = null, int? taskSlotsPerNode = default(int?), Azure.ResourceManager.Batch.Models.BatchNodeFillType? taskSchedulingNodeFillType = default(Azure.ResourceManager.Batch.Models.BatchNodeFillType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchUserAccount> userAccounts = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchAccountPoolMetadataItem> metadata = null, Azure.ResourceManager.Batch.Models.BatchAccountPoolStartTask startTask = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchCertificateReference> certificates = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchApplicationPackageReference> applicationPackages = null, System.Collections.Generic.IEnumerable<string> applicationLicenses = null, Azure.ResourceManager.Batch.Models.BatchResizeOperationStatus resizeOperationStatus = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchMountConfiguration> mountConfiguration = null, Azure.ResourceManager.Batch.Models.NodeCommunicationMode? targetNodeCommunicationMode = default(Azure.ResourceManager.Batch.Models.NodeCommunicationMode?), Azure.ResourceManager.Batch.Models.NodeCommunicationMode? currentNodeCommunicationMode = default(Azure.ResourceManager.Batch.Models.NodeCommunicationMode?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.Batch.BatchApplicationData BatchApplicationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, bool? allowUpdates = default(bool?), string defaultVersion = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.Batch.BatchApplicationPackageData BatchApplicationPackageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Batch.Models.BatchApplicationPackageState? state = default(Azure.ResourceManager.Batch.Models.BatchApplicationPackageState?), string format = null, System.Uri storageUri = null, System.DateTimeOffset? storageUriExpireOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastActivatedOn = default(System.DateTimeOffset?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchEndpointDetail BatchEndpointDetail(int? port = default(int?)) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchIPRule BatchIPRule(Azure.ResourceManager.Batch.Models.BatchIPRuleAction action = default(Azure.ResourceManager.Batch.Models.BatchIPRuleAction), string value = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchLocationQuota BatchLocationQuota(int? accountQuota = default(int?)) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchNameAvailabilityResult BatchNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.Batch.Models.BatchNameUnavailableReason? reason = default(Azure.ResourceManager.Batch.Models.BatchNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData BatchPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState?), Azure.Core.ResourceIdentifier privateEndpointId = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.ResourceManager.Batch.Models.BatchPrivateLinkServiceConnectionState connectionState = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.Batch.BatchPrivateLinkResourceData BatchPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchPrivateLinkServiceConnectionState BatchPrivateLinkServiceConnectionState(Azure.ResourceManager.Batch.Models.BatchPrivateLinkServiceConnectionStatus status = Azure.ResourceManager.Batch.Models.BatchPrivateLinkServiceConnectionStatus.Approved, string description = null, string actionRequired = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchResizeOperationStatus BatchResizeOperationStatus(int? targetDedicatedNodes = default(int?), int? targetLowPriorityNodes = default(int?), System.TimeSpan? resizeTimeout = default(System.TimeSpan?), Azure.ResourceManager.Batch.Models.BatchNodeDeallocationOption? nodeDeallocationOption = default(Azure.ResourceManager.Batch.Models.BatchNodeDeallocationOption?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchSkuCapability BatchSkuCapability(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchSupportedSku BatchSupportedSku(string name = null, string familyName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchSkuCapability> capabilities = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchVmFamilyCoreQuota BatchVmFamilyCoreQuota(string name = null, int? coreQuota = default(int?)) { throw null; }
    }
    public partial class BatchAccountAutoScaleSettings
    {
        public BatchAccountAutoScaleSettings(string formula) { }
        public System.TimeSpan? EvaluationInterval { get { throw null; } set { } }
        public string Formula { get { throw null; } set { } }
    }
    public partial class BatchAccountAutoStorageBaseConfiguration
    {
        public BatchAccountAutoStorageBaseConfiguration(Azure.Core.ResourceIdentifier storageAccountId) { }
        public Azure.ResourceManager.Batch.Models.BatchAutoStorageAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NodeIdentityResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } set { } }
    }
    public partial class BatchAccountAutoStorageConfiguration : Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageBaseConfiguration
    {
        public BatchAccountAutoStorageConfiguration(Azure.Core.ResourceIdentifier storageAccountId, System.DateTimeOffset lastKeySyncedOn) : base (default(Azure.Core.ResourceIdentifier)) { }
        public System.DateTimeOffset LastKeySyncedOn { get { throw null; } set { } }
    }
    public partial class BatchAccountCertificateCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public BatchAccountCertificateCreateOrUpdateContent() { }
        public System.BinaryData Data { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchAccountCertificateFormat? Format { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Please use `ThumbprintString` instead.", false)]
        public System.BinaryData Thumbprint { get { throw null; } set { } }
        public string ThumbprintAlgorithm { get { throw null; } set { } }
        public string ThumbprintString { get { throw null; } set { } }
    }
    public enum BatchAccountCertificateFormat
    {
        Pfx = 0,
        Cer = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchAccountCertificateProvisioningState : System.IEquatable<Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchAccountCertificateProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState left, Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState left, Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchAccountCreateOrUpdateContent
    {
        public BatchAccountCreateOrUpdateContent(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchAuthenticationMode> AllowedAuthenticationModes { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageBaseConfiguration AutoStorage { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAccountEncryptionConfiguration Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchKeyVaultReference KeyVaultReference { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAccountPoolAllocationMode? PoolAllocationMode { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class BatchAccountEncryptionConfiguration
    {
        public BatchAccountEncryptionConfiguration() { }
        public System.Uri KeyIdentifier { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAccountKeySource? KeySource { get { throw null; } set { } }
    }
    public partial class BatchAccountEndpointDependency
    {
        internal BatchAccountEndpointDependency() { }
        public string Description { get { throw null; } }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.Models.BatchEndpointDetail> EndpointDetails { get { throw null; } }
    }
    public partial class BatchAccountFixedScaleSettings
    {
        public BatchAccountFixedScaleSettings() { }
        public Azure.ResourceManager.Batch.Models.BatchNodeDeallocationOption? NodeDeallocationOption { get { throw null; } set { } }
        public System.TimeSpan? ResizeTimeout { get { throw null; } set { } }
        public int? TargetDedicatedNodes { get { throw null; } set { } }
        public int? TargetLowPriorityNodes { get { throw null; } set { } }
    }
    public partial class BatchAccountKeys
    {
        internal BatchAccountKeys() { }
        public string AccountName { get { throw null; } }
        public string Primary { get { throw null; } }
        public string Secondary { get { throw null; } }
    }
    public enum BatchAccountKeySource
    {
        MicrosoftBatch = 0,
        MicrosoftKeyVault = 1,
    }
    public enum BatchAccountKeyType
    {
        Primary = 0,
        Secondary = 1,
    }
    public partial class BatchAccountOutboundEnvironmentEndpoint
    {
        internal BatchAccountOutboundEnvironmentEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.Models.BatchAccountEndpointDependency> Endpoints { get { throw null; } }
    }
    public partial class BatchAccountPatch
    {
        public BatchAccountPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchAuthenticationMode> AllowedAuthenticationModes { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageBaseConfiguration AutoStorage { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAccountEncryptionConfiguration Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public enum BatchAccountPoolAllocationMode
    {
        BatchService = 0,
        UserSubscription = 1,
    }
    public enum BatchAccountPoolAllocationState
    {
        Steady = 0,
        Resizing = 1,
        Stopping = 2,
    }
    public partial class BatchAccountPoolAutoScaleRun
    {
        internal BatchAccountPoolAutoScaleRun() { }
        public Azure.ResponseError Error { get { throw null; } }
        public System.DateTimeOffset EvaluationOn { get { throw null; } }
        public string Results { get { throw null; } }
    }
    public partial class BatchAccountPoolMetadataItem
    {
        public BatchAccountPoolMetadataItem(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchAccountPoolProvisioningState : System.IEquatable<Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchAccountPoolProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState left, Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState left, Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchAccountPoolScaleSettings
    {
        public BatchAccountPoolScaleSettings() { }
        public Azure.ResourceManager.Batch.Models.BatchAccountAutoScaleSettings AutoScale { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAccountFixedScaleSettings FixedScale { get { throw null; } set { } }
    }
    public partial class BatchAccountPoolStartTask
    {
        public BatchAccountPoolStartTask() { }
        public string CommandLine { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchTaskContainerSettings ContainerSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchEnvironmentSetting> EnvironmentSettings { get { throw null; } }
        public int? MaxTaskRetryCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchResourceFile> ResourceFiles { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchUserIdentity UserIdentity { get { throw null; } set { } }
        public bool? WaitForSuccess { get { throw null; } set { } }
    }
    public partial class BatchAccountRegenerateKeyContent
    {
        public BatchAccountRegenerateKeyContent(Azure.ResourceManager.Batch.Models.BatchAccountKeyType keyType) { }
        public Azure.ResourceManager.Batch.Models.BatchAccountKeyType KeyType { get { throw null; } }
    }
    public partial class BatchApplicationPackageActivateContent
    {
        public BatchApplicationPackageActivateContent(string format) { }
        public string Format { get { throw null; } }
    }
    public partial class BatchApplicationPackageReference
    {
        public BatchApplicationPackageReference(Azure.Core.ResourceIdentifier id) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public enum BatchApplicationPackageState
    {
        Pending = 0,
        Active = 1,
    }
    public enum BatchAuthenticationMode
    {
        SharedKey = 0,
        Aad = 1,
        TaskAuthenticationToken = 2,
    }
    public enum BatchAutoStorageAuthenticationMode
    {
        StorageKeys = 0,
        BatchAccountManagedIdentity = 1,
    }
    public enum BatchAutoUserScope
    {
        Task = 0,
        Pool = 1,
    }
    public partial class BatchAutoUserSpecification
    {
        public BatchAutoUserSpecification() { }
        public Azure.ResourceManager.Batch.Models.BatchUserAccountElevationLevel? ElevationLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAutoUserScope? Scope { get { throw null; } set { } }
    }
    public partial class BatchBlobFileSystemConfiguration
    {
        public BatchBlobFileSystemConfiguration(string accountName, string containerName, string relativeMountPath) { }
        public string AccountKey { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
        public string BlobfuseOptions { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier IdentityResourceId { get { throw null; } set { } }
        public string RelativeMountPath { get { throw null; } set { } }
        public string SasKey { get { throw null; } set { } }
    }
    public partial class BatchCertificateReference
    {
        public BatchCertificateReference(Azure.Core.ResourceIdentifier id) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchCertificateStoreLocation? StoreLocation { get { throw null; } set { } }
        public string StoreName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchCertificateVisibility> Visibility { get { throw null; } }
    }
    public enum BatchCertificateStoreLocation
    {
        CurrentUser = 0,
        LocalMachine = 1,
    }
    public enum BatchCertificateVisibility
    {
        StartTask = 0,
        Task = 1,
        RemoteUser = 2,
    }
    public partial class BatchCifsMountConfiguration
    {
        public BatchCifsMountConfiguration(string username, string source, string relativeMountPath, string password) { }
        public string MountOptions { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string RelativeMountPath { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class BatchCloudServiceConfiguration
    {
        public BatchCloudServiceConfiguration(string osFamily) { }
        public string OSFamily { get { throw null; } set { } }
        public string OSVersion { get { throw null; } set { } }
    }
    public enum BatchContainerWorkingDirectory
    {
        TaskWorkingDirectory = 0,
        ContainerImageDefault = 1,
    }
    public partial class BatchDeploymentConfiguration
    {
        public BatchDeploymentConfiguration() { }
        public Azure.ResourceManager.Batch.Models.BatchCloudServiceConfiguration CloudServiceConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchVmConfiguration VmConfiguration { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchDiffDiskPlacement : System.IEquatable<Azure.ResourceManager.Batch.Models.BatchDiffDiskPlacement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchDiffDiskPlacement(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchDiffDiskPlacement CacheDisk { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.BatchDiffDiskPlacement other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.BatchDiffDiskPlacement left, Azure.ResourceManager.Batch.Models.BatchDiffDiskPlacement right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.BatchDiffDiskPlacement (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.BatchDiffDiskPlacement left, Azure.ResourceManager.Batch.Models.BatchDiffDiskPlacement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum BatchDiskCachingType
    {
        None = 0,
        ReadOnly = 1,
        ReadWrite = 2,
    }
    public enum BatchDiskEncryptionTarget
    {
        OSDisk = 0,
        TemporaryDisk = 1,
    }
    public enum BatchEndpointAccessDefaultAction
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class BatchEndpointAccessProfile
    {
        public BatchEndpointAccessProfile(Azure.ResourceManager.Batch.Models.BatchEndpointAccessDefaultAction defaultAction) { }
        public Azure.ResourceManager.Batch.Models.BatchEndpointAccessDefaultAction DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchIPRule> IPRules { get { throw null; } }
    }
    public partial class BatchEndpointDetail
    {
        internal BatchEndpointDetail() { }
        public int? Port { get { throw null; } }
    }
    public partial class BatchEnvironmentSetting
    {
        public BatchEnvironmentSetting(string name) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class BatchFileShareConfiguration
    {
        public BatchFileShareConfiguration(string accountName, System.Uri fileUri, string accountKey, string relativeMountPath) { }
        public string AccountKey { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
        public System.Uri FileUri { get { throw null; } set { } }
        public string MountOptions { get { throw null; } set { } }
        public string RelativeMountPath { get { throw null; } set { } }
    }
    public partial class BatchImageReference
    {
        public BatchImageReference() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public enum BatchInboundEndpointProtocol
    {
        Tcp = 0,
        Udp = 1,
    }
    public partial class BatchInboundNatPool
    {
        public BatchInboundNatPool(string name, Azure.ResourceManager.Batch.Models.BatchInboundEndpointProtocol protocol, int backendPort, int frontendPortRangeStart, int frontendPortRangeEnd) { }
        public int BackendPort { get { throw null; } set { } }
        public int FrontendPortRangeEnd { get { throw null; } set { } }
        public int FrontendPortRangeStart { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchNetworkSecurityGroupRule> NetworkSecurityGroupRules { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchInboundEndpointProtocol Protocol { get { throw null; } set { } }
    }
    public enum BatchIPAddressProvisioningType
    {
        BatchManaged = 0,
        UserManaged = 1,
        NoPublicIPAddresses = 2,
    }
    public partial class BatchIPRule
    {
        public BatchIPRule(string value) { }
        public Azure.ResourceManager.Batch.Models.BatchIPRuleAction Action { get { throw null; } [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)] set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchIPRuleAction : System.IEquatable<Azure.ResourceManager.Batch.Models.BatchIPRuleAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchIPRuleAction(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchIPRuleAction Allow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.BatchIPRuleAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.BatchIPRuleAction left, Azure.ResourceManager.Batch.Models.BatchIPRuleAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.BatchIPRuleAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.BatchIPRuleAction left, Azure.ResourceManager.Batch.Models.BatchIPRuleAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchKeyVaultReference
    {
        public BatchKeyVaultReference(Azure.Core.ResourceIdentifier id, System.Uri uri) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class BatchLinuxUserConfiguration
    {
        public BatchLinuxUserConfiguration() { }
        public int? Gid { get { throw null; } set { } }
        public string SshPrivateKey { get { throw null; } set { } }
        public int? Uid { get { throw null; } set { } }
    }
    public partial class BatchLocationQuota
    {
        internal BatchLocationQuota() { }
        public int? AccountQuota { get { throw null; } }
    }
    public partial class BatchMountConfiguration
    {
        public BatchMountConfiguration() { }
        public Azure.ResourceManager.Batch.Models.BatchBlobFileSystemConfiguration BlobFileSystemConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchCifsMountConfiguration CifsMountConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchFileShareConfiguration FileShareConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchNfsMountConfiguration NfsMountConfiguration { get { throw null; } set { } }
    }
    public partial class BatchNameAvailabilityContent
    {
        public BatchNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
    }
    public partial class BatchNameAvailabilityResult
    {
        internal BatchNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchNameUnavailableReason? Reason { get { throw null; } }
    }
    public enum BatchNameUnavailableReason
    {
        Invalid = 0,
        AlreadyExists = 1,
    }
    public partial class BatchNetworkConfiguration
    {
        public BatchNetworkConfiguration() { }
        public Azure.ResourceManager.Batch.Models.DynamicVNetAssignmentScope? DynamicVNetAssignmentScope { get { throw null; } set { } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchInboundNatPool> EndpointInboundNatPools { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchPublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
    }
    public partial class BatchNetworkProfile
    {
        public BatchNetworkProfile() { }
        public Azure.ResourceManager.Batch.Models.BatchEndpointAccessProfile AccountAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchEndpointAccessProfile NodeManagementAccess { get { throw null; } set { } }
    }
    public partial class BatchNetworkSecurityGroupRule
    {
        public BatchNetworkSecurityGroupRule(int priority, Azure.ResourceManager.Batch.Models.BatchNetworkSecurityGroupRuleAccess access, string sourceAddressPrefix) { }
        public Azure.ResourceManager.Batch.Models.BatchNetworkSecurityGroupRuleAccess Access { get { throw null; } set { } }
        public int Priority { get { throw null; } set { } }
        public string SourceAddressPrefix { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourcePortRanges { get { throw null; } }
    }
    public enum BatchNetworkSecurityGroupRuleAccess
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class BatchNfsMountConfiguration
    {
        public BatchNfsMountConfiguration(string source, string relativeMountPath) { }
        public string MountOptions { get { throw null; } set { } }
        public string RelativeMountPath { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
    }
    public enum BatchNodeDeallocationOption
    {
        Requeue = 0,
        Terminate = 1,
        TaskCompletion = 2,
        RetainedData = 3,
    }
    public enum BatchNodeFillType
    {
        Spread = 0,
        Pack = 1,
    }
    public enum BatchNodePlacementPolicyType
    {
        Regional = 0,
        Zonal = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchPrivateLinkServiceConnectionState
    {
        public BatchPrivateLinkServiceConnectionState(Azure.ResourceManager.Batch.Models.BatchPrivateLinkServiceConnectionStatus status) { }
        public string ActionRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchPrivateLinkServiceConnectionStatus Status { get { throw null; } set { } }
    }
    public enum BatchPrivateLinkServiceConnectionStatus
    {
        Approved = 0,
        Pending = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchProvisioningState : System.IEquatable<Azure.ResourceManager.Batch.Models.BatchProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchProvisioningState Invalid { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.BatchProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.BatchProvisioningState left, Azure.ResourceManager.Batch.Models.BatchProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.BatchProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.BatchProvisioningState left, Azure.ResourceManager.Batch.Models.BatchProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchPublicIPAddressConfiguration
    {
        public BatchPublicIPAddressConfiguration() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> IPAddressIds { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchIPAddressProvisioningType? Provision { get { throw null; } set { } }
    }
    public enum BatchPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class BatchResizeOperationStatus
    {
        internal BatchResizeOperationStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchNodeDeallocationOption? NodeDeallocationOption { get { throw null; } }
        public System.TimeSpan? ResizeTimeout { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public int? TargetDedicatedNodes { get { throw null; } }
        public int? TargetLowPriorityNodes { get { throw null; } }
    }
    public partial class BatchResourceFile
    {
        public BatchResourceFile() { }
        public string AutoBlobContainerName { get { throw null; } set { } }
        public System.Uri BlobContainerUri { get { throw null; } set { } }
        public string BlobPrefix { get { throw null; } set { } }
        public string FileMode { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        public System.Uri HttpUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier IdentityResourceId { get { throw null; } set { } }
    }
    public partial class BatchSkuCapability
    {
        internal BatchSkuCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public enum BatchStorageAccountType
    {
        StandardLrs = 0,
        PremiumLrs = 1,
    }
    public partial class BatchSupportedSku
    {
        internal BatchSupportedSku() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.Models.BatchSkuCapability> Capabilities { get { throw null; } }
        public string FamilyName { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class BatchTaskContainerSettings
    {
        public BatchTaskContainerSettings(string imageName) { }
        public string ContainerRunOptions { get { throw null; } set { } }
        public string ImageName { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchVmContainerRegistry Registry { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchContainerWorkingDirectory? WorkingDirectory { get { throw null; } set { } }
    }
    public partial class BatchUserAccount
    {
        public BatchUserAccount(string name, string password) { }
        public Azure.ResourceManager.Batch.Models.BatchUserAccountElevationLevel? ElevationLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchLinuxUserConfiguration LinuxUserConfiguration { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchWindowsLoginMode? WindowsUserLoginMode { get { throw null; } set { } }
    }
    public enum BatchUserAccountElevationLevel
    {
        NonAdmin = 0,
        Admin = 1,
    }
    public partial class BatchUserIdentity
    {
        public BatchUserIdentity() { }
        public Azure.ResourceManager.Batch.Models.BatchAutoUserSpecification AutoUser { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    public partial class BatchVmConfiguration
    {
        public BatchVmConfiguration(Azure.ResourceManager.Batch.Models.BatchImageReference imageReference, string nodeAgentSkuId) { }
        public Azure.ResourceManager.Batch.Models.BatchVmContainerConfiguration ContainerConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchVmDataDisk> DataDisks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchDiskEncryptionTarget> DiskEncryptionTargets { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchDiffDiskPlacement? EphemeralOSDiskPlacement { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchVmExtension> Extensions { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchImageReference ImageReference { get { throw null; } set { } }
        public bool? IsAutomaticUpdateEnabled { get { throw null; } set { } }
        public string LicenseType { get { throw null; } set { } }
        public string NodeAgentSkuId { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchNodePlacementPolicyType? NodePlacementPolicy { get { throw null; } set { } }
    }
    public partial class BatchVmContainerConfiguration
    {
        public BatchVmContainerConfiguration() { }
        public BatchVmContainerConfiguration(Azure.ResourceManager.Batch.Models.BatchVmContainerType containerType) { }
        public System.Collections.Generic.IList<string> ContainerImageNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchVmContainerRegistry> ContainerRegistries { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchVmContainerType ContainerType { get { throw null; } [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)] set { } }
    }
    public partial class BatchVmContainerRegistry
    {
        public BatchVmContainerRegistry() { }
        public Azure.Core.ResourceIdentifier IdentityResourceId { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string RegistryServer { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchVmContainerType : System.IEquatable<Azure.ResourceManager.Batch.Models.BatchVmContainerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchVmContainerType(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchVmContainerType CriCompatible { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchVmContainerType DockerCompatible { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.BatchVmContainerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.BatchVmContainerType left, Azure.ResourceManager.Batch.Models.BatchVmContainerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.BatchVmContainerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.BatchVmContainerType left, Azure.ResourceManager.Batch.Models.BatchVmContainerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchVmDataDisk
    {
        public BatchVmDataDisk(int lun, int diskSizeInGB) { }
        public Azure.ResourceManager.Batch.Models.BatchDiskCachingType? Caching { get { throw null; } set { } }
        public int DiskSizeInGB { get { throw null; } set { } }
        public int Lun { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchStorageAccountType? StorageAccountType { get { throw null; } set { } }
    }
    public partial class BatchVmExtension
    {
        public BatchVmExtension(string name, string publisher, string extensionType) { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ExtensionType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    public partial class BatchVmFamilyCoreQuota
    {
        internal BatchVmFamilyCoreQuota() { }
        public int? CoreQuota { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public enum BatchWindowsLoginMode
    {
        Batch = 0,
        Interactive = 1,
    }
    public enum DynamicVNetAssignmentScope
    {
        None = 0,
        Job = 1,
    }
    public enum InterNodeCommunicationState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum NodeCommunicationMode
    {
        Default = 0,
        Classic = 1,
        Simplified = 2,
    }
}
