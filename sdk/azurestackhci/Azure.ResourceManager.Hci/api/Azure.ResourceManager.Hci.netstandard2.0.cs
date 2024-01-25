namespace Azure.ResourceManager.Hci
{
    public partial class ArcExtensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ArcExtensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ArcExtensionResource>, System.Collections.IEnumerable
    {
        protected ArcExtensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.Hci.ArcExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.Hci.ArcExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource> Get(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.ArcExtensionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.ArcExtensionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource>> GetAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.ArcExtensionResource> GetIfExists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.ArcExtensionResource>> GetIfExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.ArcExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ArcExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.ArcExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ArcExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArcExtensionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ArcExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcExtensionData>
    {
        public ArcExtensionData() { }
        public Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState? AggregateState { get { throw null; } }
        public string ArcExtensionType { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.PerNodeExtensionState> PerNodeExtensionDetails { get { throw null; } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? ShouldAutoUpgradeMinorVersion { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        Azure.ResourceManager.Hci.ArcExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ArcExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ArcExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.ArcExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArcExtensionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArcExtensionResource() { }
        public virtual Azure.ResourceManager.Hci.ArcExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string arcSettingName, string extensionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.ArcExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.ArcExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Upgrade(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpgradeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ArcSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ArcSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ArcSettingResource>, System.Collections.IEnumerable
    {
        protected ArcSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string arcSettingName, Azure.ResourceManager.Hci.ArcSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string arcSettingName, Azure.ResourceManager.Hci.ArcSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource> Get(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.ArcSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.ArcSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource>> GetAsync(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.ArcSettingResource> GetIfExists(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.ArcSettingResource>> GetIfExistsAsync(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.ArcSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ArcSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.ArcSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ArcSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArcSettingData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ArcSettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcSettingData>
    {
        public ArcSettingData() { }
        public Azure.ResourceManager.Hci.Models.ArcSettingAggregateState? AggregateState { get { throw null; } }
        public System.Guid? ArcApplicationClientId { get { throw null; } set { } }
        public System.Guid? ArcApplicationObjectId { get { throw null; } set { } }
        public System.Guid? ArcApplicationTenantId { get { throw null; } set { } }
        public string ArcInstanceResourceGroup { get { throw null; } set { } }
        public System.Guid? ArcServicePrincipalObjectId { get { throw null; } set { } }
        public System.BinaryData ConnectivityProperties { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.PerNodeArcState> PerNodeDetails { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.Hci.ArcSettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ArcSettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ArcSettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.ArcSettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcSettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcSettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcSettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArcSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArcSettingResource() { }
        public virtual Azure.ResourceManager.Hci.ArcSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Models.ArcIdentityResult> CreateIdentity(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Models.ArcIdentityResult>> CreateIdentityAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string arcSettingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Models.ArcPasswordCredential> GeneratePassword(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Models.ArcPasswordCredential>> GeneratePasswordAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource> GetArcExtension(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource>> GetArcExtensionAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.ArcExtensionCollection GetArcExtensions() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource> Update(Azure.ResourceManager.Hci.Models.ArcSettingPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource>> UpdateAsync(Azure.ResourceManager.Hci.Models.ArcSettingPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.GalleryImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.GalleryImageResource>, System.Collections.IEnumerable
    {
        protected GalleryImageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.GalleryImageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string galleryImageName, Azure.ResourceManager.Hci.GalleryImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.GalleryImageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string galleryImageName, Azure.ResourceManager.Hci.GalleryImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.GalleryImageResource> Get(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.GalleryImageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.GalleryImageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.GalleryImageResource>> GetAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.GalleryImageResource> GetIfExists(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.GalleryImageResource>> GetIfExistsAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.GalleryImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.GalleryImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.GalleryImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.GalleryImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GalleryImageData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.GalleryImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.GalleryImageData>
    {
        public GalleryImageData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Hci.Models.CloudInitDataSource? CloudInitDataSource { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ContainerId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.GalleryImageIdentifier Identifier { get { throw null; } set { } }
        public string ImagePath { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.OperatingSystemType? OSType { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.GalleryImageStatus Status { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.GalleryImageVersion Version { get { throw null; } set { } }
        Azure.ResourceManager.Hci.GalleryImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.GalleryImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.GalleryImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.GalleryImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.GalleryImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.GalleryImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.GalleryImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryImageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GalleryImageResource() { }
        public virtual Azure.ResourceManager.Hci.GalleryImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.GalleryImageResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.GalleryImageResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string galleryImageName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.GalleryImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.GalleryImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.GalleryImageResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.GalleryImageResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.GalleryImageResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.GalleryImageResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.GalleryImageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.GalleryImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.GalleryImageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.GalleryImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GuestAgentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.GuestAgentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.GuestAgentData>
    {
        public GuestAgentData() { }
        public Azure.ResourceManager.Hci.Models.GuestCredential Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ProvisioningAction? ProvisioningAction { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Status { get { throw null; } }
        Azure.ResourceManager.Hci.GuestAgentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.GuestAgentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.GuestAgentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.GuestAgentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.GuestAgentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.GuestAgentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.GuestAgentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GuestAgentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GuestAgentResource() { }
        public virtual Azure.ResourceManager.Hci.GuestAgentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.GuestAgentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.GuestAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.GuestAgentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.GuestAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.GuestAgentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.GuestAgentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciClusterResource>, System.Collections.IEnumerable
    {
        protected HciClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Hci.HciClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Hci.HciClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.HciClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.HciClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterData>
    {
        public HciClusterData(Azure.Core.AzureLocation location) { }
        public System.Guid? AadApplicationObjectId { get { throw null; } set { } }
        public System.Guid? AadClientId { get { throw null; } set { } }
        public System.Guid? AadServicePrincipalObjectId { get { throw null; } set { } }
        public System.Guid? AadTenantId { get { throw null; } set { } }
        public string BillingModel { get { throw null; } }
        public System.Guid? CloudId { get { throw null; } }
        public string CloudManagementEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties DesiredProperties { get { throw null; } set { } }
        public System.DateTimeOffset? LastBillingTimestamp { get { throw null; } }
        public System.DateTimeOffset? LastSyncTimestamp { get { throw null; } }
        public System.Guid? PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? RegistrationTimestamp { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterReportedProperties ReportedProperties { get { throw null; } }
        public string ResourceProviderObjectId { get { throw null; } }
        public string ServiceEndpoint { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties SoftwareAssuranceProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciClusterStatus? Status { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public float? TrialDaysRemaining { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType? TypeIdentityType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        Azure.ResourceManager.Hci.HciClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciClusterResource() { }
        public virtual Azure.ResourceManager.Hci.HciClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Models.HciClusterIdentityResult> CreateIdentity(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Models.HciClusterIdentityResult>> CreateIdentityAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterResource> ExtendSoftwareAssuranceBenefit(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterResource>> ExtendSoftwareAssuranceBenefitAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource> GetArcSetting(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource>> GetArcSettingAsync(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.ArcSettingCollection GetArcSettings() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.OfferResource> GetOffers(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.OfferResource> GetOffersAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.PublisherResource> GetPublisher(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.PublisherResource>> GetPublisherAsync(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.PublisherCollection GetPublishers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateResource> GetUpdate(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateResource>> GetUpdateAsync(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.UpdateCollection GetUpdates() { throw null; }
        public virtual Azure.ResourceManager.Hci.UpdateSummaryResource GetUpdateSummary() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> Update(Azure.ResourceManager.Hci.Models.HciClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> UpdateAsync(Azure.ResourceManager.Hci.Models.HciClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UploadCertificate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciClusterCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UploadCertificateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciClusterCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class HciExtensions
    {
        public static Azure.ResourceManager.Hci.ArcExtensionResource GetArcExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.ArcSettingResource GetArcSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.GalleryImageResource> GetGalleryImage(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.GalleryImageResource>> GetGalleryImageAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.GalleryImageResource GetGalleryImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.GalleryImageCollection GetGalleryImages(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.GalleryImageResource> GetGalleryImages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.GalleryImageResource> GetGalleryImagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.GuestAgentResource GetGuestAgentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> GetHciCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> GetHciClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterResource GetHciClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterCollection GetHciClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.HciClusterResource> GetHciClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.HciClusterResource> GetHciClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.HciSkuResource GetHciSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.HybridIdentityMetadataResource GetHybridIdentityMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.LogicalNetworkResource> GetLogicalNetwork(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.LogicalNetworkResource>> GetLogicalNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.LogicalNetworkResource GetLogicalNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.LogicalNetworkCollection GetLogicalNetworks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.LogicalNetworkResource> GetLogicalNetworks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.LogicalNetworkResource> GetLogicalNetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource> GetMarketplaceGalleryImage(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource>> GetMarketplaceGalleryImageAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.MarketplaceGalleryImageResource GetMarketplaceGalleryImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.MarketplaceGalleryImageCollection GetMarketplaceGalleryImages(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource> GetMarketplaceGalleryImages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource> GetMarketplaceGalleryImagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.NetworkInterfaceResource> GetNetworkInterface(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.NetworkInterfaceResource>> GetNetworkInterfaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.NetworkInterfaceResource GetNetworkInterfaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.NetworkInterfaceCollection GetNetworkInterfaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.NetworkInterfaceResource> GetNetworkInterfaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.NetworkInterfaceResource> GetNetworkInterfacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.OfferResource GetOfferResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.PublisherResource GetPublisherResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.StorageContainerResource> GetStorageContainer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.StorageContainerResource>> GetStorageContainerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.StorageContainerResource GetStorageContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.StorageContainerCollection GetStorageContainers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.StorageContainerResource> GetStorageContainers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.StorageContainerResource> GetStorageContainersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateResource GetUpdateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateRunResource GetUpdateRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateSummaryResource GetUpdateSummaryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.VirtualHardDiskResource> GetVirtualHardDisk(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.VirtualHardDiskResource>> GetVirtualHardDiskAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.VirtualHardDiskResource GetVirtualHardDiskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.VirtualHardDiskCollection GetVirtualHardDisks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.VirtualHardDiskResource> GetVirtualHardDisks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.VirtualHardDiskResource> GetVirtualHardDisksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.VirtualMachineInstanceResource GetVirtualMachineInstance(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Hci.VirtualMachineInstanceResource GetVirtualMachineInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class HciSkuCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciSkuResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciSkuResource>, System.Collections.IEnumerable
    {
        protected HciSkuCollection() { }
        public virtual Azure.Response<bool> Exists(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciSkuResource> Get(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciSkuResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciSkuResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciSkuResource>> GetAsync(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.HciSkuResource> GetIfExists(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.HciSkuResource>> GetIfExistsAsync(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciSkuResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciSkuResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciSkuResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciSkuResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciSkuData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciSkuData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciSkuData>
    {
        public HciSkuData() { }
        public string Content { get { throw null; } set { } }
        public string ContentVersion { get { throw null; } set { } }
        public string OfferId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string PublisherId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciSkuMappings> SkuMappings { get { throw null; } }
        Azure.ResourceManager.Hci.HciSkuData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciSkuData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciSkuData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciSkuData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciSkuData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciSkuData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciSkuData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciSkuResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciSkuResource() { }
        public virtual Azure.ResourceManager.Hci.HciSkuData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string publisherName, string offerName, string skuName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciSkuResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciSkuResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridIdentityMetadataData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HybridIdentityMetadataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HybridIdentityMetadataData>
    {
        public HybridIdentityMetadataData() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string PublicKey { get { throw null; } set { } }
        public string ResourceUid { get { throw null; } set { } }
        Azure.ResourceManager.Hci.HybridIdentityMetadataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HybridIdentityMetadataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HybridIdentityMetadataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HybridIdentityMetadataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HybridIdentityMetadataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HybridIdentityMetadataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HybridIdentityMetadataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridIdentityMetadataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridIdentityMetadataResource() { }
        public virtual Azure.ResourceManager.Hci.HybridIdentityMetadataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HybridIdentityMetadataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HybridIdentityMetadataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicalNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.LogicalNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.LogicalNetworkResource>, System.Collections.IEnumerable
    {
        protected LogicalNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.LogicalNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string logicalNetworkName, Azure.ResourceManager.Hci.LogicalNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.LogicalNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string logicalNetworkName, Azure.ResourceManager.Hci.LogicalNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.LogicalNetworkResource> Get(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.LogicalNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.LogicalNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.LogicalNetworkResource>> GetAsync(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.LogicalNetworkResource> GetIfExists(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.LogicalNetworkResource>> GetIfExistsAsync(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.LogicalNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.LogicalNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.LogicalNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.LogicalNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicalNetworkData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.LogicalNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.LogicalNetworkData>
    {
        public LogicalNetworkData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<string> DhcpOptionsDnsServers { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.LogicalNetworkStatus Status { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.Subnet> Subnets { get { throw null; } }
        public string VmSwitchName { get { throw null; } set { } }
        Azure.ResourceManager.Hci.LogicalNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.LogicalNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.LogicalNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.LogicalNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.LogicalNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.LogicalNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.LogicalNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicalNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicalNetworkResource() { }
        public virtual Azure.ResourceManager.Hci.LogicalNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.LogicalNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.LogicalNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string logicalNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.LogicalNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.LogicalNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.LogicalNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.LogicalNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.LogicalNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.LogicalNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.LogicalNetworkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.LogicalNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.LogicalNetworkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.LogicalNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MarketplaceGalleryImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource>, System.Collections.IEnumerable
    {
        protected MarketplaceGalleryImageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string marketplaceGalleryImageName, Azure.ResourceManager.Hci.MarketplaceGalleryImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string marketplaceGalleryImageName, Azure.ResourceManager.Hci.MarketplaceGalleryImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource> Get(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource>> GetAsync(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource> GetIfExists(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource>> GetIfExistsAsync(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MarketplaceGalleryImageData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.MarketplaceGalleryImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.MarketplaceGalleryImageData>
    {
        public MarketplaceGalleryImageData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Hci.Models.CloudInitDataSource? CloudInitDataSource { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ContainerId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.GalleryImageIdentifier Identifier { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.OperatingSystemType? OSType { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatus Status { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.GalleryImageVersion Version { get { throw null; } set { } }
        Azure.ResourceManager.Hci.MarketplaceGalleryImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.MarketplaceGalleryImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.MarketplaceGalleryImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.MarketplaceGalleryImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.MarketplaceGalleryImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.MarketplaceGalleryImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.MarketplaceGalleryImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceGalleryImageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MarketplaceGalleryImageResource() { }
        public virtual Azure.ResourceManager.Hci.MarketplaceGalleryImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string marketplaceGalleryImageName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.MarketplaceGalleryImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.MarketplaceGalleryImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkInterfaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.NetworkInterfaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.NetworkInterfaceResource>, System.Collections.IEnumerable
    {
        protected NetworkInterfaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.NetworkInterfaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkInterfaceName, Azure.ResourceManager.Hci.NetworkInterfaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.NetworkInterfaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkInterfaceName, Azure.ResourceManager.Hci.NetworkInterfaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.NetworkInterfaceResource> Get(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.NetworkInterfaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.NetworkInterfaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.NetworkInterfaceResource>> GetAsync(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.NetworkInterfaceResource> GetIfExists(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.NetworkInterfaceResource>> GetIfExistsAsync(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.NetworkInterfaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.NetworkInterfaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.NetworkInterfaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.NetworkInterfaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkInterfaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.NetworkInterfaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.NetworkInterfaceData>
    {
        public NetworkInterfaceData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.IPConfiguration> IPConfigurations { get { throw null; } }
        public string MacAddress { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.NetworkInterfaceStatus Status { get { throw null; } }
        Azure.ResourceManager.Hci.NetworkInterfaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.NetworkInterfaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.NetworkInterfaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.NetworkInterfaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.NetworkInterfaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.NetworkInterfaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.NetworkInterfaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkInterfaceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkInterfaceResource() { }
        public virtual Azure.ResourceManager.Hci.NetworkInterfaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.NetworkInterfaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.NetworkInterfaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkInterfaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.NetworkInterfaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.NetworkInterfaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.NetworkInterfaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.NetworkInterfaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.NetworkInterfaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.NetworkInterfaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.NetworkInterfaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.NetworkInterfacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.NetworkInterfaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.NetworkInterfacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OfferCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.OfferResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.OfferResource>, System.Collections.IEnumerable
    {
        protected OfferCollection() { }
        public virtual Azure.Response<bool> Exists(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.OfferResource> Get(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.OfferResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.OfferResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.OfferResource>> GetAsync(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.OfferResource> GetIfExists(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.OfferResource>> GetIfExistsAsync(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.OfferResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.OfferResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.OfferResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.OfferResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OfferData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.OfferData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.OfferData>
    {
        public OfferData() { }
        public string Content { get { throw null; } set { } }
        public string ContentVersion { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string PublisherId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciSkuMappings> SkuMappings { get { throw null; } }
        Azure.ResourceManager.Hci.OfferData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.OfferData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.OfferData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.OfferData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.OfferData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.OfferData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.OfferData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OfferResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OfferResource() { }
        public virtual Azure.ResourceManager.Hci.OfferData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string publisherName, string offerName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.OfferResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.OfferResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciSkuResource> GetHciSku(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciSkuResource>> GetHciSkuAsync(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciSkuCollection GetHciSkus() { throw null; }
    }
    public partial class PublisherCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.PublisherResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.PublisherResource>, System.Collections.IEnumerable
    {
        protected PublisherCollection() { }
        public virtual Azure.Response<bool> Exists(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.PublisherResource> Get(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.PublisherResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.PublisherResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.PublisherResource>> GetAsync(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.PublisherResource> GetIfExists(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.PublisherResource>> GetIfExistsAsync(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.PublisherResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.PublisherResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.PublisherResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.PublisherResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PublisherData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.PublisherData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.PublisherData>
    {
        public PublisherData() { }
        public string ProvisioningState { get { throw null; } }
        Azure.ResourceManager.Hci.PublisherData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.PublisherData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.PublisherData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.PublisherData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.PublisherData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.PublisherData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.PublisherData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublisherResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PublisherResource() { }
        public virtual Azure.ResourceManager.Hci.PublisherData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string publisherName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.PublisherResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.PublisherResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.OfferResource> GetOffer(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.OfferResource>> GetOfferAsync(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.OfferCollection GetOffers() { throw null; }
    }
    public partial class StorageContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.StorageContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.StorageContainerResource>, System.Collections.IEnumerable
    {
        protected StorageContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.StorageContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageContainerName, Azure.ResourceManager.Hci.StorageContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.StorageContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageContainerName, Azure.ResourceManager.Hci.StorageContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.StorageContainerResource> Get(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.StorageContainerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.StorageContainerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.StorageContainerResource>> GetAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.StorageContainerResource> GetIfExists(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.StorageContainerResource>> GetIfExistsAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.StorageContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.StorageContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.StorageContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.StorageContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageContainerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.StorageContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.StorageContainerData>
    {
        public StorageContainerData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.StorageContainerStatus Status { get { throw null; } }
        Azure.ResourceManager.Hci.StorageContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.StorageContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.StorageContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.StorageContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.StorageContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.StorageContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.StorageContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageContainerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageContainerResource() { }
        public virtual Azure.ResourceManager.Hci.StorageContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.StorageContainerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.StorageContainerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageContainerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.StorageContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.StorageContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.StorageContainerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.StorageContainerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.StorageContainerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.StorageContainerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.StorageContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.StorageContainerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.StorageContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.StorageContainerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UpdateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.UpdateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.UpdateResource>, System.Collections.IEnumerable
    {
        protected UpdateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string updateName, Azure.ResourceManager.Hci.UpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string updateName, Azure.ResourceManager.Hci.UpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateResource> Get(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.UpdateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.UpdateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateResource>> GetAsync(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.UpdateResource> GetIfExists(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.UpdateResource>> GetIfExistsAsync(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.UpdateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.UpdateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.UpdateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.UpdateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class UpdateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateData>
    {
        public UpdateData() { }
        public string AdditionalProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciAvailabilityType? AvailabilityType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> ComponentVersions { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? HealthCheckOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciPrecheckResult> HealthCheckResult { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciHealthState? HealthState { get { throw null; } set { } }
        public System.DateTimeOffset? InstalledOn { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string NotifyMessage { get { throw null; } set { } }
        public string PackagePath { get { throw null; } set { } }
        public float? PackageSizeInMb { get { throw null; } set { } }
        public string PackageType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.UpdatePrerequisite> Prerequisites { get { throw null; } }
        public float? ProgressPercentage { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement? RebootRequired { get { throw null; } set { } }
        public string ReleaseLink { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciUpdateState? State { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.Hci.UpdateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.UpdateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UpdateResource() { }
        public virtual Azure.ResourceManager.Hci.UpdateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string updateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource> GetUpdateRun(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource>> GetUpdateRunAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.UpdateRunCollection GetUpdateRuns() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Post(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PostAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UpdateRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.UpdateRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.UpdateRunResource>, System.Collections.IEnumerable
    {
        protected UpdateRunCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateRunResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string updateRunName, Azure.ResourceManager.Hci.UpdateRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateRunResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string updateRunName, Azure.ResourceManager.Hci.UpdateRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource> Get(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.UpdateRunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.UpdateRunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource>> GetAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.UpdateRunResource> GetIfExists(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.UpdateRunResource>> GetIfExistsAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.UpdateRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.UpdateRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.UpdateRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.UpdateRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class UpdateRunData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateRunData>
    {
        public UpdateRunData() { }
        public string Description { get { throw null; } set { } }
        public string Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndTimeUtc { get { throw null; } set { } }
        public string ErrorMessage { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedTimeUtc { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string NamePropertiesProgressName { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? StartTimeUtc { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState? State { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciUpdateStep> Steps { get { throw null; } }
        public System.DateTimeOffset? TimeStarted { get { throw null; } set { } }
        Azure.ResourceManager.Hci.UpdateRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.UpdateRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateRunResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UpdateRunResource() { }
        public virtual Azure.ResourceManager.Hci.UpdateRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string updateName, string updateRunName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateRunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateRunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UpdateSummaryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateSummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateSummaryData>
    {
        public UpdateSummaryData() { }
        public string CurrentVersion { get { throw null; } set { } }
        public string HardwareModel { get { throw null; } set { } }
        public System.DateTimeOffset? HealthCheckOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciPrecheckResult> HealthCheckResult { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciHealthState? HealthState { get { throw null; } set { } }
        public System.DateTimeOffset? LastChecked { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdated { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string OemFamily { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> PackageVersions { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState? State { get { throw null; } set { } }
        Azure.ResourceManager.Hci.UpdateSummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateSummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateSummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.UpdateSummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateSummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateSummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateSummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateSummaryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UpdateSummaryResource() { }
        public virtual Azure.ResourceManager.Hci.UpdateSummaryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateSummaryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateSummaryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateSummaryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateSummaryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateSummaryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateSummaryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualHardDiskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.VirtualHardDiskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.VirtualHardDiskResource>, System.Collections.IEnumerable
    {
        protected VirtualHardDiskCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.VirtualHardDiskResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualHardDiskName, Azure.ResourceManager.Hci.VirtualHardDiskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.VirtualHardDiskResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualHardDiskName, Azure.ResourceManager.Hci.VirtualHardDiskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.VirtualHardDiskResource> Get(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.VirtualHardDiskResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.VirtualHardDiskResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.VirtualHardDiskResource>> GetAsync(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.VirtualHardDiskResource> GetIfExists(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.VirtualHardDiskResource>> GetIfExistsAsync(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.VirtualHardDiskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.VirtualHardDiskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.VirtualHardDiskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.VirtualHardDiskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualHardDiskData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.VirtualHardDiskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.VirtualHardDiskData>
    {
        public VirtualHardDiskData(Azure.Core.AzureLocation location) { }
        public int? BlockSizeBytes { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ContainerId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.DiskFileFormat? DiskFileFormat { get { throw null; } set { } }
        public long? DiskSizeGB { get { throw null; } set { } }
        public bool? Dynamic { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public int? LogicalSectorBytes { get { throw null; } set { } }
        public int? PhysicalSectorBytes { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.VirtualHardDiskStatus Status { get { throw null; } }
        Azure.ResourceManager.Hci.VirtualHardDiskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.VirtualHardDiskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.VirtualHardDiskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.VirtualHardDiskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.VirtualHardDiskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.VirtualHardDiskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.VirtualHardDiskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualHardDiskResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualHardDiskResource() { }
        public virtual Azure.ResourceManager.Hci.VirtualHardDiskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.VirtualHardDiskResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.VirtualHardDiskResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualHardDiskName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.VirtualHardDiskResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.VirtualHardDiskResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.VirtualHardDiskResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.VirtualHardDiskResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.VirtualHardDiskResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.VirtualHardDiskResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.VirtualHardDiskResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.VirtualHardDiskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.VirtualHardDiskResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.VirtualHardDiskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineInstanceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.VirtualMachineInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.VirtualMachineInstanceData>
    {
        public VirtualMachineInstanceData() { }
        public Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.GuestAgentInstallStatus GuestAgentInstallStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesHardwareProfile HardwareProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HttpProxyConfiguration HttpProxyConfig { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.VirtualMachineConfigAgentInstanceView InstanceViewVmAgent { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> NetworkInterfaces { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public string ResourceUid { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatus Status { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesStorageProfile StorageProfile { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        Azure.ResourceManager.Hci.VirtualMachineInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.VirtualMachineInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.VirtualMachineInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.VirtualMachineInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.VirtualMachineInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.VirtualMachineInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.VirtualMachineInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineInstanceResource() { }
        public virtual Azure.ResourceManager.Hci.VirtualMachineInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.VirtualMachineInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.VirtualMachineInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.VirtualMachineInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.VirtualMachineInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.VirtualMachineInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.VirtualMachineInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.GuestAgentResource GetGuestAgent() { throw null; }
        public virtual Azure.ResourceManager.Hci.HybridIdentityMetadataResource GetHybridIdentityMetadata() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.VirtualMachineInstanceResource> Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.VirtualMachineInstanceResource>> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.VirtualMachineInstanceResource> Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.VirtualMachineInstanceResource>> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.VirtualMachineInstanceResource> Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.VirtualMachineInstanceResource>> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.VirtualMachineInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.VirtualMachineInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.VirtualMachineInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.VirtualMachineInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Hci.Mocking
{
    public partial class MockableHciArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHciArmClient() { }
        public virtual Azure.ResourceManager.Hci.ArcExtensionResource GetArcExtensionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.ArcSettingResource GetArcSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.GalleryImageResource GetGalleryImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.GuestAgentResource GetGuestAgentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciClusterResource GetHciClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciSkuResource GetHciSkuResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.HybridIdentityMetadataResource GetHybridIdentityMetadataResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.LogicalNetworkResource GetLogicalNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.MarketplaceGalleryImageResource GetMarketplaceGalleryImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.NetworkInterfaceResource GetNetworkInterfaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.OfferResource GetOfferResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.PublisherResource GetPublisherResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.StorageContainerResource GetStorageContainerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.UpdateResource GetUpdateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.UpdateRunResource GetUpdateRunResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.UpdateSummaryResource GetUpdateSummaryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.VirtualHardDiskResource GetVirtualHardDiskResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.VirtualMachineInstanceResource GetVirtualMachineInstance(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Hci.VirtualMachineInstanceResource GetVirtualMachineInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHciResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHciResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Hci.GalleryImageResource> GetGalleryImage(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.GalleryImageResource>> GetGalleryImageAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.GalleryImageCollection GetGalleryImages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> GetHciCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> GetHciClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciClusterCollection GetHciClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.LogicalNetworkResource> GetLogicalNetwork(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.LogicalNetworkResource>> GetLogicalNetworkAsync(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.LogicalNetworkCollection GetLogicalNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource> GetMarketplaceGalleryImage(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource>> GetMarketplaceGalleryImageAsync(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.MarketplaceGalleryImageCollection GetMarketplaceGalleryImages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.NetworkInterfaceResource> GetNetworkInterface(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.NetworkInterfaceResource>> GetNetworkInterfaceAsync(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.NetworkInterfaceCollection GetNetworkInterfaces() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.StorageContainerResource> GetStorageContainer(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.StorageContainerResource>> GetStorageContainerAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.StorageContainerCollection GetStorageContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.VirtualHardDiskResource> GetVirtualHardDisk(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.VirtualHardDiskResource>> GetVirtualHardDiskAsync(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.VirtualHardDiskCollection GetVirtualHardDisks() { throw null; }
    }
    public partial class MockableHciSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHciSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.GalleryImageResource> GetGalleryImages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.GalleryImageResource> GetGalleryImagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciClusterResource> GetHciClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciClusterResource> GetHciClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.LogicalNetworkResource> GetLogicalNetworks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.LogicalNetworkResource> GetLogicalNetworksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource> GetMarketplaceGalleryImages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.MarketplaceGalleryImageResource> GetMarketplaceGalleryImagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.NetworkInterfaceResource> GetNetworkInterfaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.NetworkInterfaceResource> GetNetworkInterfacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.StorageContainerResource> GetStorageContainers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.StorageContainerResource> GetStorageContainersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.VirtualHardDiskResource> GetVirtualHardDisks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.VirtualHardDiskResource> GetVirtualHardDisksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Hci.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArcExtensionAggregateState : System.IEquatable<Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArcExtensionAggregateState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Creating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Moving { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState PartiallyConnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Updating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState UpgradeFailedRollbackSucceeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState left, Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState left, Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArcIdentityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcIdentityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcIdentityResult>
    {
        internal ArcIdentityResult() { }
        public System.Guid? ArcApplicationClientId { get { throw null; } }
        public System.Guid? ArcApplicationObjectId { get { throw null; } }
        public System.Guid? ArcApplicationTenantId { get { throw null; } }
        public System.Guid? ArcServicePrincipalObjectId { get { throw null; } }
        Azure.ResourceManager.Hci.Models.ArcIdentityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcIdentityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcIdentityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcIdentityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcIdentityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcIdentityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcIdentityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArcPasswordCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcPasswordCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcPasswordCredential>
    {
        internal ArcPasswordCredential() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string KeyId { get { throw null; } }
        public string SecretText { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        Azure.ResourceManager.Hci.Models.ArcPasswordCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcPasswordCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcPasswordCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcPasswordCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcPasswordCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcPasswordCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcPasswordCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArcSettingAggregateState : System.IEquatable<Azure.ResourceManager.Hci.Models.ArcSettingAggregateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArcSettingAggregateState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Creating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState DisableInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Moving { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState PartiallyConnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ArcSettingAggregateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ArcSettingAggregateState left, Azure.ResourceManager.Hci.Models.ArcSettingAggregateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ArcSettingAggregateState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ArcSettingAggregateState left, Azure.ResourceManager.Hci.Models.ArcSettingAggregateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArcSettingPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcSettingPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcSettingPatch>
    {
        public ArcSettingPatch() { }
        public System.BinaryData ConnectivityProperties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Hci.Models.ArcSettingPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcSettingPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcSettingPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcSettingPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcSettingPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcSettingPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcSettingPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArcVmExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation>
    {
        public ArcVmExtendedLocation() { }
        public Azure.ResourceManager.Hci.Models.ArcVmExtendedLocationType? ExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArcVmExtendedLocationType : System.IEquatable<Azure.ResourceManager.Hci.Models.ArcVmExtendedLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArcVmExtendedLocationType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcVmExtendedLocationType CustomLocation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ArcVmExtendedLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ArcVmExtendedLocationType left, Azure.ResourceManager.Hci.Models.ArcVmExtendedLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ArcVmExtendedLocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ArcVmExtendedLocationType left, Azure.ResourceManager.Hci.Models.ArcVmExtendedLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmHciModelFactory
    {
        public static Azure.ResourceManager.Hci.ArcExtensionData ArcExtensionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState? aggregateState = default(Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PerNodeExtensionState> perNodeExtensionDetails = null, string forceUpdateTag = null, string publisher = null, string arcExtensionType = null, string typeHandlerVersion = null, bool? shouldAutoUpgradeMinorVersion = default(bool?), System.BinaryData settings = null, System.BinaryData protectedSettings = null, bool? enableAutomaticUpgrade = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcIdentityResult ArcIdentityResult(System.Guid? arcApplicationClientId = default(System.Guid?), System.Guid? arcApplicationTenantId = default(System.Guid?), System.Guid? arcServicePrincipalObjectId = default(System.Guid?), System.Guid? arcApplicationObjectId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcPasswordCredential ArcPasswordCredential(string secretText = null, string keyId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.ArcSettingData ArcSettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string arcInstanceResourceGroup = null, System.Guid? arcApplicationClientId = default(System.Guid?), System.Guid? arcApplicationTenantId = default(System.Guid?), System.Guid? arcServicePrincipalObjectId = default(System.Guid?), System.Guid? arcApplicationObjectId = default(System.Guid?), Azure.ResourceManager.Hci.Models.ArcSettingAggregateState? aggregateState = default(Azure.ResourceManager.Hci.Models.ArcSettingAggregateState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PerNodeArcState> perNodeDetails = null, System.BinaryData connectivityProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus ExtensionInstanceViewStatus(string code = null, Azure.ResourceManager.Hci.Models.HciStatusLevelType? level = default(Azure.ResourceManager.Hci.Models.HciStatusLevelType?), string displayStatus = null, string message = null, System.DateTimeOffset? time = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.GalleryImageData GalleryImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation extendedLocation = null, Azure.Core.ResourceIdentifier containerId = null, string imagePath = null, Azure.ResourceManager.Hci.Models.OperatingSystemType? osType = default(Azure.ResourceManager.Hci.Models.OperatingSystemType?), Azure.ResourceManager.Hci.Models.CloudInitDataSource? cloudInitDataSource = default(Azure.ResourceManager.Hci.Models.CloudInitDataSource?), Azure.ResourceManager.Hci.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Hci.Models.HyperVGeneration?), Azure.ResourceManager.Hci.Models.GalleryImageIdentifier identifier = null, Azure.ResourceManager.Hci.Models.GalleryImageVersion version = null, Azure.ResourceManager.Hci.Models.ProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Models.ProvisioningStateEnum?), Azure.ResourceManager.Hci.Models.GalleryImageStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.GalleryImageStatus GalleryImageStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Models.GalleryImageStatusProvisioningStatus provisioningStatus = null, long? downloadSizeInMB = default(long?), long? progressPercentage = default(long?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.GalleryImageStatusProvisioningStatus GalleryImageStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Models.HciClusterStatus? status = default(Azure.ResourceManager.Hci.Models.HciClusterStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.GuestAgentData GuestAgentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.GuestCredential credentials = null, Azure.ResourceManager.Hci.Models.ProvisioningAction? provisioningAction = default(Azure.ResourceManager.Hci.Models.ProvisioningAction?), string status = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.GuestAgentInstallStatus GuestAgentInstallStatus(string vmUuid = null, Azure.ResourceManager.Hci.Models.StatusType? status = default(Azure.ResourceManager.Hci.Models.StatusType?), System.DateTimeOffset? lastStatusChange = default(System.DateTimeOffset?), string agentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errorDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterData HciClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), Azure.ResourceManager.Hci.Models.HciClusterStatus? status = default(Azure.ResourceManager.Hci.Models.HciClusterStatus?), System.Guid? cloudId = default(System.Guid?), string cloudManagementEndpoint = null, System.Guid? aadClientId = default(System.Guid?), System.Guid? aadTenantId = default(System.Guid?), System.Guid? aadApplicationObjectId = default(System.Guid?), System.Guid? aadServicePrincipalObjectId = default(System.Guid?), Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties softwareAssuranceProperties = null, Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties desiredProperties = null, Azure.ResourceManager.Hci.Models.HciClusterReportedProperties reportedProperties = null, float? trialDaysRemaining = default(float?), string billingModel = null, System.DateTimeOffset? registrationTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? lastSyncTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? lastBillingTimestamp = default(System.DateTimeOffset?), string serviceEndpoint = null, string resourceProviderObjectId = null, System.Guid? principalId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType? typeIdentityType = default(Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterIdentityResult HciClusterIdentityResult(System.Guid? aadClientId = default(System.Guid?), System.Guid? aadTenantId = default(System.Guid?), System.Guid? aadServicePrincipalObjectId = default(System.Guid?), System.Guid? aadApplicationObjectId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterNode HciClusterNode(string name = null, float? id = default(float?), Azure.ResourceManager.Hci.Models.WindowsServerSubscription? windowsServerSubscription = default(Azure.ResourceManager.Hci.Models.WindowsServerSubscription?), Azure.ResourceManager.Hci.Models.ClusterNodeType? nodeType = default(Azure.ResourceManager.Hci.Models.ClusterNodeType?), string ehcResourceId = null, string manufacturer = null, string model = null, string osName = null, string osVersion = null, string osDisplayVersion = null, string serialNumber = null, float? coreCount = default(float?), float? memoryInGiB = default(float?), System.DateTimeOffset? lastLicensingTimestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterPatch HciClusterPatch(System.Collections.Generic.IDictionary<string, string> tags = null, string cloudManagementEndpoint = null, System.Guid? aadClientId = default(System.Guid?), System.Guid? aadTenantId = default(System.Guid?), Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties desiredProperties = null, System.Guid? principalId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType? managedServiceIdentityType = default(Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterReportedProperties HciClusterReportedProperties(string clusterName = null, System.Guid? clusterId = default(System.Guid?), string clusterVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciClusterNode> nodes = null, System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.ImdsAttestationState? imdsAttestation = default(Azure.ResourceManager.Hci.Models.ImdsAttestationState?), Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel? diagnosticLevel = default(Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel?), System.Collections.Generic.IEnumerable<string> supportedCapabilities = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciExtensionInstanceView HciExtensionInstanceView(string name = null, string extensionInstanceViewType = null, string typeHandlerVersion = null, Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.HciSkuData HciSkuData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null, string publisherId = null, string offerId = null, string content = null, string contentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciSkuMappings> skuMappings = null) { throw null; }
        public static Azure.ResourceManager.Hci.HybridIdentityMetadataData HybridIdentityMetadataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string resourceUid = null, string publicKey = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.InstanceViewStatus InstanceViewStatus(string code = null, Azure.ResourceManager.Hci.Models.HciStatusLevelType? level = default(Azure.ResourceManager.Hci.Models.HciStatusLevelType?), string displayStatus = null, string message = null, System.DateTimeOffset? time = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.IPConfigurationProperties IPConfigurationProperties(string gateway = null, string prefixLength = null, string privateIPAddress = null, Azure.Core.ResourceIdentifier subnetId = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.IPPoolInfo IPPoolInfo(string used = null, string available = null) { throw null; }
        public static Azure.ResourceManager.Hci.LogicalNetworkData LogicalNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<string> dhcpOptionsDnsServers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.Subnet> subnets = null, Azure.ResourceManager.Hci.Models.ProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Models.ProvisioningStateEnum?), string vmSwitchName = null, Azure.ResourceManager.Hci.Models.LogicalNetworkStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.LogicalNetworkStatus LogicalNetworkStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Models.LogicalNetworkStatusProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.LogicalNetworkStatusProvisioningStatus LogicalNetworkStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Models.HciClusterStatus? status = default(Azure.ResourceManager.Hci.Models.HciClusterStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.MarketplaceGalleryImageData MarketplaceGalleryImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation extendedLocation = null, Azure.Core.ResourceIdentifier containerId = null, Azure.ResourceManager.Hci.Models.OperatingSystemType? osType = default(Azure.ResourceManager.Hci.Models.OperatingSystemType?), Azure.ResourceManager.Hci.Models.CloudInitDataSource? cloudInitDataSource = default(Azure.ResourceManager.Hci.Models.CloudInitDataSource?), Azure.ResourceManager.Hci.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Hci.Models.HyperVGeneration?), Azure.ResourceManager.Hci.Models.GalleryImageIdentifier identifier = null, Azure.ResourceManager.Hci.Models.GalleryImageVersion version = null, Azure.ResourceManager.Hci.Models.ProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Models.ProvisioningStateEnum?), Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatus MarketplaceGalleryImageStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatusProvisioningStatus provisioningStatus = null, long? downloadSizeInMB = default(long?), long? progressPercentage = default(long?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatusProvisioningStatus MarketplaceGalleryImageStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Models.HciClusterStatus? status = default(Azure.ResourceManager.Hci.Models.HciClusterStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.NetworkInterfaceData NetworkInterfaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.IPConfiguration> ipConfigurations = null, string macAddress = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, Azure.ResourceManager.Hci.Models.ProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Models.ProvisioningStateEnum?), Azure.ResourceManager.Hci.Models.NetworkInterfaceStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.NetworkInterfaceStatus NetworkInterfaceStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Models.NetworkInterfaceStatusProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.NetworkInterfaceStatusProvisioningStatus NetworkInterfaceStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Models.HciClusterStatus? status = default(Azure.ResourceManager.Hci.Models.HciClusterStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.OfferData OfferData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null, string publisherId = null, string content = null, string contentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciSkuMappings> skuMappings = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.PerNodeArcState PerNodeArcState(string name = null, string arcInstance = null, Azure.ResourceManager.Hci.Models.NodeArcState? state = default(Azure.ResourceManager.Hci.Models.NodeArcState?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.PerNodeExtensionState PerNodeExtensionState(string name = null, string extension = null, string typeHandlerVersion = null, Azure.ResourceManager.Hci.Models.NodeExtensionState? state = default(Azure.ResourceManager.Hci.Models.NodeExtensionState?), Azure.ResourceManager.Hci.Models.HciExtensionInstanceView instanceView = null) { throw null; }
        public static Azure.ResourceManager.Hci.PublisherData PublisherData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.RouteTable RouteTable(string etag = null, string name = null, string routeTableType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.Route> routes = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties SoftwareAssuranceProperties(Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus? softwareAssuranceStatus = default(Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus?), Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent? softwareAssuranceIntent = default(Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent?), System.DateTimeOffset? lastUpdated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.StorageContainerData StorageContainerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation extendedLocation = null, string path = null, Azure.ResourceManager.Hci.Models.ProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Models.ProvisioningStateEnum?), Azure.ResourceManager.Hci.Models.StorageContainerStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.StorageContainerStatus StorageContainerStatus(string errorCode = null, string errorMessage = null, long? availableSizeMB = default(long?), long? containerSizeMB = default(long?), Azure.ResourceManager.Hci.Models.StorageContainerStatusProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.StorageContainerStatusProvisioningStatus StorageContainerStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Models.HciClusterStatus? status = default(Azure.ResourceManager.Hci.Models.HciClusterStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateData UpdateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), System.DateTimeOffset? installedOn = default(System.DateTimeOffset?), string description = null, Azure.ResourceManager.Hci.Models.HciUpdateState? state = default(Azure.ResourceManager.Hci.Models.HciUpdateState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.UpdatePrerequisite> prerequisites = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> componentVersions = null, Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement? rebootRequired = default(Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement?), Azure.ResourceManager.Hci.Models.HciHealthState? healthState = default(Azure.ResourceManager.Hci.Models.HciHealthState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPrecheckResult> healthCheckResult = null, System.DateTimeOffset? healthCheckOn = default(System.DateTimeOffset?), string packagePath = null, float? packageSizeInMb = default(float?), string displayName = null, string version = null, string publisher = null, string releaseLink = null, Azure.ResourceManager.Hci.Models.HciAvailabilityType? availabilityType = default(Azure.ResourceManager.Hci.Models.HciAvailabilityType?), string packageType = null, string additionalProperties = null, float? progressPercentage = default(float?), string notifyMessage = null) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateRunData UpdateRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), System.DateTimeOffset? timeStarted = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), string duration = null, Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState? state = default(Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState?), string namePropertiesProgressName = null, string description = null, string errorMessage = null, string status = null, System.DateTimeOffset? startTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedTimeUtc = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciUpdateStep> steps = null) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateSummaryData UpdateSummaryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string oemFamily = null, string hardwareModel = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> packageVersions = null, string currentVersion = null, System.DateTimeOffset? lastUpdated = default(System.DateTimeOffset?), System.DateTimeOffset? lastChecked = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.HciHealthState? healthState = default(Azure.ResourceManager.Hci.Models.HciHealthState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPrecheckResult> healthCheckResult = null, System.DateTimeOffset? healthCheckOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState? state = default(Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState?)) { throw null; }
        public static Azure.ResourceManager.Hci.VirtualHardDiskData VirtualHardDiskData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation extendedLocation = null, int? blockSizeBytes = default(int?), long? diskSizeGB = default(long?), bool? dynamic = default(bool?), int? logicalSectorBytes = default(int?), int? physicalSectorBytes = default(int?), Azure.ResourceManager.Hci.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Hci.Models.HyperVGeneration?), Azure.ResourceManager.Hci.Models.DiskFileFormat? diskFileFormat = default(Azure.ResourceManager.Hci.Models.DiskFileFormat?), Azure.ResourceManager.Hci.Models.ProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Models.ProvisioningStateEnum?), Azure.Core.ResourceIdentifier containerId = null, Azure.ResourceManager.Hci.Models.VirtualHardDiskStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.VirtualHardDiskStatus VirtualHardDiskStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Models.VirtualHardDiskStatusProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.VirtualHardDiskStatusProvisioningStatus VirtualHardDiskStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Models.HciClusterStatus? status = default(Azure.ResourceManager.Hci.Models.HciClusterStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.VirtualMachineConfigAgentInstanceView VirtualMachineConfigAgentInstanceView(string vmConfigAgentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.InstanceViewStatus> statuses = null) { throw null; }
        public static Azure.ResourceManager.Hci.VirtualMachineInstanceData VirtualMachineInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation extendedLocation = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesHardwareProfile hardwareProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> networkInterfaces = null, Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfile osProfile = null, Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesSecurityProfile securityProfile = null, Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesStorageProfile storageProfile = null, Azure.ResourceManager.Hci.Models.HttpProxyConfiguration httpProxyConfig = null, Azure.ResourceManager.Hci.Models.ProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Models.ProvisioningStateEnum?), Azure.ResourceManager.Hci.Models.VirtualMachineConfigAgentInstanceView instanceViewVmAgent = null, Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatus status = null, Azure.ResourceManager.Hci.Models.GuestAgentInstallStatus guestAgentInstallStatus = null, string vmId = null, string resourceUid = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatus VirtualMachineInstanceStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Models.PowerStateEnum? powerState = default(Azure.ResourceManager.Hci.Models.PowerStateEnum?), Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatusProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatusProvisioningStatus VirtualMachineInstanceStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Models.HciClusterStatus? status = default(Azure.ResourceManager.Hci.Models.HciClusterStatus?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudInitDataSource : System.IEquatable<Azure.ResourceManager.Hci.Models.CloudInitDataSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudInitDataSource(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.CloudInitDataSource Azure { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.CloudInitDataSource NoCloud { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.CloudInitDataSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.CloudInitDataSource left, Azure.ResourceManager.Hci.Models.CloudInitDataSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.CloudInitDataSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.CloudInitDataSource left, Azure.ResourceManager.Hci.Models.CloudInitDataSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterNodeType : System.IEquatable<Azure.ResourceManager.Hci.Models.ClusterNodeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterNodeType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ClusterNodeType FirstParty { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ClusterNodeType ThirdParty { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ClusterNodeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ClusterNodeType left, Azure.ResourceManager.Hci.Models.ClusterNodeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ClusterNodeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ClusterNodeType left, Azure.ResourceManager.Hci.Models.ClusterNodeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskFileFormat : System.IEquatable<Azure.ResourceManager.Hci.Models.DiskFileFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskFileFormat(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DiskFileFormat Vhd { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.DiskFileFormat Vhdx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.DiskFileFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.DiskFileFormat left, Azure.ResourceManager.Hci.Models.DiskFileFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.DiskFileFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.DiskFileFormat left, Azure.ResourceManager.Hci.Models.DiskFileFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExtensionInstanceViewStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>
    {
        internal ExtensionInstanceViewStatus() { }
        public string Code { get { throw null; } }
        public string DisplayStatus { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciStatusLevelType? Level { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
        Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtensionUpgradeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent>
    {
        public ExtensionUpgradeContent() { }
        public string TargetVersion { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryImageIdentifier : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.GalleryImageIdentifier>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GalleryImageIdentifier>
    {
        public GalleryImageIdentifier(string publisher, string offer, string sku) { }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.GalleryImageIdentifier System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.GalleryImageIdentifier>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.GalleryImageIdentifier>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.GalleryImageIdentifier System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GalleryImageIdentifier>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GalleryImageIdentifier>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GalleryImageIdentifier>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryImagePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.GalleryImagePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GalleryImagePatch>
    {
        public GalleryImagePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Hci.Models.GalleryImagePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.GalleryImagePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.GalleryImagePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.GalleryImagePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GalleryImagePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GalleryImagePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GalleryImagePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryImageStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.GalleryImageStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GalleryImageStatus>
    {
        internal GalleryImageStatus() { }
        public long? DownloadSizeInMB { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public long? ProgressPercentage { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.GalleryImageStatusProvisioningStatus ProvisioningStatus { get { throw null; } }
        Azure.ResourceManager.Hci.Models.GalleryImageStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.GalleryImageStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.GalleryImageStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.GalleryImageStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GalleryImageStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GalleryImageStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GalleryImageStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryImageStatusProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.GalleryImageStatusProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GalleryImageStatusProvisioningStatus>
    {
        internal GalleryImageStatusProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterStatus? Status { get { throw null; } }
        Azure.ResourceManager.Hci.Models.GalleryImageStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.GalleryImageStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.GalleryImageStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.GalleryImageStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GalleryImageStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GalleryImageStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GalleryImageStatusProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryImageVersion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.GalleryImageVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GalleryImageVersion>
    {
        public GalleryImageVersion() { }
        public string Name { get { throw null; } set { } }
        public long? OSDiskImageSizeInMB { get { throw null; } }
        Azure.ResourceManager.Hci.Models.GalleryImageVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.GalleryImageVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.GalleryImageVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.GalleryImageVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GalleryImageVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GalleryImageVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GalleryImageVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GuestAgentInstallStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.GuestAgentInstallStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GuestAgentInstallStatus>
    {
        public GuestAgentInstallStatus() { }
        public string AgentVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> ErrorDetails { get { throw null; } }
        public System.DateTimeOffset? LastStatusChange { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.StatusType? Status { get { throw null; } }
        public string VmUuid { get { throw null; } }
        Azure.ResourceManager.Hci.Models.GuestAgentInstallStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.GuestAgentInstallStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.GuestAgentInstallStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.GuestAgentInstallStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GuestAgentInstallStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GuestAgentInstallStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GuestAgentInstallStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GuestCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.GuestCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GuestCredential>
    {
        public GuestCredential() { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.GuestCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.GuestCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.GuestCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.GuestCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GuestCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GuestCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.GuestCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HardwareProfileUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HardwareProfileUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HardwareProfileUpdate>
    {
        public HardwareProfileUpdate() { }
        public long? MemoryMB { get { throw null; } set { } }
        public int? Processors { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.VmSizeEnum? VmSize { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.HardwareProfileUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HardwareProfileUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HardwareProfileUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HardwareProfileUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HardwareProfileUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HardwareProfileUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HardwareProfileUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciAvailabilityType : System.IEquatable<Azure.ResourceManager.Hci.Models.HciAvailabilityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciAvailabilityType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciAvailabilityType Local { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciAvailabilityType Notify { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciAvailabilityType Online { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciAvailabilityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciAvailabilityType left, Azure.ResourceManager.Hci.Models.HciAvailabilityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciAvailabilityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciAvailabilityType left, Azure.ResourceManager.Hci.Models.HciAvailabilityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciClusterCertificateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterCertificateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterCertificateContent>
    {
        public HciClusterCertificateContent() { }
        public System.Collections.Generic.IList<string> Certificates { get { throw null; } }
        Azure.ResourceManager.Hci.Models.HciClusterCertificateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterCertificateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterCertificateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterCertificateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterCertificateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterCertificateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterCertificateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciClusterDesiredProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties>
    {
        public HciClusterDesiredProperties() { }
        public Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel? DiagnosticLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.WindowsServerSubscription? WindowsServerSubscription { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciClusterDiagnosticLevel : System.IEquatable<Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciClusterDiagnosticLevel(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel Basic { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel Enhanced { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel Off { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel left, Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel left, Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciClusterIdentityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterIdentityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterIdentityResult>
    {
        internal HciClusterIdentityResult() { }
        public System.Guid? AadApplicationObjectId { get { throw null; } }
        public System.Guid? AadClientId { get { throw null; } }
        public System.Guid? AadServicePrincipalObjectId { get { throw null; } }
        public System.Guid? AadTenantId { get { throw null; } }
        Azure.ResourceManager.Hci.Models.HciClusterIdentityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterIdentityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterIdentityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterIdentityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterIdentityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterIdentityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterIdentityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciClusterNode : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterNode>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterNode>
    {
        internal HciClusterNode() { }
        public float? CoreCount { get { throw null; } }
        public string EhcResourceId { get { throw null; } }
        public float? Id { get { throw null; } }
        public System.DateTimeOffset? LastLicensingTimestamp { get { throw null; } }
        public string Manufacturer { get { throw null; } }
        public float? MemoryInGiB { get { throw null; } }
        public string Model { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ClusterNodeType? NodeType { get { throw null; } }
        public string OSDisplayVersion { get { throw null; } }
        public string OSName { get { throw null; } }
        public string OSVersion { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.WindowsServerSubscription? WindowsServerSubscription { get { throw null; } }
        Azure.ResourceManager.Hci.Models.HciClusterNode System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterNode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterNode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterNode System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterNode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterNode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterNode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterPatch>
    {
        public HciClusterPatch() { }
        public System.Guid? AadClientId { get { throw null; } set { } }
        public System.Guid? AadTenantId { get { throw null; } set { } }
        public string CloudManagementEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties DesiredProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType? ManagedServiceIdentityType { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        Azure.ResourceManager.Hci.Models.HciClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciClusterReportedProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterReportedProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterReportedProperties>
    {
        internal HciClusterReportedProperties() { }
        public System.Guid? ClusterId { get { throw null; } }
        public string ClusterName { get { throw null; } }
        public string ClusterVersion { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel? DiagnosticLevel { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ImdsAttestationState? ImdsAttestation { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciClusterNode> Nodes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedCapabilities { get { throw null; } }
        Azure.ResourceManager.Hci.Models.HciClusterReportedProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterReportedProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterReportedProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterReportedProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterReportedProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterReportedProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterReportedProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciClusterStatus : System.IEquatable<Azure.ResourceManager.Hci.Models.HciClusterStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciClusterStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus ConnectedRecently { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus NotConnectedRecently { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus NotYetRegistered { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciClusterStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciClusterStatus left, Azure.ResourceManager.Hci.Models.HciClusterStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciClusterStatus left, Azure.ResourceManager.Hci.Models.HciClusterStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciExtensionInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciExtensionInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciExtensionInstanceView>
    {
        internal HciExtensionInstanceView() { }
        public string ExtensionInstanceViewType { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus Status { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } }
        Azure.ResourceManager.Hci.Models.HciExtensionInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciExtensionInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciExtensionInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciExtensionInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciExtensionInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciExtensionInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciExtensionInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciHealthState : System.IEquatable<Azure.ResourceManager.Hci.Models.HciHealthState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciHealthState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciHealthState Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciHealthState Failure { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciHealthState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciHealthState Success { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciHealthState Unknown { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciHealthState Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciHealthState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciHealthState left, Azure.ResourceManager.Hci.Models.HciHealthState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciHealthState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciHealthState left, Azure.ResourceManager.Hci.Models.HciHealthState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciManagedServiceIdentityType : System.IEquatable<Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciManagedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType left, Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType left, Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciNodeRebootRequirement : System.IEquatable<Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciNodeRebootRequirement(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement False { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement True { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement left, Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement left, Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciPackageVersionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo>
    {
        public HciPackageVersionInfo() { }
        public System.DateTimeOffset? LastUpdated { get { throw null; } set { } }
        public string PackageType { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.HciPackageVersionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciPackageVersionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciPrecheckResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciPrecheckResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPrecheckResult>
    {
        public HciPrecheckResult() { }
        public string AdditionalData { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string HealthCheckSource { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Remediation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.UpdateSeverity? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciClusterStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciPrecheckResultTags Tags { get { throw null; } set { } }
        public string TargetResourceId { get { throw null; } set { } }
        public string TargetResourceName { get { throw null; } set { } }
        public System.DateTimeOffset? Timestamp { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.HciPrecheckResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciPrecheckResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciPrecheckResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciPrecheckResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPrecheckResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPrecheckResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPrecheckResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciPrecheckResultTags : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciPrecheckResultTags>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPrecheckResultTags>
    {
        public HciPrecheckResultTags() { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.HciPrecheckResultTags System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciPrecheckResultTags>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciPrecheckResultTags>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciPrecheckResultTags System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPrecheckResultTags>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPrecheckResultTags>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPrecheckResultTags>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciProvisioningState : System.IEquatable<Azure.ResourceManager.Hci.Models.HciProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState DisableInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState PartiallyConnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciProvisioningState left, Azure.ResourceManager.Hci.Models.HciProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciProvisioningState left, Azure.ResourceManager.Hci.Models.HciProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciSkuMappings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciSkuMappings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciSkuMappings>
    {
        public HciSkuMappings() { }
        public string CatalogPlanId { get { throw null; } set { } }
        public string MarketplaceSkuId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MarketplaceSkuVersions { get { throw null; } }
        Azure.ResourceManager.Hci.Models.HciSkuMappings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciSkuMappings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciSkuMappings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciSkuMappings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciSkuMappings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciSkuMappings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciSkuMappings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciStatusLevelType : System.IEquatable<Azure.ResourceManager.Hci.Models.HciStatusLevelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciStatusLevelType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciStatusLevelType Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciStatusLevelType Info { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciStatusLevelType Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciStatusLevelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciStatusLevelType left, Azure.ResourceManager.Hci.Models.HciStatusLevelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciStatusLevelType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciStatusLevelType left, Azure.ResourceManager.Hci.Models.HciStatusLevelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciUpdateState : System.IEquatable<Azure.ResourceManager.Hci.Models.HciUpdateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciUpdateState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState DownloadFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Downloading { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState HasPrerequisite { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState HealthCheckFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState HealthChecking { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState InstallationFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Installed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Installing { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Invalid { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState NotApplicableBecauseAnotherUpdateIsInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Obsolete { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState PreparationFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Preparing { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Ready { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState ReadyToInstall { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Recalled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState ScanFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState ScanInProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciUpdateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciUpdateState left, Azure.ResourceManager.Hci.Models.HciUpdateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciUpdateState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciUpdateState left, Azure.ResourceManager.Hci.Models.HciUpdateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciUpdateStep : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciUpdateStep>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciUpdateStep>
    {
        public HciUpdateStep() { }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? EndTimeUtc { get { throw null; } set { } }
        public string ErrorMessage { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedTimeUtc { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.DateTimeOffset? StartTimeUtc { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciUpdateStep> Steps { get { throw null; } }
        Azure.ResourceManager.Hci.Models.HciUpdateStep System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciUpdateStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciUpdateStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciUpdateStep System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciUpdateStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciUpdateStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciUpdateStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HttpProxyConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HttpProxyConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HttpProxyConfiguration>
    {
        public HttpProxyConfiguration() { }
        public string HttpProxy { get { throw null; } set { } }
        public string HttpsProxy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NoProxy { get { throw null; } }
        public string TrustedCa { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.HttpProxyConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HttpProxyConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HttpProxyConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HttpProxyConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HttpProxyConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HttpProxyConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HttpProxyConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HyperVGeneration : System.IEquatable<Azure.ResourceManager.Hci.Models.HyperVGeneration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HyperVGeneration(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HyperVGeneration V1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HyperVGeneration V2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HyperVGeneration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HyperVGeneration left, Azure.ResourceManager.Hci.Models.HyperVGeneration right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HyperVGeneration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HyperVGeneration left, Azure.ResourceManager.Hci.Models.HyperVGeneration right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImdsAttestationState : System.IEquatable<Azure.ResourceManager.Hci.Models.ImdsAttestationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImdsAttestationState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ImdsAttestationState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ImdsAttestationState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ImdsAttestationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ImdsAttestationState left, Azure.ResourceManager.Hci.Models.ImdsAttestationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ImdsAttestationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ImdsAttestationState left, Azure.ResourceManager.Hci.Models.ImdsAttestationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InstanceViewStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.InstanceViewStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.InstanceViewStatus>
    {
        internal InstanceViewStatus() { }
        public string Code { get { throw null; } }
        public string DisplayStatus { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciStatusLevelType? Level { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
        Azure.ResourceManager.Hci.Models.InstanceViewStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.InstanceViewStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.InstanceViewStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.InstanceViewStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.InstanceViewStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.InstanceViewStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.InstanceViewStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPAllocationMethodEnum : System.IEquatable<Azure.ResourceManager.Hci.Models.IPAllocationMethodEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPAllocationMethodEnum(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.IPAllocationMethodEnum Dynamic { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.IPAllocationMethodEnum Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.IPAllocationMethodEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.IPAllocationMethodEnum left, Azure.ResourceManager.Hci.Models.IPAllocationMethodEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.IPAllocationMethodEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.IPAllocationMethodEnum left, Azure.ResourceManager.Hci.Models.IPAllocationMethodEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IPConfiguration>
    {
        public IPConfiguration() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.IPConfigurationProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.IPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.IPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IPConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IPConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IPConfigurationProperties>
    {
        public IPConfigurationProperties() { }
        public string Gateway { get { throw null; } }
        public string PrefixLength { get { throw null; } }
        public string PrivateIPAddress { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.IPConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IPConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IPConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.IPConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IPConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IPConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IPConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IPPool : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IPPool>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IPPool>
    {
        public IPPool() { }
        public string End { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.IPPoolInfo Info { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.IPPoolTypeEnum? IPPoolType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Start { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.IPPool System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IPPool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IPPool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.IPPool System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IPPool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IPPool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IPPool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IPPoolInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IPPoolInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IPPoolInfo>
    {
        public IPPoolInfo() { }
        public string Available { get { throw null; } }
        public string Used { get { throw null; } }
        Azure.ResourceManager.Hci.Models.IPPoolInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IPPoolInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IPPoolInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.IPPoolInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IPPoolInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IPPoolInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IPPoolInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum IPPoolTypeEnum
    {
        Vm = 0,
        Vippool = 1,
    }
    public partial class LogicalNetworkPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogicalNetworkPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogicalNetworkPatch>
    {
        public LogicalNetworkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Hci.Models.LogicalNetworkPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogicalNetworkPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogicalNetworkPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.LogicalNetworkPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogicalNetworkPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogicalNetworkPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogicalNetworkPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicalNetworkStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogicalNetworkStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogicalNetworkStatus>
    {
        internal LogicalNetworkStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.LogicalNetworkStatusProvisioningStatus ProvisioningStatus { get { throw null; } }
        Azure.ResourceManager.Hci.Models.LogicalNetworkStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogicalNetworkStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogicalNetworkStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.LogicalNetworkStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogicalNetworkStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogicalNetworkStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogicalNetworkStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicalNetworkStatusProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogicalNetworkStatusProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogicalNetworkStatusProvisioningStatus>
    {
        internal LogicalNetworkStatusProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterStatus? Status { get { throw null; } }
        Azure.ResourceManager.Hci.Models.LogicalNetworkStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogicalNetworkStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogicalNetworkStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.LogicalNetworkStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogicalNetworkStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogicalNetworkStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogicalNetworkStatusProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceGalleryImagePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.MarketplaceGalleryImagePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.MarketplaceGalleryImagePatch>
    {
        public MarketplaceGalleryImagePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Hci.Models.MarketplaceGalleryImagePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.MarketplaceGalleryImagePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.MarketplaceGalleryImagePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.MarketplaceGalleryImagePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.MarketplaceGalleryImagePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.MarketplaceGalleryImagePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.MarketplaceGalleryImagePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceGalleryImageStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatus>
    {
        internal MarketplaceGalleryImageStatus() { }
        public long? DownloadSizeInMB { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public long? ProgressPercentage { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatusProvisioningStatus ProvisioningStatus { get { throw null; } }
        Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceGalleryImageStatusProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatusProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatusProvisioningStatus>
    {
        internal MarketplaceGalleryImageStatusProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterStatus? Status { get { throw null; } }
        Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.MarketplaceGalleryImageStatusProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkInterfacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.NetworkInterfacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NetworkInterfacePatch>
    {
        public NetworkInterfacePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Hci.Models.NetworkInterfacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.NetworkInterfacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.NetworkInterfacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.NetworkInterfacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NetworkInterfacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NetworkInterfacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NetworkInterfacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkInterfaceStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.NetworkInterfaceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NetworkInterfaceStatus>
    {
        internal NetworkInterfaceStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.NetworkInterfaceStatusProvisioningStatus ProvisioningStatus { get { throw null; } }
        Azure.ResourceManager.Hci.Models.NetworkInterfaceStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.NetworkInterfaceStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.NetworkInterfaceStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.NetworkInterfaceStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NetworkInterfaceStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NetworkInterfaceStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NetworkInterfaceStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkInterfaceStatusProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.NetworkInterfaceStatusProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NetworkInterfaceStatusProvisioningStatus>
    {
        internal NetworkInterfaceStatusProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterStatus? Status { get { throw null; } }
        Azure.ResourceManager.Hci.Models.NetworkInterfaceStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.NetworkInterfaceStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.NetworkInterfaceStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.NetworkInterfaceStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NetworkInterfaceStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NetworkInterfaceStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NetworkInterfaceStatusProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeArcState : System.IEquatable<Azure.ResourceManager.Hci.Models.NodeArcState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeArcState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Creating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState DisableInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Moving { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState PartiallyConnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.NodeArcState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.NodeArcState left, Azure.ResourceManager.Hci.Models.NodeArcState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.NodeArcState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.NodeArcState left, Azure.ResourceManager.Hci.Models.NodeArcState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeExtensionState : System.IEquatable<Azure.ResourceManager.Hci.Models.NodeExtensionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeExtensionState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Creating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Moving { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState PartiallyConnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.NodeExtensionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.NodeExtensionState left, Azure.ResourceManager.Hci.Models.NodeExtensionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.NodeExtensionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.NodeExtensionState left, Azure.ResourceManager.Hci.Models.NodeExtensionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum OperatingSystemType
    {
        Windows = 0,
        Linux = 1,
    }
    public partial class OSProfileUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OSProfileUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OSProfileUpdate>
    {
        public OSProfileUpdate() { }
        public string ComputerName { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.OSProfileUpdateLinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.OSProfileUpdateWindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.OSProfileUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OSProfileUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OSProfileUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.OSProfileUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OSProfileUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OSProfileUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OSProfileUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OSProfileUpdateLinuxConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OSProfileUpdateLinuxConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OSProfileUpdateLinuxConfiguration>
    {
        public OSProfileUpdateLinuxConfiguration() { }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public bool? ProvisionVmConfigAgent { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.OSProfileUpdateLinuxConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OSProfileUpdateLinuxConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OSProfileUpdateLinuxConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.OSProfileUpdateLinuxConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OSProfileUpdateLinuxConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OSProfileUpdateLinuxConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OSProfileUpdateLinuxConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OSProfileUpdateWindowsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OSProfileUpdateWindowsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OSProfileUpdateWindowsConfiguration>
    {
        public OSProfileUpdateWindowsConfiguration() { }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public bool? ProvisionVmConfigAgent { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.OSProfileUpdateWindowsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OSProfileUpdateWindowsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OSProfileUpdateWindowsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.OSProfileUpdateWindowsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OSProfileUpdateWindowsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OSProfileUpdateWindowsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OSProfileUpdateWindowsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PerNodeArcState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PerNodeArcState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeArcState>
    {
        internal PerNodeArcState() { }
        public string ArcInstance { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.NodeArcState? State { get { throw null; } }
        Azure.ResourceManager.Hci.Models.PerNodeArcState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PerNodeArcState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PerNodeArcState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.PerNodeArcState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeArcState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeArcState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeArcState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PerNodeExtensionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PerNodeExtensionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeExtensionState>
    {
        internal PerNodeExtensionState() { }
        public string Extension { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciExtensionInstanceView InstanceView { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.NodeExtensionState? State { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } }
        Azure.ResourceManager.Hci.Models.PerNodeExtensionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PerNodeExtensionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PerNodeExtensionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.PerNodeExtensionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeExtensionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeExtensionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeExtensionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PowerStateEnum : System.IEquatable<Azure.ResourceManager.Hci.Models.PowerStateEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PowerStateEnum(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.PowerStateEnum Deallocated { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.PowerStateEnum Deallocating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.PowerStateEnum Running { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.PowerStateEnum Starting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.PowerStateEnum Stopped { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.PowerStateEnum Stopping { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.PowerStateEnum Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.PowerStateEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.PowerStateEnum left, Azure.ResourceManager.Hci.Models.PowerStateEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.PowerStateEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.PowerStateEnum left, Azure.ResourceManager.Hci.Models.PowerStateEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningAction : System.IEquatable<Azure.ResourceManager.Hci.Models.ProvisioningAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningAction(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ProvisioningAction Install { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ProvisioningAction Repair { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ProvisioningAction Uninstall { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ProvisioningAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ProvisioningAction left, Azure.ResourceManager.Hci.Models.ProvisioningAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ProvisioningAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ProvisioningAction left, Azure.ResourceManager.Hci.Models.ProvisioningAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningStateEnum : System.IEquatable<Azure.ResourceManager.Hci.Models.ProvisioningStateEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningStateEnum(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ProvisioningStateEnum Accepted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ProvisioningStateEnum Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ProvisioningStateEnum Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ProvisioningStateEnum Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ProvisioningStateEnum InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ProvisioningStateEnum Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ProvisioningStateEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ProvisioningStateEnum left, Azure.ResourceManager.Hci.Models.ProvisioningStateEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ProvisioningStateEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ProvisioningStateEnum left, Azure.ResourceManager.Hci.Models.ProvisioningStateEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Route : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.Route>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.Route>
    {
        public Route() { }
        public string AddressPrefix { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string NextHopIPAddress { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.Route System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.Route>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.Route>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.Route System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.Route>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.Route>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.Route>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RouteTable : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RouteTable>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RouteTable>
    {
        public RouteTable() { }
        public string ETag { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.Route> Routes { get { throw null; } }
        public string RouteTableType { get { throw null; } }
        Azure.ResourceManager.Hci.Models.RouteTable System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RouteTable>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RouteTable>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.RouteTable System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RouteTable>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RouteTable>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RouteTable>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityType : System.IEquatable<Azure.ResourceManager.Hci.Models.SecurityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SecurityType ConfidentialVm { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.SecurityType TrustedLaunch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.SecurityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.SecurityType left, Azure.ResourceManager.Hci.Models.SecurityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.SecurityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.SecurityType left, Azure.ResourceManager.Hci.Models.SecurityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SoftwareAssuranceChangeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent>
    {
        public SoftwareAssuranceChangeContent() { }
        public Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent? SoftwareAssuranceIntent { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SoftwareAssuranceIntent : System.IEquatable<Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SoftwareAssuranceIntent(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent Disable { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent Enable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent left, Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent left, Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SoftwareAssuranceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties>
    {
        public SoftwareAssuranceProperties() { }
        public System.DateTimeOffset? LastUpdated { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent? SoftwareAssuranceIntent { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus? SoftwareAssuranceStatus { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SoftwareAssuranceStatus : System.IEquatable<Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SoftwareAssuranceStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus left, Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus left, Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SshPublicKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SshPublicKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SshPublicKey>
    {
        public SshPublicKey() { }
        public string KeyData { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.SshPublicKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SshPublicKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SshPublicKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SshPublicKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SshPublicKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SshPublicKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SshPublicKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StatusType : System.IEquatable<Azure.ResourceManager.Hci.Models.StatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StatusType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.StatusType Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.StatusType InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.StatusType Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.StatusType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.StatusType left, Azure.ResourceManager.Hci.Models.StatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.StatusType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.StatusType left, Azure.ResourceManager.Hci.Models.StatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageContainerPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.StorageContainerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.StorageContainerPatch>
    {
        public StorageContainerPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Hci.Models.StorageContainerPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.StorageContainerPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.StorageContainerPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.StorageContainerPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.StorageContainerPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.StorageContainerPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.StorageContainerPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageContainerStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.StorageContainerStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.StorageContainerStatus>
    {
        internal StorageContainerStatus() { }
        public long? AvailableSizeMB { get { throw null; } }
        public long? ContainerSizeMB { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.StorageContainerStatusProvisioningStatus ProvisioningStatus { get { throw null; } }
        Azure.ResourceManager.Hci.Models.StorageContainerStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.StorageContainerStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.StorageContainerStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.StorageContainerStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.StorageContainerStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.StorageContainerStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.StorageContainerStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageContainerStatusProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.StorageContainerStatusProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.StorageContainerStatusProvisioningStatus>
    {
        internal StorageContainerStatusProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterStatus? Status { get { throw null; } }
        Azure.ResourceManager.Hci.Models.StorageContainerStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.StorageContainerStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.StorageContainerStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.StorageContainerStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.StorageContainerStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.StorageContainerStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.StorageContainerStatusProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Subnet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.Subnet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.Subnet>
    {
        public Subnet() { }
        public string AddressPrefix { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AddressPrefixes { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.IPAllocationMethodEnum? IPAllocationMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> IPConfigurationReferences { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.IPPool> IPPools { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.RouteTable RouteTable { get { throw null; } set { } }
        public int? Vlan { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.Subnet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.Subnet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.Subnet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.Subnet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.Subnet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.Subnet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.Subnet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdatePrerequisite : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.UpdatePrerequisite>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.UpdatePrerequisite>
    {
        public UpdatePrerequisite() { }
        public string PackageName { get { throw null; } set { } }
        public string UpdateType { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.UpdatePrerequisite System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.UpdatePrerequisite>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.UpdatePrerequisite>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.UpdatePrerequisite System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.UpdatePrerequisite>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.UpdatePrerequisite>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.UpdatePrerequisite>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateRunPropertiesState : System.IEquatable<Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateRunPropertiesState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState left, Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState left, Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateSeverity : System.IEquatable<Azure.ResourceManager.Hci.Models.UpdateSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateSeverity(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.UpdateSeverity Critical { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSeverity Hidden { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSeverity Informational { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSeverity Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.UpdateSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.UpdateSeverity left, Azure.ResourceManager.Hci.Models.UpdateSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.UpdateSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.UpdateSeverity left, Azure.ResourceManager.Hci.Models.UpdateSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateSummariesPropertiesState : System.IEquatable<Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateSummariesPropertiesState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState AppliedSuccessfully { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState NeedsAttention { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState PreparationFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState PreparationInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState Unknown { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState UpdateAvailable { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState UpdateFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState UpdateInProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState left, Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState left, Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualHardDiskPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualHardDiskPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualHardDiskPatch>
    {
        public VirtualHardDiskPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Hci.Models.VirtualHardDiskPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualHardDiskPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualHardDiskPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.VirtualHardDiskPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualHardDiskPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualHardDiskPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualHardDiskPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualHardDiskStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualHardDiskStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualHardDiskStatus>
    {
        internal VirtualHardDiskStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.VirtualHardDiskStatusProvisioningStatus ProvisioningStatus { get { throw null; } }
        Azure.ResourceManager.Hci.Models.VirtualHardDiskStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualHardDiskStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualHardDiskStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.VirtualHardDiskStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualHardDiskStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualHardDiskStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualHardDiskStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualHardDiskStatusProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualHardDiskStatusProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualHardDiskStatusProvisioningStatus>
    {
        internal VirtualHardDiskStatusProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterStatus? Status { get { throw null; } }
        Azure.ResourceManager.Hci.Models.VirtualHardDiskStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualHardDiskStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualHardDiskStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.VirtualHardDiskStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualHardDiskStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualHardDiskStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualHardDiskStatusProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineConfigAgentInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineConfigAgentInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineConfigAgentInstanceView>
    {
        internal VirtualMachineConfigAgentInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public string VmConfigAgentVersion { get { throw null; } }
        Azure.ResourceManager.Hci.Models.VirtualMachineConfigAgentInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineConfigAgentInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineConfigAgentInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.VirtualMachineConfigAgentInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineConfigAgentInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineConfigAgentInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineConfigAgentInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePatch>
    {
        public VirtualMachineInstancePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.VirtualMachineInstanceUpdateProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePropertiesHardwareProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesHardwareProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesHardwareProfile>
    {
        public VirtualMachineInstancePropertiesHardwareProfile() { }
        public Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig DynamicMemoryConfig { get { throw null; } set { } }
        public long? MemoryMB { get { throw null; } set { } }
        public int? Processors { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.VmSizeEnum? VmSize { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesHardwareProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesHardwareProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesHardwareProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesHardwareProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesHardwareProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesHardwareProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesHardwareProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig>
    {
        public VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig() { }
        public long? MaximumMemoryMB { get { throw null; } set { } }
        public long? MinimumMemoryMB { get { throw null; } set { } }
        public int? TargetMemoryBuffer { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePropertiesOSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfile>
    {
        public VirtualMachineInstancePropertiesOSProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public string ComputerName { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfileLinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfileWindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePropertiesOSProfileLinuxConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfileLinuxConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfileLinuxConfiguration>
    {
        public VirtualMachineInstancePropertiesOSProfileLinuxConfiguration() { }
        public bool? DisablePasswordAuthentication { get { throw null; } set { } }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public bool? ProvisionVmConfigAgent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.SshPublicKey> SshPublicKeys { get { throw null; } }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfileLinuxConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfileLinuxConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfileLinuxConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfileLinuxConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfileLinuxConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfileLinuxConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfileLinuxConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePropertiesOSProfileWindowsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfileWindowsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfileWindowsConfiguration>
    {
        public VirtualMachineInstancePropertiesOSProfileWindowsConfiguration() { }
        public bool? EnableAutomaticUpdates { get { throw null; } set { } }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public bool? ProvisionVmConfigAgent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.SshPublicKey> SshPublicKeys { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfileWindowsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfileWindowsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfileWindowsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfileWindowsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfileWindowsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfileWindowsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesOSProfileWindowsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePropertiesSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesSecurityProfile>
    {
        public VirtualMachineInstancePropertiesSecurityProfile() { }
        public bool? EnableTPM { get { throw null; } set { } }
        public bool? SecureBootEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.SecurityType? SecurityType { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesSecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesSecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesSecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesSecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesSecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesSecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesSecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePropertiesStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesStorageProfile>
    {
        public VirtualMachineInstancePropertiesStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> DataDisks { get { throw null; } }
        public Azure.Core.ResourceIdentifier ImageReferenceId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesStorageProfileOSDisk OSDisk { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VmConfigStoragePathId { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePropertiesStorageProfileOSDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesStorageProfileOSDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesStorageProfileOSDisk>
    {
        public VirtualMachineInstancePropertiesStorageProfileOSDisk() { }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.OperatingSystemType? OSType { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesStorageProfileOSDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesStorageProfileOSDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesStorageProfileOSDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesStorageProfileOSDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesStorageProfileOSDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesStorageProfileOSDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstancePropertiesStorageProfileOSDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstanceStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatus>
    {
        internal VirtualMachineInstanceStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.PowerStateEnum? PowerState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatusProvisioningStatus ProvisioningStatus { get { throw null; } }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstanceStatusProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatusProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatusProvisioningStatus>
    {
        internal VirtualMachineInstanceStatusProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterStatus? Status { get { throw null; } }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstanceStatusProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstanceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstanceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstanceUpdateProperties>
    {
        public VirtualMachineInstanceUpdateProperties() { }
        public Azure.ResourceManager.Hci.Models.HardwareProfileUpdate HardwareProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> NetworkInterfaces { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.OSProfileUpdate OSProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> StorageDataDisks { get { throw null; } }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstanceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstanceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstanceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.VirtualMachineInstanceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstanceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstanceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.VirtualMachineInstanceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmSizeEnum : System.IEquatable<Azure.ResourceManager.Hci.Models.VmSizeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmSizeEnum(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.VmSizeEnum Custom { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.VmSizeEnum Default { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.VmSizeEnum StandardA2V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.VmSizeEnum StandardA4V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.VmSizeEnum StandardD16SV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.VmSizeEnum StandardD2SV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.VmSizeEnum StandardD32SV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.VmSizeEnum StandardD4SV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.VmSizeEnum StandardD8SV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.VmSizeEnum StandardDS13V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.VmSizeEnum StandardDS2V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.VmSizeEnum StandardDS3V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.VmSizeEnum StandardDS4V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.VmSizeEnum StandardDS5V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.VmSizeEnum StandardK8S2V1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.VmSizeEnum StandardK8S3V1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.VmSizeEnum StandardK8S4V1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.VmSizeEnum StandardK8S5V1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.VmSizeEnum StandardK8SV1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.VmSizeEnum StandardNK12 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.VmSizeEnum StandardNK6 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.VmSizeEnum StandardNV12 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.VmSizeEnum StandardNV6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.VmSizeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.VmSizeEnum left, Azure.ResourceManager.Hci.Models.VmSizeEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.VmSizeEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.VmSizeEnum left, Azure.ResourceManager.Hci.Models.VmSizeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsServerSubscription : System.IEquatable<Azure.ResourceManager.Hci.Models.WindowsServerSubscription>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsServerSubscription(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.WindowsServerSubscription Disabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.WindowsServerSubscription Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.WindowsServerSubscription other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.WindowsServerSubscription left, Azure.ResourceManager.Hci.Models.WindowsServerSubscription right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.WindowsServerSubscription (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.WindowsServerSubscription left, Azure.ResourceManager.Hci.Models.WindowsServerSubscription right) { throw null; }
        public override string ToString() { throw null; }
    }
}
