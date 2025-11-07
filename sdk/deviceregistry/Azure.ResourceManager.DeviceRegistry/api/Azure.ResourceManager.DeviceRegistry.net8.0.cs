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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource> GetDeviceRegistryNamespace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource GetDeviceRegistryNamespaceAssetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource>> GetDeviceRegistryNamespaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource GetDeviceRegistryNamespaceDeviceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource GetDeviceRegistryNamespaceDiscoveredAssetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource GetDeviceRegistryNamespaceDiscoveredDeviceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource GetDeviceRegistryNamespaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceCollection GetDeviceRegistryNamespaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource> GetDeviceRegistryNamespaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource> GetDeviceRegistryNamespacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryCollection GetDeviceRegistrySchemaRegistries(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> GetDeviceRegistrySchemaRegistries(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> GetDeviceRegistrySchemaRegistriesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> GetDeviceRegistrySchemaRegistry(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string schemaRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource>> GetDeviceRegistrySchemaRegistryAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string schemaRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource GetDeviceRegistrySchemaRegistryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource GetDeviceRegistrySchemaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource GetDeviceRegistrySchemaVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DeviceRegistryNamespaceAssetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource>, System.Collections.IEnumerable
    {
        protected DeviceRegistryNamespaceAssetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assetName, Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assetName, Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource> Get(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource>> GetAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource> GetIfExists(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource>> GetIfExistsAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceRegistryNamespaceAssetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetData>
    {
        public DeviceRegistryNamespaceAssetData(Azure.Core.AzureLocation location, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespaceAssetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceRegistryNamespaceAssetResource() { }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string assetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceRegistryNamespaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource>, System.Collections.IEnumerable
    {
        protected DeviceRegistryNamespaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource> Get(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource>> GetAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource> GetIfExists(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource>> GetIfExistsAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceRegistryNamespaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceData>
    {
        public DeviceRegistryNamespaceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespaceDeviceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource>, System.Collections.IEnumerable
    {
        protected DeviceRegistryNamespaceDeviceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deviceName, Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deviceName, Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource> Get(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource>> GetAsync(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource> GetIfExists(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource>> GetIfExistsAsync(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceRegistryNamespaceDeviceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceData>
    {
        public DeviceRegistryNamespaceDeviceData(Azure.Core.AzureLocation location) { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDeviceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespaceDeviceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceRegistryNamespaceDeviceResource() { }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string deviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDevicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDevicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceRegistryNamespaceDiscoveredAssetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource>, System.Collections.IEnumerable
    {
        protected DeviceRegistryNamespaceDiscoveredAssetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string discoveredAssetName, Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string discoveredAssetName, Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string discoveredAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string discoveredAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource> Get(string discoveredAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource>> GetAsync(string discoveredAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource> GetIfExists(string discoveredAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource>> GetIfExistsAsync(string discoveredAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceRegistryNamespaceDiscoveredAssetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetData>
    {
        public DeviceRegistryNamespaceDiscoveredAssetData(Azure.Core.AzureLocation location, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespaceDiscoveredAssetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceRegistryNamespaceDiscoveredAssetResource() { }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string discoveredAssetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceRegistryNamespaceDiscoveredDeviceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource>, System.Collections.IEnumerable
    {
        protected DeviceRegistryNamespaceDiscoveredDeviceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string discoveredDeviceName, Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string discoveredDeviceName, Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string discoveredDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string discoveredDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource> Get(string discoveredDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource>> GetAsync(string discoveredDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource> GetIfExists(string discoveredDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource>> GetIfExistsAsync(string discoveredDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceRegistryNamespaceDiscoveredDeviceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceData>
    {
        public DeviceRegistryNamespaceDiscoveredDeviceData(Azure.Core.AzureLocation location, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDeviceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespaceDiscoveredDeviceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceRegistryNamespaceDiscoveredDeviceResource() { }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string discoveredDeviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDevicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDevicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceRegistryNamespaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceRegistryNamespaceResource() { }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource> GetDeviceRegistryNamespaceAsset(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource>> GetDeviceRegistryNamespaceAssetAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetCollection GetDeviceRegistryNamespaceAssets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource> GetDeviceRegistryNamespaceDevice(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource>> GetDeviceRegistryNamespaceDeviceAsync(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceCollection GetDeviceRegistryNamespaceDevices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource> GetDeviceRegistryNamespaceDiscoveredAsset(string discoveredAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource>> GetDeviceRegistryNamespaceDiscoveredAssetAsync(string discoveredAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetCollection GetDeviceRegistryNamespaceDiscoveredAssets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource> GetDeviceRegistryNamespaceDiscoveredDevice(string discoveredDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource>> GetDeviceRegistryNamespaceDiscoveredDeviceAsync(string discoveredDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceCollection GetDeviceRegistryNamespaceDiscoveredDevices() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Migrate(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> MigrateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
}
namespace Azure.ResourceManager.DeviceRegistry.Mocking
{
    public partial class MockableDeviceRegistryArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDeviceRegistryArmClient() { }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource GetDeviceRegistryAssetEndpointProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource GetDeviceRegistryAssetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerResource GetDeviceRegistryBillingContainerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetResource GetDeviceRegistryNamespaceAssetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceResource GetDeviceRegistryNamespaceDeviceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetResource GetDeviceRegistryNamespaceDiscoveredAssetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceResource GetDeviceRegistryNamespaceDiscoveredDeviceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource GetDeviceRegistryNamespaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource GetDeviceRegistrySchemaRegistryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaResource GetDeviceRegistrySchemaResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionResource GetDeviceRegistrySchemaVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource> GetDeviceRegistryNamespace(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource>> GetDeviceRegistryNamespaceAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceCollection GetDeviceRegistryNamespaces() { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryCollection GetDeviceRegistrySchemaRegistries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> GetDeviceRegistrySchemaRegistry(string schemaRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource>> GetDeviceRegistrySchemaRegistryAsync(string schemaRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource> GetDeviceRegistryNamespaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceResource> GetDeviceRegistryNamespacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> GetDeviceRegistrySchemaRegistries(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryResource> GetDeviceRegistrySchemaRegistriesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DeviceRegistry.Models
{
    public static partial class ArmDeviceRegistryModelFactory
    {
        public static Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileStatusError AssetEndpointProfileStatusError(int? code = default(int?), string message = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.AssetProperties AssetProperties(string uuid = null, bool? isEnabled = default(bool?), string externalAssetId = null, string displayName = null, string description = null, string assetEndpointProfileRef = null, long? version = default(long?), string manufacturer = null, System.Uri manufacturerUri = null, string model = null, string productCode = null, string hardwareRevision = null, string softwareRevision = null, System.Uri documentationUri = null, string serialNumber = null, System.Collections.Generic.IDictionary<string, System.BinaryData> attributes = null, System.Collections.Generic.IEnumerable<string> discoveredAssetRefs = null, string defaultDatasetsConfiguration = null, string defaultEventsConfiguration = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopic defaultTopic = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset> datasets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEvent> events = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatus status = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.AssetUpdateProperties AssetUpdateProperties(bool? isEnabled = default(bool?), string displayName = null, string description = null, string manufacturer = null, System.Uri manufacturerUri = null, string model = null, string productCode = null, string hardwareRevision = null, string softwareRevision = null, System.Uri documentationUri = null, string serialNumber = null, System.Collections.Generic.IDictionary<string, System.BinaryData> attributes = null, string defaultDatasetsConfiguration = null, string defaultEventsConfiguration = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopic defaultTopic = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset> datasets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEvent> events = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData DeviceRegistryAssetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceRegistry.Models.AssetProperties properties = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData DeviceRegistryAssetEndpointProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfileProperties properties = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfilePatch DeviceRegistryAssetEndpointProfilePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfileProperties DeviceRegistryAssetEndpointProfileProperties(string uuid = null, System.Uri targetAddress = null, string endpointProfileType = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAuthentication authentication = null, string additionalConfiguration = null, string discoveredAssetEndpointProfileRef = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileStatusError> statusErrors = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetPatch DeviceRegistryAssetPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.DeviceRegistry.Models.AssetUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatus DeviceRegistryAssetStatus(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusError> errors = null, long? version = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusDataset> datasets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusEvent> events = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusDataset DeviceRegistryAssetStatusDataset(string name = null, Azure.ResourceManager.DeviceRegistry.Models.MessageSchemaReference messageSchemaReference = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusError DeviceRegistryAssetStatusError(int? code = default(int?), string message = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusEvent DeviceRegistryAssetStatusEvent(string name = null, Azure.ResourceManager.DeviceRegistry.Models.MessageSchemaReference messageSchemaReference = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryBillingContainerData DeviceRegistryBillingContainerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? billingContainerProvisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset DeviceRegistryDataset(string name = null, string datasetConfiguration = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopic topic = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPoint> dataPoints = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryErrorDetails DeviceRegistryErrorDetails(string code = null, string message = null, string info = null, string correlationId = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceAssetData DeviceRegistryNamespaceAssetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetProperties properties = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetPatch DeviceRegistryNamespaceAssetPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetProperties DeviceRegistryNamespaceAssetProperties(string uuid = null, bool? enabled = default(bool?), string externalAssetId = null, string displayName = null, string description = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRef deviceRef = null, System.Collections.Generic.IEnumerable<string> assetTypeRefs = null, long? version = default(long?), System.DateTimeOffset? lastTransitionOn = default(System.DateTimeOffset?), string manufacturer = null, string manufacturerUri = null, string model = null, string productCode = null, string hardwareRevision = null, string softwareRevision = null, string documentationUri = null, string serialNumber = null, System.Collections.Generic.IDictionary<string, System.BinaryData> attributes = null, System.Collections.Generic.IEnumerable<string> discoveredAssetRefs = null, string defaultDatasetsConfiguration = null, string defaultEventsConfiguration = null, string defaultStreamsConfiguration = null, string defaultManagementGroupsConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination> defaultDatasetsDestinations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.EventDestination> defaultEventsDestinations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination> defaultStreamsDestinations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDataset> datasets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup> eventGroups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream> streams = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.ManagementGroup> managementGroups = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatus status = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatus DeviceRegistryNamespaceAssetStatus(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusConfig config = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusDataset> datasets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEventGroup> eventGroups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusStream> streams = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementGroup> managementGroups = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusDataset DeviceRegistryNamespaceAssetStatusDataset(string name = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceMessageSchemaReference messageSchemaReference = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError error = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEvent DeviceRegistryNamespaceAssetStatusEvent(string name = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceMessageSchemaReference messageSchemaReference = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError error = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEventGroup DeviceRegistryNamespaceAssetStatusEventGroup(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEvent> events = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementAction DeviceRegistryNamespaceAssetStatusManagementAction(string name = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceMessageSchemaReference requestMessageSchemaReference = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceMessageSchemaReference responseMessageSchemaReference = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError error = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementGroup DeviceRegistryNamespaceAssetStatusManagementGroup(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementAction> actions = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusStream DeviceRegistryNamespaceAssetStatusStream(string name = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceMessageSchemaReference messageSchemaReference = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError error = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceData DeviceRegistryNamespaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceProperties properties = null, Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDeviceData DeviceRegistryNamespaceDeviceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDeviceProperties properties = null, string etag = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDevicePatch DeviceRegistryNamespaceDevicePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDeviceProperties DeviceRegistryNamespaceDeviceProperties(string uuid = null, bool? enabled = default(bool?), string externalDeviceId = null, string discoveredDeviceRef = null, string manufacturer = null, string model = null, string operatingSystem = null, string operatingSystemVersion = null, Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoints endpoints = null, System.Collections.Generic.IDictionary<string, System.BinaryData> attributes = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus status = null, long? version = default(long?), System.DateTimeOffset? lastTransitionOn = default(System.DateTimeOffset?), Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredAssetData DeviceRegistryNamespaceDiscoveredAssetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetProperties properties = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetPatch DeviceRegistryNamespaceDiscoveredAssetPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetProperties DeviceRegistryNamespaceDiscoveredAssetProperties(Azure.ResourceManager.DeviceRegistry.Models.DeviceRef deviceRef = null, string displayName = null, System.Collections.Generic.IEnumerable<string> assetTypeRefs = null, string description = null, string discoveryId = null, string externalAssetId = null, long version = (long)0, string manufacturer = null, string manufacturerUri = null, string model = null, string productCode = null, string hardwareRevision = null, string softwareRevision = null, string documentationUri = null, string serialNumber = null, System.Collections.Generic.IDictionary<string, System.BinaryData> attributes = null, string defaultDatasetsConfiguration = null, string defaultEventsConfiguration = null, string defaultStreamsConfiguration = null, string defaultManagementGroupsConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination> defaultDatasetsDestinations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.EventDestination> defaultEventsDestinations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination> defaultStreamsDestinations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDataset> datasets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEventGroup> eventGroups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredStream> streams = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementGroup> managementGroups = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryNamespaceDiscoveredDeviceData DeviceRegistryNamespaceDiscoveredDeviceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDeviceProperties properties = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDevicePatch DeviceRegistryNamespaceDiscoveredDevicePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDeviceProperties DeviceRegistryNamespaceDiscoveredDeviceProperties(string externalDeviceId = null, Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints endpoints = null, string manufacturer = null, string model = null, string operatingSystem = null, string operatingSystemVersion = null, System.Collections.Generic.IDictionary<string, System.BinaryData> attributes = null, string discoveryId = null, long version = (long)0, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceMessageSchemaReference DeviceRegistryNamespaceMessageSchemaReference(string schemaRegistryNamespace = null, string schemaName = null, string schemaVersion = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespacePatch DeviceRegistryNamespacePatch(Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentity identity = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.DeviceRegistry.Models.NamespaceUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceProperties DeviceRegistryNamespaceProperties(string uuid = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoint> messagingEndpoints = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaData DeviceRegistrySchemaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaProperties DeviceRegistrySchemaProperties(string uuid = null, string displayName = null, string description = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaFormat format = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaFormat), Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaType schemaType = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaType), Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaRegistryData DeviceRegistrySchemaRegistryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryProperties properties = null, Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryPatch DeviceRegistrySchemaRegistryPatch(Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentity identity = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.DeviceRegistry.Models.SchemaRegistryUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryProperties DeviceRegistrySchemaRegistryProperties(string uuid = null, string @namespace = null, string displayName = null, string description = null, System.Uri storageAccountContainerUri = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistrySchemaVersionData DeviceRegistrySchemaVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaVersionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaVersionProperties DeviceRegistrySchemaVersionProperties(string uuid = null, string description = null, string schemaContent = null, string hash = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusConfig DeviceRegistryStatusConfig(long? version = default(long?), System.DateTimeOffset? lastTransitionOn = default(System.DateTimeOffset?), Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError error = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError DeviceRegistryStatusError(string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryErrorDetails> details = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus DeviceStatus(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusConfig config = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.DeviceStatusEndpoint> endpointsInbound = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DeviceStatusEndpoint DeviceStatusEndpoint(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError error = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DiscoveredInboundEndpoints DiscoveredInboundEndpoints(string endpointType = null, string address = null, string version = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.AuthenticationMethod> supportedAuthenticationMethods = null, string additionalConfiguration = null, System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints DiscoveredMessagingEndpoints(System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.DiscoveredInboundEndpoints> inbound = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.DeviceMessagingEndpoint> outboundAssigned = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.ManagementGroup ManagementGroup(string name = null, string dataSource = null, string managementGroupConfiguration = null, string typeRef = null, string defaultTopic = null, int? defaultTimeoutInSeconds = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.ManagementAction> actions = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.MessageSchemaReference MessageSchemaReference(string schemaRegistryNamespace = null, string schemaName = null, string schemaVersion = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoints MessagingEndpoints(System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.InboundEndpoints> inbound = null, Azure.ResourceManager.DeviceRegistry.Models.OutboundEndpoints outbound = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetUpdateProperties NamespaceAssetUpdateProperties(bool? enabled = default(bool?), string displayName = null, string description = null, System.Collections.Generic.IEnumerable<string> assetTypeRefs = null, string manufacturer = null, string manufacturerUri = null, string model = null, string productCode = null, string hardwareRevision = null, string softwareRevision = null, string documentationUri = null, string serialNumber = null, System.Collections.Generic.IDictionary<string, System.BinaryData> attributes = null, string defaultDatasetsConfiguration = null, string defaultEventsConfiguration = null, string defaultStreamsConfiguration = null, string defaultManagementGroupsConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination> defaultDatasetsDestinations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.EventDestination> defaultEventsDestinations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination> defaultStreamsDestinations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDataset> datasets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup> eventGroups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream> streams = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.ManagementGroup> managementGroups = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceDataset NamespaceDataset(string name = null, string dataSource = null, string typeRef = null, string datasetConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination> destinations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDatasetDataPoint> dataPoints = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties NamespaceDeviceUpdateProperties(string operatingSystemVersion = null, Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoints endpoints = null, System.Collections.Generic.IDictionary<string, System.BinaryData> attributes = null, bool? enabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetUpdateProperties NamespaceDiscoveredAssetUpdateProperties(Azure.ResourceManager.DeviceRegistry.Models.DeviceRef deviceRef = null, string displayName = null, System.Collections.Generic.IEnumerable<string> assetTypeRefs = null, string description = null, string discoveryId = null, long? version = default(long?), string manufacturer = null, string manufacturerUri = null, string model = null, string productCode = null, string hardwareRevision = null, string softwareRevision = null, string documentationUri = null, string serialNumber = null, System.Collections.Generic.IDictionary<string, System.BinaryData> attributes = null, string defaultDatasetsConfiguration = null, string defaultEventsConfiguration = null, string defaultStreamsConfiguration = null, string defaultManagementGroupsConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination> defaultDatasetsDestinations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.EventDestination> defaultEventsDestinations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination> defaultStreamsDestinations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDataset> datasets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEventGroup> eventGroups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredStream> streams = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementGroup> managementGroups = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDataset NamespaceDiscoveredDataset(string name = null, string dataSource = null, string typeRef = null, string datasetConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination> destinations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDatasetDataPoint> dataPoints = null, System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceUpdateProperties NamespaceDiscoveredDeviceUpdateProperties(string externalDeviceId = null, Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints endpoints = null, string operatingSystemVersion = null, System.Collections.Generic.IDictionary<string, System.BinaryData> attributes = null, string discoveryId = null, long? version = default(long?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEvent NamespaceDiscoveredEvent(string name = null, string dataSource = null, string eventConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.EventDestination> destinations = null, string typeRef = null, System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEventGroup NamespaceDiscoveredEventGroup(string name = null, string dataSource = null, string eventGroupConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.EventDestination> defaultDestinations = null, string typeRef = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEvent> events = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementGroup NamespaceDiscoveredManagementGroup(string name = null, string managementGroupConfiguration = null, string typeRef = null, string dataSource = null, string defaultTopic = null, int? defaultTimeoutInSeconds = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementAction> actions = null, System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredStream NamespaceDiscoveredStream(string name = null, string streamConfiguration = null, string typeRef = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination> destinations = null, System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceEvent NamespaceEvent(string name = null, string dataSource = null, string eventConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.EventDestination> destinations = null, string typeRef = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup NamespaceEventGroup(string name = null, string dataSource = null, string eventGroupConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.EventDestination> defaultDestinations = null, string typeRef = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEvent> events = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent NamespaceMigrateContent(Azure.ResourceManager.DeviceRegistry.Models.Scope? scope = default(Azure.ResourceManager.DeviceRegistry.Models.Scope?), System.Collections.Generic.IEnumerable<string> resourceIds = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream NamespaceStream(string name = null, string streamConfiguration = null, string typeRef = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination> destinations = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.OutboundEndpoints OutboundEndpoints(System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.DeviceMessagingEndpoint> assigned = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.DeviceMessagingEndpoint> unassigned = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentity SystemAssignedServiceIdentity(System.Guid? principalId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentityType type = default(Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentityType)) { throw null; }
    }
    public partial class AssetEndpointProfileStatusError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileStatusError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileStatusError>
    {
        internal AssetEndpointProfileStatusError() { }
        public int? Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileStatusError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileStatusError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.AssetProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.AssetProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.AssetUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.AssetUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.AuthenticationMethod? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceRegistry.Models.AuthenticationMethod left, Azure.ResourceManager.DeviceRegistry.Models.AuthenticationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BrokerStateStoreDestinationConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.BrokerStateStoreDestinationConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.BrokerStateStoreDestinationConfiguration>
    {
        public BrokerStateStoreDestinationConfiguration(string key) { }
        public string Key { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.BrokerStateStoreDestinationConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.BrokerStateStoreDestinationConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.DataPointObservabilityMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceRegistry.Models.DataPointObservabilityMode left, Azure.ResourceManager.DeviceRegistry.Models.DataPointObservabilityMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatasetBrokerStateStoreDestination : Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetBrokerStateStoreDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetBrokerStateStoreDestination>
    {
        public DatasetBrokerStateStoreDestination(Azure.ResourceManager.DeviceRegistry.Models.BrokerStateStoreDestinationConfiguration configuration) { }
        public string Key { get { throw null; } set { } }
        protected override Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DatasetBrokerStateStoreDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetBrokerStateStoreDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetBrokerStateStoreDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DatasetBrokerStateStoreDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetBrokerStateStoreDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetBrokerStateStoreDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetBrokerStateStoreDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DatasetDestination : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination>
    {
        internal DatasetDestination() { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.DeviceRegistry.Models.DatasetDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceMessagingEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceMessagingEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfilePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfilePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfileProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfileProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusDataset JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusDataset PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusEvent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetStatusEvent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPointBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPointBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPointBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataPointBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryDataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryErrorDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryErrorDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryErrorDetails>
    {
        internal DeviceRegistryErrorDetails() { }
        public string Code { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string Info { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryErrorDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryErrorDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryErrorDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryErrorDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryErrorDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryErrorDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryErrorDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryErrorDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryErrorDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryEvent : Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEventBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEvent>
    {
        public DeviceRegistryEvent(string name, string eventNotifier) : base (default(string), default(string)) { }
        public Azure.ResourceManager.DeviceRegistry.Models.EventObservabilityMode? ObservabilityMode { get { throw null; } set { } }
        protected override Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespaceAssetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetPatch>
    {
        public DeviceRegistryNamespaceAssetPatch() { }
        public Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespaceAssetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetProperties>
    {
        public DeviceRegistryNamespaceAssetProperties(Azure.ResourceManager.DeviceRegistry.Models.DeviceRef deviceRef) { }
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
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatus Status { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream> Streams { get { throw null; } }
        public string Uuid { get { throw null; } }
        public long? Version { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespaceAssetStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatus>
    {
        internal DeviceRegistryNamespaceAssetStatus() { }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusConfig Config { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusDataset> Datasets { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEventGroup> EventGroups { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementGroup> ManagementGroups { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusStream> Streams { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespaceAssetStatusDataset : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusDataset>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusDataset>
    {
        internal DeviceRegistryNamespaceAssetStatusDataset() { }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError Error { get { throw null; } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceMessageSchemaReference MessageSchemaReference { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusDataset JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusDataset PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusDataset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusDataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusDataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusDataset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusDataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusDataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusDataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespaceAssetStatusEvent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEvent>
    {
        internal DeviceRegistryNamespaceAssetStatusEvent() { }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError Error { get { throw null; } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceMessageSchemaReference MessageSchemaReference { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEvent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEvent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEvent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEvent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespaceAssetStatusEventGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEventGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEventGroup>
    {
        internal DeviceRegistryNamespaceAssetStatusEventGroup() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEvent> Events { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEventGroup JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEventGroup PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEventGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEventGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEventGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEventGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEventGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEventGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusEventGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespaceAssetStatusManagementAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementAction>
    {
        internal DeviceRegistryNamespaceAssetStatusManagementAction() { }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError Error { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceMessageSchemaReference RequestMessageSchemaReference { get { throw null; } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceMessageSchemaReference ResponseMessageSchemaReference { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespaceAssetStatusManagementGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementGroup>
    {
        internal DeviceRegistryNamespaceAssetStatusManagementGroup() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementAction> Actions { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementGroup JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementGroup PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusManagementGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespaceAssetStatusStream : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusStream>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusStream>
    {
        internal DeviceRegistryNamespaceAssetStatusStream() { }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError Error { get { throw null; } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceMessageSchemaReference MessageSchemaReference { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusStream JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusStream PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusStream System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusStream>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusStream>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusStream System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusStream>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusStream>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceAssetStatusStream>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespaceDevicePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDevicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDevicePatch>
    {
        public DeviceRegistryNamespaceDevicePatch() { }
        public Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDevicePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDevicePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDevicePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDevicePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDevicePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDevicePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDevicePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDevicePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDevicePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespaceDeviceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDeviceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDeviceProperties>
    {
        public DeviceRegistryNamespaceDeviceProperties() { }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDeviceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDeviceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDeviceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDeviceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDeviceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDeviceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDeviceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDeviceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDeviceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespaceDiscoveredAssetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetPatch>
    {
        public DeviceRegistryNamespaceDiscoveredAssetPatch() { }
        public Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespaceDiscoveredAssetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetProperties>
    {
        public DeviceRegistryNamespaceDiscoveredAssetProperties(Azure.ResourceManager.DeviceRegistry.Models.DeviceRef deviceRef, string discoveryId, long version) { }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredAssetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespaceDiscoveredDevicePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDevicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDevicePatch>
    {
        public DeviceRegistryNamespaceDiscoveredDevicePatch() { }
        public Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDevicePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDevicePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDevicePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDevicePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDevicePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDevicePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDevicePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDevicePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDevicePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespaceDiscoveredDeviceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDeviceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDeviceProperties>
    {
        public DeviceRegistryNamespaceDiscoveredDeviceProperties(string discoveryId, long version) { }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDeviceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDeviceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDeviceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDeviceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDeviceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDeviceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDeviceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDeviceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceDiscoveredDeviceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespaceMessageSchemaReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceMessageSchemaReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceMessageSchemaReference>
    {
        internal DeviceRegistryNamespaceMessageSchemaReference() { }
        public string SchemaName { get { throw null; } }
        public string SchemaRegistryNamespace { get { throw null; } }
        public string SchemaVersion { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceMessageSchemaReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceMessageSchemaReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceMessageSchemaReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceMessageSchemaReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceMessageSchemaReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceMessageSchemaReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceMessageSchemaReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceMessageSchemaReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceMessageSchemaReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespacePatch>
    {
        public DeviceRegistryNamespacePatch() { }
        public Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.NamespaceUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespacePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespacePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceProperties>
    {
        public DeviceRegistryNamespaceProperties() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoint> MessagingEndpoints { get { throw null; } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public string Uuid { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryNamespaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? (string value) { throw null; }
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
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaFormat? (string value) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistrySchemaRegistryPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryPatch>
    {
        public DeviceRegistrySchemaRegistryPatch() { }
        public Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.SchemaRegistryUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaRegistryProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaType? (string value) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaVersionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaVersionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistrySchemaVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryStatusConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusConfig>
    {
        internal DeviceRegistryStatusConfig() { }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError Error { get { throw null; } }
        public System.DateTimeOffset? LastTransitionOn { get { throw null; } }
        public long? Version { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryStatusError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError>
    {
        internal DeviceRegistryStatusError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryErrorDetails> Details { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryTopic : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopic>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopic>
    {
        public DeviceRegistryTopic(string path) { }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopicRetainType? Retain { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopic JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopic PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopicRetainType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopicRetainType left, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryTopicRetainType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceRegistryUsernamePasswordCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryUsernamePasswordCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryUsernamePasswordCredentials>
    {
        public DeviceRegistryUsernamePasswordCredentials(string usernameSecretName, string passwordSecretName) { }
        public string PasswordSecretName { get { throw null; } set { } }
        public string UsernameSecretName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryUsernamePasswordCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryUsernamePasswordCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryUsernamePasswordCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryUsernamePasswordCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryUsernamePasswordCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryUsernamePasswordCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryUsernamePasswordCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryUsernamePasswordCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryUsernamePasswordCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus>
    {
        internal DeviceStatus() { }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusConfig Config { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.DeviceStatusEndpoint> EndpointsInbound { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceStatusEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceStatusEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceStatusEndpoint>
    {
        internal DeviceStatusEndpoint() { }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryStatusError Error { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceStatusEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DeviceStatusEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DiscoveredInboundEndpoints JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DiscoveredInboundEndpoints PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DiscoveredMessagingEndpoints>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EventDestination : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.EventDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.EventDestination>
    {
        internal EventDestination() { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.EventDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.EventDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override Azure.ResourceManager.DeviceRegistry.Models.EventDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.DeviceRegistry.Models.EventDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.EventObservabilityMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceRegistry.Models.EventObservabilityMode left, Azure.ResourceManager.DeviceRegistry.Models.EventObservabilityMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventStorageDestination : Azure.ResourceManager.DeviceRegistry.Models.EventDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.EventStorageDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.EventStorageDestination>
    {
        public EventStorageDestination(Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration configuration) { }
        public string Path { get { throw null; } set { } }
        protected override Azure.ResourceManager.DeviceRegistry.Models.EventDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.DeviceRegistry.Models.EventDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.HostAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.HostAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.InboundEndpoints JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.InboundEndpoints PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.ManagementAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.ManagementAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.ManagementActionType? (string value) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.ManagementGroup JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.ManagementGroup PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.MessageSchemaReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.MessageSchemaReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoints JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoints PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationQo? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationQo left, Azure.ResourceManager.DeviceRegistry.Models.MqttDestinationQo right) { throw null; }
        public override string ToString() { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceAssetUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDataset JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDataset PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDatasetDataPoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDatasetDataPoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDatasetDataPoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDatasetDataPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDatasetDataPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDatasetDataPoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDatasetDataPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDatasetDataPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDatasetDataPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceDeviceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties>
    {
        public NamespaceDeviceUpdateProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Attributes { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoints Endpoints { get { throw null; } set { } }
        public string OperatingSystemVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDeviceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredAssetUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDataset JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDataset PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDatasetDataPoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDatasetDataPoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDatasetDataPoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDatasetDataPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDatasetDataPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDatasetDataPoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDatasetDataPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDatasetDataPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDatasetDataPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredDeviceUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEvent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEvent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEventGroup JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredEventGroup PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementActionType? (string value) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementGroup JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredManagementGroup PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredStream JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceDiscoveredStream PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceEvent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceEvent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceEventGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceMigrateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent>
    {
        public NamespaceMigrateContent() { }
        public System.Collections.Generic.IList<string> ResourceIds { get { throw null; } }
        public Azure.ResourceManager.DeviceRegistry.Models.Scope? Scope { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceMigrateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceStream : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream>
    {
        public NamespaceStream(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination> Destinations { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string StreamConfiguration { get { throw null; } set { } }
        public string TypeRef { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceStream>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceUpdateProperties>
    {
        public NamespaceUpdateProperties() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.MessagingEndpoint> MessagingEndpoints { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.NamespaceUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.NamespaceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.NamespaceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OutboundEndpoints : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.OutboundEndpoints>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.OutboundEndpoints>
    {
        public OutboundEndpoints(System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.DeviceMessagingEndpoint> assigned) { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.DeviceMessagingEndpoint> Assigned { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DeviceRegistry.Models.DeviceMessagingEndpoint> Unassigned { get { throw null; } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.OutboundEndpoints JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.OutboundEndpoints PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.SchemaRegistryUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.SchemaRegistryUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.Scope? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceRegistry.Models.Scope left, Azure.ResourceManager.DeviceRegistry.Models.Scope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageDestinationConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration>
    {
        public StorageDestinationConfiguration(string path) { }
        public string Path { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StorageDestinationConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class StreamDestination : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StreamDestination>
    {
        internal StreamDestination() { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.StreamDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.StreamDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override Azure.ResourceManager.DeviceRegistry.Models.StreamDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.DeviceRegistry.Models.StreamDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override Azure.ResourceManager.DeviceRegistry.Models.StreamDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.DeviceRegistry.Models.StreamDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.StreamStorageDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StreamStorageDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.StreamStorageDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.StreamStorageDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StreamStorageDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StreamStorageDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.StreamStorageDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SystemAssignedServiceIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentity>
    {
        public SystemAssignedServiceIdentity(Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentityType type) { }
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentityType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SystemAssignedServiceIdentityType : System.IEquatable<Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SystemAssignedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentityType SystemAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentityType left, Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentityType left, Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class X509CertificateCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.X509CertificateCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.X509CertificateCredentials>
    {
        public X509CertificateCredentials(string certificateSecretName) { }
        public string CertificateSecretName { get { throw null; } set { } }
        public string IntermediateCertificatesSecretName { get { throw null; } set { } }
        public string KeySecretName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.X509CertificateCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DeviceRegistry.Models.X509CertificateCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DeviceRegistry.Models.X509CertificateCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.X509CertificateCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.X509CertificateCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.X509CertificateCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.X509CertificateCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.X509CertificateCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.X509CertificateCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
