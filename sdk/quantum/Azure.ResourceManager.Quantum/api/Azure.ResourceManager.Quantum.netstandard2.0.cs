namespace Azure.ResourceManager.Quantum
{
    public static partial class QuantumExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityResult> CheckNameAvailabilityWorkspace(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityWorkspaceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Quantum.Models.ProviderDescription> GetOfferings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Quantum.Models.ProviderDescription> GetOfferingsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Quantum.QuantumWorkspaceResource> GetQuantumWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quantum.QuantumWorkspaceResource>> GetQuantumWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Quantum.QuantumWorkspaceResource GetQuantumWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Quantum.QuantumWorkspaceCollection GetQuantumWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Quantum.QuantumWorkspaceResource> GetQuantumWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Quantum.QuantumWorkspaceResource> GetQuantumWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QuantumWorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quantum.QuantumWorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quantum.QuantumWorkspaceResource>, System.Collections.IEnumerable
    {
        protected QuantumWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quantum.QuantumWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Quantum.QuantumWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quantum.QuantumWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Quantum.QuantumWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quantum.QuantumWorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quantum.QuantumWorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quantum.QuantumWorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quantum.QuantumWorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Quantum.QuantumWorkspaceResource> GetIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Quantum.QuantumWorkspaceResource>> GetIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Quantum.QuantumWorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quantum.QuantumWorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Quantum.QuantumWorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quantum.QuantumWorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class QuantumWorkspaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.QuantumWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.QuantumWorkspaceData>
    {
        public QuantumWorkspaceData(Azure.Core.AzureLocation location) { }
        public System.Uri EndpointUri { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Quantum.Models.Provider> Providers { get { throw null; } }
        public Azure.ResourceManager.Quantum.Models.ProvisioningStatus? ProvisioningState { get { throw null; } }
        public string StorageAccount { get { throw null; } set { } }
        public Azure.ResourceManager.Quantum.Models.UsableStatus? Usable { get { throw null; } }
        Azure.ResourceManager.Quantum.QuantumWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.QuantumWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.QuantumWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.QuantumWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.QuantumWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.QuantumWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.QuantumWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuantumWorkspaceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QuantumWorkspaceResource() { }
        public virtual Azure.ResourceManager.Quantum.QuantumWorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Quantum.QuantumWorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quantum.QuantumWorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quantum.QuantumWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quantum.QuantumWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quantum.QuantumWorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quantum.QuantumWorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quantum.QuantumWorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quantum.QuantumWorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quantum.QuantumWorkspaceResource> Update(Azure.ResourceManager.Quantum.Models.QuantumWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quantum.QuantumWorkspaceResource>> UpdateAsync(Azure.ResourceManager.Quantum.Models.QuantumWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Quantum.Mocking
{
    public partial class MockableQuantumArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableQuantumArmClient() { }
        public virtual Azure.ResourceManager.Quantum.QuantumWorkspaceResource GetQuantumWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableQuantumResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableQuantumResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Quantum.QuantumWorkspaceResource> GetQuantumWorkspace(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quantum.QuantumWorkspaceResource>> GetQuantumWorkspaceAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Quantum.QuantumWorkspaceCollection GetQuantumWorkspaces() { throw null; }
    }
    public partial class MockableQuantumSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableQuantumSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityResult> CheckNameAvailabilityWorkspace(string locationName, Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityWorkspaceAsync(string locationName, Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quantum.Models.ProviderDescription> GetOfferings(string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quantum.Models.ProviderDescription> GetOfferingsAsync(string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quantum.QuantumWorkspaceResource> GetQuantumWorkspaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quantum.QuantumWorkspaceResource> GetQuantumWorkspacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Quantum.Models
{
    public static partial class ArmQuantumModelFactory
    {
        public static Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityResult CheckNameAvailabilityResult(bool? nameAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.PricingDetail PricingDetail(string id = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.PricingDimension PricingDimension(string id = null, string name = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.ProviderDescription ProviderDescription(string id = null, string name = null, Azure.ResourceManager.Quantum.Models.ProviderProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.ProviderProperties ProviderProperties(string description = null, string providerType = null, string company = null, string defaultEndpoint = null, Azure.ResourceManager.Quantum.Models.ProviderPropertiesAad aad = null, Azure.ResourceManager.Quantum.Models.ProviderPropertiesManagedApplication managedApplication = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quantum.Models.TargetDescription> targets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quantum.Models.SkuDescription> skus = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quantum.Models.QuotaDimension> quotaDimensions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quantum.Models.PricingDimension> pricingDimensions = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.ProviderPropertiesAad ProviderPropertiesAad(string applicationId = null, System.Guid? tenantId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.ProviderPropertiesManagedApplication ProviderPropertiesManagedApplication(string publisherId = null, string offerId = null) { throw null; }
        public static Azure.ResourceManager.Quantum.QuantumWorkspaceData QuantumWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quantum.Models.Provider> providers = null, Azure.ResourceManager.Quantum.Models.UsableStatus? usable = default(Azure.ResourceManager.Quantum.Models.UsableStatus?), Azure.ResourceManager.Quantum.Models.ProvisioningStatus? provisioningState = default(Azure.ResourceManager.Quantum.Models.ProvisioningStatus?), string storageAccount = null, System.Uri endpointUri = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.QuotaDimension QuotaDimension(string id = null, string scope = null, string period = null, float? quota = default(float?), string name = null, string description = null, string unit = null, string unitPlural = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.SkuDescription SkuDescription(string id = null, string name = null, string version = null, string description = null, System.Uri restrictedAccessUri = null, bool? autoAdd = default(bool?), System.Collections.Generic.IEnumerable<string> targets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quantum.Models.QuotaDimension> quotaDimensions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quantum.Models.PricingDetail> pricingDetails = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.TargetDescription TargetDescription(string id = null, string name = null, string description = null, System.Collections.Generic.IEnumerable<string> acceptedDataFormats = null, System.Collections.Generic.IEnumerable<string> acceptedContentEncodings = null) { throw null; }
    }
    public partial class CheckNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityContent>
    {
        public CheckNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityResult>
    {
        internal CheckNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
        Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PricingDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.PricingDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.PricingDetail>
    {
        internal PricingDetail() { }
        public string Id { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.ResourceManager.Quantum.Models.PricingDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.PricingDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.PricingDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.PricingDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.PricingDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.PricingDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.PricingDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PricingDimension : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.PricingDimension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.PricingDimension>
    {
        internal PricingDimension() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        Azure.ResourceManager.Quantum.Models.PricingDimension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.PricingDimension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.PricingDimension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.PricingDimension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.PricingDimension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.PricingDimension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.PricingDimension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Provider : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.Provider>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.Provider>
    {
        public Provider() { }
        public string ApplicationName { get { throw null; } set { } }
        public System.Uri InstanceUri { get { throw null; } set { } }
        public string ProviderId { get { throw null; } set { } }
        public string ProviderSku { get { throw null; } set { } }
        public Azure.ResourceManager.Quantum.Models.Status? ProvisioningState { get { throw null; } set { } }
        public string ResourceUsageId { get { throw null; } set { } }
        Azure.ResourceManager.Quantum.Models.Provider System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.Provider>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.Provider>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.Provider System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.Provider>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.Provider>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.Provider>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderDescription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderDescription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderDescription>
    {
        internal ProviderDescription() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Quantum.Models.ProviderProperties Properties { get { throw null; } }
        Azure.ResourceManager.Quantum.Models.ProviderDescription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderDescription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderDescription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.ProviderDescription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderDescription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderDescription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderDescription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderProperties>
    {
        internal ProviderProperties() { }
        public Azure.ResourceManager.Quantum.Models.ProviderPropertiesAad Aad { get { throw null; } }
        public string Company { get { throw null; } }
        public string DefaultEndpoint { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.Quantum.Models.ProviderPropertiesManagedApplication ManagedApplication { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Quantum.Models.PricingDimension> PricingDimensions { get { throw null; } }
        public string ProviderType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Quantum.Models.QuotaDimension> QuotaDimensions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Quantum.Models.SkuDescription> Skus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Quantum.Models.TargetDescription> Targets { get { throw null; } }
        Azure.ResourceManager.Quantum.Models.ProviderProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.ProviderProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderPropertiesAad : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderPropertiesAad>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderPropertiesAad>
    {
        internal ProviderPropertiesAad() { }
        public string ApplicationId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        Azure.ResourceManager.Quantum.Models.ProviderPropertiesAad System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderPropertiesAad>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderPropertiesAad>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.ProviderPropertiesAad System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderPropertiesAad>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderPropertiesAad>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderPropertiesAad>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderPropertiesManagedApplication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderPropertiesManagedApplication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderPropertiesManagedApplication>
    {
        internal ProviderPropertiesManagedApplication() { }
        public string OfferId { get { throw null; } }
        public string PublisherId { get { throw null; } }
        Azure.ResourceManager.Quantum.Models.ProviderPropertiesManagedApplication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderPropertiesManagedApplication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderPropertiesManagedApplication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.ProviderPropertiesManagedApplication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderPropertiesManagedApplication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderPropertiesManagedApplication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderPropertiesManagedApplication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningStatus : System.IEquatable<Azure.ResourceManager.Quantum.Models.ProvisioningStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningStatus(string value) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.ProvisioningStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.ProvisioningStatus ProviderDeleting { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.ProvisioningStatus ProviderLaunching { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.ProvisioningStatus ProviderProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.ProvisioningStatus ProviderUpdating { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.ProvisioningStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Quantum.Models.ProvisioningStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Quantum.Models.ProvisioningStatus left, Azure.ResourceManager.Quantum.Models.ProvisioningStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Quantum.Models.ProvisioningStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Quantum.Models.ProvisioningStatus left, Azure.ResourceManager.Quantum.Models.ProvisioningStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuantumWorkspacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumWorkspacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumWorkspacePatch>
    {
        public QuantumWorkspacePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Quantum.Models.QuantumWorkspacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumWorkspacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumWorkspacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.QuantumWorkspacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumWorkspacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumWorkspacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumWorkspacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuotaDimension : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuotaDimension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuotaDimension>
    {
        internal QuotaDimension() { }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Period { get { throw null; } }
        public float? Quota { get { throw null; } }
        public string Scope { get { throw null; } }
        public string Unit { get { throw null; } }
        public string UnitPlural { get { throw null; } }
        Azure.ResourceManager.Quantum.Models.QuotaDimension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuotaDimension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuotaDimension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.QuotaDimension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuotaDimension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuotaDimension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuotaDimension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuDescription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.SkuDescription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.SkuDescription>
    {
        internal SkuDescription() { }
        public bool? AutoAdd { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Quantum.Models.PricingDetail> PricingDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Quantum.Models.QuotaDimension> QuotaDimensions { get { throw null; } }
        public System.Uri RestrictedAccessUri { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Targets { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.ResourceManager.Quantum.Models.SkuDescription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.SkuDescription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.SkuDescription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.SkuDescription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.SkuDescription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.SkuDescription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.SkuDescription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.Quantum.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.Status Deleted { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.Status Deleting { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.Status Failed { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.Status Launching { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.Status Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.Status Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Quantum.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Quantum.Models.Status left, Azure.ResourceManager.Quantum.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.Quantum.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Quantum.Models.Status left, Azure.ResourceManager.Quantum.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TargetDescription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.TargetDescription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.TargetDescription>
    {
        internal TargetDescription() { }
        public System.Collections.Generic.IReadOnlyList<string> AcceptedContentEncodings { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AcceptedDataFormats { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        Azure.ResourceManager.Quantum.Models.TargetDescription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.TargetDescription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.TargetDescription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.TargetDescription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.TargetDescription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.TargetDescription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.TargetDescription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsableStatus : System.IEquatable<Azure.ResourceManager.Quantum.Models.UsableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsableStatus(string value) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.UsableStatus No { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.UsableStatus Partial { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.UsableStatus Yes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Quantum.Models.UsableStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Quantum.Models.UsableStatus left, Azure.ResourceManager.Quantum.Models.UsableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Quantum.Models.UsableStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Quantum.Models.UsableStatus left, Azure.ResourceManager.Quantum.Models.UsableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
