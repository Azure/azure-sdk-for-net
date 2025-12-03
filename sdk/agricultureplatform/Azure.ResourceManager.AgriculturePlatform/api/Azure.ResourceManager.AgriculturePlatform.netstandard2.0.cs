namespace Azure.ResourceManager.AgriculturePlatform
{
    public static partial class AgriculturePlatformExtensions
    {
        public static Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource> GetAgricultureService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string agriServiceResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource>> GetAgricultureServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string agriServiceResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource GetAgricultureServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AgriculturePlatform.AgricultureServiceCollection GetAgricultureServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource> GetAgricultureServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource> GetAgricultureServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AgricultureServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource>, System.Collections.IEnumerable
    {
        protected AgricultureServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string agriServiceResourceName, Azure.ResourceManager.AgriculturePlatform.AgricultureServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string agriServiceResourceName, Azure.ResourceManager.AgriculturePlatform.AgricultureServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string agriServiceResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string agriServiceResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource> Get(string agriServiceResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource>> GetAsync(string agriServiceResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource> GetIfExists(string agriServiceResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource>> GetIfExistsAsync(string agriServiceResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AgricultureServiceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceData>
    {
        public AgricultureServiceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku Sku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AgriculturePlatform.AgricultureServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.AgricultureServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgricultureServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AgricultureServiceResource() { }
        public virtual Azure.ResourceManager.AgriculturePlatform.AgricultureServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string agriServiceResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult> GetAvailableSolutions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult>> GetAvailableSolutionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AgriculturePlatform.AgricultureServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.AgricultureServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerAgriculturePlatformContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerAgriculturePlatformContext() { }
        public static Azure.ResourceManager.AgriculturePlatform.AzureResourceManagerAgriculturePlatformContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
}
namespace Azure.ResourceManager.AgriculturePlatform.Mocking
{
    public partial class MockableAgriculturePlatformArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableAgriculturePlatformArmClient() { }
        public virtual Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource GetAgricultureServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableAgriculturePlatformResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAgriculturePlatformResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource> GetAgricultureService(string agriServiceResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource>> GetAgricultureServiceAsync(string agriServiceResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AgriculturePlatform.AgricultureServiceCollection GetAgricultureServices() { throw null; }
    }
    public partial class MockableAgriculturePlatformSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAgriculturePlatformSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource> GetAgricultureServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AgriculturePlatform.AgricultureServiceResource> GetAgricultureServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.AgriculturePlatform.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgriculturePlatformProvisioningState : System.IEquatable<Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgriculturePlatformProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformProvisioningState left, Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformProvisioningState left, Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgriculturePlatformSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku>
    {
        public AgriculturePlatformSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSkuTier? Tier { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AgriculturePlatformSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    public partial class AgricultureServiceConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceConfig>
    {
        public AgricultureServiceConfig() { }
        public Azure.Core.ResourceIdentifier AppServiceResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier CosmosDBResourceId { get { throw null; } }
        public string InstanceUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier KeyVaultResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RedisCacheResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageAccountResourceId { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgricultureServicePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServicePatch>
    {
        public AgricultureServicePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServicePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServicePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServicePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServicePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServicePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServicePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServicePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServicePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServicePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgricultureServicePatchProperties
    {
        public AgricultureServicePatchProperties() { }
    }
    public partial class AgricultureServiceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceProperties>
    {
        public AgricultureServiceProperties() { }
        public Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceConfig Config { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap> DataConnectorCredentials { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap> InstalledSolutions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgricultureSolution : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureSolution>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureSolution>
    {
        public AgricultureSolution() { }
        public string ApplicationName { get { throw null; } set { } }
        public string MarketPlacePublisherId { get { throw null; } set { } }
        public string PartnerId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string SaasSubscriptionId { get { throw null; } set { } }
        public string SaasSubscriptionName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.AgricultureSolution JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.AgricultureSolution PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AgriculturePlatform.Models.AgricultureSolution System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureSolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureSolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.AgricultureSolution System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureSolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureSolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgricultureSolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgriServiceResourceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties>
    {
        public AgriServiceResourceUpdateProperties() { }
        public Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceConfig Config { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap> DataConnectorCredentials { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap> InstalledSolutions { get { throw null; } }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmAgriculturePlatformModelFactory
    {
        public static Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceConfig AgricultureServiceConfig(string instanceUri = null, string version = null, Azure.Core.ResourceIdentifier appServiceResourceId = null, Azure.Core.ResourceIdentifier cosmosDBResourceId = null, Azure.Core.ResourceIdentifier storageAccountResourceId = null, Azure.Core.ResourceIdentifier keyVaultResourceId = null, Azure.Core.ResourceIdentifier redisCacheResourceId = null) { throw null; }
        public static Azure.ResourceManager.AgriculturePlatform.AgricultureServiceData AgricultureServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku sku = null) { throw null; }
        public static Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServicePatch AgricultureServicePatch(Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku sku = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceProperties AgricultureServiceProperties(Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformProvisioningState? provisioningState = default(Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformProvisioningState?), Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceConfig config = null, System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> managedOnBehalfOfMoboBrokerResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap> dataConnectorCredentials = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap> installedSolutions = null) { throw null; }
        public static Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties AgriServiceResourceUpdateProperties(Azure.ResourceManager.AgriculturePlatform.Models.AgricultureServiceConfig config = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap> dataConnectorCredentials = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap> installedSolutions = null) { throw null; }
        public static Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult AvailableAgriSolutionListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution> solutions = null) { throw null; }
        public static Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution DataManagerForAgricultureSolution(string partnerId = null, string solutionId = null, string partnerTenantId = null, System.Collections.Generic.IEnumerable<string> dataAccessScopes = null, Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails marketPlaceOfferDetails = null, string saasApplicationId = null, string accessAzureDataManagerForAgricultureApplicationId = null, string accessAzureDataManagerForAgricultureApplicationName = null, bool isValidateInput = false) { throw null; }
        public static Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails MarketPlaceOfferDetails(string saasOfferId = null, string publisherId = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthCredentialsKind : System.IEquatable<Azure.ResourceManager.AgriculturePlatform.Models.AuthCredentialsKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthCredentialsKind(string value) { throw null; }
        public static Azure.ResourceManager.AgriculturePlatform.Models.AuthCredentialsKind ApiKeyAuthCredentials { get { throw null; } }
        public static Azure.ResourceManager.AgriculturePlatform.Models.AuthCredentialsKind OAuthClientCredentials { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AgriculturePlatform.Models.AuthCredentialsKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AgriculturePlatform.Models.AuthCredentialsKind left, Azure.ResourceManager.AgriculturePlatform.Models.AuthCredentialsKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.AgriculturePlatform.Models.AuthCredentialsKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AgriculturePlatform.Models.AuthCredentialsKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AgriculturePlatform.Models.AuthCredentialsKind left, Azure.ResourceManager.AgriculturePlatform.Models.AuthCredentialsKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvailableAgriSolutionListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult>
    {
        internal AvailableAgriSolutionListResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution> Solutions { get { throw null; } }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataConnectorCredentialMap : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap>
    {
        public DataConnectorCredentialMap(string key, Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials value) { }
        public string Key { get { throw null; } set { } }
        public Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataConnectorCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials>
    {
        public DataConnectorCredentials() { }
        public string ClientId { get { throw null; } set { } }
        public string KeyName { get { throw null; } set { } }
        public string KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public Azure.ResourceManager.AgriculturePlatform.Models.AuthCredentialsKind? Kind { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataManagerForAgricultureSolution : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution>
    {
        internal DataManagerForAgricultureSolution() { }
        public string AccessAzureDataManagerForAgricultureApplicationId { get { throw null; } }
        public string AccessAzureDataManagerForAgricultureApplicationName { get { throw null; } }
        public System.Collections.Generic.IList<string> DataAccessScopes { get { throw null; } }
        public bool IsValidateInput { get { throw null; } }
        public Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails MarketPlaceOfferDetails { get { throw null; } }
        public string PartnerId { get { throw null; } }
        public string PartnerTenantId { get { throw null; } }
        public string SaasApplicationId { get { throw null; } }
        public string SolutionId { get { throw null; } }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstalledSolutionMap : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap>
    {
        public InstalledSolutionMap(string key, Azure.ResourceManager.AgriculturePlatform.Models.AgricultureSolution value) { }
        public string Key { get { throw null; } set { } }
        public Azure.ResourceManager.AgriculturePlatform.Models.AgricultureSolution Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketPlaceOfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails>
    {
        internal MarketPlaceOfferDetails() { }
        public string PublisherId { get { throw null; } }
        public string SaasOfferId { get { throw null; } }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
