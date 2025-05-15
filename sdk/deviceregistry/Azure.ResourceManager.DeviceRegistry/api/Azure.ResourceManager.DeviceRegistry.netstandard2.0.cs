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
        public static Azure.ResourceManager.DeviceRegistry.Models.MessageSchemaReference MessageSchemaReference(string schemaRegistryNamespace = null, string schemaName = null, string schemaVersion = null) { throw null; }
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
}
