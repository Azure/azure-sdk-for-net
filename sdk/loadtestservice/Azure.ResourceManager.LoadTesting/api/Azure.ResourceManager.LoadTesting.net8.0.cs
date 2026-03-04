namespace Azure.ResourceManager.LoadTesting
{
    public partial class AzureResourceManagerLoadTestingContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerLoadTestingContext() { }
        public static Azure.ResourceManager.LoadTesting.AzureResourceManagerLoadTestingContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
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
        public static Azure.ResourceManager.LoadTesting.LoadTestMappingResource GetLoadTestMappingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestMappingResource> GetLoadTestMappingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string loadTestMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestMappingResource>> GetLoadTestMappingResourceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string loadTestMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.LoadTesting.LoadTestMappingResourceCollection GetLoadTestMappingResources(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource GetLoadTestProfileMappingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource> GetLoadTestProfileMappingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string loadTestProfileMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource>> GetLoadTestProfileMappingResourceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string loadTestProfileMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceCollection GetLoadTestProfileMappingResources(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResource GetMaxMonthlyVirtualUserHoursResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LoadTesting.LoadTestingQuotaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestingQuotaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestingQuotaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.LoadTestingQuotaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestingQuotaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestingQuotaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestingQuotaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadTestingQuotaResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestingQuotaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestingQuotaData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LoadTestingQuotaResource() { }
        public virtual Azure.ResourceManager.LoadTesting.LoadTestingQuotaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaAvailabilityResult> CheckAvailability(Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaAvailabilityResult>> CheckAvailabilityAsync(Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string quotaBucketName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.LoadTesting.LoadTestingQuotaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestingQuotaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestingQuotaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.LoadTestingQuotaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestingQuotaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestingQuotaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestingQuotaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadTestingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestingResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestingResourceData>
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
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResource> GetMaxMonthlyVirtualUserHoursResource(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResource>> GetMaxMonthlyVirtualUserHoursResourceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResourceCollection GetMaxMonthlyVirtualUserHoursResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LoadTesting.Models.LoadTestingOutboundEnvironmentEndpoint> OutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LoadTesting.Models.LoadTestingOutboundEnvironmentEndpoint> OutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.LoadTesting.LoadTestingResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestingResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestingResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.LoadTestingResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestingResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestingResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestingResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LoadTesting.LoadTestingResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestingResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestingResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.LoadTestingResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestingResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestingResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestingResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadTestMappingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestMappingResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestMappingResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LoadTestMappingResource() { }
        public virtual Azure.ResourceManager.LoadTesting.LoadTestMappingResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string loadTestMappingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestMappingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestMappingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.LoadTesting.LoadTestMappingResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestMappingResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestMappingResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.LoadTestMappingResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestMappingResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestMappingResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestMappingResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestMappingResource> Update(Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestMappingResource>> UpdateAsync(Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LoadTestMappingResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LoadTesting.LoadTestMappingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LoadTesting.LoadTestMappingResource>, System.Collections.IEnumerable
    {
        protected LoadTestMappingResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LoadTesting.LoadTestMappingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string loadTestMappingName, Azure.ResourceManager.LoadTesting.LoadTestMappingResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LoadTesting.LoadTestMappingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string loadTestMappingName, Azure.ResourceManager.LoadTesting.LoadTestMappingResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string loadTestMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string loadTestMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestMappingResource> Get(string loadTestMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LoadTesting.LoadTestMappingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LoadTesting.LoadTestMappingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestMappingResource>> GetAsync(string loadTestMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.LoadTesting.LoadTestMappingResource> GetIfExists(string loadTestMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.LoadTesting.LoadTestMappingResource>> GetIfExistsAsync(string loadTestMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LoadTesting.LoadTestMappingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LoadTesting.LoadTestMappingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LoadTesting.LoadTestMappingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LoadTesting.LoadTestMappingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LoadTestMappingResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestMappingResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestMappingResourceData>
    {
        public LoadTestMappingResourceData() { }
        public Azure.ResourceManager.LoadTesting.Models.LoadTestMappingProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LoadTesting.LoadTestMappingResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestMappingResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestMappingResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.LoadTestMappingResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestMappingResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestMappingResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestMappingResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadTestProfileMappingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LoadTestProfileMappingResource() { }
        public virtual Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string loadTestProfileMappingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource> Update(Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource>> UpdateAsync(Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LoadTestProfileMappingResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource>, System.Collections.IEnumerable
    {
        protected LoadTestProfileMappingResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string loadTestProfileMappingName, Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string loadTestProfileMappingName, Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string loadTestProfileMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string loadTestProfileMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource> Get(string loadTestProfileMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource>> GetAsync(string loadTestProfileMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource> GetIfExists(string loadTestProfileMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource>> GetIfExistsAsync(string loadTestProfileMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LoadTestProfileMappingResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceData>
    {
        public LoadTestProfileMappingResourceData() { }
        public Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MaxMonthlyVirtualUserHoursResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MaxMonthlyVirtualUserHoursResource() { }
        public virtual Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string loadTestName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResource> Set(Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursLimitRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResource>> SetAsync(Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursLimitRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MaxMonthlyVirtualUserHoursResourceCollection : Azure.ResourceManager.ArmCollection
    {
        protected MaxMonthlyVirtualUserHoursResourceCollection() { }
        public virtual Azure.Response<bool> Exists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResource> GetIfExists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResource>> GetIfExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MaxMonthlyVirtualUserHoursResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResourceData>
    {
        internal MaxMonthlyVirtualUserHoursResourceData() { }
        public Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursResourceProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.LoadTesting.Mocking
{
    public partial class MockableLoadTestingArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableLoadTestingArmClient() { }
        public virtual Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource GetLoadTestingQuotaResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.LoadTesting.LoadTestingResource GetLoadTestingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.LoadTesting.LoadTestMappingResource GetLoadTestMappingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestMappingResource> GetLoadTestMappingResource(Azure.Core.ResourceIdentifier scope, string loadTestMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestMappingResource>> GetLoadTestMappingResourceAsync(Azure.Core.ResourceIdentifier scope, string loadTestMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LoadTesting.LoadTestMappingResourceCollection GetLoadTestMappingResources(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource GetLoadTestProfileMappingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource> GetLoadTestProfileMappingResource(Azure.Core.ResourceIdentifier scope, string loadTestProfileMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResource>> GetLoadTestProfileMappingResourceAsync(Azure.Core.ResourceIdentifier scope, string loadTestProfileMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceCollection GetLoadTestProfileMappingResources(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResource GetMaxMonthlyVirtualUserHoursResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public static Azure.ResourceManager.LoadTesting.LoadTestMappingResourceData LoadTestMappingResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.LoadTesting.Models.LoadTestMappingProperties properties = null) { throw null; }
        public static Azure.ResourceManager.LoadTesting.LoadTestProfileMappingResourceData LoadTestProfileMappingResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingProperties properties = null) { throw null; }
        public static Azure.ResourceManager.LoadTesting.MaxMonthlyVirtualUserHoursResourceData MaxMonthlyVirtualUserHoursResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursResourceProperties MaxMonthlyVirtualUserHoursResourceProperties(int? limit = default(int?), int? usage = default(int?), Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState? provisioningState = default(Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState?)) { throw null; }
    }
    public partial class LoadTestingCmkEncryptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkEncryptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkEncryptionProperties>
    {
        public LoadTestingCmkEncryptionProperties() { }
        public Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentity Identity { get { throw null; } set { } }
        public System.Uri KeyUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkEncryptionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkEncryptionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType left, Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType left, Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LoadTestingEndpointDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDependency>
    {
        internal LoadTestingEndpointDependency() { }
        public string Description { get { throw null; } }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDetail> EndpointDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDependency JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDependency PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestingOutboundEnvironmentEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestingOutboundEnvironmentEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState left, Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState left, Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LoadTestingQuotaAvailabilityResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaAvailabilityResult>
    {
        public LoadTestingQuotaAvailabilityResult() { }
        public string AvailabilityStatus { get { throw null; } set { } }
        public bool? IsAvailable { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketDimensions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketDimensions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestingResourcePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestingResourcePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LoadTesting.Models.LoadTestingResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.Models.LoadTestingResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestingResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadTestMappingProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestMappingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestMappingProperties>
    {
        public LoadTestMappingProperties() { }
        public string AzureLoadTestingResourceId { get { throw null; } set { } }
        public string SourceResourceId { get { throw null; } set { } }
        public string TestId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestMappingProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestMappingProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LoadTesting.Models.LoadTestMappingProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestMappingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestMappingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.Models.LoadTestMappingProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestMappingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestMappingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestMappingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadTestMappingResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourcePatch>
    {
        public LoadTestMappingResourcePatch() { }
        public Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourceUpdateProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourcePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourcePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadTestMappingResourceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourceUpdateProperties>
    {
        public LoadTestMappingResourceUpdateProperties() { }
        public string AzureLoadTestingResourceId { get { throw null; } set { } }
        public string SourceResourceId { get { throw null; } set { } }
        public string TestId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourceUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourceUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestMappingResourceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadTestProfileMappingProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingProperties>
    {
        public LoadTestProfileMappingProperties() { }
        public string AzureLoadTestingResourceId { get { throw null; } set { } }
        public string SourceResourceId { get { throw null; } set { } }
        public string TestProfileId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadTestProfileMappingResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourcePatch>
    {
        public LoadTestProfileMappingResourcePatch() { }
        public Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourceUpdateProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourcePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourcePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadTestProfileMappingResourceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourceUpdateProperties>
    {
        public LoadTestProfileMappingResourceUpdateProperties() { }
        public string AzureLoadTestingResourceId { get { throw null; } set { } }
        public string SourceResourceId { get { throw null; } set { } }
        public string TestProfileId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourceUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourceUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.LoadTestProfileMappingResourceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MaxMonthlyVirtualUserHoursLimitRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursLimitRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursLimitRequest>
    {
        public MaxMonthlyVirtualUserHoursLimitRequest() { }
        public int? Limit { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursLimitRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursLimitRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursLimitRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursLimitRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursLimitRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursLimitRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursLimitRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursLimitRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursLimitRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MaxMonthlyVirtualUserHoursResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursResourceProperties>
    {
        internal MaxMonthlyVirtualUserHoursResourceProperties() { }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState? ProvisioningState { get { throw null; } }
        public int? Usage { get { throw null; } }
        protected virtual Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LoadTesting.Models.MaxMonthlyVirtualUserHoursResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
