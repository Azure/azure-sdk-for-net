namespace Azure.ResourceManager.LoadTesting
{
    public static partial class LoadTestingExtensions
    {
        public static Azure.ResourceManager.LoadTesting.LoadTestingQuotaCollection GetAllLoadTestingQuota(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource> GetLoadTestingQuota(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string quotaBucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource>> GetLoadTestingQuotaAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string quotaBucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource GetLoadTestingQuotaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.LoadTesting.LoadTestingResource GetLoadTestingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource> GetLoadTestingResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string loadTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource>> GetLoadTestingResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string loadTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.LoadTesting.LoadTestingResourceCollection GetLoadTestingResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.LoadTesting.LoadTestingResource> GetLoadTestingResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.LoadTesting.LoadTestingResource> GetLoadTestingResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LoadTestingQuotaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource>, System.Collections.IEnumerable
    {
        protected LoadTestingQuotaCollection() { }
        public virtual Azure.Response<bool> Exists(string quotaBucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string quotaBucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource> Get(string quotaBucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource>> GetAsync(string quotaBucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource> GetIfExists(string quotaBucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource>> GetIfExistsAsync(string quotaBucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LoadTestingQuotaData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestingQuotaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestingQuotaData>
    {
        public LoadTestingQuotaData() { }
        public int? Limit { get { throw null; } set { } }
        public Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState? ProvisioningState { get { throw null; } }
        public int? Usage { get { throw null; } set { } }
        Azure.ResourceManager.LoadTesting.LoadTestingQuotaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestingQuotaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestingQuotaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.LoadTestingQuotaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestingQuotaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestingQuotaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestingQuotaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadTestingQuotaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LoadTestingQuotaResource() { }
        public virtual Azure.ResourceManager.LoadTesting.LoadTestingQuotaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaAvailabilityResult> CheckLoadTestingQuotaAvailability(Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaAvailabilityResult>> CheckLoadTestingQuotaAvailabilityAsync(Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string quotaBucketName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LoadTestingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LoadTestingResource() { }
        public virtual Azure.ResourceManager.LoadTesting.LoadTestingResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string loadTestName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LoadTesting.Models.LoadTestingOutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LoadTesting.Models.LoadTestingOutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LoadTesting.LoadTestingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.LoadTesting.Models.LoadTestingResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LoadTesting.LoadTestingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.LoadTesting.Models.LoadTestingResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LoadTestingResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LoadTesting.LoadTestingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LoadTesting.LoadTestingResource>, System.Collections.IEnumerable
    {
        protected LoadTestingResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LoadTesting.LoadTestingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string loadTestName, Azure.ResourceManager.LoadTesting.LoadTestingResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LoadTesting.LoadTestingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string loadTestName, Azure.ResourceManager.LoadTesting.LoadTestingResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string loadTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string loadTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource> Get(string loadTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LoadTesting.LoadTestingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LoadTesting.LoadTestingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource>> GetAsync(string loadTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.LoadTesting.LoadTestingResource> GetIfExists(string loadTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.LoadTesting.LoadTestingResource>> GetIfExistsAsync(string loadTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LoadTesting.LoadTestingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LoadTesting.LoadTestingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LoadTesting.LoadTestingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LoadTesting.LoadTestingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LoadTestingResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestingResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestingResourceData>
    {
        public LoadTestingResourceData(Azure.Core.AzureLocation location) { }
        public string DataPlaneUri { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkEncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.LoadTesting.LoadTestingResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestingResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestingResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.LoadTestingResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestingResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestingResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestingResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.LoadTesting.Mocking
{
    public partial class MockableLoadTestingArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableLoadTestingArmClient() { }
        public virtual Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource GetLoadTestingQuotaResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.LoadTesting.LoadTestingResource GetLoadTestingResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableLoadTestingResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableLoadTestingResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource> GetLoadTestingResource(string loadTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource>> GetLoadTestingResourceAsync(string loadTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LoadTesting.LoadTestingResourceCollection GetLoadTestingResources() { throw null; }
    }
    public partial class MockableLoadTestingSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableLoadTestingSubscriptionResource() { }
        public virtual Azure.ResourceManager.LoadTesting.LoadTestingQuotaCollection GetAllLoadTestingQuota(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource> GetLoadTestingQuota(Azure.Core.AzureLocation location, string quotaBucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource>> GetLoadTestingQuotaAsync(Azure.Core.AzureLocation location, string quotaBucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LoadTesting.LoadTestingResource> GetLoadTestingResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LoadTesting.LoadTestingResource> GetLoadTestingResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.LoadTesting.Models
{
    public static partial class ArmLoadTestingModelFactory
    {
        public static Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDependency LoadTestingEndpointDependency(string domainName = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDetail> endpointDetails = null) { throw null; }
        public static Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDetail LoadTestingEndpointDetail(int? port = default(int?)) { throw null; }
        public static Azure.ResourceManager.LoadTesting.Models.LoadTestingOutboundEnvironmentEndpoint LoadTestingOutboundEnvironmentEndpoint(string category = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDependency> endpoints = null) { throw null; }
        public static Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaAvailabilityResult LoadTestingQuotaAvailabilityResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, bool? isAvailable = default(bool?), string availabilityStatus = null) { throw null; }
        public static Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketContent LoadTestingQuotaBucketContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, int? currentUsage = default(int?), int? currentQuota = default(int?), int? newQuota = default(int?), Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketDimensions dimensions = null) { throw null; }
        public static Azure.ResourceManager.LoadTesting.LoadTestingQuotaData LoadTestingQuotaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, int? limit = default(int?), int? usage = default(int?), Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState? provisioningState = default(Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.LoadTesting.LoadTestingResourceData LoadTestingResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string description = null, Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState? provisioningState = default(Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState?), string dataPlaneUri = null, Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkEncryptionProperties encryption = null) { throw null; }
    }
    public partial class LoadTestingCmkEncryptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkEncryptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkEncryptionProperties>
    {
        public LoadTestingCmkEncryptionProperties() { }
        public Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentity Identity { get { throw null; } set { } }
        public System.Uri KeyUri { get { throw null; } set { } }
        Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkEncryptionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkEncryptionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkEncryptionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkEncryptionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkEncryptionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkEncryptionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkEncryptionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadTestingCmkIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentity>
    {
        public LoadTestingCmkIdentity() { }
        public Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType? IdentityType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoadTestingCmkIdentityType : System.IEquatable<Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoadTestingCmkIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType left, Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType left, Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LoadTestingEndpointDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDependency>
    {
        internal LoadTestingEndpointDependency() { }
        public string Description { get { throw null; } }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDetail> EndpointDetails { get { throw null; } }
        Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadTestingEndpointDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDetail>
    {
        internal LoadTestingEndpointDetail() { }
        public int? Port { get { throw null; } }
        Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadTestingOutboundEnvironmentEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingOutboundEnvironmentEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingOutboundEnvironmentEndpoint>
    {
        internal LoadTestingOutboundEnvironmentEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDependency> Endpoints { get { throw null; } }
        Azure.ResourceManager.LoadTesting.Models.LoadTestingOutboundEnvironmentEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingOutboundEnvironmentEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingOutboundEnvironmentEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.Models.LoadTestingOutboundEnvironmentEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingOutboundEnvironmentEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingOutboundEnvironmentEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingOutboundEnvironmentEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoadTestingProvisioningState : System.IEquatable<Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoadTestingProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState left, Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState left, Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LoadTestingQuotaAvailabilityResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaAvailabilityResult>
    {
        public LoadTestingQuotaAvailabilityResult() { }
        public string AvailabilityStatus { get { throw null; } set { } }
        public bool? IsAvailable { get { throw null; } set { } }
        Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadTestingQuotaBucketContent : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketContent>
    {
        public LoadTestingQuotaBucketContent() { }
        public int? CurrentQuota { get { throw null; } set { } }
        public int? CurrentUsage { get { throw null; } set { } }
        public Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketDimensions Dimensions { get { throw null; } set { } }
        public int? NewQuota { get { throw null; } set { } }
        Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadTestingQuotaBucketDimensions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketDimensions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketDimensions>
    {
        public LoadTestingQuotaBucketDimensions() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketDimensions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketDimensions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketDimensions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketDimensions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketDimensions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketDimensions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketDimensions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadTestingResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingResourcePatch>
    {
        public LoadTestingResourcePatch() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkEncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        Azure.ResourceManager.LoadTesting.Models.LoadTestingResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.Models.LoadTestingResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
