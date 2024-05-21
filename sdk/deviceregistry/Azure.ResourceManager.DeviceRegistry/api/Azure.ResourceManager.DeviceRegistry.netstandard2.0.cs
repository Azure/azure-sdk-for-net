namespace Azure.ResourceManager.DeviceRegistry
{
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
        public System.Uri AssetEndpointProfileUri { get { throw null; } set { } }
        public string AssetType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Attributes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.DataPoint> DataPoints { get { throw null; } }
        public string DefaultDataPointsConfiguration { get { throw null; } set { } }
        public string DefaultEventsConfiguration { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Uri DocumentationUri { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.AssetEvent> Events { get { throw null; } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string ExternalAssetId { get { throw null; } set { } }
        public string HardwareRevision { get { throw null; } set { } }
        public string Manufacturer { get { throw null; } set { } }
        public System.Uri ManufacturerUri { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public string SerialNumber { get { throw null; } set { } }
        public string SoftwareRevision { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.AssetStatus Status { get { throw null; } }
        public string Uuid { get { throw null; } }
        public int? Version { get { throw null; } }
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
        public string AdditionalConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public System.Uri TargetAddress { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.OwnCertificate> TransportAuthenticationOwnCertificates { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.UserAuthentication UserAuthentication { get { throw null; } set { } }
        public string Uuid { get { throw null; } }
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
    }
}
namespace Azure.ResourceManager.DeviceRegistry.Mocking
{
    public partial class MockableDeviceRegistryArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDeviceRegistryArmClient() { }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileResource GetDeviceRegistryAssetEndpointProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetResource GetDeviceRegistryAssetResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
    }
}
namespace Azure.ResourceManager.DeviceRegistry.Models
{
    public static partial class ArmDeviceRegistryModelFactory
    {
        public static Azure.ResourceManager.DeviceRegistry.Models.AssetStatus AssetStatus(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.AssetStatusError> errors = null, int? version = default(int?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.AssetStatusError AssetStatusError(int? code = default(int?), string message = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetData DeviceRegistryAssetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation extendedLocation = null, string uuid = null, string assetType = null, bool? enabled = default(bool?), string externalAssetId = null, string displayName = null, string description = null, System.Uri assetEndpointProfileUri = null, int? version = default(int?), string manufacturer = null, System.Uri manufacturerUri = null, string model = null, string productCode = null, string hardwareRevision = null, string softwareRevision = null, System.Uri documentationUri = null, string serialNumber = null, System.Collections.Generic.IDictionary<string, System.BinaryData> attributes = null, string defaultDataPointsConfiguration = null, string defaultEventsConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.DataPoint> dataPoints = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.AssetEvent> events = null, Azure.ResourceManager.DeviceRegistry.Models.AssetStatus status = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.DeviceRegistryAssetEndpointProfileData DeviceRegistryAssetEndpointProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation extendedLocation = null, string uuid = null, System.Uri targetAddress = null, Azure.ResourceManager.DeviceRegistry.Models.UserAuthentication userAuthentication = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.OwnCertificate> transportAuthenticationOwnCertificates = null, string additionalConfiguration = null, Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryProvisioningState?)) { throw null; }
    }
    public partial class AssetEvent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEvent>
    {
        public AssetEvent(string eventNotifier) { }
        public string CapabilityId { get { throw null; } set { } }
        public string EventConfiguration { get { throw null; } set { } }
        public string EventNotifier { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.EventsObservabilityMode? ObservabilityMode { get { throw null; } set { } }
        Azure.ResourceManager.DeviceRegistry.Models.AssetEvent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetEvent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetStatus>
    {
        internal AssetStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeviceRegistry.Models.AssetStatusError> Errors { get { throw null; } }
        public int? Version { get { throw null; } }
        Azure.ResourceManager.DeviceRegistry.Models.AssetStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetStatusError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetStatusError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetStatusError>
    {
        internal AssetStatusError() { }
        public int? Code { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.ResourceManager.DeviceRegistry.Models.AssetStatusError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetStatusError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetStatusError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetStatusError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetStatusError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetStatusError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetStatusError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataPoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DataPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DataPoint>
    {
        public DataPoint(string dataSource) { }
        public string CapabilityId { get { throw null; } set { } }
        public string DataPointConfiguration { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DataPointsObservabilityMode? ObservabilityMode { get { throw null; } set { } }
        Azure.ResourceManager.DeviceRegistry.Models.DataPoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DataPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DataPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DataPoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DataPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DataPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DataPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataPointsObservabilityMode : System.IEquatable<Azure.ResourceManager.DeviceRegistry.Models.DataPointsObservabilityMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataPointsObservabilityMode(string value) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.DataPointsObservabilityMode Counter { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.DataPointsObservabilityMode Gauge { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.DataPointsObservabilityMode Histogram { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.DataPointsObservabilityMode Log { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.DataPointsObservabilityMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceRegistry.Models.DataPointsObservabilityMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceRegistry.Models.DataPointsObservabilityMode left, Azure.ResourceManager.DeviceRegistry.Models.DataPointsObservabilityMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.DataPointsObservabilityMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceRegistry.Models.DataPointsObservabilityMode left, Azure.ResourceManager.DeviceRegistry.Models.DataPointsObservabilityMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceRegistryAssetEndpointProfilePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfilePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfilePatch>
    {
        public DeviceRegistryAssetEndpointProfilePatch() { }
        public string AdditionalConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Uri TargetAddress { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.OwnCertificate> TransportAuthenticationOwnCertificates { get { throw null; } }
        public Azure.ResourceManager.DeviceRegistry.Models.UserAuthenticationUpdate UserAuthentication { get { throw null; } set { } }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfilePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfilePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfilePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfilePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfilePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfilePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetEndpointProfilePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryAssetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetPatch>
    {
        public DeviceRegistryAssetPatch() { }
        public string AssetType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Attributes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.DataPoint> DataPoints { get { throw null; } }
        public string DefaultDataPointsConfiguration { get { throw null; } set { } }
        public string DefaultEventsConfiguration { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Uri DocumentationUri { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.AssetEvent> Events { get { throw null; } }
        public string HardwareRevision { get { throw null; } set { } }
        public string Manufacturer { get { throw null; } set { } }
        public System.Uri ManufacturerUri { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public string SerialNumber { get { throw null; } set { } }
        public string SoftwareRevision { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryAssetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.DeviceRegistryExtendedLocation>
    {
        public DeviceRegistryExtendedLocation(string extendedLocationType, string name) { }
        public string ExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
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
    public readonly partial struct EventsObservabilityMode : System.IEquatable<Azure.ResourceManager.DeviceRegistry.Models.EventsObservabilityMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventsObservabilityMode(string value) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.EventsObservabilityMode Log { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.EventsObservabilityMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceRegistry.Models.EventsObservabilityMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceRegistry.Models.EventsObservabilityMode left, Azure.ResourceManager.DeviceRegistry.Models.EventsObservabilityMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.EventsObservabilityMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceRegistry.Models.EventsObservabilityMode left, Azure.ResourceManager.DeviceRegistry.Models.EventsObservabilityMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OwnCertificate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.OwnCertificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.OwnCertificate>
    {
        public OwnCertificate() { }
        public string CertPasswordReference { get { throw null; } set { } }
        public string CertSecretReference { get { throw null; } set { } }
        public string CertThumbprint { get { throw null; } set { } }
        Azure.ResourceManager.DeviceRegistry.Models.OwnCertificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.OwnCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.OwnCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.OwnCertificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.OwnCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.OwnCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.OwnCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.UserAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.UserAuthentication>
    {
        public UserAuthentication(Azure.ResourceManager.DeviceRegistry.Models.UserAuthenticationMode mode) { }
        public Azure.ResourceManager.DeviceRegistry.Models.UserAuthenticationMode Mode { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.UsernamePasswordCredentials UsernamePasswordCredentials { get { throw null; } set { } }
        public string X509CredentialsCertificateReference { get { throw null; } set { } }
        Azure.ResourceManager.DeviceRegistry.Models.UserAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.UserAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.UserAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.UserAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.UserAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.UserAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.UserAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UserAuthenticationMode : System.IEquatable<Azure.ResourceManager.DeviceRegistry.Models.UserAuthenticationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UserAuthenticationMode(string value) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.UserAuthenticationMode Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.UserAuthenticationMode Certificate { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.UserAuthenticationMode UsernamePassword { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceRegistry.Models.UserAuthenticationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceRegistry.Models.UserAuthenticationMode left, Azure.ResourceManager.DeviceRegistry.Models.UserAuthenticationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.UserAuthenticationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceRegistry.Models.UserAuthenticationMode left, Azure.ResourceManager.DeviceRegistry.Models.UserAuthenticationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserAuthenticationUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.UserAuthenticationUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.UserAuthenticationUpdate>
    {
        public UserAuthenticationUpdate() { }
        public Azure.ResourceManager.DeviceRegistry.Models.UserAuthenticationMode? Mode { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.UsernamePasswordCredentialsUpdate UsernamePasswordCredentials { get { throw null; } set { } }
        public string X509CredentialsCertificateReference { get { throw null; } set { } }
        Azure.ResourceManager.DeviceRegistry.Models.UserAuthenticationUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.UserAuthenticationUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.UserAuthenticationUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.UserAuthenticationUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.UserAuthenticationUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.UserAuthenticationUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.UserAuthenticationUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UsernamePasswordCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.UsernamePasswordCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.UsernamePasswordCredentials>
    {
        public UsernamePasswordCredentials(string usernameReference, string passwordReference) { }
        public string PasswordReference { get { throw null; } set { } }
        public string UsernameReference { get { throw null; } set { } }
        Azure.ResourceManager.DeviceRegistry.Models.UsernamePasswordCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.UsernamePasswordCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.UsernamePasswordCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.UsernamePasswordCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.UsernamePasswordCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.UsernamePasswordCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.UsernamePasswordCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UsernamePasswordCredentialsUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.UsernamePasswordCredentialsUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.UsernamePasswordCredentialsUpdate>
    {
        public UsernamePasswordCredentialsUpdate() { }
        public string PasswordReference { get { throw null; } set { } }
        public string UsernameReference { get { throw null; } set { } }
        Azure.ResourceManager.DeviceRegistry.Models.UsernamePasswordCredentialsUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.UsernamePasswordCredentialsUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.UsernamePasswordCredentialsUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.UsernamePasswordCredentialsUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.UsernamePasswordCredentialsUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.UsernamePasswordCredentialsUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.UsernamePasswordCredentialsUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
