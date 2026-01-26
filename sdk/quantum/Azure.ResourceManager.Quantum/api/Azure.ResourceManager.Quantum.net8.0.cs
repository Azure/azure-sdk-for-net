namespace Azure.ResourceManager.Quantum
{
    public partial class AzureResourceManagerQuantumContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerQuantumContext() { }
        public static Azure.ResourceManager.Quantum.AzureResourceManagerQuantumContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class QuantumExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityResult> CheckWorkspaceNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityResult>> CheckWorkspaceNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Quantum.Models.QuantumProviderDescription> GetAll(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Quantum.Models.QuantumProviderDescription> GetAllAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Quantum.Models.QuantumSuiteOffer> GetBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Quantum.Models.QuantumSuiteOffer> GetBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Quantum.Models.WorkspaceResourceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Quantum.QuantumWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.QuantumWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.QuantumWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.QuantumWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.QuantumWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.QuantumWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.QuantumWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuantumWorkspaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.QuantumWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.QuantumWorkspaceData>
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
        public virtual Azure.Response<Azure.ResourceManager.Quantum.Models.WorkspaceKeyListResult> GetKeysWorkspace(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quantum.Models.WorkspaceKeyListResult>> GetKeysWorkspaceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RegenerateKeysWorkspace(Azure.ResourceManager.Quantum.Models.WorkspaceApiKeys keySpecification, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegenerateKeysWorkspaceAsync(Azure.ResourceManager.Quantum.Models.WorkspaceApiKeys keySpecification, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quantum.QuantumWorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quantum.QuantumWorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quantum.QuantumWorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quantum.QuantumWorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Quantum.QuantumWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.QuantumWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.QuantumWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.QuantumWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.QuantumWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.QuantumWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.QuantumWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityResult> CheckWorkspaceNameAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityResult>> CheckWorkspaceNameAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quantum.Models.QuantumProviderDescription> GetAll(Azure.Core.AzureLocation locationName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quantum.Models.QuantumProviderDescription> GetAllAsync(Azure.Core.AzureLocation locationName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quantum.Models.QuantumSuiteOffer> GetBySubscription(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quantum.Models.QuantumSuiteOffer> GetBySubscriptionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quantum.QuantumWorkspaceResource> GetQuantumWorkspaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quantum.QuantumWorkspaceResource> GetQuantumWorkspacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Quantum.Models
{
    public static partial class ArmQuantumModelFactory
    {
        public static Azure.ResourceManager.Quantum.Models.MoboBrokerResource MoboBrokerResource(Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.ProviderAadInfo ProviderAadInfo(string applicationId = null, System.Guid? tenantId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.ProviderApplicationInfo ProviderApplicationInfo(string publisherId = null, string offerId = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.ProviderPricingDimension ProviderPricingDimension(string id = null, string name = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.ProviderSkuDescription ProviderSkuDescription(string id = null, string name = null, string version = null, string description = null, System.Uri restrictedAccessUri = null, bool? autoAdd = default(bool?), System.Collections.Generic.IEnumerable<string> targets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quantum.Models.QuantumQuotaDimension> quotaDimensions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quantum.Models.QuantumPricingDetail> pricingDetails = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.ProviderTargetDescription ProviderTargetDescription(string id = null, string name = null, string description = null, System.Collections.Generic.IEnumerable<string> acceptedDataFormats = null, System.Collections.Generic.IEnumerable<string> acceptedContentEncodings = null, int? numQubits = default(int?), string targetProfile = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> metadata = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.QuantumPricingDetail QuantumPricingDetail(string id = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.QuantumProviderDescription QuantumProviderDescription(string id = null, string name = null, Azure.ResourceManager.Quantum.Models.QuantumProviderProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.QuantumProviderProperties QuantumProviderProperties(string description = null, string providerType = null, string company = null, string defaultEndpoint = null, Azure.ResourceManager.Quantum.Models.ProviderAadInfo aad = null, Azure.ResourceManager.Quantum.Models.ProviderApplicationInfo managedApplication = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quantum.Models.ProviderTargetDescription> targets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quantum.Models.ProviderSkuDescription> skus = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quantum.Models.QuantumQuotaDimension> quotaDimensions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quantum.Models.ProviderPricingDimension> pricingDimensions = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.QuantumQuotaDimension QuantumQuotaDimension(string id = null, string scope = null, string period = null, float? quota = default(float?), string name = null, string description = null, string unit = null, string unitPlural = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.QuantumSuiteOffer QuantumSuiteOffer(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quantum.Models.QuantumSuiteOfferProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.QuantumSuiteOfferProperties QuantumSuiteOfferProperties(string providerId = null, string providerName = null, string companyName = null, string location = null, string description = null, Azure.Core.AzureLocation? quotas = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.Quantum.QuantumWorkspaceData QuantumWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Quantum.Models.WorkspaceResourceProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.QuantumWorkspacePatch QuantumWorkspacePatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.WorkspaceApiKey WorkspaceApiKey(System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string key = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.WorkspaceApiKeys WorkspaceApiKeys(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quantum.Models.WorkspaceKeyType> keys = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.WorkspaceKeyListResult WorkspaceKeyListResult(bool? isApiKeyEnabled = default(bool?), Azure.ResourceManager.Quantum.Models.WorkspaceApiKey primaryKey = null, Azure.ResourceManager.Quantum.Models.WorkspaceApiKey secondaryKey = null, string primaryConnectionString = null, string secondaryConnectionString = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityResult WorkspaceNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityReason? reason = default(Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.WorkspaceResourceProperties WorkspaceResourceProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quantum.Models.QuantumProvider> providers = null, Azure.ResourceManager.Quantum.Models.WorkspaceUsableStatus? usable = default(Azure.ResourceManager.Quantum.Models.WorkspaceUsableStatus?), Azure.ResourceManager.Quantum.Models.ProviderProvisioningStatus? provisioningState = default(Azure.ResourceManager.Quantum.Models.ProviderProvisioningStatus?), Azure.Core.ResourceIdentifier storageAccount = null, Azure.ResourceManager.Quantum.Models.QuantumWorkspaceKind? workspaceKind = default(Azure.ResourceManager.Quantum.Models.QuantumWorkspaceKind?), System.Uri endpointUri = null, bool? isApiKeyEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quantum.Models.MoboBrokerResource> managedOnBehalfOfMoboBrokerResources = null, Azure.Core.ResourceIdentifier managedStorageAccount = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CheckNameAvailabilityReason : System.IEquatable<Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CheckNameAvailabilityReason(string value) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MoboBrokerResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.MoboBrokerResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.MoboBrokerResource>
    {
        internal MoboBrokerResource() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        protected virtual Azure.ResourceManager.Quantum.Models.MoboBrokerResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Quantum.Models.MoboBrokerResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Quantum.Models.MoboBrokerResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.MoboBrokerResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.MoboBrokerResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.MoboBrokerResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.MoboBrokerResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.MoboBrokerResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.MoboBrokerResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderAadInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderAadInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderAadInfo>
    {
        internal ProviderAadInfo() { }
        public string ApplicationId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        protected virtual Azure.ResourceManager.Quantum.Models.ProviderAadInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Quantum.Models.ProviderAadInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Quantum.Models.ProviderAadInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderAadInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderAadInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.ProviderAadInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderAadInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderAadInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderAadInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderApplicationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderApplicationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderApplicationInfo>
    {
        internal ProviderApplicationInfo() { }
        public string OfferId { get { throw null; } }
        public string PublisherId { get { throw null; } }
        protected virtual Azure.ResourceManager.Quantum.Models.ProviderApplicationInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Quantum.Models.ProviderApplicationInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Quantum.Models.ProviderApplicationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderApplicationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderApplicationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.ProviderApplicationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderApplicationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderApplicationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderApplicationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderPricingDimension : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderPricingDimension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderPricingDimension>
    {
        internal ProviderPricingDimension() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.Quantum.Models.ProviderPricingDimension JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Quantum.Models.ProviderPricingDimension PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Quantum.Models.ProviderPricingDimension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderPricingDimension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderPricingDimension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.ProviderPricingDimension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderPricingDimension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderPricingDimension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderPricingDimension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProviderProvisioningStatus : System.IEquatable<Azure.ResourceManager.Quantum.Models.ProviderProvisioningStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProviderProvisioningStatus(string value) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.ProviderProvisioningStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.ProviderProvisioningStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.ProviderProvisioningStatus ProviderDeleting { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.ProviderProvisioningStatus ProviderLaunching { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.ProviderProvisioningStatus ProviderProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.ProviderProvisioningStatus ProviderUpdating { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.ProviderProvisioningStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Quantum.Models.ProviderProvisioningStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Quantum.Models.ProviderProvisioningStatus left, Azure.ResourceManager.Quantum.Models.ProviderProvisioningStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Quantum.Models.ProviderProvisioningStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Quantum.Models.ProviderProvisioningStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Quantum.Models.ProviderProvisioningStatus left, Azure.ResourceManager.Quantum.Models.ProviderProvisioningStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProviderSkuDescription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderSkuDescription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderSkuDescription>
    {
        internal ProviderSkuDescription() { }
        public bool? AutoAdd { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Quantum.Models.QuantumPricingDetail> PricingDetails { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Quantum.Models.QuantumQuotaDimension> QuotaDimensions { get { throw null; } }
        public System.Uri RestrictedAccessUri { get { throw null; } }
        public System.Collections.Generic.IList<string> Targets { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.Quantum.Models.ProviderSkuDescription JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Quantum.Models.ProviderSkuDescription PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Quantum.Models.ProviderSkuDescription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderSkuDescription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderSkuDescription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.ProviderSkuDescription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderSkuDescription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderSkuDescription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderSkuDescription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderTargetDescription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderTargetDescription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderTargetDescription>
    {
        internal ProviderTargetDescription() { }
        public System.Collections.Generic.IList<string> AcceptedContentEncodings { get { throw null; } }
        public System.Collections.Generic.IList<string> AcceptedDataFormats { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public int? NumQubits { get { throw null; } }
        public string TargetProfile { get { throw null; } }
        protected virtual Azure.ResourceManager.Quantum.Models.ProviderTargetDescription JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Quantum.Models.ProviderTargetDescription PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Quantum.Models.ProviderTargetDescription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderTargetDescription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.ProviderTargetDescription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.ProviderTargetDescription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderTargetDescription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderTargetDescription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.ProviderTargetDescription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuantumPricingDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumPricingDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumPricingDetail>
    {
        internal QuantumPricingDetail() { }
        public string Id { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Quantum.Models.QuantumPricingDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Quantum.Models.QuantumPricingDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Quantum.Models.QuantumPricingDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumPricingDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumPricingDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.QuantumPricingDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumPricingDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumPricingDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumPricingDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuantumProvider : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumProvider>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumProvider>
    {
        public QuantumProvider() { }
        public string ApplicationName { get { throw null; } set { } }
        public System.Uri InstanceUri { get { throw null; } set { } }
        public string ProviderId { get { throw null; } set { } }
        public string ProviderSku { get { throw null; } set { } }
        public Azure.ResourceManager.Quantum.Models.QuantumProvisioningStatus? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.Quantum.Models.QuantumQuotaAllocations Quotas { get { throw null; } set { } }
        public string ResourceUsageId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Quantum.Models.QuantumProvider JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Quantum.Models.QuantumProvider PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Quantum.Models.QuantumProvider System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumProvider>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumProvider>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.QuantumProvider System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumProvider>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumProvider>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumProvider>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuantumProviderDescription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumProviderDescription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumProviderDescription>
    {
        internal QuantumProviderDescription() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Quantum.Models.QuantumProviderProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Quantum.Models.QuantumProviderDescription JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Quantum.Models.QuantumProviderDescription PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Quantum.Models.QuantumProviderDescription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumProviderDescription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumProviderDescription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.QuantumProviderDescription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumProviderDescription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumProviderDescription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumProviderDescription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuantumProviderProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumProviderProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumProviderProperties>
    {
        internal QuantumProviderProperties() { }
        public Azure.ResourceManager.Quantum.Models.ProviderAadInfo Aad { get { throw null; } }
        public string Company { get { throw null; } }
        public string DefaultEndpoint { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.Quantum.Models.ProviderApplicationInfo ManagedApplication { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Quantum.Models.ProviderPricingDimension> PricingDimensions { get { throw null; } }
        public string ProviderType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Quantum.Models.QuantumQuotaDimension> QuotaDimensions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Quantum.Models.ProviderSkuDescription> Skus { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Quantum.Models.ProviderTargetDescription> Targets { get { throw null; } }
        protected virtual Azure.ResourceManager.Quantum.Models.QuantumProviderProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Quantum.Models.QuantumProviderProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Quantum.Models.QuantumProviderProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumProviderProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumProviderProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.QuantumProviderProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumProviderProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumProviderProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumProviderProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuantumProvisioningStatus : System.IEquatable<Azure.ResourceManager.Quantum.Models.QuantumProvisioningStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuantumProvisioningStatus(string value) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.QuantumProvisioningStatus Deleted { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.QuantumProvisioningStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.QuantumProvisioningStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.QuantumProvisioningStatus Launching { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.QuantumProvisioningStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.QuantumProvisioningStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Quantum.Models.QuantumProvisioningStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Quantum.Models.QuantumProvisioningStatus left, Azure.ResourceManager.Quantum.Models.QuantumProvisioningStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Quantum.Models.QuantumProvisioningStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Quantum.Models.QuantumProvisioningStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Quantum.Models.QuantumProvisioningStatus left, Azure.ResourceManager.Quantum.Models.QuantumProvisioningStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuantumQuotaAllocations : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumQuotaAllocations>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumQuotaAllocations>
    {
        public QuantumQuotaAllocations(int standardMinutesLifetime) { }
        public int? HighMinutesLifetime { get { throw null; } set { } }
        public int StandardMinutesLifetime { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Quantum.Models.QuantumQuotaAllocations JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Quantum.Models.QuantumQuotaAllocations PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Quantum.Models.QuantumQuotaAllocations System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumQuotaAllocations>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumQuotaAllocations>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.QuantumQuotaAllocations System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumQuotaAllocations>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumQuotaAllocations>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumQuotaAllocations>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuantumQuotaDimension : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumQuotaDimension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumQuotaDimension>
    {
        internal QuantumQuotaDimension() { }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Period { get { throw null; } }
        public float? Quota { get { throw null; } }
        public string Scope { get { throw null; } }
        public string Unit { get { throw null; } }
        public string UnitPlural { get { throw null; } }
        protected virtual Azure.ResourceManager.Quantum.Models.QuantumQuotaDimension JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Quantum.Models.QuantumQuotaDimension PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Quantum.Models.QuantumQuotaDimension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumQuotaDimension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumQuotaDimension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.QuantumQuotaDimension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumQuotaDimension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumQuotaDimension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumQuotaDimension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuantumSuiteOffer : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumSuiteOffer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumSuiteOffer>
    {
        internal QuantumSuiteOffer() { }
        public Azure.ResourceManager.Quantum.Models.QuantumSuiteOfferProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Quantum.Models.QuantumSuiteOffer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumSuiteOffer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumSuiteOffer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.QuantumSuiteOffer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumSuiteOffer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumSuiteOffer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumSuiteOffer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuantumSuiteOfferProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumSuiteOfferProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumSuiteOfferProperties>
    {
        internal QuantumSuiteOfferProperties() { }
        public string CompanyName { get { throw null; } }
        public string Description { get { throw null; } }
        public string Location { get { throw null; } }
        public string ProviderId { get { throw null; } }
        public string ProviderName { get { throw null; } }
        public Azure.Core.AzureLocation? Quotas { get { throw null; } }
        protected virtual Azure.ResourceManager.Quantum.Models.QuantumSuiteOfferProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Quantum.Models.QuantumSuiteOfferProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Quantum.Models.QuantumSuiteOfferProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumSuiteOfferProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumSuiteOfferProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.QuantumSuiteOfferProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumSuiteOfferProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumSuiteOfferProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumSuiteOfferProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuantumWorkspaceKind : System.IEquatable<Azure.ResourceManager.Quantum.Models.QuantumWorkspaceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuantumWorkspaceKind(string value) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.QuantumWorkspaceKind V1 { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.QuantumWorkspaceKind V2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Quantum.Models.QuantumWorkspaceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Quantum.Models.QuantumWorkspaceKind left, Azure.ResourceManager.Quantum.Models.QuantumWorkspaceKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Quantum.Models.QuantumWorkspaceKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Quantum.Models.QuantumWorkspaceKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Quantum.Models.QuantumWorkspaceKind left, Azure.ResourceManager.Quantum.Models.QuantumWorkspaceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuantumWorkspacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumWorkspacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumWorkspacePatch>
    {
        public QuantumWorkspacePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Quantum.Models.QuantumWorkspacePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Quantum.Models.QuantumWorkspacePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Quantum.Models.QuantumWorkspacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumWorkspacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.QuantumWorkspacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.QuantumWorkspacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumWorkspacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumWorkspacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.QuantumWorkspacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceApiKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.WorkspaceApiKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceApiKey>
    {
        internal WorkspaceApiKey() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Key { get { throw null; } }
        protected virtual Azure.ResourceManager.Quantum.Models.WorkspaceApiKey JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Quantum.Models.WorkspaceApiKey PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Quantum.Models.WorkspaceApiKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.WorkspaceApiKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.WorkspaceApiKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.WorkspaceApiKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceApiKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceApiKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceApiKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceApiKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.WorkspaceApiKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceApiKeys>
    {
        public WorkspaceApiKeys() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Quantum.Models.WorkspaceKeyType> Keys { get { throw null; } }
        protected virtual Azure.ResourceManager.Quantum.Models.WorkspaceApiKeys JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Quantum.Models.WorkspaceApiKeys PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Quantum.Models.WorkspaceApiKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.WorkspaceApiKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.WorkspaceApiKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.WorkspaceApiKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceApiKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceApiKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceApiKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceKeyListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.WorkspaceKeyListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceKeyListResult>
    {
        internal WorkspaceKeyListResult() { }
        public bool? IsApiKeyEnabled { get { throw null; } }
        public string PrimaryConnectionString { get { throw null; } }
        public Azure.ResourceManager.Quantum.Models.WorkspaceApiKey PrimaryKey { get { throw null; } }
        public string SecondaryConnectionString { get { throw null; } }
        public Azure.ResourceManager.Quantum.Models.WorkspaceApiKey SecondaryKey { get { throw null; } }
        protected virtual Azure.ResourceManager.Quantum.Models.WorkspaceKeyListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Quantum.Models.WorkspaceKeyListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Quantum.Models.WorkspaceKeyListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.WorkspaceKeyListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.WorkspaceKeyListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.WorkspaceKeyListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceKeyListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceKeyListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceKeyListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkspaceKeyType : System.IEquatable<Azure.ResourceManager.Quantum.Models.WorkspaceKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkspaceKeyType(string value) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.WorkspaceKeyType Primary { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.WorkspaceKeyType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Quantum.Models.WorkspaceKeyType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Quantum.Models.WorkspaceKeyType left, Azure.ResourceManager.Quantum.Models.WorkspaceKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Quantum.Models.WorkspaceKeyType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Quantum.Models.WorkspaceKeyType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Quantum.Models.WorkspaceKeyType left, Azure.ResourceManager.Quantum.Models.WorkspaceKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkspaceNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityContent>
    {
        public WorkspaceNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityResult>
    {
        internal WorkspaceNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Quantum.Models.CheckNameAvailabilityReason? Reason { get { throw null; } }
        protected virtual Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.WorkspaceResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceResourceProperties>
    {
        public WorkspaceResourceProperties() { }
        public System.Uri EndpointUri { get { throw null; } }
        public bool? IsApiKeyEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Quantum.Models.MoboBrokerResource> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public Azure.Core.ResourceIdentifier ManagedStorageAccount { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Quantum.Models.QuantumProvider> Providers { get { throw null; } }
        public Azure.ResourceManager.Quantum.Models.ProviderProvisioningStatus? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageAccount { get { throw null; } set { } }
        public Azure.ResourceManager.Quantum.Models.WorkspaceUsableStatus? Usable { get { throw null; } }
        public Azure.ResourceManager.Quantum.Models.QuantumWorkspaceKind? WorkspaceKind { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Quantum.Models.WorkspaceResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Quantum.Models.WorkspaceResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Quantum.Models.WorkspaceResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.WorkspaceResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quantum.Models.WorkspaceResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quantum.Models.WorkspaceResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quantum.Models.WorkspaceResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkspaceUsableStatus : System.IEquatable<Azure.ResourceManager.Quantum.Models.WorkspaceUsableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkspaceUsableStatus(string value) { throw null; }
        public static Azure.ResourceManager.Quantum.Models.WorkspaceUsableStatus No { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.WorkspaceUsableStatus Partial { get { throw null; } }
        public static Azure.ResourceManager.Quantum.Models.WorkspaceUsableStatus Yes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Quantum.Models.WorkspaceUsableStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Quantum.Models.WorkspaceUsableStatus left, Azure.ResourceManager.Quantum.Models.WorkspaceUsableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Quantum.Models.WorkspaceUsableStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Quantum.Models.WorkspaceUsableStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Quantum.Models.WorkspaceUsableStatus left, Azure.ResourceManager.Quantum.Models.WorkspaceUsableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
