namespace Azure.ResourceManager.DeviceRegistry
{
    public partial class AzureResourceManagerDeviceRegistryContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDeviceRegistryContext() { }
        public static Azure.ResourceManager.DeviceRegistry.AzureResourceManagerDeviceRegistryContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DeviceRegistryAssetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource>, System.Collections.IEnumerable
    {
        protected DeviceRegistryAssetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assetName, Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assetName, Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource> Get(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource>> GetAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource> GetIfExists(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource>> GetIfExistsAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceRegistryAssetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData>
    {
        public DeviceRegistryAssetData(Azure.Core.AzureLocation location, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.AssetProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryAssetEndpointProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource>, System.Collections.IEnumerable
    {
        protected DeviceRegistryAssetEndpointProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assetEndpointProfileName, Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assetEndpointProfileName, Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assetEndpointProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assetEndpointProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource> Get(string assetEndpointProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource>> GetAsync(string assetEndpointProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource> GetIfExists(string assetEndpointProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource>> GetIfExistsAsync(string assetEndpointProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceRegistryAssetEndpointProfileData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData>
    {
        public DeviceRegistryAssetEndpointProfileData(Azure.Core.AzureLocation location, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfileProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryAssetEndpointProfileResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceRegistryAssetEndpointProfileResource() { }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string assetEndpointProfileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceRegistryAssetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceRegistryAssetResource() { }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string assetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceRegistryBillingContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerResource>, System.Collections.IEnumerable
    {
        protected DeviceRegistryBillingContainerCollection() { }
        public virtual Azure.Response<bool> Exists(string billingContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string billingContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerResource> Get(string billingContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerResource>> GetAsync(string billingContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerResource> GetIfExists(string billingContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerResource>> GetIfExistsAsync(string billingContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceRegistryBillingContainerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerData>
    {
        internal DeviceRegistryBillingContainerData() { }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? BillingContainerProvisioningState { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryBillingContainerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceRegistryBillingContainerResource() { }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string billingContainerName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class DeviceRegistryExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource> GetDeviceRegistryAsset(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource>> GetDeviceRegistryAssetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource> GetDeviceRegistryAssetEndpointProfile(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string assetEndpointProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource>> GetDeviceRegistryAssetEndpointProfileAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string assetEndpointProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource GetDeviceRegistryAssetEndpointProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileCollection GetDeviceRegistryAssetEndpointProfiles(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource> GetDeviceRegistryAssetEndpointProfiles(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource> GetDeviceRegistryAssetEndpointProfilesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource GetDeviceRegistryAssetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetCollection GetDeviceRegistryAssets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource> GetDeviceRegistryAssets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource> GetDeviceRegistryAssetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerResource> GetDeviceRegistryBillingContainer(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string billingContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerResource>> GetDeviceRegistryBillingContainerAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string billingContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerResource GetDeviceRegistryBillingContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerCollection GetDeviceRegistryBillingContainers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryCollection GetDeviceRegistrySchemaRegistries(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> GetDeviceRegistrySchemaRegistries(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> GetDeviceRegistrySchemaRegistriesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> GetDeviceRegistrySchemaRegistry(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string schemaRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource>> GetDeviceRegistrySchemaRegistryAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string schemaRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource GetDeviceRegistrySchemaRegistryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource GetDeviceRegistrySchemaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource GetDeviceRegistrySchemaVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceResource> GetNamespace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource GetNamespaceAssetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceResource>> GetNamespaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource GetNamespaceDeviceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource GetNamespaceDiscoveredAssetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource GetNamespaceDiscoveredDeviceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.NamespaceResource GetNamespaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.NamespaceCollection GetNamespaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DeviceRegistry.NamespaceResource> GetNamespaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.NamespaceResource> GetNamespacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceRegistrySchemaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource>, System.Collections.IEnumerable
    {
        protected DeviceRegistrySchemaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string schemaName, Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string schemaName, Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource> Get(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource>> GetAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource> GetIfExists(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource>> GetIfExistsAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceRegistrySchemaData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData>
    {
        public DeviceRegistrySchemaData() { }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistrySchemaRegistryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource>, System.Collections.IEnumerable
    {
        protected DeviceRegistrySchemaRegistryCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string schemaRegistryName, Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string schemaRegistryName, Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string schemaRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> Get(string schemaRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource>> GetAsync(string schemaRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> GetIfExists(string schemaRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource>> GetIfExistsAsync(string schemaRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceRegistrySchemaRegistryData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryData>
    {
        public DeviceRegistrySchemaRegistryData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistrySchemaRegistryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceRegistrySchemaRegistryResource() { }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string schemaRegistryName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource> GetDeviceRegistrySchema(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource>> GetDeviceRegistrySchemaAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaCollection GetDeviceRegistrySchemas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceRegistrySchemaResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceRegistrySchemaResource() { }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string schemaRegistryName, string schemaName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource> GetDeviceRegistrySchemaVersion(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource>> GetDeviceRegistrySchemaVersionAsync(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionCollection GetDeviceRegistrySchemaVersions() { throw null; }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceRegistrySchemaVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource>, System.Collections.IEnumerable
    {
        protected DeviceRegistrySchemaVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string schemaVersionName, Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string schemaVersionName, Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource> Get(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource>> GetAsync(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource> GetIfExists(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource>> GetIfExistsAsync(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceRegistrySchemaVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData>
    {
        public DeviceRegistrySchemaVersionData() { }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaVersionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistrySchemaVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceRegistrySchemaVersionResource() { }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string schemaRegistryName, string schemaName, string schemaVersionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespaceAssetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource>, System.Collections.IEnumerable
    {
        protected NamespaceAssetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assetName, Azure.ResourceManager.DeviceRegistry.NamespaceAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assetName, Azure.ResourceManager.DeviceRegistry.NamespaceAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource> Get(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource>> GetAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource> GetIfExists(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource>> GetIfExistsAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NamespaceAssetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceAssetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceAssetData>
    {
        public NamespaceAssetData(Azure.Core.AzureLocation location, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.NamespaceAssetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceAssetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceAssetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.NamespaceAssetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceAssetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceAssetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceAssetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceAssetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceAssetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceAssetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NamespaceAssetResource() { }
        public virtual Azure.ResourceManager.DeviceRegistry.NamespaceAssetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string assetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceRegistry.NamespaceAssetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceAssetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceAssetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.NamespaceAssetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceAssetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceAssetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceAssetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.NamespaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.NamespaceResource>, System.Collections.IEnumerable
    {
        protected NamespaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.NamespaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.DeviceRegistry.NamespaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.NamespaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.DeviceRegistry.NamespaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceResource> Get(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.NamespaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.NamespaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceResource>> GetAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.NamespaceResource> GetIfExists(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.NamespaceResource>> GetIfExistsAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceRegistry.NamespaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.NamespaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceRegistry.NamespaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.NamespaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NamespaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceData>
    {
        public NamespaceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.NamespaceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.NamespaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.NamespaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceDeviceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource>, System.Collections.IEnumerable
    {
        protected NamespaceDeviceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deviceName, Azure.ResourceManager.DeviceRegistry.NamespaceDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deviceName, Azure.ResourceManager.DeviceRegistry.NamespaceDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource> Get(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource>> GetAsync(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource> GetIfExists(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource>> GetIfExistsAsync(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NamespaceDeviceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceData>
    {
        public NamespaceDeviceData(Azure.Core.AzureLocation location) { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.NamespaceDeviceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.NamespaceDeviceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceDeviceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NamespaceDeviceResource() { }
        public virtual Azure.ResourceManager.DeviceRegistry.NamespaceDeviceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string deviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceRegistry.NamespaceDeviceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.NamespaceDeviceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.NamespaceDevicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.NamespaceDevicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespaceDiscoveredAssetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource>, System.Collections.IEnumerable
    {
        protected NamespaceDiscoveredAssetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string discoveredAssetName, Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string discoveredAssetName, Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string discoveredAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string discoveredAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource> Get(string discoveredAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource>> GetAsync(string discoveredAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource> GetIfExists(string discoveredAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource>> GetIfExistsAsync(string discoveredAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NamespaceDiscoveredAssetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetData>
    {
        public NamespaceDiscoveredAssetData(Azure.Core.AzureLocation location, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceDiscoveredAssetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NamespaceDiscoveredAssetResource() { }
        public virtual Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string discoveredAssetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespaceDiscoveredDeviceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource>, System.Collections.IEnumerable
    {
        protected NamespaceDiscoveredDeviceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string discoveredDeviceName, Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string discoveredDeviceName, Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string discoveredDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string discoveredDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource> Get(string discoveredDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource>> GetAsync(string discoveredDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource> GetIfExists(string discoveredDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource>> GetIfExistsAsync(string discoveredDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NamespaceDiscoveredDeviceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceData>
    {
        public NamespaceDiscoveredDeviceData(Azure.Core.AzureLocation location, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceDiscoveredDeviceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NamespaceDiscoveredDeviceResource() { }
        public virtual Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string discoveredDeviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDevicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDevicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NamespaceResource() { }
        public virtual Azure.ResourceManager.DeviceRegistry.NamespaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource> GetNamespaceAsset(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource>> GetNamespaceAssetAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.NamespaceAssetCollection GetNamespaceAssets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource> GetNamespaceDevice(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource>> GetNamespaceDeviceAsync(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.NamespaceDeviceCollection GetNamespaceDevices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource> GetNamespaceDiscoveredAsset(string discoveredAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource>> GetNamespaceDiscoveredAssetAsync(string discoveredAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetCollection GetNamespaceDiscoveredAssets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource> GetNamespaceDiscoveredDevice(string discoveredDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource>> GetNamespaceDiscoveredDeviceAsync(string discoveredDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceCollection GetNamespaceDiscoveredDevices() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Migrate(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> MigrateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceRegistry.NamespaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.NamespaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.NamespaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.NamespaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.NamespaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.NamespacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.NamespaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.NamespacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DeviceRegistry.Mocking
{
    public partial class MockableDeviceRegistryArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDeviceRegistryArmClient() { }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource GetDeviceRegistryAssetEndpointProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource GetDeviceRegistryAssetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerResource GetDeviceRegistryBillingContainerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource GetDeviceRegistrySchemaRegistryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource GetDeviceRegistrySchemaResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource GetDeviceRegistrySchemaVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.NamespaceAssetResource GetNamespaceAssetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.NamespaceDeviceResource GetNamespaceDeviceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetResource GetNamespaceDiscoveredAssetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceResource GetNamespaceDiscoveredDeviceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.NamespaceResource GetNamespaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDeviceRegistryResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDeviceRegistryResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource> GetDeviceRegistryAsset(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource>> GetDeviceRegistryAssetAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource> GetDeviceRegistryAssetEndpointProfile(string assetEndpointProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource>> GetDeviceRegistryAssetEndpointProfileAsync(string assetEndpointProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileCollection GetDeviceRegistryAssetEndpointProfiles() { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetCollection GetDeviceRegistryAssets() { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryCollection GetDeviceRegistrySchemaRegistries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> GetDeviceRegistrySchemaRegistry(string schemaRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource>> GetDeviceRegistrySchemaRegistryAsync(string schemaRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceResource> GetNamespace(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.NamespaceResource>> GetNamespaceAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.NamespaceCollection GetNamespaces() { throw null; }
    }
    public partial class MockableDeviceRegistrySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDeviceRegistrySubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource> GetDeviceRegistryAssetEndpointProfiles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource> GetDeviceRegistryAssetEndpointProfilesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource> GetDeviceRegistryAssets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource> GetDeviceRegistryAssetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerResource> GetDeviceRegistryBillingContainer(string billingContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerResource>> GetDeviceRegistryBillingContainerAsync(string billingContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerCollection GetDeviceRegistryBillingContainers() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> GetDeviceRegistrySchemaRegistries(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> GetDeviceRegistrySchemaRegistriesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.NamespaceResource> GetNamespaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.NamespaceResource> GetNamespacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DeviceRegistry.Models
{
    public static partial class ArmDeviceRegistryModelFactory
    {
        public static Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileStatusError AssetEndpointProfileStatusError(int? code = default(int?), string message = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.AssetProperties AssetProperties(string uuid = null, bool? isEnabled = default(bool?), string externalAssetId = null, string displayName = null, string description = null, string assetEndpointProfileRef = null, long? version = default(long?), string manufacturer = null, System.Uri manufacturerUri = null, string model = null, string productCode = null, string hardwareRevision = null, string softwareRevision = null, System.Uri documentationUri = null, string serialNumber = null, System.Collections.Generic.IDictionary<string, System.BinaryData> attributes = null, System.Collections.Generic.IEnumerable<string> discoveredAssetRefs = null, string defaultDatasetsConfiguration = null, string defaultEventsConfiguration = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopic defaultTopic = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset> datasets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEvent> events = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatus status = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData DeviceRegistryAssetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceRegistry.Models.AssetProperties properties = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData DeviceRegistryAssetEndpointProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfileProperties properties = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfileProperties DeviceRegistryAssetEndpointProfileProperties(string uuid = null, System.Uri targetAddress = null, string endpointProfileType = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAuthentication authentication = null, string additionalConfiguration = null, string discoveredAssetEndpointProfileRef = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileStatusError> statusErrors = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatus DeviceRegistryAssetStatus(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusError> errors = null, long? version = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusDataset> datasets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusEvent> events = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusDataset DeviceRegistryAssetStatusDataset(string name = null, Azure.ResourceManager.DeviceRegistry.Models.MessageSchemaReference messageSchemaReference = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusError DeviceRegistryAssetStatusError(int? code = default(int?), string message = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusEvent DeviceRegistryAssetStatusEvent(string name = null, Azure.ResourceManager.DeviceRegistry.Models.MessageSchemaReference messageSchemaReference = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerData DeviceRegistryBillingContainerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? billingContainerProvisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData DeviceRegistrySchemaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaProperties DeviceRegistrySchemaProperties(string uuid = null, string displayName = null, string description = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaFormat format = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaFormat), Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaType schemaType = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaType), Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryData DeviceRegistrySchemaRegistryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryProperties DeviceRegistrySchemaRegistryProperties(string uuid = null, string @namespace = null, string displayName = null, string description = null, System.Uri storageAccountContainerUri = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData DeviceRegistrySchemaVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaVersionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaVersionProperties DeviceRegistrySchemaVersionProperties(string uuid = null, string description = null, string schemaContent = null, string hash = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus DeviceStatus(Azure.ResourceManager.DeviceRegistry.Models.StatusConfig config = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.DeviceStatusEndpoint> endpointsInbound = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceStatusEndpoint DeviceStatusEndpoint(Azure.ResourceManager.DeviceRegistry.Models.StatusError error = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.ErrorDetails ErrorDetails(string code = null, string message = null, string info = null, string correlationId = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.MessageSchemaReference MessageSchemaReference(string schemaRegistryNamespace = null, string schemaName = null, string schemaVersion = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.NamespaceAssetData NamespaceAssetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetProperties properties = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetProperties NamespaceAssetProperties(string uuid = null, bool? enabled = default(bool?), string externalAssetId = null, string displayName = null, string description = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRef deviceRef = null, System.Collections.Generic.IEnumerable<string> assetTypeRefs = null, long? version = default(long?), System.DateTimeOffset? lastTransitionOn = default(System.DateTimeOffset?), string manufacturer = null, string manufacturerUri = null, string model = null, string productCode = null, string hardwareRevision = null, string softwareRevision = null, string documentationUri = null, string serialNumber = null, System.Collections.Generic.IDictionary<string, System.BinaryData> attributes = null, System.Collections.Generic.IEnumerable<string> discoveredAssetRefs = null, string defaultDatasetsConfiguration = null, string defaultEventsConfiguration = null, string defaultStreamsConfiguration = null, string defaultManagementGroupsConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination> defaultDatasetsDestinations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.EventDestination> defaultEventsDestinations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination> defaultStreamsDestinations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDataset> datasets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup> eventGroups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream> streams = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.ManagementGroup> managementGroups = null, Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatus status = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatus NamespaceAssetStatus(Azure.ResourceManager.DeviceRegistry.Models.StatusConfig config = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusDataset> datasets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEventGroup> eventGroups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusStream> streams = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementGroup> managementGroups = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusDataset NamespaceAssetStatusDataset(string name = null, Azure.ResourceManager.DeviceRegistry.Models.NamespaceMessageSchemaReference messageSchemaReference = null, Azure.ResourceManager.DeviceRegistry.Models.StatusError error = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEvent NamespaceAssetStatusEvent(string name = null, Azure.ResourceManager.DeviceRegistry.Models.NamespaceMessageSchemaReference messageSchemaReference = null, Azure.ResourceManager.DeviceRegistry.Models.StatusError error = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEventGroup NamespaceAssetStatusEventGroup(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEvent> events = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementAction NamespaceAssetStatusManagementAction(string name = null, Azure.ResourceManager.DeviceRegistry.Models.NamespaceMessageSchemaReference requestMessageSchemaReference = null, Azure.ResourceManager.DeviceRegistry.Models.NamespaceMessageSchemaReference responseMessageSchemaReference = null, Azure.ResourceManager.DeviceRegistry.Models.StatusError error = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementGroup NamespaceAssetStatusManagementGroup(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementAction> actions = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusStream NamespaceAssetStatusStream(string name = null, Azure.ResourceManager.DeviceRegistry.Models.NamespaceMessageSchemaReference messageSchemaReference = null, Azure.ResourceManager.DeviceRegistry.Models.StatusError error = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.NamespaceData NamespaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceRegistry.Models.NamespaceProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.NamespaceDeviceData NamespaceDeviceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceProperties properties = null, string etag = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceProperties NamespaceDeviceProperties(string uuid = null, bool? enabled = default(bool?), string externalDeviceId = null, string discoveredDeviceRef = null, string manufacturer = null, string model = null, string operatingSystem = null, string operatingSystemVersion = null, Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoints endpoints = null, System.Collections.Generic.IDictionary<string, System.BinaryData> attributes = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus status = null, long? version = default(long?), System.DateTimeOffset? lastTransitionOn = default(System.DateTimeOffset?), Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredAssetData NamespaceDiscoveredAssetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetProperties properties = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetProperties NamespaceDiscoveredAssetProperties(Azure.ResourceManager.DeviceRegistry.Models.DeviceRef deviceRef = null, string displayName = null, System.Collections.Generic.IEnumerable<string> assetTypeRefs = null, string description = null, string discoveryId = null, string externalAssetId = null, long version = (long)0, string manufacturer = null, string manufacturerUri = null, string model = null, string productCode = null, string hardwareRevision = null, string softwareRevision = null, string documentationUri = null, string serialNumber = null, System.Collections.Generic.IDictionary<string, System.BinaryData> attributes = null, string defaultDatasetsConfiguration = null, string defaultEventsConfiguration = null, string defaultStreamsConfiguration = null, string defaultManagementGroupsConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination> defaultDatasetsDestinations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.EventDestination> defaultEventsDestinations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination> defaultStreamsDestinations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDataset> datasets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEventGroup> eventGroups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredStream> streams = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementGroup> managementGroups = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.NamespaceDiscoveredDeviceData NamespaceDiscoveredDeviceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceProperties properties = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceProperties NamespaceDiscoveredDeviceProperties(string externalDeviceId = null, Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints endpoints = null, string manufacturer = null, string model = null, string operatingSystem = null, string operatingSystemVersion = null, System.Collections.Generic.IDictionary<string, System.BinaryData> attributes = null, string discoveryId = null, long version = (long)0, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceMessageSchemaReference NamespaceMessageSchemaReference(string schemaRegistryNamespace = null, string schemaName = null, string schemaVersion = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceProperties NamespaceProperties(string uuid = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoint> messagingEndpoints = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.StatusConfig StatusConfig(long? version = default(long?), System.DateTimeOffset? lastTransitionOn = default(System.DateTimeOffset?), Azure.ResourceManager.DeviceRegistry.Models.StatusError error = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.StatusError StatusError(string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.ErrorDetails> details = null) { throw null; }
    }
    public partial class AssetEndpointProfileStatusError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileStatusError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileStatusError>
    {
        internal AssetEndpointProfileStatusError() { }
        public int? Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileStatusError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileStatusError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileStatusError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileStatusError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileStatusError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileStatusError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileStatusError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetEndpointProfileUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileUpdateProperties>
    {
        public AssetEndpointProfileUpdateProperties() { }
        public string AdditionalConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAuthentication Authentication { get { throw null; } set { } }
        public string EndpointProfileType { get { throw null; } set { } }
        public System.Uri TargetAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetProperties>
    {
        public AssetProperties(string assetEndpointProfileRef) { }
        public string AssetEndpointProfileRef { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Attributes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset> Datasets { get { throw null; } }
        public string DefaultDatasetsConfiguration { get { throw null; } set { } }
        public string DefaultEventsConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopic DefaultTopic { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DiscoveredAssetRefs { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public System.Uri DocumentationUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEvent> Events { get { throw null; } }
        public string ExternalAssetId { get { throw null; } set { } }
        public string HardwareRevision { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string Manufacturer { get { throw null; } set { } }
        public System.Uri ManufacturerUri { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public string SerialNumber { get { throw null; } set { } }
        public string SoftwareRevision { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatus Status { get { throw null; } }
        public string Uuid { get { throw null; } }
        public long? Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetUpdateProperties>
    {
        public AssetUpdateProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Attributes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset> Datasets { get { throw null; } }
        public string DefaultDatasetsConfiguration { get { throw null; } set { } }
        public string DefaultEventsConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopic DefaultTopic { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Uri DocumentationUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEvent> Events { get { throw null; } }
        public string HardwareRevision { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string Manufacturer { get { throw null; } set { } }
        public System.Uri ManufacturerUri { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public string SerialNumber { get { throw null; } set { } }
        public string SoftwareRevision { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthenticationMethod : System.IEquatable<Azure.ResourceManager.DeviceRegistry.Models.AuthenticationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthenticationMethod(string value) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.AuthenticationMethod Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.AuthenticationMethod Certificate { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.AuthenticationMethod UsernamePassword { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceRegistry.Models.AuthenticationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceRegistry.Models.AuthenticationMethod left, Azure.ResourceManager.DeviceRegistry.Models.AuthenticationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.AuthenticationMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceRegistry.Models.AuthenticationMethod left, Azure.ResourceManager.DeviceRegistry.Models.AuthenticationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BrokerStateStoreDestinationConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.BrokerStateStoreDestinationConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.BrokerStateStoreDestinationConfiguration>
    {
        public BrokerStateStoreDestinationConfiguration(string key) { }
        public string Key { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.BrokerStateStoreDestinationConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.BrokerStateStoreDestinationConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.BrokerStateStoreDestinationConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.BrokerStateStoreDestinationConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.BrokerStateStoreDestinationConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.BrokerStateStoreDestinationConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.BrokerStateStoreDestinationConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataPointObservabilityMode : System.IEquatable<Azure.ResourceManager.DeviceRegistry.Models.DataPointObservabilityMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataPointObservabilityMode(string value) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DataPointObservabilityMode Counter { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.DataPointObservabilityMode Gauge { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.DataPointObservabilityMode Histogram { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.DataPointObservabilityMode Log { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.DataPointObservabilityMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceRegistry.Models.DataPointObservabilityMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceRegistry.Models.DataPointObservabilityMode left, Azure.ResourceManager.DeviceRegistry.Models.DataPointObservabilityMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.DataPointObservabilityMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceRegistry.Models.DataPointObservabilityMode left, Azure.ResourceManager.DeviceRegistry.Models.DataPointObservabilityMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatasetBrokerStateStoreDestination : Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetBrokerStateStoreDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetBrokerStateStoreDestination>
    {
        public DatasetBrokerStateStoreDestination(Azure.ResourceManager.DeviceRegistry.Models.BrokerStateStoreDestinationConfiguration configuration) { }
        public string Key { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DatasetBrokerStateStoreDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetBrokerStateStoreDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetBrokerStateStoreDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DatasetBrokerStateStoreDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetBrokerStateStoreDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetBrokerStateStoreDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetBrokerStateStoreDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DatasetDestination : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination>
    {
        protected DatasetDestination() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatasetMqttDestination : Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetMqttDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetMqttDestination>
    {
        public DatasetMqttDestination(Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationConfiguration configuration) { }
        public Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationConfiguration Configuration { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DatasetMqttDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetMqttDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetMqttDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DatasetMqttDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetMqttDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetMqttDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetMqttDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatasetStorageDestination : Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetStorageDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetStorageDestination>
    {
        public DatasetStorageDestination(Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration configuration) { }
        public string Path { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DatasetStorageDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetStorageDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetStorageDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DatasetStorageDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetStorageDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetStorageDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetStorageDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceMessagingEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceMessagingEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceMessagingEndpoint>
    {
        public DeviceMessagingEndpoint(string address) { }
        public string Address { get { throw null; } set { } }
        public string EndpointType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceMessagingEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceMessagingEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceMessagingEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceMessagingEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceMessagingEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceMessagingEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceMessagingEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRef : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRef>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRef>
    {
        public DeviceRef(string deviceName, string endpointName) { }
        public string DeviceName { get { throw null; } set { } }
        public string EndpointName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRef System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRef System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryAssetEndpointProfilePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfilePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfilePatch>
    {
        public DeviceRegistryAssetEndpointProfilePatch() { }
        public Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfilePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfilePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfilePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfilePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfilePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfilePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfilePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryAssetEndpointProfileProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfileProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfileProperties>
    {
        public DeviceRegistryAssetEndpointProfileProperties(System.Uri targetAddress, string endpointProfileType) { }
        public string AdditionalConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAuthentication Authentication { get { throw null; } set { } }
        public string DiscoveredAssetEndpointProfileRef { get { throw null; } set { } }
        public string EndpointProfileType { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileStatusError> StatusErrors { get { throw null; } }
        public System.Uri TargetAddress { get { throw null; } set { } }
        public string Uuid { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfileProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfileProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfileProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfileProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfileProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfileProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfileProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryAssetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetPatch>
    {
        public DeviceRegistryAssetPatch() { }
        public Azure.ResourceManager.DeviceRegistry.Models.AssetUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryAssetStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatus>
    {
        internal DeviceRegistryAssetStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusDataset> Datasets { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusError> Errors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusEvent> Events { get { throw null; } }
        public long? Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryAssetStatusDataset : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusDataset>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusDataset>
    {
        internal DeviceRegistryAssetStatusDataset() { }
        public Azure.ResourceManager.DeviceRegistry.Models.MessageSchemaReference MessageSchemaReference { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusDataset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusDataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusDataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusDataset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusDataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusDataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusDataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryAssetStatusError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusError>
    {
        internal DeviceRegistryAssetStatusError() { }
        public int? Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryAssetStatusEvent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusEvent>
    {
        internal DeviceRegistryAssetStatusEvent() { }
        public Azure.ResourceManager.DeviceRegistry.Models.MessageSchemaReference MessageSchemaReference { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusEvent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusEvent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAuthentication>
    {
        public DeviceRegistryAuthentication(Azure.ResourceManager.DeviceRegistry.Models.AuthenticationMethod method) { }
        public Azure.ResourceManager.DeviceRegistry.Models.AuthenticationMethod Method { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryUsernamePasswordCredentials UsernamePasswordCredentials { get { throw null; } set { } }
        public string X509CredentialsCertificateSecretName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryDataPoint : Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPointBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPoint>
    {
        public DeviceRegistryDataPoint(string name, string dataSource) : base (default(string), default(string)) { }
        public Azure.ResourceManager.DeviceRegistry.Models.DataPointObservabilityMode? ObservabilityMode { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryDataPointBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPointBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPointBase>
    {
        public DeviceRegistryDataPointBase(string name, string dataSource) { }
        public string DataPointConfiguration { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPointBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPointBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPointBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPointBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPointBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPointBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPointBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryDataset : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset>
    {
        public DeviceRegistryDataset(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPoint> DataPoints { get { throw null; } }
        public string DatasetConfiguration { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopic Topic { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryEvent : Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEventBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEvent>
    {
        public DeviceRegistryEvent(string name, string eventNotifier) : base (default(string), default(string)) { }
        public Azure.ResourceManager.DeviceRegistry.Models.EventObservabilityMode? ObservabilityMode { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEvent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEvent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryEventBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEventBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEventBase>
    {
        public DeviceRegistryEventBase(string name, string eventNotifier) { }
        public string EventConfiguration { get { throw null; } set { } }
        public string EventNotifier { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopic Topic { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEventBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEventBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEventBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEventBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEventBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEventBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEventBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation>
    {
        public DeviceRegistryExtendedLocation(string extendedLocationType, string name) { }
        public string ExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceRegistryProvisioningState : System.IEquatable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceRegistryProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState left, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState left, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceRegistrySchemaFormat : System.IEquatable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceRegistrySchemaFormat(string value) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaFormat Delta10 { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaFormat JsonSchemaDraft7 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaFormat left, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaFormat left, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceRegistrySchemaProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaProperties>
    {
        public DeviceRegistrySchemaProperties(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaFormat format, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaType schemaType) { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaFormat Format { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaType SchemaType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Uuid { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistrySchemaRegistryPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryPatch>
    {
        public DeviceRegistrySchemaRegistryPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.SchemaRegistryUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistrySchemaRegistryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryProperties>
    {
        public DeviceRegistrySchemaRegistryProperties(string @namespace, System.Uri storageAccountContainerUri) { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public System.Uri StorageAccountContainerUri { get { throw null; } set { } }
        public string Uuid { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceRegistrySchemaType : System.IEquatable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceRegistrySchemaType(string value) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaType MessageSchema { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaType left, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaType left, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceRegistrySchemaVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaVersionProperties>
    {
        public DeviceRegistrySchemaVersionProperties(string schemaContent) { }
        public string Description { get { throw null; } set { } }
        public string Hash { get { throw null; } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public string SchemaContent { get { throw null; } set { } }
        public string Uuid { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryTopic : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopic>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopic>
    {
        public DeviceRegistryTopic(string path) { }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopicRetainType? Retain { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopic System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopic>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopic>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopic System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopic>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopic>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopic>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceRegistryTopicRetainType : System.IEquatable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopicRetainType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceRegistryTopicRetainType(string value) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopicRetainType Keep { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopicRetainType Never { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopicRetainType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopicRetainType left, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopicRetainType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopicRetainType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopicRetainType left, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopicRetainType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceRegistryUsernamePasswordCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryUsernamePasswordCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryUsernamePasswordCredentials>
    {
        public DeviceRegistryUsernamePasswordCredentials(string usernameSecretName, string passwordSecretName) { }
        public string PasswordSecretName { get { throw null; } set { } }
        public string UsernameSecretName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryUsernamePasswordCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryUsernamePasswordCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryUsernamePasswordCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryUsernamePasswordCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryUsernamePasswordCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryUsernamePasswordCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryUsernamePasswordCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus>
    {
        internal DeviceStatus() { }
        public Azure.ResourceManager.DeviceRegistry.Models.StatusConfig Config { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.DeviceStatusEndpoint> EndpointsInbound { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceStatusEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceStatusEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceStatusEndpoint>
    {
        internal DeviceStatusEndpoint() { }
        public Azure.ResourceManager.DeviceRegistry.Models.StatusError Error { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceStatusEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceStatusEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceStatusEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceStatusEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceStatusEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceStatusEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceStatusEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveredInboundEndpoints : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DiscoveredInboundEndpoints>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DiscoveredInboundEndpoints>
    {
        public DiscoveredInboundEndpoints(string endpointType, string address) { }
        public string AdditionalConfiguration { get { throw null; } set { } }
        public string Address { get { throw null; } set { } }
        public string EndpointType { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.AuthenticationMethod> SupportedAuthenticationMethods { get { throw null; } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DiscoveredInboundEndpoints System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DiscoveredInboundEndpoints>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DiscoveredInboundEndpoints>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DiscoveredInboundEndpoints System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DiscoveredInboundEndpoints>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DiscoveredInboundEndpoints>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DiscoveredInboundEndpoints>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveredMessagingEndpoints : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints>
    {
        public DiscoveredMessagingEndpoints() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.DiscoveredInboundEndpoints> Inbound { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.DeviceMessagingEndpoint> OutboundAssigned { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.ErrorDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.ErrorDetails>
    {
        internal ErrorDetails() { }
        public string Code { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string Info { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.ErrorDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.ErrorDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.ErrorDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.ErrorDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.ErrorDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.ErrorDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.ErrorDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EventDestination : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.EventDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.EventDestination>
    {
        protected EventDestination() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.EventDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.EventDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.EventDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.EventDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.EventDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.EventDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.EventDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventMqttDestination : Azure.ResourceManager.DeviceRegistry.Models.EventDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.EventMqttDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.EventMqttDestination>
    {
        public EventMqttDestination(Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationConfiguration configuration) { }
        public Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationConfiguration Configuration { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.EventMqttDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.EventMqttDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.EventMqttDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.EventMqttDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.EventMqttDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.EventMqttDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.EventMqttDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventObservabilityMode : System.IEquatable<Azure.ResourceManager.DeviceRegistry.Models.EventObservabilityMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventObservabilityMode(string value) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.EventObservabilityMode Log { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.EventObservabilityMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceRegistry.Models.EventObservabilityMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceRegistry.Models.EventObservabilityMode left, Azure.ResourceManager.DeviceRegistry.Models.EventObservabilityMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.EventObservabilityMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceRegistry.Models.EventObservabilityMode left, Azure.ResourceManager.DeviceRegistry.Models.EventObservabilityMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventStorageDestination : Azure.ResourceManager.DeviceRegistry.Models.EventDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.EventStorageDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.EventStorageDestination>
    {
        public EventStorageDestination(Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration configuration) { }
        public string Path { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.EventStorageDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.EventStorageDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.EventStorageDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.EventStorageDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.EventStorageDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.EventStorageDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.EventStorageDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HostAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.HostAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.HostAuthentication>
    {
        public HostAuthentication(Azure.ResourceManager.DeviceRegistry.Models.AuthenticationMethod method) { }
        public Azure.ResourceManager.DeviceRegistry.Models.AuthenticationMethod Method { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryUsernamePasswordCredentials UsernamePasswordCredentials { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.X509CertificateCredentials X509Credentials { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.HostAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.HostAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.HostAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.HostAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.HostAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.HostAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.HostAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InboundEndpoints : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.InboundEndpoints>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.InboundEndpoints>
    {
        public InboundEndpoints(string endpointType, string address) { }
        public string AdditionalConfiguration { get { throw null; } set { } }
        public string Address { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.HostAuthentication Authentication { get { throw null; } set { } }
        public string EndpointType { get { throw null; } set { } }
        public string TrustList { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.InboundEndpoints System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.InboundEndpoints>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.InboundEndpoints>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.InboundEndpoints System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.InboundEndpoints>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.InboundEndpoints>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.InboundEndpoints>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagementAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.ManagementAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.ManagementAction>
    {
        public ManagementAction(string name, string targetUri) { }
        public string ActionConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.ManagementActionType? ActionType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string TargetUri { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public string Topic { get { throw null; } set { } }
        public string TypeRef { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.ManagementAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.ManagementAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.ManagementAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.ManagementAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.ManagementAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.ManagementAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.ManagementAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagementActionType : System.IEquatable<Azure.ResourceManager.DeviceRegistry.Models.ManagementActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagementActionType(string value) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.ManagementActionType Call { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.ManagementActionType Read { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.ManagementActionType Write { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceRegistry.Models.ManagementActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceRegistry.Models.ManagementActionType left, Azure.ResourceManager.DeviceRegistry.Models.ManagementActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.ManagementActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceRegistry.Models.ManagementActionType left, Azure.ResourceManager.DeviceRegistry.Models.ManagementActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagementGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.ManagementGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.ManagementGroup>
    {
        public ManagementGroup(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.ManagementAction> Actions { get { throw null; } }
        public string DataSource { get { throw null; } set { } }
        public int? DefaultTimeoutInSeconds { get { throw null; } set { } }
        public string DefaultTopic { get { throw null; } set { } }
        public string ManagementGroupConfiguration { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string TypeRef { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.ManagementGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.ManagementGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.ManagementGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.ManagementGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.ManagementGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.ManagementGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.ManagementGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageSchemaReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.MessageSchemaReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.MessageSchemaReference>
    {
        internal MessageSchemaReference() { }
        public string SchemaName { get { throw null; } }
        public string SchemaRegistryNamespace { get { throw null; } }
        public string SchemaVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.MessageSchemaReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.MessageSchemaReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.MessageSchemaReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.MessageSchemaReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.MessageSchemaReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.MessageSchemaReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.MessageSchemaReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessagingEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoint>
    {
        public MessagingEndpoint(string address) { }
        public string Address { get { throw null; } set { } }
        public string EndpointType { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessagingEndpoints : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoints>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoints>
    {
        public MessagingEndpoints() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.InboundEndpoints> Inbound { get { throw null; } }
        public Azure.ResourceManager.DeviceRegistry.Models.OutboundEndpoints Outbound { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoints System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoints>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoints>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoints System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoints>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoints>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoints>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MqttDestinationConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationConfiguration>
    {
        public MqttDestinationConfiguration(string topic) { }
        public Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationQo? Qos { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopicRetainType? Retain { get { throw null; } set { } }
        public string Topic { get { throw null; } set { } }
        public long? Ttl { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MqttDestinationQo : System.IEquatable<Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationQo>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MqttDestinationQo(string value) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationQo Qos0 { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationQo Qos1 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationQo other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationQo left, Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationQo right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationQo (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationQo left, Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationQo right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NamespaceAssetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetPatch>
    {
        public NamespaceAssetPatch() { }
        public Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceAssetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetProperties>
    {
        public NamespaceAssetProperties(Azure.ResourceManager.DeviceRegistry.Models.DeviceRef deviceRef) { }
        public System.Collections.Generic.IList<string> AssetTypeRefs { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Attributes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDataset> Datasets { get { throw null; } }
        public string DefaultDatasetsConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination> DefaultDatasetsDestinations { get { throw null; } }
        public string DefaultEventsConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.EventDestination> DefaultEventsDestinations { get { throw null; } }
        public string DefaultManagementGroupsConfiguration { get { throw null; } set { } }
        public string DefaultStreamsConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination> DefaultStreamsDestinations { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRef DeviceRef { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DiscoveredAssetRefs { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public string DocumentationUri { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup> EventGroups { get { throw null; } }
        public string ExternalAssetId { get { throw null; } set { } }
        public string HardwareRevision { get { throw null; } set { } }
        public System.DateTimeOffset? LastTransitionOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.ManagementGroup> ManagementGroups { get { throw null; } }
        public string Manufacturer { get { throw null; } set { } }
        public string ManufacturerUri { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public string SerialNumber { get { throw null; } set { } }
        public string SoftwareRevision { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatus Status { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream> Streams { get { throw null; } }
        public string Uuid { get { throw null; } }
        public long? Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceAssetStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatus>
    {
        internal NamespaceAssetStatus() { }
        public Azure.ResourceManager.DeviceRegistry.Models.StatusConfig Config { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusDataset> Datasets { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEventGroup> EventGroups { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementGroup> ManagementGroups { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusStream> Streams { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceAssetStatusDataset : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusDataset>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusDataset>
    {
        internal NamespaceAssetStatusDataset() { }
        public Azure.ResourceManager.DeviceRegistry.Models.StatusError Error { get { throw null; } }
        public Azure.ResourceManager.DeviceRegistry.Models.NamespaceMessageSchemaReference MessageSchemaReference { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusDataset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusDataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusDataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusDataset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusDataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusDataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusDataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceAssetStatusEvent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEvent>
    {
        internal NamespaceAssetStatusEvent() { }
        public Azure.ResourceManager.DeviceRegistry.Models.StatusError Error { get { throw null; } }
        public Azure.ResourceManager.DeviceRegistry.Models.NamespaceMessageSchemaReference MessageSchemaReference { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEvent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEvent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceAssetStatusEventGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEventGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEventGroup>
    {
        internal NamespaceAssetStatusEventGroup() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEvent> Events { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEventGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEventGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEventGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEventGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEventGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEventGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusEventGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceAssetStatusManagementAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementAction>
    {
        internal NamespaceAssetStatusManagementAction() { }
        public Azure.ResourceManager.DeviceRegistry.Models.StatusError Error { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DeviceRegistry.Models.NamespaceMessageSchemaReference RequestMessageSchemaReference { get { throw null; } }
        public Azure.ResourceManager.DeviceRegistry.Models.NamespaceMessageSchemaReference ResponseMessageSchemaReference { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceAssetStatusManagementGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementGroup>
    {
        internal NamespaceAssetStatusManagementGroup() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementAction> Actions { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusManagementGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceAssetStatusStream : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusStream>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusStream>
    {
        internal NamespaceAssetStatusStream() { }
        public Azure.ResourceManager.DeviceRegistry.Models.StatusError Error { get { throw null; } }
        public Azure.ResourceManager.DeviceRegistry.Models.NamespaceMessageSchemaReference MessageSchemaReference { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusStream System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusStream>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusStream>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusStream System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusStream>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusStream>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetStatusStream>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceAssetUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetUpdateProperties>
    {
        public NamespaceAssetUpdateProperties() { }
        public System.Collections.Generic.IList<string> AssetTypeRefs { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Attributes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDataset> Datasets { get { throw null; } }
        public string DefaultDatasetsConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination> DefaultDatasetsDestinations { get { throw null; } }
        public string DefaultEventsConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.EventDestination> DefaultEventsDestinations { get { throw null; } }
        public string DefaultManagementGroupsConfiguration { get { throw null; } set { } }
        public string DefaultStreamsConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination> DefaultStreamsDestinations { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string DocumentationUri { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup> EventGroups { get { throw null; } }
        public string HardwareRevision { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.ManagementGroup> ManagementGroups { get { throw null; } }
        public string Manufacturer { get { throw null; } set { } }
        public string ManufacturerUri { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public string SerialNumber { get { throw null; } set { } }
        public string SoftwareRevision { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream> Streams { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceDataset : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDataset>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDataset>
    {
        public NamespaceDataset(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDatasetDataPoint> DataPoints { get { throw null; } }
        public string DatasetConfiguration { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination> Destinations { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string TypeRef { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDataset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDataset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceDatasetDataPoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDatasetDataPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDatasetDataPoint>
    {
        public NamespaceDatasetDataPoint(string name, string dataSource) { }
        public string DataPointConfiguration { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string TypeRef { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDatasetDataPoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDatasetDataPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDatasetDataPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDatasetDataPoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDatasetDataPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDatasetDataPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDatasetDataPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceDevicePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDevicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDevicePatch>
    {
        public NamespaceDevicePatch() { }
        public Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDevicePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDevicePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDevicePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDevicePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDevicePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDevicePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDevicePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceDeviceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceProperties>
    {
        public NamespaceDeviceProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Attributes { get { throw null; } }
        public string DiscoveredDeviceRef { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoints Endpoints { get { throw null; } set { } }
        public string ExternalDeviceId { get { throw null; } set { } }
        public System.DateTimeOffset? LastTransitionOn { get { throw null; } }
        public string Manufacturer { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string OperatingSystem { get { throw null; } set { } }
        public string OperatingSystemVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus Status { get { throw null; } }
        public string Uuid { get { throw null; } }
        public long? Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceDeviceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties>
    {
        public NamespaceDeviceUpdateProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Attributes { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoints Endpoints { get { throw null; } set { } }
        public string OperatingSystemVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceDiscoveredAssetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetPatch>
    {
        public NamespaceDiscoveredAssetPatch() { }
        public Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceDiscoveredAssetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetProperties>
    {
        public NamespaceDiscoveredAssetProperties(Azure.ResourceManager.DeviceRegistry.Models.DeviceRef deviceRef, string discoveryId, long version) { }
        public System.Collections.Generic.IList<string> AssetTypeRefs { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Attributes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDataset> Datasets { get { throw null; } }
        public string DefaultDatasetsConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination> DefaultDatasetsDestinations { get { throw null; } }
        public string DefaultEventsConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.EventDestination> DefaultEventsDestinations { get { throw null; } }
        public string DefaultManagementGroupsConfiguration { get { throw null; } set { } }
        public string DefaultStreamsConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination> DefaultStreamsDestinations { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRef DeviceRef { get { throw null; } set { } }
        public string DiscoveryId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string DocumentationUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEventGroup> EventGroups { get { throw null; } }
        public string ExternalAssetId { get { throw null; } set { } }
        public string HardwareRevision { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementGroup> ManagementGroups { get { throw null; } }
        public string Manufacturer { get { throw null; } set { } }
        public string ManufacturerUri { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public string SerialNumber { get { throw null; } set { } }
        public string SoftwareRevision { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredStream> Streams { get { throw null; } }
        public long Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceDiscoveredAssetUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetUpdateProperties>
    {
        public NamespaceDiscoveredAssetUpdateProperties() { }
        public System.Collections.Generic.IList<string> AssetTypeRefs { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Attributes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDataset> Datasets { get { throw null; } }
        public string DefaultDatasetsConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination> DefaultDatasetsDestinations { get { throw null; } }
        public string DefaultEventsConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.EventDestination> DefaultEventsDestinations { get { throw null; } }
        public string DefaultManagementGroupsConfiguration { get { throw null; } set { } }
        public string DefaultStreamsConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination> DefaultStreamsDestinations { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRef DeviceRef { get { throw null; } set { } }
        public string DiscoveryId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string DocumentationUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEventGroup> EventGroups { get { throw null; } }
        public string HardwareRevision { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementGroup> ManagementGroups { get { throw null; } }
        public string Manufacturer { get { throw null; } set { } }
        public string ManufacturerUri { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public string SerialNumber { get { throw null; } set { } }
        public string SoftwareRevision { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredStream> Streams { get { throw null; } }
        public long? Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceDiscoveredDataset : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDataset>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDataset>
    {
        public NamespaceDiscoveredDataset(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDatasetDataPoint> DataPoints { get { throw null; } }
        public string DatasetConfiguration { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination> Destinations { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string TypeRef { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDataset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDataset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceDiscoveredDatasetDataPoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDatasetDataPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDatasetDataPoint>
    {
        public NamespaceDiscoveredDatasetDataPoint(string name, string dataSource) { }
        public string DataPointConfiguration { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string TypeRef { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDatasetDataPoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDatasetDataPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDatasetDataPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDatasetDataPoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDatasetDataPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDatasetDataPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDatasetDataPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceDiscoveredDevicePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDevicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDevicePatch>
    {
        public NamespaceDiscoveredDevicePatch() { }
        public Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDevicePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDevicePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDevicePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDevicePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDevicePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDevicePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDevicePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceDiscoveredDeviceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceProperties>
    {
        public NamespaceDiscoveredDeviceProperties(string discoveryId, long version) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Attributes { get { throw null; } }
        public string DiscoveryId { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints Endpoints { get { throw null; } set { } }
        public string ExternalDeviceId { get { throw null; } set { } }
        public string Manufacturer { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string OperatingSystem { get { throw null; } set { } }
        public string OperatingSystemVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public long Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceDiscoveredDeviceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceUpdateProperties>
    {
        public NamespaceDiscoveredDeviceUpdateProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Attributes { get { throw null; } }
        public string DiscoveryId { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints Endpoints { get { throw null; } set { } }
        public string ExternalDeviceId { get { throw null; } set { } }
        public string OperatingSystemVersion { get { throw null; } set { } }
        public long? Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceDiscoveredEvent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEvent>
    {
        public NamespaceDiscoveredEvent(string name) { }
        public string DataSource { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.EventDestination> Destinations { get { throw null; } }
        public string EventConfiguration { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string TypeRef { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEvent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEvent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceDiscoveredEventGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEventGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEventGroup>
    {
        public NamespaceDiscoveredEventGroup(string name) { }
        public string DataSource { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.EventDestination> DefaultDestinations { get { throw null; } }
        public string EventGroupConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEvent> Events { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string TypeRef { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEventGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEventGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEventGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEventGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEventGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEventGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEventGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceDiscoveredManagementAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementAction>
    {
        public NamespaceDiscoveredManagementAction(string name, string targetUri) { }
        public string ActionConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementActionType? ActionType { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string TargetUri { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public string Topic { get { throw null; } set { } }
        public string TypeRef { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NamespaceDiscoveredManagementActionType : System.IEquatable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NamespaceDiscoveredManagementActionType(string value) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementActionType Call { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementActionType Read { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementActionType Write { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementActionType left, Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementActionType left, Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NamespaceDiscoveredManagementGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementGroup>
    {
        public NamespaceDiscoveredManagementGroup(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementAction> Actions { get { throw null; } }
        public string DataSource { get { throw null; } set { } }
        public int? DefaultTimeoutInSeconds { get { throw null; } set { } }
        public string DefaultTopic { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public string ManagementGroupConfiguration { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string TypeRef { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceDiscoveredStream : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredStream>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredStream>
    {
        public NamespaceDiscoveredStream(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination> Destinations { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string StreamConfiguration { get { throw null; } set { } }
        public string TypeRef { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredStream System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredStream>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredStream>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredStream System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredStream>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredStream>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredStream>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceEvent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEvent>
    {
        public NamespaceEvent(string name) { }
        public string DataSource { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.EventDestination> Destinations { get { throw null; } }
        public string EventConfiguration { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string TypeRef { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceEvent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceEvent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceEventGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup>
    {
        public NamespaceEventGroup(string name) { }
        public string DataSource { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.EventDestination> DefaultDestinations { get { throw null; } }
        public string EventGroupConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEvent> Events { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string TypeRef { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceMessageSchemaReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceMessageSchemaReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceMessageSchemaReference>
    {
        internal NamespaceMessageSchemaReference() { }
        public string SchemaName { get { throw null; } }
        public string SchemaRegistryNamespace { get { throw null; } }
        public string SchemaVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceMessageSchemaReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceMessageSchemaReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceMessageSchemaReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceMessageSchemaReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceMessageSchemaReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceMessageSchemaReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceMessageSchemaReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceMigrateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent>
    {
        public NamespaceMigrateContent() { }
        public System.Collections.Generic.IList<string> ResourceIds { get { throw null; } }
        public Azure.ResourceManager.DeviceRegistry.Models.Scope? Scope { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespacePatch>
    {
        public NamespacePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoint> MessagingEndpoints { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceProperties>
    {
        public NamespaceProperties() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoint> MessagingEndpoints { get { throw null; } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public string Uuid { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceStream : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream>
    {
        public NamespaceStream(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination> Destinations { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string StreamConfiguration { get { throw null; } set { } }
        public string TypeRef { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OutboundEndpoints : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.OutboundEndpoints>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.OutboundEndpoints>
    {
        public OutboundEndpoints(System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.DeviceMessagingEndpoint> assigned) { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.DeviceMessagingEndpoint> Assigned { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.DeviceMessagingEndpoint> Unassigned { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.OutboundEndpoints System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.OutboundEndpoints>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.OutboundEndpoints>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.OutboundEndpoints System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.OutboundEndpoints>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.OutboundEndpoints>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.OutboundEndpoints>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchemaRegistryUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.SchemaRegistryUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.SchemaRegistryUpdateProperties>
    {
        public SchemaRegistryUpdateProperties() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.SchemaRegistryUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.SchemaRegistryUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.SchemaRegistryUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.SchemaRegistryUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.SchemaRegistryUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.SchemaRegistryUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.SchemaRegistryUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Scope : System.IEquatable<Azure.ResourceManager.DeviceRegistry.Models.Scope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Scope(string value) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.Scope Resources { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceRegistry.Models.Scope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceRegistry.Models.Scope left, Azure.ResourceManager.DeviceRegistry.Models.Scope right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.Scope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceRegistry.Models.Scope left, Azure.ResourceManager.DeviceRegistry.Models.Scope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StatusConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StatusConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StatusConfig>
    {
        internal StatusConfig() { }
        public Azure.ResourceManager.DeviceRegistry.Models.StatusError Error { get { throw null; } }
        public System.DateTimeOffset? LastTransitionOn { get { throw null; } }
        public long? Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.StatusConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StatusConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StatusConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.StatusConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StatusConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StatusConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StatusConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StatusError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StatusError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StatusError>
    {
        internal StatusError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeviceRegistry.Models.ErrorDetails> Details { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.StatusError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StatusError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StatusError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.StatusError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StatusError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StatusError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StatusError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageDestinationConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration>
    {
        public StorageDestinationConfiguration(string path) { }
        public string Path { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class StreamDestination : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination>
    {
        protected StreamDestination() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.StreamDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.StreamDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamMqttDestination : Azure.ResourceManager.DeviceRegistry.Models.StreamDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StreamMqttDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StreamMqttDestination>
    {
        public StreamMqttDestination(Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationConfiguration configuration) { }
        public Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationConfiguration Configuration { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.StreamMqttDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StreamMqttDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StreamMqttDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.StreamMqttDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StreamMqttDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StreamMqttDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StreamMqttDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamStorageDestination : Azure.ResourceManager.DeviceRegistry.Models.StreamDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StreamStorageDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StreamStorageDestination>
    {
        public StreamStorageDestination(Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration configuration) { }
        public string Path { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.StreamStorageDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StreamStorageDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StreamStorageDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.StreamStorageDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StreamStorageDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StreamStorageDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StreamStorageDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class X509CertificateCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.X509CertificateCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.X509CertificateCredentials>
    {
        public X509CertificateCredentials(string certificateSecretName) { }
        public string CertificateSecretName { get { throw null; } set { } }
        public string IntermediateCertificatesSecretName { get { throw null; } set { } }
        public string KeySecretName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.X509CertificateCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.X509CertificateCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.X509CertificateCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.X509CertificateCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.X509CertificateCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.X509CertificateCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.X509CertificateCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
