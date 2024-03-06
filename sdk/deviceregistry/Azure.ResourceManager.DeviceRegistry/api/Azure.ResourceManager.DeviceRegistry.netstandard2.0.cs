namespace Azure.ResourceManager.DeviceRegistry
{
    public partial class AssetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.AssetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.AssetResource>, System.Collections.IEnumerable
    {
        protected AssetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.AssetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assetName, Azure.ResourceManager.DeviceRegistry.AssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.AssetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assetName, Azure.ResourceManager.DeviceRegistry.AssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetResource> Get(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.AssetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.AssetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetResource>> GetAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.AssetResource> GetIfExists(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.AssetResource>> GetIfExistsAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceRegistry.AssetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.AssetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceRegistry.AssetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.AssetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AssetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.AssetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.AssetData>
    {
        public AssetData(Azure.Core.AzureLocation location, Azure.ResourceManager.DeviceRegistry.Models.AssetExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.DeviceRegistry.Models.AssetExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.AssetProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.DeviceRegistry.AssetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.AssetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.AssetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.AssetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.AssetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.AssetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.AssetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetEndpointProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource>, System.Collections.IEnumerable
    {
        protected AssetEndpointProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assetEndpointProfileName, Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assetEndpointProfileName, Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assetEndpointProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assetEndpointProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource> Get(string assetEndpointProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource>> GetAsync(string assetEndpointProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource> GetIfExists(string assetEndpointProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource>> GetIfExistsAsync(string assetEndpointProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AssetEndpointProfileData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileData>
    {
        public AssetEndpointProfileData(Azure.Core.AzureLocation location, Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetEndpointProfileResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AssetEndpointProfileResource() { }
        public virtual Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string assetEndpointProfileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AssetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AssetResource() { }
        public virtual Azure.ResourceManager.DeviceRegistry.AssetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string assetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.AssetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.AssetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceRegistry.AssetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceRegistry.Models.AssetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DeviceRegistryExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetResource> GetAsset(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetResource>> GetAssetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource> GetAssetEndpointProfile(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string assetEndpointProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource>> GetAssetEndpointProfileAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string assetEndpointProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource GetAssetEndpointProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileCollection GetAssetEndpointProfiles(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource> GetAssetEndpointProfiles(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource> GetAssetEndpointProfilesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.AssetResource GetAssetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.AssetCollection GetAssets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DeviceRegistry.AssetResource> GetAssets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.AssetResource> GetAssetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> GetOperationStatu(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetOperationStatuAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DeviceRegistry.Mocking
{
    public partial class MockableDeviceRegistryArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDeviceRegistryArmClient() { }
        public virtual Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource GetAssetEndpointProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.AssetResource GetAssetResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDeviceRegistryResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDeviceRegistryResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetResource> GetAsset(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetResource>> GetAssetAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource> GetAssetEndpointProfile(string assetEndpointProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource>> GetAssetEndpointProfileAsync(string assetEndpointProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileCollection GetAssetEndpointProfiles() { throw null; }
        public virtual Azure.ResourceManager.DeviceRegistry.AssetCollection GetAssets() { throw null; }
    }
    public partial class MockableDeviceRegistrySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDeviceRegistrySubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource> GetAssetEndpointProfiles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileResource> GetAssetEndpointProfilesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceRegistry.AssetResource> GetAssets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceRegistry.AssetResource> GetAssetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> GetOperationStatu(Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetOperationStatuAsync(Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DeviceRegistry.Models
{
    public static partial class ArmDeviceRegistryModelFactory
    {
        public static Azure.ResourceManager.DeviceRegistry.AssetData AssetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceRegistry.Models.AssetProperties properties = null, Azure.ResourceManager.DeviceRegistry.Models.AssetExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.AssetEndpointProfileData AssetEndpointProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileProperties properties = null, Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileProperties AssetEndpointProfileProperties(string uuid = null, System.Uri targetAddress = null, Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesUserAuthentication userAuthentication = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesTransportAuthenticationOwnCertificatesItem> transportAuthenticationOwnCertificates = null, string additionalConfiguration = null, Azure.ResourceManager.DeviceRegistry.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.AssetProperties AssetProperties(string uuid = null, string assetType = null, bool? enabled = default(bool?), string externalAssetId = null, string displayName = null, string description = null, System.Uri assetEndpointProfileUri = null, int? version = default(int?), string manufacturer = null, System.Uri manufacturerUri = null, string model = null, string productCode = null, string hardwareRevision = null, string softwareRevision = null, System.Uri documentationUri = null, string serialNumber = null, System.Collections.Generic.IDictionary<string, System.BinaryData> attributes = null, string defaultDataPointsConfiguration = null, string defaultEventsConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessDataPointsItem> dataPoints = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessEventsItem> events = null, Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatus status = null, Azure.ResourceManager.DeviceRegistry.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiess AssetPropertiess(string uuid = null, string assetType = null, bool? enabled = default(bool?), string externalAssetId = null, string displayName = null, string description = null, System.Uri assetEndpointProfileUri = null, int? version = default(int?), string manufacturer = null, System.Uri manufacturerUri = null, string model = null, string productCode = null, string hardwareRevision = null, string softwareRevision = null, System.Uri documentationUri = null, string serialNumber = null, System.Collections.Generic.IDictionary<string, System.BinaryData> attributes = null, string defaultDataPointsConfiguration = null, string defaultEventsConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessDataPointsItem> dataPoints = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessEventsItem> events = null, Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatus status = null, Azure.ResourceManager.DeviceRegistry.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceRegistry.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatus AssetPropertiessStatus(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatusErrorsItem> errors = null, int? version = default(int?)) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatusErrorsItem AssetPropertiessStatusErrorsItem(int? code = default(int?), string message = null) { throw null; }
    }
    public partial class AssetEndpointProfileExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileExtendedLocation>
    {
        public AssetEndpointProfileExtendedLocation() { }
        public string AssetEndpointProfileExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileExtendedLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileExtendedLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileExtendedLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetEndpointProfilePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePatch>
    {
        public AssetEndpointProfilePatch() { }
        public Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetEndpointProfileProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileProperties>
    {
        public AssetEndpointProfileProperties(System.Uri targetAddress) { }
        public string AdditionalConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Uri TargetAddress { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesTransportAuthenticationOwnCertificatesItem> TransportAuthenticationOwnCertificates { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesUserAuthentication UserAuthentication { get { throw null; } set { } }
        public string Uuid { get { throw null; } }
        Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfileProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetEndpointProfilePropertiesTransportAuthenticationOwnCertificatesItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesTransportAuthenticationOwnCertificatesItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesTransportAuthenticationOwnCertificatesItem>
    {
        public AssetEndpointProfilePropertiesTransportAuthenticationOwnCertificatesItem() { }
        public string CertPasswordReference { get { throw null; } set { } }
        public string CertSecretReference { get { throw null; } set { } }
        public string CertThumbprint { get { throw null; } set { } }
        Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesTransportAuthenticationOwnCertificatesItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesTransportAuthenticationOwnCertificatesItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesTransportAuthenticationOwnCertificatesItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesTransportAuthenticationOwnCertificatesItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesTransportAuthenticationOwnCertificatesItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesTransportAuthenticationOwnCertificatesItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesTransportAuthenticationOwnCertificatesItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetEndpointProfilePropertiesUserAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesUserAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesUserAuthentication>
    {
        public AssetEndpointProfilePropertiesUserAuthentication(Azure.ResourceManager.DeviceRegistry.Models.Mode mode) { }
        public Azure.ResourceManager.DeviceRegistry.Models.Mode Mode { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesUserAuthenticationUsernamePasswordCredentials UsernamePasswordCredentials { get { throw null; } set { } }
        public string X509CredentialsCertificateReference { get { throw null; } set { } }
        Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesUserAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesUserAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesUserAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesUserAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesUserAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesUserAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesUserAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetEndpointProfilePropertiesUserAuthenticationUsernamePasswordCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesUserAuthenticationUsernamePasswordCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesUserAuthenticationUsernamePasswordCredentials>
    {
        public AssetEndpointProfilePropertiesUserAuthenticationUsernamePasswordCredentials(string usernameReference, string passwordReference) { }
        public string PasswordReference { get { throw null; } set { } }
        public string UsernameReference { get { throw null; } set { } }
        Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesUserAuthenticationUsernamePasswordCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesUserAuthenticationUsernamePasswordCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesUserAuthenticationUsernamePasswordCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesUserAuthenticationUsernamePasswordCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesUserAuthenticationUsernamePasswordCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesUserAuthenticationUsernamePasswordCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetEndpointProfilePropertiesUserAuthenticationUsernamePasswordCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetExtendedLocation>
    {
        public AssetExtendedLocation() { }
        public string AssetExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.DeviceRegistry.Models.AssetExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetExtendedLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetExtendedLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetExtendedLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPatch>
    {
        public AssetPatch() { }
        public Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiess Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.DeviceRegistry.Models.AssetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetProperties : Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiess, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetProperties>
    {
        public AssetProperties() { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetPropertiess : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiess>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiess>
    {
        public AssetPropertiess() { }
        public System.Uri AssetEndpointProfileUri { get { throw null; } set { } }
        public string AssetType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Attributes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessDataPointsItem> DataPoints { get { throw null; } }
        public string DefaultDataPointsConfiguration { get { throw null; } set { } }
        public string DefaultEventsConfiguration { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Uri DocumentationUri { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessEventsItem> Events { get { throw null; } }
        public string ExternalAssetId { get { throw null; } set { } }
        public string HardwareRevision { get { throw null; } set { } }
        public string Manufacturer { get { throw null; } set { } }
        public System.Uri ManufacturerUri { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SerialNumber { get { throw null; } set { } }
        public string SoftwareRevision { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatus Status { get { throw null; } }
        public string Uuid { get { throw null; } }
        public int? Version { get { throw null; } }
        Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiess System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiess>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiess>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiess System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiess>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiess>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiess>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetPropertiessDataPointsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessDataPointsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessDataPointsItem>
    {
        public AssetPropertiessDataPointsItem(string dataSource) { }
        public string CapabilityId { get { throw null; } set { } }
        public string DataPointConfiguration { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.DataPointsObservabilityMode? ObservabilityMode { get { throw null; } set { } }
        Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessDataPointsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessDataPointsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessDataPointsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessDataPointsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessDataPointsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessDataPointsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessDataPointsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetPropertiessEventsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessEventsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessEventsItem>
    {
        public AssetPropertiessEventsItem(string eventNotifier) { }
        public string CapabilityId { get { throw null; } set { } }
        public string EventConfiguration { get { throw null; } set { } }
        public string EventNotifier { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceRegistry.Models.EventsObservabilityMode? ObservabilityMode { get { throw null; } set { } }
        Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessEventsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessEventsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessEventsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessEventsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessEventsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessEventsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessEventsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetPropertiessStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatus>
    {
        internal AssetPropertiessStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatusErrorsItem> Errors { get { throw null; } }
        public int? Version { get { throw null; } }
        Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetPropertiessStatusErrorsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatusErrorsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatusErrorsItem>
    {
        internal AssetPropertiessStatusErrorsItem() { }
        public int? Code { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatusErrorsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatusErrorsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatusErrorsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatusErrorsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatusErrorsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatusErrorsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceRegistry.Models.AssetPropertiessStatusErrorsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Mode : System.IEquatable<Azure.ResourceManager.DeviceRegistry.Models.Mode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Mode(string value) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.Mode Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.Mode Certificate { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.Mode UsernamePassword { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceRegistry.Models.Mode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceRegistry.Models.Mode left, Azure.ResourceManager.DeviceRegistry.Models.Mode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.Mode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceRegistry.Models.Mode left, Azure.ResourceManager.DeviceRegistry.Models.Mode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.DeviceRegistry.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DeviceRegistry.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DeviceRegistry.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceRegistry.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceRegistry.Models.ProvisioningState left, Azure.ResourceManager.DeviceRegistry.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceRegistry.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceRegistry.Models.ProvisioningState left, Azure.ResourceManager.DeviceRegistry.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
