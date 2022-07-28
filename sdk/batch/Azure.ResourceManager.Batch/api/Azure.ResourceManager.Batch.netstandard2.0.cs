namespace Azure.ResourceManager.Batch
{
    public partial class ApplicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.ApplicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.ApplicationResource>, System.Collections.IEnumerable
    {
        protected ApplicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.ApplicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.Batch.ApplicationData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.ApplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.Batch.ApplicationData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.ApplicationResource> Get(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.ApplicationResource> GetAll(int? maxresults = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.ApplicationResource> GetAllAsync(int? maxresults = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.ApplicationResource>> GetAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Batch.ApplicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.ApplicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Batch.ApplicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.ApplicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApplicationData : Azure.ResourceManager.Models.ResourceData
    {
        public ApplicationData() { }
        public bool? AllowUpdates { get { throw null; } set { } }
        public string DefaultVersion { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
    }
    public partial class ApplicationPackageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.ApplicationPackageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.ApplicationPackageResource>, System.Collections.IEnumerable
    {
        protected ApplicationPackageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.ApplicationPackageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string versionName, Azure.ResourceManager.Batch.ApplicationPackageData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.ApplicationPackageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string versionName, Azure.ResourceManager.Batch.ApplicationPackageData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.ApplicationPackageResource> Get(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.ApplicationPackageResource> GetAll(int? maxresults = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.ApplicationPackageResource> GetAllAsync(int? maxresults = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.ApplicationPackageResource>> GetAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Batch.ApplicationPackageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.ApplicationPackageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Batch.ApplicationPackageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.ApplicationPackageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApplicationPackageData : Azure.ResourceManager.Models.ResourceData
    {
        public ApplicationPackageData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Format { get { throw null; } }
        public System.DateTimeOffset? LastActivationOn { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.PackageState? State { get { throw null; } }
        public System.Uri StorageUri { get { throw null; } }
        public System.DateTimeOffset? StorageUrlExpiry { get { throw null; } }
    }
    public partial class ApplicationPackageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApplicationPackageResource() { }
        public virtual Azure.ResourceManager.Batch.ApplicationPackageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Batch.ApplicationPackageResource> Activate(Azure.ResourceManager.Batch.Models.ActivateApplicationPackageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.ApplicationPackageResource>> ActivateAsync(Azure.ResourceManager.Batch.Models.ActivateApplicationPackageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string applicationName, string versionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.ApplicationPackageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.ApplicationPackageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.ApplicationPackageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Batch.ApplicationPackageData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.ApplicationPackageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Batch.ApplicationPackageData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApplicationResource() { }
        public virtual Azure.ResourceManager.Batch.ApplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string applicationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.ApplicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.ApplicationPackageResource> GetApplicationPackage(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.ApplicationPackageResource>> GetApplicationPackageAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.ApplicationPackageCollection GetApplicationPackages() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.ApplicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.ApplicationResource> Update(Azure.ResourceManager.Batch.ApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.ApplicationResource>> UpdateAsync(Azure.ResourceManager.Batch.ApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Batch.BatchAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Batch.BatchAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchAccountData : Azure.ResourceManager.Models.ResourceData
    {
        internal BatchAccountData() { }
        public string AccountEndpoint { get { throw null; } }
        public int? ActiveJobAndJobScheduleQuota { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.Models.AuthenticationMode> AllowedAuthenticationModes { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.AutoStorageProperties AutoStorage { get { throw null; } }
        public int? DedicatedCoreQuota { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.Models.VirtualMachineFamilyCoreQuota> DedicatedCoreQuotaPerVmFamily { get { throw null; } }
        public bool? DedicatedCoreQuotaPerVmFamilyEnforced { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.EncryptionProperties Encryption { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchAccountIdentity Identity { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.KeyVaultReference KeyVaultReference { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public int? LowPriorityCoreQuota { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchVirtualMachineNetworkProfile NetworkProfile { get { throw null; } }
        public string NodeManagementEndpoint { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.PoolAllocationMode? PoolAllocationMode { get { throw null; } }
        public int? PoolQuota { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.PublicNetworkAccessType? PublicNetworkAccess { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
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
        public virtual Azure.Response<Azure.ResourceManager.Batch.ApplicationResource> GetApplication(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.ApplicationResource>> GetApplicationAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.ApplicationCollection GetApplications() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource> GetBatchPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource>> GetBatchPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionCollection GetBatchPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchPrivateLinkResource> GetBatchPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchPrivateLinkResource>> GetBatchPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchPrivateLinkResourceCollection GetBatchPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.CertificateResource> GetCertificate(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.CertificateResource>> GetCertificateAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.CertificateCollection GetCertificates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.DetectorResponseResource> GetDetectorResponse(string detectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.DetectorResponseResource>> GetDetectorResponseAsync(string detectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.DetectorResponseCollection GetDetectorResponses() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.Models.BatchAccountKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.Models.BatchAccountKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.Models.OutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.Models.OutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.PoolResource> GetPool(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.PoolResource>> GetPoolAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.PoolCollection GetPools() { throw null; }
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
    public static partial class BatchExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Batch.Models.CheckNameAvailabilityResult> CheckNameAvailabilityLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, Azure.ResourceManager.Batch.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, Azure.ResourceManager.Batch.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Batch.ApplicationPackageResource GetApplicationPackageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Batch.ApplicationResource GetApplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource> GetBatchAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource>> GetBatchAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Batch.BatchAccountResource GetBatchAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Batch.BatchAccountCollection GetBatchAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Batch.BatchAccountResource> GetBatchAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Batch.BatchAccountResource> GetBatchAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource GetBatchPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Batch.BatchPrivateLinkResource GetBatchPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Batch.CertificateResource GetCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Batch.DetectorResponseResource GetDetectorResponseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Batch.PoolResource GetPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Batch.Models.BatchLocationQuota> GetQuotasLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.Models.BatchLocationQuota>> GetQuotasLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Batch.Models.SupportedSku> GetSupportedCloudServiceSkusLocations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, int? maxresults = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Batch.Models.SupportedSku> GetSupportedCloudServiceSkusLocationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, int? maxresults = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Batch.Models.SupportedSku> GetSupportedVirtualMachineSkusLocations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, int? maxresults = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Batch.Models.SupportedSku> GetSupportedVirtualMachineSkusLocationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, int? maxresults = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class CertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.CertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.CertificateResource>, System.Collections.IEnumerable
    {
        protected CertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.CertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.Batch.Models.CertificateCreateOrUpdateParameters certificateCreateOrUpdateParameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.CertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.Batch.Models.CertificateCreateOrUpdateParameters certificateCreateOrUpdateParameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.CertificateResource> Get(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.CertificateResource> GetAll(int? maxresults = default(int?), string select = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.CertificateResource> GetAllAsync(int? maxresults = default(int?), string select = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.CertificateResource>> GetAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Batch.CertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.CertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Batch.CertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.CertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CertificateData : Azure.ResourceManager.Models.ResourceData
    {
        public CertificateData() { }
        public Azure.ResponseError DeleteCertificateError { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.CertificateFormat? Format { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.CertificateProvisioningState? PreviousProvisioningState { get { throw null; } }
        public System.DateTimeOffset? PreviousProvisioningStateTransitionOn { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.CertificateProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? ProvisioningStateTransitionOn { get { throw null; } }
        public string PublicData { get { throw null; } }
        public string Thumbprint { get { throw null; } set { } }
        public string ThumbprintAlgorithm { get { throw null; } set { } }
    }
    public partial class CertificateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CertificateResource() { }
        public virtual Azure.ResourceManager.Batch.CertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Batch.CertificateResource> CancelDeletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.CertificateResource>> CancelDeletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string certificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.CertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.CertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.CertificateResource> Update(Azure.ResourceManager.Batch.Models.CertificateCreateOrUpdateParameters certificateCreateOrUpdateParameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.CertificateResource>> UpdateAsync(Azure.ResourceManager.Batch.Models.CertificateCreateOrUpdateParameters certificateCreateOrUpdateParameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DetectorResponseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.DetectorResponseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.DetectorResponseResource>, System.Collections.IEnumerable
    {
        protected DetectorResponseCollection() { }
        public virtual Azure.Response<bool> Exists(string detectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string detectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.DetectorResponseResource> Get(string detectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.DetectorResponseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.DetectorResponseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.DetectorResponseResource>> GetAsync(string detectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Batch.DetectorResponseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.DetectorResponseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Batch.DetectorResponseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.DetectorResponseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DetectorResponseData : Azure.ResourceManager.Models.ResourceData
    {
        public DetectorResponseData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    public partial class DetectorResponseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DetectorResponseResource() { }
        public virtual Azure.ResourceManager.Batch.DetectorResponseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string detectorId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.DetectorResponseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.DetectorResponseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.PoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.PoolResource>, System.Collections.IEnumerable
    {
        protected PoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.PoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.Batch.PoolData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.PoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.Batch.PoolData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.PoolResource> Get(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.PoolResource> GetAll(int? maxresults = default(int?), string select = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.PoolResource> GetAllAsync(int? maxresults = default(int?), string select = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.PoolResource>> GetAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Batch.PoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.PoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Batch.PoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.PoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PoolData : Azure.ResourceManager.Models.ResourceData
    {
        public PoolData() { }
        public Azure.ResourceManager.Batch.Models.AllocationState? AllocationState { get { throw null; } }
        public System.DateTimeOffset? AllocationStateTransitionOn { get { throw null; } }
        public System.Collections.Generic.IList<string> ApplicationLicenses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.ApplicationPackageReference> ApplicationPackages { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.AutoScaleRun AutoScaleRun { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.CertificateReference> Certificates { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public int? CurrentDedicatedNodes { get { throw null; } }
        public int? CurrentLowPriorityNodes { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.DeploymentConfiguration DeploymentConfiguration { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchPoolIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.InterNodeCommunicationState? InterNodeCommunication { get { throw null; } set { } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.MetadataItem> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.MountConfiguration> MountConfiguration { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.NetworkConfiguration NetworkConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.PoolProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? ProvisioningStateTransitionOn { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.ResizeOperationStatus ResizeOperationStatus { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.ScaleSettings ScaleSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.StartTask StartTask { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.ComputeNodeFillType? TaskSchedulingNodeFillType { get { throw null; } set { } }
        public int? TaskSlotsPerNode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.UserAccount> UserAccounts { get { throw null; } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class PoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PoolResource() { }
        public virtual Azure.ResourceManager.Batch.PoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string poolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.PoolResource> DisableAutoScale(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.PoolResource>> DisableAutoScaleAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.PoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.PoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.PoolResource> StopResize(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.PoolResource>> StopResizeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.PoolResource> Update(Azure.ResourceManager.Batch.PoolData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.PoolResource>> UpdateAsync(Azure.ResourceManager.Batch.PoolData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Batch.Models
{
    public enum AccountKeyType
    {
        Primary = 0,
        Secondary = 1,
    }
    public partial class ActivateApplicationPackageContent
    {
        public ActivateApplicationPackageContent(string format) { }
        public string Format { get { throw null; } }
    }
    public enum AllocationState
    {
        Steady = 0,
        Resizing = 1,
        Stopping = 2,
    }
    public partial class ApplicationPackageReference
    {
        public ApplicationPackageReference(string id) { }
        public string Id { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public enum AuthenticationMode
    {
        SharedKey = 0,
        AAD = 1,
        TaskAuthenticationToken = 2,
    }
    public partial class AutoScaleRun
    {
        internal AutoScaleRun() { }
        public Azure.ResourceManager.Batch.Models.AutoScaleRunError Error { get { throw null; } }
        public System.DateTimeOffset EvaluationOn { get { throw null; } }
        public string Results { get { throw null; } }
    }
    public partial class AutoScaleRunError
    {
        internal AutoScaleRunError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.Models.AutoScaleRunError> Details { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class AutoScaleSettings
    {
        public AutoScaleSettings(string formula) { }
        public System.TimeSpan? EvaluationInterval { get { throw null; } set { } }
        public string Formula { get { throw null; } set { } }
    }
    public enum AutoStorageAuthenticationMode
    {
        StorageKeys = 0,
        BatchAccountManagedIdentity = 1,
    }
    public partial class AutoStorageBaseProperties
    {
        public AutoStorageBaseProperties(string storageAccountId) { }
        public Azure.ResourceManager.Batch.Models.AutoStorageAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string NodeIdentityReferenceResourceId { get { throw null; } set { } }
        public string StorageAccountId { get { throw null; } set { } }
    }
    public partial class AutoStorageProperties : Azure.ResourceManager.Batch.Models.AutoStorageBaseProperties
    {
        public AutoStorageProperties(string storageAccountId, System.DateTimeOffset lastKeySync) : base (default(string)) { }
        public System.DateTimeOffset LastKeySync { get { throw null; } set { } }
    }
    public enum AutoUserScope
    {
        Task = 0,
        Pool = 1,
    }
    public partial class AutoUserSpecification
    {
        public AutoUserSpecification() { }
        public Azure.ResourceManager.Batch.Models.ElevationLevel? ElevationLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.AutoUserScope? Scope { get { throw null; } set { } }
    }
    public partial class AzureBlobFileSystemConfiguration
    {
        public AzureBlobFileSystemConfiguration(string accountName, string containerName, string relativeMountPath) { }
        public string AccountKey { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
        public string BlobfuseOptions { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string IdentityReferenceResourceId { get { throw null; } set { } }
        public string RelativeMountPath { get { throw null; } set { } }
        public string SasKey { get { throw null; } set { } }
    }
    public partial class AzureFileShareConfiguration
    {
        public AzureFileShareConfiguration(string accountName, System.Uri azureFileUri, string accountKey, string relativeMountPath) { }
        public string AccountKey { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
        public System.Uri AzureFileUri { get { throw null; } set { } }
        public string MountOptions { get { throw null; } set { } }
        public string RelativeMountPath { get { throw null; } set { } }
    }
    public partial class BatchAccountCreateOrUpdateContent
    {
        public BatchAccountCreateOrUpdateContent(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.AuthenticationMode> AllowedAuthenticationModes { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.AutoStorageBaseProperties AutoStorage { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.EncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAccountIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.KeyVaultReference KeyVaultReference { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchVirtualMachineNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.PoolAllocationMode? PoolAllocationMode { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.PublicNetworkAccessType? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class BatchAccountIdentity
    {
        public BatchAccountIdentity(Azure.ResourceManager.Batch.Models.ResourceIdentityType resourceIdentityType) { }
        public string PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.ResourceIdentityType ResourceIdentityType { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    public partial class BatchAccountKeys
    {
        internal BatchAccountKeys() { }
        public string AccountName { get { throw null; } }
        public string Primary { get { throw null; } }
        public string Secondary { get { throw null; } }
    }
    public partial class BatchAccountPatch
    {
        public BatchAccountPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.AuthenticationMode> AllowedAuthenticationModes { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.AutoStorageBaseProperties AutoStorage { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.EncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAccountIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchVirtualMachineNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.PublicNetworkAccessType? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class BatchAccountRegenerateKeyContent
    {
        public BatchAccountRegenerateKeyContent(Azure.ResourceManager.Batch.Models.AccountKeyType keyName) { }
        public Azure.ResourceManager.Batch.Models.AccountKeyType KeyName { get { throw null; } }
    }
    public enum BatchDiskCachingType
    {
        None = 0,
        ReadOnly = 1,
        ReadWrite = 2,
    }
    public partial class BatchImageReference
    {
        public BatchImageReference() { }
        public string Id { get { throw null; } set { } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class BatchLocationQuota
    {
        internal BatchLocationQuota() { }
        public int? AccountQuota { get { throw null; } }
    }
    public partial class BatchPoolIdentity
    {
        public BatchPoolIdentity(Azure.ResourceManager.Batch.Models.PoolIdentityType poolIdentityType) { }
        public Azure.ResourceManager.Batch.Models.PoolIdentityType PoolIdentityType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    public enum BatchPrivateEndpointConnectionProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Failed = 4,
        Cancelled = 5,
    }
    public partial class BatchPrivateLinkServiceConnectionState
    {
        public BatchPrivateLinkServiceConnectionState(Azure.ResourceManager.Batch.Models.PrivateLinkServiceConnectionStatus status) { }
        public string ActionRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.PrivateLinkServiceConnectionStatus Status { get { throw null; } set { } }
    }
    public enum BatchStorageAccountType
    {
        StandardLRS = 0,
        PremiumLRS = 1,
    }
    public partial class BatchVirtualMachineDataDisk
    {
        public BatchVirtualMachineDataDisk(int lun, int diskSizeGB) { }
        public Azure.ResourceManager.Batch.Models.BatchDiskCachingType? Caching { get { throw null; } set { } }
        public int DiskSizeGB { get { throw null; } set { } }
        public int Lun { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchStorageAccountType? StorageAccountType { get { throw null; } set { } }
    }
    public partial class BatchVirtualMachineNetworkProfile
    {
        public BatchVirtualMachineNetworkProfile() { }
        public Azure.ResourceManager.Batch.Models.EndpointAccessProfile AccountAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.EndpointAccessProfile NodeManagementAccess { get { throw null; } set { } }
    }
    public partial class CertificateCreateOrUpdateParameters : Azure.ResourceManager.Models.ResourceData
    {
        public CertificateCreateOrUpdateParameters() { }
        public string Data { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.CertificateFormat? Format { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } set { } }
        public string ThumbprintAlgorithm { get { throw null; } set { } }
    }
    public enum CertificateFormat
    {
        Pfx = 0,
        Cer = 1,
    }
    public enum CertificateProvisioningState
    {
        Succeeded = 0,
        Deleting = 1,
        Failed = 2,
    }
    public partial class CertificateReference
    {
        public CertificateReference(string id) { }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.CertificateStoreLocation? StoreLocation { get { throw null; } set { } }
        public string StoreName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.CertificateVisibility> Visibility { get { throw null; } }
    }
    public enum CertificateStoreLocation
    {
        CurrentUser = 0,
        LocalMachine = 1,
    }
    public enum CertificateVisibility
    {
        StartTask = 0,
        Task = 1,
        RemoteUser = 2,
    }
    public partial class CheckNameAvailabilityContent
    {
        public CheckNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.ResourceType ResourceType { get { throw null; } }
    }
    public partial class CheckNameAvailabilityResult
    {
        internal CheckNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.NameAvailabilityReason? Reason { get { throw null; } }
    }
    public partial class CifsMountConfiguration
    {
        public CifsMountConfiguration(string username, string source, string relativeMountPath, string password) { }
        public string MountOptions { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string RelativeMountPath { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class CloudServiceConfiguration
    {
        public CloudServiceConfiguration(string osFamily) { }
        public string OSFamily { get { throw null; } set { } }
        public string OSVersion { get { throw null; } set { } }
    }
    public enum ComputeNodeDeallocationOption
    {
        Requeue = 0,
        Terminate = 1,
        TaskCompletion = 2,
        RetainedData = 3,
    }
    public enum ComputeNodeFillType
    {
        Spread = 0,
        Pack = 1,
    }
    public partial class ContainerConfiguration
    {
        public ContainerConfiguration() { }
        public System.Collections.Generic.IList<string> ContainerImageNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.ContainerRegistry> ContainerRegistries { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.ContainerType ContainerType { get { throw null; } set { } }
    }
    public partial class ContainerRegistry
    {
        public ContainerRegistry() { }
        public string IdentityReferenceResourceId { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string RegistryServer { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerType : System.IEquatable<Azure.ResourceManager.Batch.Models.ContainerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerType(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.ContainerType DockerCompatible { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.ContainerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.ContainerType left, Azure.ResourceManager.Batch.Models.ContainerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.ContainerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.ContainerType left, Azure.ResourceManager.Batch.Models.ContainerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ContainerWorkingDirectory
    {
        TaskWorkingDirectory = 0,
        ContainerImageDefault = 1,
    }
    public partial class DeploymentConfiguration
    {
        public DeploymentConfiguration() { }
        public Azure.ResourceManager.Batch.Models.CloudServiceConfiguration CloudServiceConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.VirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiffDiskPlacement : System.IEquatable<Azure.ResourceManager.Batch.Models.DiffDiskPlacement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiffDiskPlacement(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.DiffDiskPlacement CacheDisk { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.DiffDiskPlacement other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.DiffDiskPlacement left, Azure.ResourceManager.Batch.Models.DiffDiskPlacement right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.DiffDiskPlacement (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.DiffDiskPlacement left, Azure.ResourceManager.Batch.Models.DiffDiskPlacement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum DiskEncryptionTarget
    {
        OSDisk = 0,
        TemporaryDisk = 1,
    }
    public enum DynamicVNetAssignmentScope
    {
        None = 0,
        Job = 1,
    }
    public enum ElevationLevel
    {
        NonAdmin = 0,
        Admin = 1,
    }
    public partial class EncryptionProperties
    {
        public EncryptionProperties() { }
        public string KeyIdentifier { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.KeySource? KeySource { get { throw null; } set { } }
    }
    public enum EndpointAccessDefaultAction
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class EndpointAccessProfile
    {
        public EndpointAccessProfile(Azure.ResourceManager.Batch.Models.EndpointAccessDefaultAction defaultAction) { }
        public Azure.ResourceManager.Batch.Models.EndpointAccessDefaultAction DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.IPRule> IPRules { get { throw null; } }
    }
    public partial class EndpointDependency
    {
        internal EndpointDependency() { }
        public string Description { get { throw null; } }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.Models.EndpointDetail> EndpointDetails { get { throw null; } }
    }
    public partial class EndpointDetail
    {
        internal EndpointDetail() { }
        public int? Port { get { throw null; } }
    }
    public partial class EnvironmentSetting
    {
        public EnvironmentSetting(string name) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class FixedScaleSettings
    {
        public FixedScaleSettings() { }
        public Azure.ResourceManager.Batch.Models.ComputeNodeDeallocationOption? NodeDeallocationOption { get { throw null; } set { } }
        public System.TimeSpan? ResizeTimeout { get { throw null; } set { } }
        public int? TargetDedicatedNodes { get { throw null; } set { } }
        public int? TargetLowPriorityNodes { get { throw null; } set { } }
    }
    public enum InboundEndpointProtocol
    {
        TCP = 0,
        UDP = 1,
    }
    public partial class InboundNatPool
    {
        public InboundNatPool(string name, Azure.ResourceManager.Batch.Models.InboundEndpointProtocol protocol, int backendPort, int frontendPortRangeStart, int frontendPortRangeEnd) { }
        public int BackendPort { get { throw null; } set { } }
        public int FrontendPortRangeEnd { get { throw null; } set { } }
        public int FrontendPortRangeStart { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.NetworkSecurityGroupRule> NetworkSecurityGroupRules { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.InboundEndpointProtocol Protocol { get { throw null; } set { } }
    }
    public enum InterNodeCommunicationState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum IPAddressProvisioningType
    {
        BatchManaged = 0,
        UserManaged = 1,
        NoPublicIPAddresses = 2,
    }
    public partial class IPRule
    {
        public IPRule(string value) { }
        public Azure.ResourceManager.Batch.Models.IPRuleAction Action { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPRuleAction : System.IEquatable<Azure.ResourceManager.Batch.Models.IPRuleAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPRuleAction(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.IPRuleAction Allow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.IPRuleAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.IPRuleAction left, Azure.ResourceManager.Batch.Models.IPRuleAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.IPRuleAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.IPRuleAction left, Azure.ResourceManager.Batch.Models.IPRuleAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum KeySource
    {
        MicrosoftBatch = 0,
        MicrosoftKeyVault = 1,
    }
    public partial class KeyVaultReference
    {
        public KeyVaultReference(string id, System.Uri uri) { }
        public string Id { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class LinuxUserConfiguration
    {
        public LinuxUserConfiguration() { }
        public int? Gid { get { throw null; } set { } }
        public string SshPrivateKey { get { throw null; } set { } }
        public int? Uid { get { throw null; } set { } }
    }
    public enum LoginMode
    {
        Batch = 0,
        Interactive = 1,
    }
    public partial class MetadataItem
    {
        public MetadataItem(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class MountConfiguration
    {
        public MountConfiguration() { }
        public Azure.ResourceManager.Batch.Models.AzureBlobFileSystemConfiguration AzureBlobFileSystemConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.AzureFileShareConfiguration AzureFileShareConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.CifsMountConfiguration CifsMountConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.NFSMountConfiguration NfsMountConfiguration { get { throw null; } set { } }
    }
    public enum NameAvailabilityReason
    {
        Invalid = 0,
        AlreadyExists = 1,
    }
    public partial class NetworkConfiguration
    {
        public NetworkConfiguration() { }
        public Azure.ResourceManager.Batch.Models.DynamicVNetAssignmentScope? DynamicVNetAssignmentScope { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.InboundNatPool> EndpointInboundNatPools { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.PublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
    }
    public partial class NetworkSecurityGroupRule
    {
        public NetworkSecurityGroupRule(int priority, Azure.ResourceManager.Batch.Models.NetworkSecurityGroupRuleAccess access, string sourceAddressPrefix) { }
        public Azure.ResourceManager.Batch.Models.NetworkSecurityGroupRuleAccess Access { get { throw null; } set { } }
        public int Priority { get { throw null; } set { } }
        public string SourceAddressPrefix { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourcePortRanges { get { throw null; } }
    }
    public enum NetworkSecurityGroupRuleAccess
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class NFSMountConfiguration
    {
        public NFSMountConfiguration(string source, string relativeMountPath) { }
        public string MountOptions { get { throw null; } set { } }
        public string RelativeMountPath { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
    }
    public enum NodePlacementPolicyType
    {
        Regional = 0,
        Zonal = 1,
    }
    public partial class OutboundEnvironmentEndpoint
    {
        internal OutboundEnvironmentEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.Models.EndpointDependency> Endpoints { get { throw null; } }
    }
    public enum PackageState
    {
        Pending = 0,
        Active = 1,
    }
    public enum PoolAllocationMode
    {
        BatchService = 0,
        UserSubscription = 1,
    }
    public enum PoolIdentityType
    {
        None = 0,
        UserAssigned = 1,
    }
    public enum PoolProvisioningState
    {
        Succeeded = 0,
        Deleting = 1,
    }
    public enum PrivateLinkServiceConnectionStatus
    {
        Approved = 0,
        Pending = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public enum ProvisioningState
    {
        Invalid = 0,
        Creating = 1,
        Deleting = 2,
        Succeeded = 3,
        Failed = 4,
        Cancelled = 5,
    }
    public partial class PublicIPAddressConfiguration
    {
        public PublicIPAddressConfiguration() { }
        public System.Collections.Generic.IList<string> IPAddressIds { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.IPAddressProvisioningType? Provision { get { throw null; } set { } }
    }
    public enum PublicNetworkAccessType
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ResizeError
    {
        internal ResizeError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.Models.ResizeError> Details { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class ResizeOperationStatus
    {
        internal ResizeOperationStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.Models.ResizeError> Errors { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.ComputeNodeDeallocationOption? NodeDeallocationOption { get { throw null; } }
        public System.TimeSpan? ResizeTimeout { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public int? TargetDedicatedNodes { get { throw null; } }
        public int? TargetLowPriorityNodes { get { throw null; } }
    }
    public partial class ResourceFile
    {
        public ResourceFile() { }
        public string AutoStorageContainerName { get { throw null; } set { } }
        public string BlobPrefix { get { throw null; } set { } }
        public string FileMode { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        public System.Uri HttpUri { get { throw null; } set { } }
        public string IdentityReferenceResourceId { get { throw null; } set { } }
        public System.Uri StorageContainerUri { get { throw null; } set { } }
    }
    public enum ResourceIdentityType
    {
        None = 0,
        SystemAssigned = 1,
        UserAssigned = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceType : System.IEquatable<Azure.ResourceManager.Batch.Models.ResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceType(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.ResourceType MicrosoftBatchBatchAccounts { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.ResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.ResourceType left, Azure.ResourceManager.Batch.Models.ResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.ResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.ResourceType left, Azure.ResourceManager.Batch.Models.ResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScaleSettings
    {
        public ScaleSettings() { }
        public Azure.ResourceManager.Batch.Models.AutoScaleSettings AutoScale { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.FixedScaleSettings FixedScale { get { throw null; } set { } }
    }
    public partial class SkuCapability
    {
        internal SkuCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class StartTask
    {
        public StartTask() { }
        public string CommandLine { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.TaskContainerSettings ContainerSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.EnvironmentSetting> EnvironmentSettings { get { throw null; } }
        public int? MaxTaskRetryCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.ResourceFile> ResourceFiles { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.UserIdentity UserIdentity { get { throw null; } set { } }
        public bool? WaitForSuccess { get { throw null; } set { } }
    }
    public partial class SupportedSku
    {
        internal SupportedSku() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.Models.SkuCapability> Capabilities { get { throw null; } }
        public string FamilyName { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class TaskContainerSettings
    {
        public TaskContainerSettings(string imageName) { }
        public string ContainerRunOptions { get { throw null; } set { } }
        public string ImageName { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.ContainerRegistry Registry { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.ContainerWorkingDirectory? WorkingDirectory { get { throw null; } set { } }
    }
    public partial class UserAccount
    {
        public UserAccount(string name, string password) { }
        public Azure.ResourceManager.Batch.Models.ElevationLevel? ElevationLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.LinuxUserConfiguration LinuxUserConfiguration { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.LoginMode? WindowsUserLoginMode { get { throw null; } set { } }
    }
    public partial class UserIdentity
    {
        public UserIdentity() { }
        public Azure.ResourceManager.Batch.Models.AutoUserSpecification AutoUser { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    public partial class VirtualMachineConfiguration
    {
        public VirtualMachineConfiguration(Azure.ResourceManager.Batch.Models.BatchImageReference imageReference, string nodeAgentSkuId) { }
        public Azure.ResourceManager.Batch.Models.ContainerConfiguration ContainerConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchVirtualMachineDataDisk> DataDisks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.DiskEncryptionTarget> DiskEncryptionTargets { get { throw null; } }
        public bool? EnableAutomaticUpdates { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.DiffDiskPlacement? EphemeralOSDiskPlacement { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.VmExtension> Extensions { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchImageReference ImageReference { get { throw null; } set { } }
        public string LicenseType { get { throw null; } set { } }
        public string NodeAgentSkuId { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.NodePlacementPolicyType? NodePlacementPolicy { get { throw null; } set { } }
    }
    public partial class VirtualMachineFamilyCoreQuota
    {
        internal VirtualMachineFamilyCoreQuota() { }
        public int? CoreQuota { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class VmExtension
    {
        public VmExtension(string name, string publisher, string vmExtensionType) { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string VMExtensionType { get { throw null; } set { } }
    }
}
