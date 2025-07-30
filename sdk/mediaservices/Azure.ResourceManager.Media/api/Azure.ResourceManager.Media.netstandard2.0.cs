namespace Azure.ResourceManager.Media
{
    public partial class AzureResourceManagerMediaContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerMediaContext() { }
        public static Azure.ResourceManager.Media.AzureResourceManagerMediaContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ContentKeyPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.ContentKeyPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.ContentKeyPolicyResource>, System.Collections.IEnumerable
    {
        protected ContentKeyPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.ContentKeyPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string contentKeyPolicyName, Azure.ResourceManager.Media.ContentKeyPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.ContentKeyPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string contentKeyPolicyName, Azure.ResourceManager.Media.ContentKeyPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string contentKeyPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string contentKeyPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.ContentKeyPolicyResource> Get(string contentKeyPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.ContentKeyPolicyResource> GetAll(string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.ContentKeyPolicyResource> GetAllAsync(string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.ContentKeyPolicyResource>> GetAsync(string contentKeyPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Media.ContentKeyPolicyResource> GetIfExists(string contentKeyPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Media.ContentKeyPolicyResource>> GetIfExistsAsync(string contentKeyPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.ContentKeyPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.ContentKeyPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.ContentKeyPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.ContentKeyPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContentKeyPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.ContentKeyPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.ContentKeyPolicyData>
    {
        public ContentKeyPolicyData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.ContentKeyPolicyOption> Options { get { throw null; } }
        public System.Guid? PolicyId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.ContentKeyPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.ContentKeyPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.ContentKeyPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.ContentKeyPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.ContentKeyPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.ContentKeyPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.ContentKeyPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentKeyPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.ContentKeyPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.ContentKeyPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContentKeyPolicyResource() { }
        public virtual Azure.ResourceManager.Media.ContentKeyPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string contentKeyPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.ContentKeyPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.ContentKeyPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.Models.ContentKeyPolicyProperties> GetPolicyPropertiesWithSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.Models.ContentKeyPolicyProperties>> GetPolicyPropertiesWithSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Media.ContentKeyPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.ContentKeyPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.ContentKeyPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.ContentKeyPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.ContentKeyPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.ContentKeyPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.ContentKeyPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.ContentKeyPolicyResource> Update(Azure.ResourceManager.Media.ContentKeyPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.ContentKeyPolicyResource>> UpdateAsync(Azure.ResourceManager.Media.ContentKeyPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaAssetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaAssetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaAssetResource>, System.Collections.IEnumerable
    {
        protected MediaAssetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaAssetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assetName, Azure.ResourceManager.Media.MediaAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaAssetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assetName, Azure.ResourceManager.Media.MediaAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaAssetResource> Get(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.MediaAssetResource> GetAll(string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.MediaAssetResource> GetAllAsync(string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaAssetResource>> GetAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Media.MediaAssetResource> GetIfExists(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Media.MediaAssetResource>> GetIfExistsAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.MediaAssetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaAssetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.MediaAssetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaAssetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MediaAssetData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaAssetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetData>
    {
        public MediaAssetData() { }
        public string AlternateId { get { throw null; } set { } }
        public System.Guid? AssetId { get { throw null; } }
        public string Container { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string EncryptionScope { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string StorageAccountName { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.MediaAssetStorageEncryptionFormat? StorageEncryptionFormat { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaAssetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaAssetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaAssetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaAssetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaAssetFilterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaAssetFilterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaAssetFilterResource>, System.Collections.IEnumerable
    {
        protected MediaAssetFilterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaAssetFilterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string filterName, Azure.ResourceManager.Media.MediaAssetFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaAssetFilterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string filterName, Azure.ResourceManager.Media.MediaAssetFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaAssetFilterResource> Get(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.MediaAssetFilterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.MediaAssetFilterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaAssetFilterResource>> GetAsync(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Media.MediaAssetFilterResource> GetIfExists(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Media.MediaAssetFilterResource>> GetIfExistsAsync(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.MediaAssetFilterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaAssetFilterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.MediaAssetFilterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaAssetFilterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MediaAssetFilterData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaAssetFilterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetFilterData>
    {
        public MediaAssetFilterData() { }
        public int? FirstQualityBitrate { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.PresentationTimeRange PresentationTimeRange { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.FilterTrackSelection> Tracks { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaAssetFilterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaAssetFilterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaAssetFilterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaAssetFilterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetFilterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetFilterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetFilterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaAssetFilterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaAssetFilterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetFilterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaAssetFilterResource() { }
        public virtual Azure.ResourceManager.Media.MediaAssetFilterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string assetName, string filterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaAssetFilterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaAssetFilterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Media.MediaAssetFilterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaAssetFilterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaAssetFilterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaAssetFilterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetFilterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetFilterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetFilterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaAssetFilterResource> Update(Azure.ResourceManager.Media.MediaAssetFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaAssetFilterResource>> UpdateAsync(Azure.ResourceManager.Media.MediaAssetFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaAssetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaAssetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaAssetResource() { }
        public virtual Azure.ResourceManager.Media.MediaAssetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string assetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaAssetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaAssetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.Models.StorageEncryptedAssetDecryptionInfo> GetEncryptionKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.Models.StorageEncryptedAssetDecryptionInfo>> GetEncryptionKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaAssetFilterResource> GetMediaAssetFilter(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaAssetFilterResource>> GetMediaAssetFilterAsync(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaAssetFilterCollection GetMediaAssetFilters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaAssetTrackResource> GetMediaAssetTrack(string trackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaAssetTrackResource>> GetMediaAssetTrackAsync(string trackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaAssetTrackCollection GetMediaAssetTracks() { throw null; }
        public virtual Azure.Pageable<System.Uri> GetStorageContainerUris(Azure.ResourceManager.Media.Models.MediaAssetStorageContainerSasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.Uri> GetStorageContainerUrisAsync(Azure.ResourceManager.Media.Models.MediaAssetStorageContainerSasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.Models.MediaAssetStreamingLocator> GetStreamingLocators(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.Models.MediaAssetStreamingLocator> GetStreamingLocatorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Media.MediaAssetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaAssetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaAssetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaAssetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaAssetResource> Update(Azure.ResourceManager.Media.MediaAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaAssetResource>> UpdateAsync(Azure.ResourceManager.Media.MediaAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaAssetTrackCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaAssetTrackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaAssetTrackResource>, System.Collections.IEnumerable
    {
        protected MediaAssetTrackCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaAssetTrackResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string trackName, Azure.ResourceManager.Media.MediaAssetTrackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaAssetTrackResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string trackName, Azure.ResourceManager.Media.MediaAssetTrackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string trackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string trackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaAssetTrackResource> Get(string trackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.MediaAssetTrackResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.MediaAssetTrackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaAssetTrackResource>> GetAsync(string trackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Media.MediaAssetTrackResource> GetIfExists(string trackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Media.MediaAssetTrackResource>> GetIfExistsAsync(string trackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.MediaAssetTrackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaAssetTrackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.MediaAssetTrackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaAssetTrackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MediaAssetTrackData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaAssetTrackData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetTrackData>
    {
        public MediaAssetTrackData() { }
        public Azure.ResourceManager.Media.Models.MediaServicesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaAssetTrackBase Track { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaAssetTrackData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaAssetTrackData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaAssetTrackData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaAssetTrackData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetTrackData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetTrackData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetTrackData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaAssetTrackResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaAssetTrackData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetTrackData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaAssetTrackResource() { }
        public virtual Azure.ResourceManager.Media.MediaAssetTrackData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string assetName, string trackName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaAssetTrackResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaAssetTrackResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Media.MediaAssetTrackData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaAssetTrackData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaAssetTrackData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaAssetTrackData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetTrackData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetTrackData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaAssetTrackData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaAssetTrackResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.MediaAssetTrackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaAssetTrackResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.MediaAssetTrackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateTrackData(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateTrackDataAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MediaExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityResult> CheckMediaServicesNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityResult>> CheckMediaServicesNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Media.ContentKeyPolicyResource GetContentKeyPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.MediaAssetFilterResource GetMediaAssetFilterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.MediaAssetResource GetMediaAssetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.MediaAssetTrackResource GetMediaAssetTrackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.MediaJobResource GetMediaJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.MediaLiveEventResource GetMediaLiveEventResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.MediaLiveOutputResource GetMediaLiveOutputResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource> GetMediaServicesAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource>> GetMediaServicesAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Media.MediaServicesAccountFilterResource GetMediaServicesAccountFilterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.MediaServicesAccountResource GetMediaServicesAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.MediaServicesAccountCollection GetMediaServicesAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Media.MediaServicesAccountResource> GetMediaServicesAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Media.MediaServicesAccountResource> GetMediaServicesAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource GetMediaServicesPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.MediaServicesPrivateLinkResource GetMediaServicesPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.MediaTransformResource GetMediaTransformResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.StreamingEndpointResource GetStreamingEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.StreamingLocatorResource GetStreamingLocatorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.StreamingPolicyResource GetStreamingPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MediaJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaJobResource>, System.Collections.IEnumerable
    {
        protected MediaJobCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaJobResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string jobName, Azure.ResourceManager.Media.MediaJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaJobResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jobName, Azure.ResourceManager.Media.MediaJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaJobResource> Get(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.MediaJobResource> GetAll(string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.MediaJobResource> GetAllAsync(string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaJobResource>> GetAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Media.MediaJobResource> GetIfExists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Media.MediaJobResource>> GetIfExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.MediaJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.MediaJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MediaJobData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaJobData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaJobData>
    {
        public MediaJobData() { }
        public System.Collections.Generic.IDictionary<string, string> CorrelationData { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaJobInputBasicProperties Input { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaJobOutput> Outputs { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaJobPriority? Priority { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaJobState? State { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaJobData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaJobData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaJobData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaJobData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaJobData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaJobData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaJobData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaJobData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaJobData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaJobResource() { }
        public virtual Azure.ResourceManager.Media.MediaJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response CancelJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string transformName, string jobName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Media.MediaJobData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaJobData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaJobData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaJobData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaJobData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaJobData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaJobData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaJobResource> Update(Azure.ResourceManager.Media.MediaJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaJobResource>> UpdateAsync(Azure.ResourceManager.Media.MediaJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaLiveEventCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaLiveEventResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaLiveEventResource>, System.Collections.IEnumerable
    {
        protected MediaLiveEventCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaLiveEventResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string liveEventName, Azure.ResourceManager.Media.MediaLiveEventData data, bool? autoStart = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaLiveEventResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string liveEventName, Azure.ResourceManager.Media.MediaLiveEventData data, bool? autoStart = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string liveEventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string liveEventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaLiveEventResource> Get(string liveEventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.MediaLiveEventResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.MediaLiveEventResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaLiveEventResource>> GetAsync(string liveEventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Media.MediaLiveEventResource> GetIfExists(string liveEventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Media.MediaLiveEventResource>> GetIfExistsAsync(string liveEventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.MediaLiveEventResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaLiveEventResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.MediaLiveEventResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaLiveEventResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MediaLiveEventData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaLiveEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaLiveEventData>
    {
        public MediaLiveEventData(Azure.Core.AzureLocation location) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Media.Models.CrossSiteAccessPolicies CrossSiteAccessPolicies { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.LiveEventEncoding Encoding { get { throw null; } set { } }
        public string HostnamePrefix { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.LiveEventInput Input { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.Media.Models.LiveEventPreview Preview { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Media.Models.LiveEventResourceState? ResourceState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.StreamOptionsFlag> StreamOptions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.LiveEventTranscription> Transcriptions { get { throw null; } }
        public bool? UseStaticHostname { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaLiveEventData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaLiveEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaLiveEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaLiveEventData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaLiveEventData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaLiveEventData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaLiveEventData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaLiveEventResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaLiveEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaLiveEventData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaLiveEventResource() { }
        public virtual Azure.ResourceManager.Media.MediaLiveEventData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaLiveEventResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaLiveEventResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Allocate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AllocateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string liveEventName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaLiveEventResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaLiveEventResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaLiveOutputResource> GetMediaLiveOutput(string liveOutputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaLiveOutputResource>> GetMediaLiveOutputAsync(string liveOutputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaLiveOutputCollection GetMediaLiveOutputs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaLiveEventResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaLiveEventResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Reset(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResetAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaLiveEventResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaLiveEventResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.Models.LiveEventActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.Models.LiveEventActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Media.MediaLiveEventData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaLiveEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaLiveEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaLiveEventData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaLiveEventData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaLiveEventData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaLiveEventData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaLiveEventResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.MediaLiveEventData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaLiveEventResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.MediaLiveEventData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaLiveOutputCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaLiveOutputResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaLiveOutputResource>, System.Collections.IEnumerable
    {
        protected MediaLiveOutputCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaLiveOutputResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string liveOutputName, Azure.ResourceManager.Media.MediaLiveOutputData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaLiveOutputResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string liveOutputName, Azure.ResourceManager.Media.MediaLiveOutputData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string liveOutputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string liveOutputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaLiveOutputResource> Get(string liveOutputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.MediaLiveOutputResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.MediaLiveOutputResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaLiveOutputResource>> GetAsync(string liveOutputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Media.MediaLiveOutputResource> GetIfExists(string liveOutputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Media.MediaLiveOutputResource>> GetIfExistsAsync(string liveOutputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.MediaLiveOutputResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaLiveOutputResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.MediaLiveOutputResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaLiveOutputResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MediaLiveOutputData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaLiveOutputData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaLiveOutputData>
    {
        public MediaLiveOutputData() { }
        public System.TimeSpan? ArchiveWindowLength { get { throw null; } set { } }
        public string AssetName { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public int? HlsFragmentsPerTsSegment { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string ManifestName { get { throw null; } set { } }
        public long? OutputSnapTime { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Media.Models.LiveOutputResourceState? ResourceState { get { throw null; } }
        public System.TimeSpan? RewindWindowLength { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaLiveOutputData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaLiveOutputData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaLiveOutputData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaLiveOutputData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaLiveOutputData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaLiveOutputData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaLiveOutputData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaLiveOutputResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaLiveOutputData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaLiveOutputData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaLiveOutputResource() { }
        public virtual Azure.ResourceManager.Media.MediaLiveOutputData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string liveEventName, string liveOutputName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaLiveOutputResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaLiveOutputResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Media.MediaLiveOutputData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaLiveOutputData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaLiveOutputData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaLiveOutputData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaLiveOutputData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaLiveOutputData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaLiveOutputData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaLiveOutputResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.MediaLiveOutputData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaLiveOutputResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.MediaLiveOutputData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaServicesAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaServicesAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaServicesAccountResource>, System.Collections.IEnumerable
    {
        protected MediaServicesAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaServicesAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Media.MediaServicesAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaServicesAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Media.MediaServicesAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.MediaServicesAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.MediaServicesAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Media.MediaServicesAccountResource> GetIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Media.MediaServicesAccountResource>> GetIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.MediaServicesAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaServicesAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.MediaServicesAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaServicesAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MediaServicesAccountData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesAccountData>
    {
        public MediaServicesAccountData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Media.Models.AccountEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.MediaAccessControl KeyDeliveryAccessControl { get { throw null; } set { } }
        public System.Guid? MediaServicesAccountId { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaServicesMinimumTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaServicesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaServicesPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaServicesStorageAccount> StorageAccounts { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaStorageAuthentication? StorageAuthentication { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaServicesAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaServicesAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaServicesAccountFilterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaServicesAccountFilterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaServicesAccountFilterResource>, System.Collections.IEnumerable
    {
        protected MediaServicesAccountFilterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaServicesAccountFilterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string filterName, Azure.ResourceManager.Media.MediaServicesAccountFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaServicesAccountFilterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string filterName, Azure.ResourceManager.Media.MediaServicesAccountFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountFilterResource> Get(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.MediaServicesAccountFilterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.MediaServicesAccountFilterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountFilterResource>> GetAsync(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Media.MediaServicesAccountFilterResource> GetIfExists(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Media.MediaServicesAccountFilterResource>> GetIfExistsAsync(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.MediaServicesAccountFilterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaServicesAccountFilterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.MediaServicesAccountFilterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaServicesAccountFilterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MediaServicesAccountFilterData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesAccountFilterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesAccountFilterData>
    {
        public MediaServicesAccountFilterData() { }
        public int? FirstQualityBitrate { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.PresentationTimeRange PresentationTimeRange { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.FilterTrackSelection> Tracks { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaServicesAccountFilterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesAccountFilterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesAccountFilterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaServicesAccountFilterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesAccountFilterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesAccountFilterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesAccountFilterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaServicesAccountFilterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesAccountFilterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesAccountFilterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaServicesAccountFilterResource() { }
        public virtual Azure.ResourceManager.Media.MediaServicesAccountFilterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string filterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountFilterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountFilterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Media.MediaServicesAccountFilterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesAccountFilterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesAccountFilterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaServicesAccountFilterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesAccountFilterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesAccountFilterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesAccountFilterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountFilterResource> Update(Azure.ResourceManager.Media.MediaServicesAccountFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountFilterResource>> UpdateAsync(Azure.ResourceManager.Media.MediaServicesAccountFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaServicesAccountResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesAccountData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaServicesAccountResource() { }
        public virtual Azure.ResourceManager.Media.MediaServicesAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.ContentKeyPolicyCollection GetContentKeyPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.ContentKeyPolicyResource> GetContentKeyPolicy(string contentKeyPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.ContentKeyPolicyResource>> GetContentKeyPolicyAsync(string contentKeyPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.Models.MediaServicesEdgePolicies> GetEdgePolicies(Azure.ResourceManager.Media.Models.EdgePoliciesRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.Models.MediaServicesEdgePolicies>> GetEdgePoliciesAsync(Azure.ResourceManager.Media.Models.EdgePoliciesRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaAssetResource> GetMediaAsset(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaAssetResource>> GetMediaAssetAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaAssetCollection GetMediaAssets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaLiveEventResource> GetMediaLiveEvent(string liveEventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaLiveEventResource>> GetMediaLiveEventAsync(string liveEventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaLiveEventCollection GetMediaLiveEvents() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountFilterResource> GetMediaServicesAccountFilter(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountFilterResource>> GetMediaServicesAccountFilterAsync(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaServicesAccountFilterCollection GetMediaServicesAccountFilters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource> GetMediaServicesPrivateEndpointConnection(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource>> GetMediaServicesPrivateEndpointConnectionAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionCollection GetMediaServicesPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource> GetMediaServicesPrivateLinkResource(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource>> GetMediaServicesPrivateLinkResourceAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaServicesPrivateLinkResourceCollection GetMediaServicesPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaTransformResource> GetMediaTransform(string transformName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaTransformResource>> GetMediaTransformAsync(string transformName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaTransformCollection GetMediaTransforms() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource> GetStreamingEndpoint(string streamingEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource>> GetStreamingEndpointAsync(string streamingEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.StreamingEndpointCollection GetStreamingEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingLocatorResource> GetStreamingLocator(string streamingLocatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingLocatorResource>> GetStreamingLocatorAsync(string streamingLocatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.StreamingLocatorCollection GetStreamingLocators() { throw null; }
        public virtual Azure.ResourceManager.Media.StreamingPolicyCollection GetStreamingPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingPolicyResource> GetStreamingPolicy(string streamingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingPolicyResource>> GetStreamingPolicyAsync(string streamingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SyncStorageKeys(Azure.ResourceManager.Media.Models.SyncStorageKeysContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SyncStorageKeysAsync(Azure.ResourceManager.Media.Models.SyncStorageKeysContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Media.MediaServicesAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaServicesAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaServicesAccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.Models.MediaServicesAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaServicesAccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.Models.MediaServicesAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaServicesPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected MediaServicesPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MediaServicesPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData>
    {
        public MediaServicesPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Media.Models.MediaPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaServicesPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaServicesPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaServicesPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaServicesPrivateLinkResource() { }
        public virtual Azure.ResourceManager.Media.MediaServicesPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Media.MediaServicesPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaServicesPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaServicesPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected MediaServicesPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MediaServicesPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesPrivateLinkResourceData>
    {
        public MediaServicesPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaServicesPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaServicesPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaServicesPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaServicesPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaTransformCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaTransformResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaTransformResource>, System.Collections.IEnumerable
    {
        protected MediaTransformCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaTransformResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string transformName, Azure.ResourceManager.Media.MediaTransformData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaTransformResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string transformName, Azure.ResourceManager.Media.MediaTransformData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string transformName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string transformName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaTransformResource> Get(string transformName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.MediaTransformResource> GetAll(string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.MediaTransformResource> GetAllAsync(string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaTransformResource>> GetAsync(string transformName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Media.MediaTransformResource> GetIfExists(string transformName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Media.MediaTransformResource>> GetIfExistsAsync(string transformName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.MediaTransformResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaTransformResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.MediaTransformResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaTransformResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MediaTransformData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaTransformData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaTransformData>
    {
        public MediaTransformData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaTransformOutput> Outputs { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaTransformData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaTransformData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaTransformData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaTransformData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaTransformData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaTransformData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaTransformData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaTransformResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaTransformData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaTransformData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaTransformResource() { }
        public virtual Azure.ResourceManager.Media.MediaTransformData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string transformName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaTransformResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaTransformResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaJobResource> GetMediaJob(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaJobResource>> GetMediaJobAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaJobCollection GetMediaJobs() { throw null; }
        Azure.ResourceManager.Media.MediaTransformData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaTransformData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.MediaTransformData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.MediaTransformData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaTransformData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaTransformData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.MediaTransformData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaTransformResource> Update(Azure.ResourceManager.Media.MediaTransformData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaTransformResource>> UpdateAsync(Azure.ResourceManager.Media.MediaTransformData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StreamingEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.StreamingEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.StreamingEndpointResource>, System.Collections.IEnumerable
    {
        protected StreamingEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string streamingEndpointName, Azure.ResourceManager.Media.StreamingEndpointData data, bool? autoStart = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string streamingEndpointName, Azure.ResourceManager.Media.StreamingEndpointData data, bool? autoStart = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string streamingEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string streamingEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource> Get(string streamingEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.StreamingEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.StreamingEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource>> GetAsync(string streamingEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Media.StreamingEndpointResource> GetIfExists(string streamingEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Media.StreamingEndpointResource>> GetIfExistsAsync(string streamingEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.StreamingEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.StreamingEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.StreamingEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.StreamingEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StreamingEndpointData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.StreamingEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingEndpointData>
    {
        public StreamingEndpointData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Media.Models.StreamingEndpointAccessControl AccessControl { get { throw null; } set { } }
        public string AvailabilitySetName { get { throw null; } set { } }
        public string CdnProfile { get { throw null; } set { } }
        public string CdnProvider { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Media.Models.CrossSiteAccessPolicies CrossSiteAccessPolicies { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> CustomHostNames { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? FreeTrialEndOn { get { throw null; } }
        public string HostName { get { throw null; } }
        public bool? IsCdnEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public long? MaxCacheAge { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Media.Models.StreamingEndpointResourceState? ResourceState { get { throw null; } }
        public int? ScaleUnits { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.StreamingEndpointCurrentSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.StreamingEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.StreamingEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.StreamingEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.StreamingEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.StreamingEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingEndpointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StreamingEndpointResource() { }
        public virtual Azure.ResourceManager.Media.StreamingEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string streamingEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.Models.StreamingEndpointSkuInfo> GetSupportedSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.Models.StreamingEndpointSkuInfo> GetSupportedSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Scale(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.Models.StreamingEntityScaleUnit streamingEntityScaleUnit, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ScaleAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.Models.StreamingEntityScaleUnit streamingEntityScaleUnit, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Media.StreamingEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.StreamingEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.StreamingEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.StreamingEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.StreamingEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.StreamingEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StreamingLocatorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.StreamingLocatorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.StreamingLocatorResource>, System.Collections.IEnumerable
    {
        protected StreamingLocatorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingLocatorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string streamingLocatorName, Azure.ResourceManager.Media.StreamingLocatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingLocatorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string streamingLocatorName, Azure.ResourceManager.Media.StreamingLocatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string streamingLocatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string streamingLocatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingLocatorResource> Get(string streamingLocatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.StreamingLocatorResource> GetAll(string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.StreamingLocatorResource> GetAllAsync(string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingLocatorResource>> GetAsync(string streamingLocatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Media.StreamingLocatorResource> GetIfExists(string streamingLocatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Media.StreamingLocatorResource>> GetIfExistsAsync(string streamingLocatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.StreamingLocatorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.StreamingLocatorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.StreamingLocatorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.StreamingLocatorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StreamingLocatorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.StreamingLocatorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingLocatorData>
    {
        public StreamingLocatorData() { }
        public string AlternativeMediaId { get { throw null; } set { } }
        public string AssetName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.StreamingLocatorContentKey> ContentKeys { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DefaultContentKeyPolicyName { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Filters { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public System.Guid? StreamingLocatorId { get { throw null; } set { } }
        public string StreamingPolicyName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.StreamingLocatorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.StreamingLocatorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.StreamingLocatorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.StreamingLocatorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingLocatorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingLocatorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingLocatorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingLocatorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.StreamingLocatorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingLocatorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StreamingLocatorResource() { }
        public virtual Azure.ResourceManager.Media.StreamingLocatorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string streamingLocatorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingLocatorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingLocatorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.Models.StreamingLocatorContentKey> GetContentKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.Models.StreamingLocatorContentKey> GetContentKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.Models.StreamingPathsResult> GetStreamingPaths(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.Models.StreamingPathsResult>> GetStreamingPathsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Media.StreamingLocatorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.StreamingLocatorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.StreamingLocatorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.StreamingLocatorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingLocatorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingLocatorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingLocatorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingLocatorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.StreamingLocatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingLocatorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.StreamingLocatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StreamingPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.StreamingPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.StreamingPolicyResource>, System.Collections.IEnumerable
    {
        protected StreamingPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string streamingPolicyName, Azure.ResourceManager.Media.StreamingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string streamingPolicyName, Azure.ResourceManager.Media.StreamingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string streamingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string streamingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingPolicyResource> Get(string streamingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.StreamingPolicyResource> GetAll(string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.StreamingPolicyResource> GetAllAsync(string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingPolicyResource>> GetAsync(string streamingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Media.StreamingPolicyResource> GetIfExists(string streamingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Media.StreamingPolicyResource>> GetIfExistsAsync(string streamingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.StreamingPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.StreamingPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.StreamingPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.StreamingPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StreamingPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.StreamingPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingPolicyData>
    {
        public StreamingPolicyData() { }
        public Azure.ResourceManager.Media.Models.CommonEncryptionCbcs CommonEncryptionCbcs { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.CommonEncryptionCenc CommonEncryptionCenc { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DefaultContentKeyPolicyName { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.EnvelopeEncryption EnvelopeEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.MediaEnabledProtocols NoEncryptionEnabledProtocols { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.StreamingPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.StreamingPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.StreamingPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.StreamingPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.StreamingPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StreamingPolicyResource() { }
        public virtual Azure.ResourceManager.Media.StreamingPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string streamingPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Media.StreamingPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.StreamingPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.StreamingPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.StreamingPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.StreamingPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.StreamingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.StreamingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Media.Mocking
{
    public partial class MockableMediaArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMediaArmClient() { }
        public virtual Azure.ResourceManager.Media.ContentKeyPolicyResource GetContentKeyPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaAssetFilterResource GetMediaAssetFilterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaAssetResource GetMediaAssetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaAssetTrackResource GetMediaAssetTrackResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaJobResource GetMediaJobResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaLiveEventResource GetMediaLiveEventResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaLiveOutputResource GetMediaLiveOutputResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaServicesAccountFilterResource GetMediaServicesAccountFilterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaServicesAccountResource GetMediaServicesAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource GetMediaServicesPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaServicesPrivateLinkResource GetMediaServicesPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaTransformResource GetMediaTransformResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Media.StreamingEndpointResource GetStreamingEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Media.StreamingLocatorResource GetStreamingLocatorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Media.StreamingPolicyResource GetStreamingPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMediaResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMediaResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource> GetMediaServicesAccount(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource>> GetMediaServicesAccountAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaServicesAccountCollection GetMediaServicesAccounts() { throw null; }
    }
    public partial class MockableMediaSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMediaSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityResult> CheckMediaServicesNameAvailability(Azure.Core.AzureLocation locationName, Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityResult>> CheckMediaServicesNameAvailabilityAsync(Azure.Core.AzureLocation locationName, Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.MediaServicesAccountResource> GetMediaServicesAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.MediaServicesAccountResource> GetMediaServicesAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Media.Models
{
    public partial class AacAudio : Azure.ResourceManager.Media.Models.MediaAudioBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AacAudio>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AacAudio>
    {
        public AacAudio() { }
        public Azure.ResourceManager.Media.Models.AacAudioProfile? Profile { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.AacAudio System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AacAudio>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AacAudio>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.AacAudio System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AacAudio>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AacAudio>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AacAudio>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AacAudioProfile : System.IEquatable<Azure.ResourceManager.Media.Models.AacAudioProfile>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AacAudioProfile(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.AacAudioProfile AacLc { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.AacAudioProfile HEAacV1 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.AacAudioProfile HEAacV2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.AacAudioProfile other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.AacAudioProfile left, Azure.ResourceManager.Media.Models.AacAudioProfile right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.AacAudioProfile (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.AacAudioProfile left, Azure.ResourceManager.Media.Models.AacAudioProfile right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AbsoluteClipTime : Azure.ResourceManager.Media.Models.ClipTime, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AbsoluteClipTime>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AbsoluteClipTime>
    {
        public AbsoluteClipTime(System.TimeSpan time) { }
        public System.TimeSpan Time { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.AbsoluteClipTime System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AbsoluteClipTime>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AbsoluteClipTime>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.AbsoluteClipTime System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AbsoluteClipTime>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AbsoluteClipTime>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AbsoluteClipTime>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccountEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AccountEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AccountEncryption>
    {
        public AccountEncryption(Azure.ResourceManager.Media.Models.AccountEncryptionKeyType keyType) { }
        public Azure.ResourceManager.Media.Models.ResourceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.AccountEncryptionKeyType KeyType { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.AccountEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AccountEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AccountEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.AccountEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AccountEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AccountEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AccountEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccountEncryptionKeyType : System.IEquatable<Azure.ResourceManager.Media.Models.AccountEncryptionKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccountEncryptionKeyType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.AccountEncryptionKeyType CustomerKey { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.AccountEncryptionKeyType SystemKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.AccountEncryptionKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.AccountEncryptionKeyType left, Azure.ResourceManager.Media.Models.AccountEncryptionKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.AccountEncryptionKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.AccountEncryptionKeyType left, Azure.ResourceManager.Media.Models.AccountEncryptionKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AkamaiSignatureHeaderAuthenticationKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AkamaiSignatureHeaderAuthenticationKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AkamaiSignatureHeaderAuthenticationKey>
    {
        public AkamaiSignatureHeaderAuthenticationKey() { }
        public string Base64Key { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.AkamaiSignatureHeaderAuthenticationKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AkamaiSignatureHeaderAuthenticationKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AkamaiSignatureHeaderAuthenticationKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.AkamaiSignatureHeaderAuthenticationKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AkamaiSignatureHeaderAuthenticationKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AkamaiSignatureHeaderAuthenticationKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AkamaiSignatureHeaderAuthenticationKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmMediaModelFactory
    {
        public static Azure.ResourceManager.Media.Models.AccountEncryption AccountEncryption(Azure.ResourceManager.Media.Models.AccountEncryptionKeyType keyType = default(Azure.ResourceManager.Media.Models.AccountEncryptionKeyType), Azure.ResourceManager.Media.Models.KeyVaultProperties keyVaultProperties = null, Azure.ResourceManager.Media.Models.ResourceIdentity identity = null, string status = null) { throw null; }
        public static Azure.ResourceManager.Media.Models.AudioTrack AudioTrack(string fileName = null, string displayName = null, string languageCode = null, Azure.ResourceManager.Media.Models.HlsSettings hlsSettings = null, string dashRole = null, int? mpeg4TrackId = default(int?), int? bitRate = default(int?)) { throw null; }
        public static Azure.ResourceManager.Media.ContentKeyPolicyData ContentKeyPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? policyId = default(System.Guid?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.ContentKeyPolicyOption> options = null) { throw null; }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyOption ContentKeyPolicyOption(System.Guid? policyOptionId = default(System.Guid?), string name = null, Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration configuration = null, Azure.ResourceManager.Media.Models.ContentKeyPolicyRestriction restriction = null) { throw null; }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyProperties ContentKeyPolicyProperties(System.Guid? policyId = default(System.Guid?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.ContentKeyPolicyOption> options = null) { throw null; }
        public static Azure.ResourceManager.Media.Models.EdgeUsageDataCollectionPolicy EdgeUsageDataCollectionPolicy(string dataCollectionFrequency = null, string dataReportingFrequency = null, System.TimeSpan? maxAllowedUnreportedUsageDuration = default(System.TimeSpan?), Azure.ResourceManager.Media.Models.EdgeUsageDataEventHub eventHubDetails = null) { throw null; }
        public static Azure.ResourceManager.Media.Models.EdgeUsageDataEventHub EdgeUsageDataEventHub(string name = null, string @namespace = null, string token = null) { throw null; }
        public static Azure.ResourceManager.Media.Models.KeyVaultProperties KeyVaultProperties(string keyIdentifier = null, string currentKeyIdentifier = null) { throw null; }
        public static Azure.ResourceManager.Media.MediaAssetData MediaAssetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? assetId = default(System.Guid?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string alternateId = null, string description = null, string container = null, string storageAccountName = null, Azure.ResourceManager.Media.Models.MediaAssetStorageEncryptionFormat? storageEncryptionFormat = default(Azure.ResourceManager.Media.Models.MediaAssetStorageEncryptionFormat?), string encryptionScope = null) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaAssetFileEncryptionMetadata MediaAssetFileEncryptionMetadata(string initializationVector = null, string assetFileName = null, System.Guid assetFileId = default(System.Guid)) { throw null; }
        public static Azure.ResourceManager.Media.MediaAssetFilterData MediaAssetFilterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Media.Models.PresentationTimeRange presentationTimeRange = null, int? firstQualityBitrate = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.FilterTrackSelection> tracks = null) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaAssetStreamingLocator MediaAssetStreamingLocator(string name = null, string assetName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Guid? streamingLocatorId = default(System.Guid?), string streamingPolicyName = null, string defaultContentKeyPolicyName = null) { throw null; }
        public static Azure.ResourceManager.Media.MediaAssetTrackData MediaAssetTrackData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Media.Models.MediaAssetTrackBase track = null, Azure.ResourceManager.Media.Models.MediaServicesProvisioningState? provisioningState = default(Azure.ResourceManager.Media.Models.MediaServicesProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Media.MediaJobData MediaJobData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.Media.Models.MediaJobState? state = default(Azure.ResourceManager.Media.Models.MediaJobState?), string description = null, Azure.ResourceManager.Media.Models.MediaJobInputBasicProperties input = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.MediaJobOutput> outputs = null, Azure.ResourceManager.Media.Models.MediaJobPriority? priority = default(Azure.ResourceManager.Media.Models.MediaJobPriority?), System.Collections.Generic.IDictionary<string, string> correlationData = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaJobError MediaJobError(Azure.ResourceManager.Media.Models.MediaJobErrorCode? code = default(Azure.ResourceManager.Media.Models.MediaJobErrorCode?), string message = null, Azure.ResourceManager.Media.Models.MediaJobErrorCategory? category = default(Azure.ResourceManager.Media.Models.MediaJobErrorCategory?), Azure.ResourceManager.Media.Models.MediaJobRetry? retry = default(Azure.ResourceManager.Media.Models.MediaJobRetry?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.MediaJobErrorDetail> details = null) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaJobErrorDetail MediaJobErrorDetail(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaJobOutput MediaJobOutput(string odataType = null, Azure.ResourceManager.Media.Models.MediaJobError error = null, Azure.ResourceManager.Media.Models.MediaTransformPreset presetOverride = null, Azure.ResourceManager.Media.Models.MediaJobState? state = default(Azure.ResourceManager.Media.Models.MediaJobState?), int? progress = default(int?), string label = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaJobOutputAsset MediaJobOutputAsset(Azure.ResourceManager.Media.Models.MediaJobError error = null, Azure.ResourceManager.Media.Models.MediaTransformPreset presetOverride = null, Azure.ResourceManager.Media.Models.MediaJobState? state = default(Azure.ResourceManager.Media.Models.MediaJobState?), int? progress = default(int?), string label = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string assetName = null) { throw null; }
        public static Azure.ResourceManager.Media.MediaLiveEventData MediaLiveEventData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string description = null, Azure.ResourceManager.Media.Models.LiveEventInput input = null, Azure.ResourceManager.Media.Models.LiveEventPreview preview = null, Azure.ResourceManager.Media.Models.LiveEventEncoding encoding = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.LiveEventTranscription> transcriptions = null, string provisioningState = null, Azure.ResourceManager.Media.Models.LiveEventResourceState? resourceState = default(Azure.ResourceManager.Media.Models.LiveEventResourceState?), Azure.ResourceManager.Media.Models.CrossSiteAccessPolicies crossSiteAccessPolicies = null, bool? useStaticHostname = default(bool?), string hostnamePrefix = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.StreamOptionsFlag> streamOptions = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Media.MediaLiveOutputData MediaLiveOutputData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, string assetName = null, System.TimeSpan? archiveWindowLength = default(System.TimeSpan?), System.TimeSpan? rewindWindowLength = default(System.TimeSpan?), string manifestName = null, int? hlsFragmentsPerTsSegment = default(int?), long? outputSnapTime = default(long?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string provisioningState = null, Azure.ResourceManager.Media.Models.LiveOutputResourceState? resourceState = default(Azure.ResourceManager.Media.Models.LiveOutputResourceState?)) { throw null; }
        public static Azure.ResourceManager.Media.MediaServicesAccountData MediaServicesAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Guid? mediaServicesAccountId = default(System.Guid?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.MediaServicesStorageAccount> storageAccounts = null, Azure.ResourceManager.Media.Models.MediaStorageAuthentication? storageAuthentication = default(Azure.ResourceManager.Media.Models.MediaStorageAuthentication?), Azure.ResourceManager.Media.Models.AccountEncryption encryption = null, Azure.ResourceManager.Media.Models.MediaAccessControl keyDeliveryAccessControl = null, Azure.ResourceManager.Media.Models.MediaServicesPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Media.Models.MediaServicesPublicNetworkAccess?), Azure.ResourceManager.Media.Models.MediaServicesProvisioningState? provisioningState = default(Azure.ResourceManager.Media.Models.MediaServicesProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Media.Models.MediaServicesMinimumTlsVersion? minimumTlsVersion = default(Azure.ResourceManager.Media.Models.MediaServicesMinimumTlsVersion?)) { throw null; }
        public static Azure.ResourceManager.Media.MediaServicesAccountFilterData MediaServicesAccountFilterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Media.Models.PresentationTimeRange presentationTimeRange = null, int? firstQualityBitrate = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.FilterTrackSelection> tracks = null) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaServicesAccountPatch MediaServicesAccountPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Guid? mediaServiceId = default(System.Guid?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.MediaServicesStorageAccount> storageAccounts = null, Azure.ResourceManager.Media.Models.MediaStorageAuthentication? storageAuthentication = default(Azure.ResourceManager.Media.Models.MediaStorageAuthentication?), Azure.ResourceManager.Media.Models.AccountEncryption encryption = null, Azure.ResourceManager.Media.Models.MediaAccessControl keyDeliveryAccessControl = null, Azure.ResourceManager.Media.Models.MediaServicesPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Media.Models.MediaServicesPublicNetworkAccess?), Azure.ResourceManager.Media.Models.MediaServicesProvisioningState? provisioningState = default(Azure.ResourceManager.Media.Models.MediaServicesProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Media.Models.MediaServicesMinimumTlsVersion? minimumTlsVersion = default(Azure.ResourceManager.Media.Models.MediaServicesMinimumTlsVersion?)) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaServicesEdgePolicies MediaServicesEdgePolicies(Azure.ResourceManager.Media.Models.EdgeUsageDataCollectionPolicy usageDataCollectionPolicy = null) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityResult MediaServicesNameAvailabilityResult(bool isNameAvailable = false, string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData MediaServicesPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.Media.Models.MediaPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Media.MediaServicesPrivateLinkResourceData MediaServicesPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaServicesStorageAccount MediaServicesStorageAccount(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType accountType = default(Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType), Azure.ResourceManager.Media.Models.ResourceIdentity identity = null, string status = null) { throw null; }
        public static Azure.ResourceManager.Media.MediaTransformData MediaTransformData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string description = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.MediaTransformOutput> outputs = null) { throw null; }
        public static Azure.ResourceManager.Media.Models.StorageEncryptedAssetDecryptionInfo StorageEncryptedAssetDecryptionInfo(byte[] key = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.MediaAssetFileEncryptionMetadata> assetFileEncryptionMetadata = null) { throw null; }
        public static Azure.ResourceManager.Media.Models.StreamingEndpointCapacity StreamingEndpointCapacity(string scaleType = null, int? @default = default(int?), int? minimum = default(int?), int? maximum = default(int?)) { throw null; }
        public static Azure.ResourceManager.Media.Models.StreamingEndpointCurrentSku StreamingEndpointCurrentSku(string name = null, int? capacity = default(int?)) { throw null; }
        public static Azure.ResourceManager.Media.StreamingEndpointData StreamingEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Media.Models.StreamingEndpointCurrentSku sku = null, string description = null, int? scaleUnits = default(int?), string availabilitySetName = null, Azure.ResourceManager.Media.Models.StreamingEndpointAccessControl accessControl = null, long? maxCacheAge = default(long?), System.Collections.Generic.IEnumerable<string> customHostNames = null, string hostName = null, bool? isCdnEnabled = default(bool?), string cdnProvider = null, string cdnProfile = null, string provisioningState = null, Azure.ResourceManager.Media.Models.StreamingEndpointResourceState? resourceState = default(Azure.ResourceManager.Media.Models.StreamingEndpointResourceState?), Azure.ResourceManager.Media.Models.CrossSiteAccessPolicies crossSiteAccessPolicies = null, System.DateTimeOffset? freeTrialEndOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Media.Models.StreamingEndpointSkuInfo StreamingEndpointSkuInfo(Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), Azure.ResourceManager.Media.Models.StreamingEndpointCapacity capacity = null, string skuName = null) { throw null; }
        public static Azure.ResourceManager.Media.Models.StreamingLocatorContentKey StreamingLocatorContentKey(System.Guid id = default(System.Guid), Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType? keyType = default(Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType?), string labelReferenceInStreamingPolicy = null, string value = null, string policyName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.MediaTrackSelection> tracks = null) { throw null; }
        public static Azure.ResourceManager.Media.StreamingLocatorData StreamingLocatorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string assetName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Guid? streamingLocatorId = default(System.Guid?), string streamingPolicyName = null, string defaultContentKeyPolicyName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.StreamingLocatorContentKey> contentKeys = null, string alternativeMediaId = null, System.Collections.Generic.IEnumerable<string> filters = null) { throw null; }
        public static Azure.ResourceManager.Media.Models.StreamingPath StreamingPath(Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol streamingProtocol = default(Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol), Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme encryptionScheme = default(Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme), System.Collections.Generic.IEnumerable<string> paths = null) { throw null; }
        public static Azure.ResourceManager.Media.Models.StreamingPathsResult StreamingPathsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.StreamingPath> streamingPaths = null, System.Collections.Generic.IEnumerable<string> downloadPaths = null) { throw null; }
        public static Azure.ResourceManager.Media.StreamingPolicyData StreamingPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string defaultContentKeyPolicyName = null, Azure.ResourceManager.Media.Models.EnvelopeEncryption envelopeEncryption = null, Azure.ResourceManager.Media.Models.CommonEncryptionCenc commonEncryptionCenc = null, Azure.ResourceManager.Media.Models.CommonEncryptionCbcs commonEncryptionCbcs = null, Azure.ResourceManager.Media.Models.MediaEnabledProtocols noEncryptionEnabledProtocols = null) { throw null; }
        public static Azure.ResourceManager.Media.Models.TextTrack TextTrack(string fileName = null, string displayName = null, string languageCode = null, Azure.ResourceManager.Media.Models.PlayerVisibility? playerVisibility = default(Azure.ResourceManager.Media.Models.PlayerVisibility?), Azure.ResourceManager.Media.Models.HlsSettings hlsSettings = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AudioAnalysisMode : System.IEquatable<Azure.ResourceManager.Media.Models.AudioAnalysisMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AudioAnalysisMode(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.AudioAnalysisMode Basic { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.AudioAnalysisMode Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.AudioAnalysisMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.AudioAnalysisMode left, Azure.ResourceManager.Media.Models.AudioAnalysisMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.AudioAnalysisMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.AudioAnalysisMode left, Azure.ResourceManager.Media.Models.AudioAnalysisMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AudioAnalyzerPreset : Azure.ResourceManager.Media.Models.MediaTransformPreset, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AudioAnalyzerPreset>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AudioAnalyzerPreset>
    {
        public AudioAnalyzerPreset() { }
        public string AudioLanguage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ExperimentalOptions { get { throw null; } }
        public Azure.ResourceManager.Media.Models.AudioAnalysisMode? Mode { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.AudioAnalyzerPreset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AudioAnalyzerPreset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AudioAnalyzerPreset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.AudioAnalyzerPreset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AudioAnalyzerPreset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AudioAnalyzerPreset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AudioAnalyzerPreset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AudioOverlay : Azure.ResourceManager.Media.Models.MediaOverlayBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AudioOverlay>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AudioOverlay>
    {
        public AudioOverlay(string inputLabel) : base (default(string)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.AudioOverlay System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AudioOverlay>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AudioOverlay>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.AudioOverlay System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AudioOverlay>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AudioOverlay>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AudioOverlay>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AudioTrack : Azure.ResourceManager.Media.Models.MediaAssetTrackBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AudioTrack>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AudioTrack>
    {
        public AudioTrack() { }
        public int? BitRate { get { throw null; } }
        public string DashRole { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.HlsSettings HlsSettings { get { throw null; } set { } }
        public string LanguageCode { get { throw null; } set { } }
        public int? Mpeg4TrackId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.AudioTrack System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AudioTrack>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AudioTrack>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.AudioTrack System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AudioTrack>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AudioTrack>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AudioTrack>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AudioTrackDescriptor : Azure.ResourceManager.Media.Models.TrackDescriptor, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AudioTrackDescriptor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AudioTrackDescriptor>
    {
        public AudioTrackDescriptor() { }
        public Azure.ResourceManager.Media.Models.ChannelMapping? ChannelMapping { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.AudioTrackDescriptor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AudioTrackDescriptor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.AudioTrackDescriptor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.AudioTrackDescriptor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AudioTrackDescriptor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AudioTrackDescriptor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.AudioTrackDescriptor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BuiltInStandardEncoderPreset : Azure.ResourceManager.Media.Models.MediaTransformPreset, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.BuiltInStandardEncoderPreset>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.BuiltInStandardEncoderPreset>
    {
        public BuiltInStandardEncoderPreset(Azure.ResourceManager.Media.Models.EncoderNamedPreset presetName) { }
        public Azure.ResourceManager.Media.Models.EncoderPresetConfigurations Configurations { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.EncoderNamedPreset PresetName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.BuiltInStandardEncoderPreset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.BuiltInStandardEncoderPreset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.BuiltInStandardEncoderPreset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.BuiltInStandardEncoderPreset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.BuiltInStandardEncoderPreset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.BuiltInStandardEncoderPreset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.BuiltInStandardEncoderPreset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CbcsDrmConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.CbcsDrmConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CbcsDrmConfiguration>
    {
        public CbcsDrmConfiguration() { }
        public Azure.ResourceManager.Media.Models.StreamingPolicyFairPlayConfiguration FairPlay { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.StreamingPolicyPlayReadyConfiguration PlayReady { get { throw null; } set { } }
        public string WidevineCustomLicenseAcquisitionUriTemplate { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.CbcsDrmConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.CbcsDrmConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.CbcsDrmConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.CbcsDrmConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CbcsDrmConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CbcsDrmConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CbcsDrmConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CencDrmConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.CencDrmConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CencDrmConfiguration>
    {
        public CencDrmConfiguration() { }
        public Azure.ResourceManager.Media.Models.StreamingPolicyPlayReadyConfiguration PlayReady { get { throw null; } set { } }
        public string WidevineCustomLicenseAcquisitionUriTemplate { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.CencDrmConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.CencDrmConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.CencDrmConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.CencDrmConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CencDrmConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CencDrmConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CencDrmConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChannelMapping : System.IEquatable<Azure.ResourceManager.Media.Models.ChannelMapping>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChannelMapping(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.ChannelMapping BackLeft { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ChannelMapping BackRight { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ChannelMapping Center { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ChannelMapping FrontLeft { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ChannelMapping FrontRight { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ChannelMapping LowFrequencyEffects { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ChannelMapping StereoLeft { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ChannelMapping StereoRight { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.ChannelMapping other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.ChannelMapping left, Azure.ResourceManager.Media.Models.ChannelMapping right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.ChannelMapping (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.ChannelMapping left, Azure.ResourceManager.Media.Models.ChannelMapping right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ClipTime : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ClipTime>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ClipTime>
    {
        protected ClipTime() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ClipTime System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ClipTime>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ClipTime>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ClipTime System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ClipTime>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ClipTime>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ClipTime>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodecCopyAudio : Azure.ResourceManager.Media.Models.MediaCodecBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.CodecCopyAudio>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CodecCopyAudio>
    {
        public CodecCopyAudio() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.CodecCopyAudio System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.CodecCopyAudio>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.CodecCopyAudio>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.CodecCopyAudio System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CodecCopyAudio>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CodecCopyAudio>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CodecCopyAudio>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodecCopyVideo : Azure.ResourceManager.Media.Models.MediaCodecBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.CodecCopyVideo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CodecCopyVideo>
    {
        public CodecCopyVideo() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.CodecCopyVideo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.CodecCopyVideo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.CodecCopyVideo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.CodecCopyVideo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CodecCopyVideo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CodecCopyVideo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CodecCopyVideo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommonEncryptionCbcs : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.CommonEncryptionCbcs>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CommonEncryptionCbcs>
    {
        public CommonEncryptionCbcs() { }
        public string ClearKeyEncryptionCustomKeysAcquisitionUriTemplate { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaTrackSelection> ClearTracks { get { throw null; } }
        public Azure.ResourceManager.Media.Models.StreamingPolicyContentKeys ContentKeys { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.CbcsDrmConfiguration Drm { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.MediaEnabledProtocols EnabledProtocols { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.CommonEncryptionCbcs System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.CommonEncryptionCbcs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.CommonEncryptionCbcs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.CommonEncryptionCbcs System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CommonEncryptionCbcs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CommonEncryptionCbcs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CommonEncryptionCbcs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommonEncryptionCenc : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.CommonEncryptionCenc>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CommonEncryptionCenc>
    {
        public CommonEncryptionCenc() { }
        public string ClearKeyEncryptionCustomKeysAcquisitionUriTemplate { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaTrackSelection> ClearTracks { get { throw null; } }
        public Azure.ResourceManager.Media.Models.StreamingPolicyContentKeys ContentKeys { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.CencDrmConfiguration Drm { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.MediaEnabledProtocols EnabledProtocols { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.CommonEncryptionCenc System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.CommonEncryptionCenc>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.CommonEncryptionCenc>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.CommonEncryptionCenc System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CommonEncryptionCenc>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CommonEncryptionCenc>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CommonEncryptionCenc>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentKeyPolicyClearKeyConfiguration : Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyClearKeyConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyClearKeyConfiguration>
    {
        public ContentKeyPolicyClearKeyConfiguration() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyClearKeyConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyClearKeyConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyClearKeyConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyClearKeyConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyClearKeyConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyClearKeyConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyClearKeyConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ContentKeyPolicyConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration>
    {
        protected ContentKeyPolicyConfiguration() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentKeyPolicyFairPlayConfiguration : Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayConfiguration>
    {
        public ContentKeyPolicyFairPlayConfiguration(byte[] applicationSecretKey, string fairPlayPfxPassword, string fairPlayPfx, Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType rentalAndLeaseKeyType, long rentalDuration) { }
        public byte[] ApplicationSecretKey { get { throw null; } set { } }
        public string FairPlayPfx { get { throw null; } set { } }
        public string FairPlayPfxPassword { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayOfflineRentalConfiguration OfflineRentalConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType RentalAndLeaseKeyType { get { throw null; } set { } }
        public long RentalDuration { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentKeyPolicyFairPlayOfflineRentalConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayOfflineRentalConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayOfflineRentalConfiguration>
    {
        public ContentKeyPolicyFairPlayOfflineRentalConfiguration(long playbackDurationInSeconds, long storageDurationInSeconds) { }
        public long PlaybackDurationInSeconds { get { throw null; } set { } }
        public long StorageDurationInSeconds { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayOfflineRentalConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayOfflineRentalConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayOfflineRentalConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayOfflineRentalConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayOfflineRentalConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayOfflineRentalConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayOfflineRentalConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentKeyPolicyFairPlayRentalAndLeaseKeyType : System.IEquatable<Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentKeyPolicyFairPlayRentalAndLeaseKeyType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType DualExpiry { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType PersistentLimited { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType PersistentUnlimited { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType Undefined { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType left, Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType left, Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContentKeyPolicyOpenRestriction : Azure.ResourceManager.Media.Models.ContentKeyPolicyRestriction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyOpenRestriction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyOpenRestriction>
    {
        public ContentKeyPolicyOpenRestriction() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyOpenRestriction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyOpenRestriction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyOpenRestriction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyOpenRestriction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyOpenRestriction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyOpenRestriction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyOpenRestriction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentKeyPolicyOption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyOption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyOption>
    {
        public ContentKeyPolicyOption(Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration configuration, Azure.ResourceManager.Media.Models.ContentKeyPolicyRestriction restriction) { }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration Configuration { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Guid? PolicyOptionId { get { throw null; } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyRestriction Restriction { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyOption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyOption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyOption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyOption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyOption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyOption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyOption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentKeyPolicyPlayReadyConfiguration : Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyConfiguration>
    {
        public ContentKeyPolicyPlayReadyConfiguration(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicense> licenses) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicense> Licenses { get { throw null; } }
        public System.BinaryData ResponseCustomData { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentKeyPolicyPlayReadyContentEncryptionKeyFromHeader : Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentKeyLocation, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentEncryptionKeyFromHeader>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentEncryptionKeyFromHeader>
    {
        public ContentKeyPolicyPlayReadyContentEncryptionKeyFromHeader() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentEncryptionKeyFromHeader System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentEncryptionKeyFromHeader>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentEncryptionKeyFromHeader>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentEncryptionKeyFromHeader System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentEncryptionKeyFromHeader>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentEncryptionKeyFromHeader>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentEncryptionKeyFromHeader>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentKeyPolicyPlayReadyContentEncryptionKeyFromKeyIdentifier : Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentKeyLocation, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentEncryptionKeyFromKeyIdentifier>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentEncryptionKeyFromKeyIdentifier>
    {
        public ContentKeyPolicyPlayReadyContentEncryptionKeyFromKeyIdentifier(System.Guid? keyId) { }
        public System.Guid? KeyId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentEncryptionKeyFromKeyIdentifier System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentEncryptionKeyFromKeyIdentifier>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentEncryptionKeyFromKeyIdentifier>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentEncryptionKeyFromKeyIdentifier System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentEncryptionKeyFromKeyIdentifier>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentEncryptionKeyFromKeyIdentifier>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentEncryptionKeyFromKeyIdentifier>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ContentKeyPolicyPlayReadyContentKeyLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentKeyLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentKeyLocation>
    {
        protected ContentKeyPolicyPlayReadyContentKeyLocation() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentKeyLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentKeyLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentKeyLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentKeyLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentKeyLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentKeyLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentKeyLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentKeyPolicyPlayReadyContentType : System.IEquatable<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentKeyPolicyPlayReadyContentType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType UltraVioletDownload { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType UltraVioletStreaming { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType Unknown { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType Unspecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType left, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType left, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestriction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestriction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestriction>
    {
        public ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestriction(bool isBestEffort, int configurationData) { }
        public int ConfigurationData { get { throw null; } set { } }
        public bool IsBestEffort { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestriction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestriction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestriction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestriction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestriction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestriction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestriction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentKeyPolicyPlayReadyLicense : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicense>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicense>
    {
        public ContentKeyPolicyPlayReadyLicense(bool allowTestDevices, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType licenseType, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentKeyLocation contentKeyLocation, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType contentType) { }
        public bool AllowTestDevices { get { throw null; } set { } }
        public System.DateTimeOffset? BeginOn { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentKeyLocation ContentKeyLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType ContentType { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public System.TimeSpan? GracePeriod { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyPlayRight PlayRight { get { throw null; } set { } }
        public System.TimeSpan? RelativeBeginDate { get { throw null; } set { } }
        public System.TimeSpan? RelativeExpirationDate { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.PlayReadySecurityLevel? SecurityLevel { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicense System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicense>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicense>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicense System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicense>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicense>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicense>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentKeyPolicyPlayReadyLicenseType : System.IEquatable<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentKeyPolicyPlayReadyLicenseType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType NonPersistent { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType Persistent { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType left, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType left, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContentKeyPolicyPlayReadyPlayRight : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyPlayRight>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyPlayRight>
    {
        public ContentKeyPolicyPlayReadyPlayRight(bool hasDigitalVideoOnlyContentRestriction, bool hasImageConstraintForAnalogComponentVideoRestriction, bool hasImageConstraintForAnalogComputerMonitorRestriction, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption allowPassingVideoContentToUnknownOutput) { }
        public int? AgcAndColorStripeRestriction { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption AllowPassingVideoContentToUnknownOutput { get { throw null; } set { } }
        public int? AnalogVideoOutputProtectionLevel { get { throw null; } set { } }
        public int? CompressedDigitalAudioOutputProtectionLevel { get { throw null; } set { } }
        public int? CompressedDigitalVideoOutputProtectionLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestriction ExplicitAnalogTelevisionOutputRestriction { get { throw null; } set { } }
        public System.TimeSpan? FirstPlayExpiration { get { throw null; } set { } }
        public bool HasDigitalVideoOnlyContentRestriction { get { throw null; } set { } }
        public bool HasImageConstraintForAnalogComponentVideoRestriction { get { throw null; } set { } }
        public bool HasImageConstraintForAnalogComputerMonitorRestriction { get { throw null; } set { } }
        public int? ScmsRestriction { get { throw null; } set { } }
        public int? UncompressedDigitalAudioOutputProtectionLevel { get { throw null; } set { } }
        public int? UncompressedDigitalVideoOutputProtectionLevel { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyPlayRight System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyPlayRight>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyPlayRight>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyPlayRight System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyPlayRight>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyPlayRight>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyPlayRight>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentKeyPolicyPlayReadyUnknownOutputPassingOption : System.IEquatable<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentKeyPolicyPlayReadyUnknownOutputPassingOption(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption Allowed { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption AllowedWithVideoConstriction { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption NotAllowed { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption left, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption left, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContentKeyPolicyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyProperties>
    {
        internal ContentKeyPolicyProperties() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Media.Models.ContentKeyPolicyOption> Options { get { throw null; } }
        public System.Guid? PolicyId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ContentKeyPolicyRestriction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyRestriction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyRestriction>
    {
        protected ContentKeyPolicyRestriction() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyRestriction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyRestriction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyRestriction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyRestriction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyRestriction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyRestriction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyRestriction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ContentKeyPolicyRestrictionTokenKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenKey>
    {
        protected ContentKeyPolicyRestrictionTokenKey() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentKeyPolicyRestrictionTokenType : System.IEquatable<Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentKeyPolicyRestrictionTokenType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType Jwt { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType Swt { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType left, Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType left, Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContentKeyPolicyRsaTokenKey : Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenKey, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyRsaTokenKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyRsaTokenKey>
    {
        public ContentKeyPolicyRsaTokenKey(byte[] exponent, byte[] modulus) { }
        public byte[] Exponent { get { throw null; } set { } }
        public byte[] Modulus { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyRsaTokenKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyRsaTokenKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyRsaTokenKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyRsaTokenKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyRsaTokenKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyRsaTokenKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyRsaTokenKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentKeyPolicySymmetricTokenKey : Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenKey, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicySymmetricTokenKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicySymmetricTokenKey>
    {
        public ContentKeyPolicySymmetricTokenKey(byte[] keyValue) { }
        public byte[] KeyValue { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicySymmetricTokenKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicySymmetricTokenKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicySymmetricTokenKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicySymmetricTokenKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicySymmetricTokenKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicySymmetricTokenKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicySymmetricTokenKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentKeyPolicyTokenClaim : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyTokenClaim>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyTokenClaim>
    {
        public ContentKeyPolicyTokenClaim() { }
        public string ClaimType { get { throw null; } set { } }
        public string ClaimValue { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyTokenClaim System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyTokenClaim>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyTokenClaim>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyTokenClaim System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyTokenClaim>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyTokenClaim>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyTokenClaim>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentKeyPolicyTokenRestriction : Azure.ResourceManager.Media.Models.ContentKeyPolicyRestriction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyTokenRestriction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyTokenRestriction>
    {
        public ContentKeyPolicyTokenRestriction(string issuer, string audience, Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenKey primaryVerificationKey, Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType restrictionTokenType) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenKey> AlternateVerificationKeys { get { throw null; } }
        public string Audience { get { throw null; } set { } }
        public string Issuer { get { throw null; } set { } }
        public string OpenIdConnectDiscoveryDocument { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenKey PrimaryVerificationKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.ContentKeyPolicyTokenClaim> RequiredClaims { get { throw null; } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType RestrictionTokenType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyTokenRestriction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyTokenRestriction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyTokenRestriction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyTokenRestriction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyTokenRestriction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyTokenRestriction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyTokenRestriction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentKeyPolicyUnknownConfiguration : Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyUnknownConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyUnknownConfiguration>
    {
        public ContentKeyPolicyUnknownConfiguration() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyUnknownConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyUnknownConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyUnknownConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyUnknownConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyUnknownConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyUnknownConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyUnknownConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentKeyPolicyUnknownRestriction : Azure.ResourceManager.Media.Models.ContentKeyPolicyRestriction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyUnknownRestriction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyUnknownRestriction>
    {
        public ContentKeyPolicyUnknownRestriction() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyUnknownRestriction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyUnknownRestriction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyUnknownRestriction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyUnknownRestriction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyUnknownRestriction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyUnknownRestriction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyUnknownRestriction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentKeyPolicyWidevineConfiguration : Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyWidevineConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyWidevineConfiguration>
    {
        public ContentKeyPolicyWidevineConfiguration(string widevineTemplate) { }
        public string WidevineTemplate { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyWidevineConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyWidevineConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyWidevineConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyWidevineConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyWidevineConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyWidevineConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyWidevineConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentKeyPolicyX509CertificateTokenKey : Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenKey, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyX509CertificateTokenKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyX509CertificateTokenKey>
    {
        public ContentKeyPolicyX509CertificateTokenKey(byte[] rawBody) { }
        public byte[] RawBody { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyX509CertificateTokenKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyX509CertificateTokenKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyX509CertificateTokenKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ContentKeyPolicyX509CertificateTokenKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyX509CertificateTokenKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyX509CertificateTokenKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ContentKeyPolicyX509CertificateTokenKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CrossSiteAccessPolicies : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.CrossSiteAccessPolicies>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CrossSiteAccessPolicies>
    {
        public CrossSiteAccessPolicies() { }
        public string ClientAccessPolicy { get { throw null; } set { } }
        public string CrossDomainPolicy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.CrossSiteAccessPolicies System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.CrossSiteAccessPolicies>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.CrossSiteAccessPolicies>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.CrossSiteAccessPolicies System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CrossSiteAccessPolicies>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CrossSiteAccessPolicies>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.CrossSiteAccessPolicies>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DDAudio : Azure.ResourceManager.Media.Models.MediaAudioBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.DDAudio>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.DDAudio>
    {
        public DDAudio() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.DDAudio System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.DDAudio>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.DDAudio>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.DDAudio System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.DDAudio>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.DDAudio>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.DDAudio>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeinterlaceMode : System.IEquatable<Azure.ResourceManager.Media.Models.DeinterlaceMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeinterlaceMode(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.DeinterlaceMode AutoPixelAdaptive { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.DeinterlaceMode Off { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.DeinterlaceMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.DeinterlaceMode left, Azure.ResourceManager.Media.Models.DeinterlaceMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.DeinterlaceMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.DeinterlaceMode left, Azure.ResourceManager.Media.Models.DeinterlaceMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeinterlaceParity : System.IEquatable<Azure.ResourceManager.Media.Models.DeinterlaceParity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeinterlaceParity(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.DeinterlaceParity Auto { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.DeinterlaceParity BottomFieldFirst { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.DeinterlaceParity TopFieldFirst { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.DeinterlaceParity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.DeinterlaceParity left, Azure.ResourceManager.Media.Models.DeinterlaceParity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.DeinterlaceParity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.DeinterlaceParity left, Azure.ResourceManager.Media.Models.DeinterlaceParity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeinterlaceSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.DeinterlaceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.DeinterlaceSettings>
    {
        public DeinterlaceSettings() { }
        public Azure.ResourceManager.Media.Models.DeinterlaceMode? Mode { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.DeinterlaceParity? Parity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.DeinterlaceSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.DeinterlaceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.DeinterlaceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.DeinterlaceSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.DeinterlaceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.DeinterlaceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.DeinterlaceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgePoliciesRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.EdgePoliciesRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EdgePoliciesRequestContent>
    {
        public EdgePoliciesRequestContent() { }
        public string DeviceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.EdgePoliciesRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.EdgePoliciesRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.EdgePoliciesRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.EdgePoliciesRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EdgePoliciesRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EdgePoliciesRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EdgePoliciesRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeUsageDataCollectionPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.EdgeUsageDataCollectionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EdgeUsageDataCollectionPolicy>
    {
        internal EdgeUsageDataCollectionPolicy() { }
        public string DataCollectionFrequency { get { throw null; } }
        public string DataReportingFrequency { get { throw null; } }
        public Azure.ResourceManager.Media.Models.EdgeUsageDataEventHub EventHubDetails { get { throw null; } }
        public System.TimeSpan? MaxAllowedUnreportedUsageDuration { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.EdgeUsageDataCollectionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.EdgeUsageDataCollectionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.EdgeUsageDataCollectionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.EdgeUsageDataCollectionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EdgeUsageDataCollectionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EdgeUsageDataCollectionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EdgeUsageDataCollectionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeUsageDataEventHub : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.EdgeUsageDataEventHub>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EdgeUsageDataEventHub>
    {
        internal EdgeUsageDataEventHub() { }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        public string Token { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.EdgeUsageDataEventHub System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.EdgeUsageDataEventHub>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.EdgeUsageDataEventHub>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.EdgeUsageDataEventHub System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EdgeUsageDataEventHub>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EdgeUsageDataEventHub>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EdgeUsageDataEventHub>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncoderNamedPreset : System.IEquatable<Azure.ResourceManager.Media.Models.EncoderNamedPreset>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncoderNamedPreset(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset AacGoodQualityAudio { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset AdaptiveStreaming { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset ContentAwareEncoding { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset ContentAwareEncodingExperimental { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset CopyAllBitrateNonInterleaved { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset DDGoodQualityAudio { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset H264MultipleBitrate1080P { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset H264MultipleBitrate720P { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset H264MultipleBitrateSD { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset H264SingleBitrate1080P { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset H264SingleBitrate720P { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset H264SingleBitrateSD { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset H265AdaptiveStreaming { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset H265ContentAwareEncoding { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset H265SingleBitrate1080P { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset H265SingleBitrate4K { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset H265SingleBitrate720P { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.EncoderNamedPreset other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.EncoderNamedPreset left, Azure.ResourceManager.Media.Models.EncoderNamedPreset right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.EncoderNamedPreset (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.EncoderNamedPreset left, Azure.ResourceManager.Media.Models.EncoderNamedPreset right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EncoderPresetConfigurations : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.EncoderPresetConfigurations>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EncoderPresetConfigurations>
    {
        public EncoderPresetConfigurations() { }
        public Azure.ResourceManager.Media.Models.EncodingComplexity? Complexity { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.InterleaveOutput? InterleaveOutput { get { throw null; } set { } }
        public float? KeyFrameIntervalInSeconds { get { throw null; } set { } }
        public int? MaxBitrateBps { get { throw null; } set { } }
        public int? MaxHeight { get { throw null; } set { } }
        public int? MaxLayers { get { throw null; } set { } }
        public int? MinBitrateBps { get { throw null; } set { } }
        public int? MinHeight { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.EncoderPresetConfigurations System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.EncoderPresetConfigurations>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.EncoderPresetConfigurations>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.EncoderPresetConfigurations System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EncoderPresetConfigurations>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EncoderPresetConfigurations>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EncoderPresetConfigurations>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncodingComplexity : System.IEquatable<Azure.ResourceManager.Media.Models.EncodingComplexity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncodingComplexity(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.EncodingComplexity Balanced { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncodingComplexity Quality { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncodingComplexity Speed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.EncodingComplexity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.EncodingComplexity left, Azure.ResourceManager.Media.Models.EncodingComplexity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.EncodingComplexity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.EncodingComplexity left, Azure.ResourceManager.Media.Models.EncodingComplexity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EncryptionSchemeDefaultKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.EncryptionSchemeDefaultKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EncryptionSchemeDefaultKey>
    {
        public EncryptionSchemeDefaultKey() { }
        public string Label { get { throw null; } set { } }
        public string PolicyName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.EncryptionSchemeDefaultKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.EncryptionSchemeDefaultKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.EncryptionSchemeDefaultKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.EncryptionSchemeDefaultKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EncryptionSchemeDefaultKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EncryptionSchemeDefaultKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EncryptionSchemeDefaultKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnvelopeEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.EnvelopeEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EnvelopeEncryption>
    {
        public EnvelopeEncryption() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaTrackSelection> ClearTracks { get { throw null; } }
        public Azure.ResourceManager.Media.Models.StreamingPolicyContentKeys ContentKeys { get { throw null; } set { } }
        public string CustomKeyAcquisitionUriTemplate { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.MediaEnabledProtocols EnabledProtocols { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.EnvelopeEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.EnvelopeEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.EnvelopeEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.EnvelopeEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EnvelopeEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EnvelopeEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.EnvelopeEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FadeOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.FadeOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FadeOptions>
    {
        public FadeOptions(System.TimeSpan duration, string fadeColor) { }
        public System.TimeSpan Duration { get { throw null; } set { } }
        public string FadeColor { get { throw null; } set { } }
        public string Start { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.FadeOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.FadeOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.FadeOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.FadeOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FadeOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FadeOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FadeOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FilteringOperations : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.FilteringOperations>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FilteringOperations>
    {
        public FilteringOperations() { }
        public Azure.ResourceManager.Media.Models.RectangularWindow Crop { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.DeinterlaceSettings Deinterlace { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.FadeOptions FadeIn { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.FadeOptions FadeOut { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaOverlayBase> Overlays { get { throw null; } }
        public Azure.ResourceManager.Media.Models.RotationSetting? Rotation { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.FilteringOperations System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.FilteringOperations>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.FilteringOperations>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.FilteringOperations System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FilteringOperations>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FilteringOperations>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FilteringOperations>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FilterTrackPropertyCompareOperation : System.IEquatable<Azure.ResourceManager.Media.Models.FilterTrackPropertyCompareOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FilterTrackPropertyCompareOperation(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.FilterTrackPropertyCompareOperation Equal { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.FilterTrackPropertyCompareOperation NotEqual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.FilterTrackPropertyCompareOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.FilterTrackPropertyCompareOperation left, Azure.ResourceManager.Media.Models.FilterTrackPropertyCompareOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.FilterTrackPropertyCompareOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.FilterTrackPropertyCompareOperation left, Azure.ResourceManager.Media.Models.FilterTrackPropertyCompareOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FilterTrackPropertyCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.FilterTrackPropertyCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FilterTrackPropertyCondition>
    {
        public FilterTrackPropertyCondition(Azure.ResourceManager.Media.Models.FilterTrackPropertyType property, string value, Azure.ResourceManager.Media.Models.FilterTrackPropertyCompareOperation operation) { }
        public Azure.ResourceManager.Media.Models.FilterTrackPropertyCompareOperation Operation { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.FilterTrackPropertyType Property { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.FilterTrackPropertyCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.FilterTrackPropertyCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.FilterTrackPropertyCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.FilterTrackPropertyCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FilterTrackPropertyCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FilterTrackPropertyCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FilterTrackPropertyCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FilterTrackPropertyType : System.IEquatable<Azure.ResourceManager.Media.Models.FilterTrackPropertyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FilterTrackPropertyType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.FilterTrackPropertyType Bitrate { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.FilterTrackPropertyType FourCC { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.FilterTrackPropertyType Language { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.FilterTrackPropertyType Name { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.FilterTrackPropertyType Type { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.FilterTrackPropertyType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.FilterTrackPropertyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.FilterTrackPropertyType left, Azure.ResourceManager.Media.Models.FilterTrackPropertyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.FilterTrackPropertyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.FilterTrackPropertyType left, Azure.ResourceManager.Media.Models.FilterTrackPropertyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FilterTrackSelection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.FilterTrackSelection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FilterTrackSelection>
    {
        public FilterTrackSelection(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.FilterTrackPropertyCondition> trackSelections) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.FilterTrackPropertyCondition> TrackSelections { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.FilterTrackSelection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.FilterTrackSelection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.FilterTrackSelection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.FilterTrackSelection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FilterTrackSelection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FilterTrackSelection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FilterTrackSelection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FromAllInputFile : Azure.ResourceManager.Media.Models.MediaJobInputDefinition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.FromAllInputFile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FromAllInputFile>
    {
        public FromAllInputFile() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.FromAllInputFile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.FromAllInputFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.FromAllInputFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.FromAllInputFile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FromAllInputFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FromAllInputFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FromAllInputFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FromEachInputFile : Azure.ResourceManager.Media.Models.MediaJobInputDefinition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.FromEachInputFile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FromEachInputFile>
    {
        public FromEachInputFile() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.FromEachInputFile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.FromEachInputFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.FromEachInputFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.FromEachInputFile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FromEachInputFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FromEachInputFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.FromEachInputFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct H264Complexity : System.IEquatable<Azure.ResourceManager.Media.Models.H264Complexity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public H264Complexity(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.H264Complexity Balanced { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H264Complexity Quality { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H264Complexity Speed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.H264Complexity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.H264Complexity left, Azure.ResourceManager.Media.Models.H264Complexity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.H264Complexity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.H264Complexity left, Azure.ResourceManager.Media.Models.H264Complexity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class H264Layer : Azure.ResourceManager.Media.Models.VideoLayer, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.H264Layer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.H264Layer>
    {
        public H264Layer(int bitrate) : base (default(int)) { }
        public System.TimeSpan? BufferWindow { get { throw null; } set { } }
        public float? ConstantRateFactor { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.LayerEntropyMode? EntropyMode { get { throw null; } set { } }
        public string Level { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.H264VideoProfile? Profile { get { throw null; } set { } }
        public int? ReferenceFrames { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.H264Layer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.H264Layer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.H264Layer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.H264Layer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.H264Layer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.H264Layer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.H264Layer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct H264RateControlMode : System.IEquatable<Azure.ResourceManager.Media.Models.H264RateControlMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public H264RateControlMode(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.H264RateControlMode Abr { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H264RateControlMode Cbr { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H264RateControlMode Crf { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.H264RateControlMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.H264RateControlMode left, Azure.ResourceManager.Media.Models.H264RateControlMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.H264RateControlMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.H264RateControlMode left, Azure.ResourceManager.Media.Models.H264RateControlMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class H264Video : Azure.ResourceManager.Media.Models.MediaVideoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.H264Video>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.H264Video>
    {
        public H264Video() { }
        public Azure.ResourceManager.Media.Models.H264Complexity? Complexity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.H264Layer> Layers { get { throw null; } }
        public Azure.ResourceManager.Media.Models.H264RateControlMode? RateControlMode { get { throw null; } set { } }
        public bool? UseSceneChangeDetection { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.H264Video System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.H264Video>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.H264Video>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.H264Video System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.H264Video>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.H264Video>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.H264Video>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct H264VideoProfile : System.IEquatable<Azure.ResourceManager.Media.Models.H264VideoProfile>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public H264VideoProfile(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.H264VideoProfile Auto { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H264VideoProfile Baseline { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H264VideoProfile High { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H264VideoProfile High422 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H264VideoProfile High444 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H264VideoProfile Main { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.H264VideoProfile other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.H264VideoProfile left, Azure.ResourceManager.Media.Models.H264VideoProfile right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.H264VideoProfile (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.H264VideoProfile left, Azure.ResourceManager.Media.Models.H264VideoProfile right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct H265Complexity : System.IEquatable<Azure.ResourceManager.Media.Models.H265Complexity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public H265Complexity(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.H265Complexity Balanced { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H265Complexity Quality { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H265Complexity Speed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.H265Complexity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.H265Complexity left, Azure.ResourceManager.Media.Models.H265Complexity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.H265Complexity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.H265Complexity left, Azure.ResourceManager.Media.Models.H265Complexity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class H265Layer : Azure.ResourceManager.Media.Models.H265VideoLayer, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.H265Layer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.H265Layer>
    {
        public H265Layer(int bitrate) : base (default(int)) { }
        public System.TimeSpan? BufferWindow { get { throw null; } set { } }
        public float? Crf { get { throw null; } set { } }
        public string Level { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.H265VideoProfile? Profile { get { throw null; } set { } }
        public int? ReferenceFrames { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.H265Layer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.H265Layer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.H265Layer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.H265Layer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.H265Layer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.H265Layer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.H265Layer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class H265Video : Azure.ResourceManager.Media.Models.MediaVideoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.H265Video>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.H265Video>
    {
        public H265Video() { }
        public Azure.ResourceManager.Media.Models.H265Complexity? Complexity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.H265Layer> Layers { get { throw null; } }
        public bool? UseSceneChangeDetection { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.H265Video System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.H265Video>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.H265Video>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.H265Video System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.H265Video>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.H265Video>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.H265Video>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class H265VideoLayer : Azure.ResourceManager.Media.Models.MediaLayerBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.H265VideoLayer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.H265VideoLayer>
    {
        public H265VideoLayer(int bitrate) { }
        public int? BFrames { get { throw null; } set { } }
        public int Bitrate { get { throw null; } set { } }
        public string FrameRate { get { throw null; } set { } }
        public int? MaxBitrate { get { throw null; } set { } }
        public int? Slices { get { throw null; } set { } }
        public bool? UseAdaptiveBFrame { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.H265VideoLayer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.H265VideoLayer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.H265VideoLayer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.H265VideoLayer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.H265VideoLayer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.H265VideoLayer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.H265VideoLayer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct H265VideoProfile : System.IEquatable<Azure.ResourceManager.Media.Models.H265VideoProfile>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public H265VideoProfile(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.H265VideoProfile Auto { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H265VideoProfile Main { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H265VideoProfile Main10 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.H265VideoProfile other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.H265VideoProfile left, Azure.ResourceManager.Media.Models.H265VideoProfile right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.H265VideoProfile (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.H265VideoProfile left, Azure.ResourceManager.Media.Models.H265VideoProfile right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HlsSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.HlsSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.HlsSettings>
    {
        public HlsSettings() { }
        public string Characteristics { get { throw null; } set { } }
        public bool? IsDefault { get { throw null; } set { } }
        public bool? IsForced { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.HlsSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.HlsSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.HlsSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.HlsSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.HlsSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.HlsSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.HlsSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InputVideoStretchMode : System.IEquatable<Azure.ResourceManager.Media.Models.InputVideoStretchMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InputVideoStretchMode(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.InputVideoStretchMode AutoFit { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.InputVideoStretchMode AutoSize { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.InputVideoStretchMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.InputVideoStretchMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.InputVideoStretchMode left, Azure.ResourceManager.Media.Models.InputVideoStretchMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.InputVideoStretchMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.InputVideoStretchMode left, Azure.ResourceManager.Media.Models.InputVideoStretchMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InsightsType : System.IEquatable<Azure.ResourceManager.Media.Models.InsightsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InsightsType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.InsightsType AllInsights { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.InsightsType AudioInsightsOnly { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.InsightsType VideoInsightsOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.InsightsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.InsightsType left, Azure.ResourceManager.Media.Models.InsightsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.InsightsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.InsightsType left, Azure.ResourceManager.Media.Models.InsightsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InterleaveOutput : System.IEquatable<Azure.ResourceManager.Media.Models.InterleaveOutput>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InterleaveOutput(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.InterleaveOutput InterleavedOutput { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.InterleaveOutput NonInterleavedOutput { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.InterleaveOutput other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.InterleaveOutput left, Azure.ResourceManager.Media.Models.InterleaveOutput right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.InterleaveOutput (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.InterleaveOutput left, Azure.ResourceManager.Media.Models.InterleaveOutput right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPAccessControlDefaultAction : System.IEquatable<Azure.ResourceManager.Media.Models.IPAccessControlDefaultAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPAccessControlDefaultAction(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.IPAccessControlDefaultAction Allow { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.IPAccessControlDefaultAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.IPAccessControlDefaultAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.IPAccessControlDefaultAction left, Azure.ResourceManager.Media.Models.IPAccessControlDefaultAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.IPAccessControlDefaultAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.IPAccessControlDefaultAction left, Azure.ResourceManager.Media.Models.IPAccessControlDefaultAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.IPRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.IPRange>
    {
        public IPRange() { }
        public System.Net.IPAddress Address { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int? SubnetPrefixLength { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.IPRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.IPRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.IPRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.IPRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.IPRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.IPRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.IPRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JpgFormat : Azure.ResourceManager.Media.Models.OutputImageFileFormat, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.JpgFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.JpgFormat>
    {
        public JpgFormat(string filenamePattern) : base (default(string)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.JpgFormat System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.JpgFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.JpgFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.JpgFormat System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.JpgFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.JpgFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.JpgFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JpgImage : Azure.ResourceManager.Media.Models.MediaImageBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.JpgImage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.JpgImage>
    {
        public JpgImage(string start) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.JpgLayer> Layers { get { throw null; } }
        public int? SpriteColumn { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.JpgImage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.JpgImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.JpgImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.JpgImage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.JpgImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.JpgImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.JpgImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JpgLayer : Azure.ResourceManager.Media.Models.MediaLayerBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.JpgLayer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.JpgLayer>
    {
        public JpgLayer() { }
        public int? Quality { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.JpgLayer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.JpgLayer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.JpgLayer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.JpgLayer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.JpgLayer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.JpgLayer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.JpgLayer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.KeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.KeyVaultProperties>
    {
        public KeyVaultProperties() { }
        public string CurrentKeyIdentifier { get { throw null; } }
        public string KeyIdentifier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.KeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.KeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.KeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.KeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.KeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.KeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.KeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LayerEntropyMode : System.IEquatable<Azure.ResourceManager.Media.Models.LayerEntropyMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LayerEntropyMode(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.LayerEntropyMode Cabac { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LayerEntropyMode Cavlc { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.LayerEntropyMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.LayerEntropyMode left, Azure.ResourceManager.Media.Models.LayerEntropyMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.LayerEntropyMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.LayerEntropyMode left, Azure.ResourceManager.Media.Models.LayerEntropyMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LiveEventActionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.LiveEventActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventActionContent>
    {
        public LiveEventActionContent() { }
        public bool? RemoveOutputsOnStop { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.LiveEventActionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.LiveEventActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.LiveEventActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.LiveEventActionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiveEventEncoding : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.LiveEventEncoding>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventEncoding>
    {
        public LiveEventEncoding() { }
        public Azure.ResourceManager.Media.Models.LiveEventEncodingType? EncodingType { get { throw null; } set { } }
        public System.TimeSpan? KeyFrameInterval { get { throw null; } set { } }
        public string PresetName { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.InputVideoStretchMode? StretchMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.LiveEventEncoding System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.LiveEventEncoding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.LiveEventEncoding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.LiveEventEncoding System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventEncoding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventEncoding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventEncoding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LiveEventEncodingType : System.IEquatable<Azure.ResourceManager.Media.Models.LiveEventEncodingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LiveEventEncodingType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.LiveEventEncodingType None { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveEventEncodingType PassthroughBasic { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveEventEncodingType PassthroughStandard { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveEventEncodingType Premium1080P { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveEventEncodingType Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.LiveEventEncodingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.LiveEventEncodingType left, Azure.ResourceManager.Media.Models.LiveEventEncodingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.LiveEventEncodingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.LiveEventEncodingType left, Azure.ResourceManager.Media.Models.LiveEventEncodingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LiveEventEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.LiveEventEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventEndpoint>
    {
        public LiveEventEndpoint() { }
        public string Protocol { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.LiveEventEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.LiveEventEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.LiveEventEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.LiveEventEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiveEventInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.LiveEventInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventInput>
    {
        public LiveEventInput(Azure.ResourceManager.Media.Models.LiveEventInputProtocol streamingProtocol) { }
        public string AccessToken { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.LiveEventEndpoint> Endpoints { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.IPRange> IPAllowedIPs { get { throw null; } }
        public System.TimeSpan? KeyFrameIntervalDuration { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.LiveEventInputProtocol StreamingProtocol { get { throw null; } set { } }
        Azure.ResourceManager.Media.Models.LiveEventInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.LiveEventInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.LiveEventInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.LiveEventInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LiveEventInputProtocol : System.IEquatable<Azure.ResourceManager.Media.Models.LiveEventInputProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LiveEventInputProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.LiveEventInputProtocol FragmentedMp4 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveEventInputProtocol Rtmp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.LiveEventInputProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.LiveEventInputProtocol left, Azure.ResourceManager.Media.Models.LiveEventInputProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.LiveEventInputProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.LiveEventInputProtocol left, Azure.ResourceManager.Media.Models.LiveEventInputProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LiveEventInputTrackSelection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.LiveEventInputTrackSelection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventInputTrackSelection>
    {
        public LiveEventInputTrackSelection() { }
        public string Operation { get { throw null; } set { } }
        public string Property { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.LiveEventInputTrackSelection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.LiveEventInputTrackSelection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.LiveEventInputTrackSelection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.LiveEventInputTrackSelection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventInputTrackSelection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventInputTrackSelection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventInputTrackSelection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiveEventPreview : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.LiveEventPreview>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventPreview>
    {
        public LiveEventPreview() { }
        public string AlternativeMediaId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.LiveEventEndpoint> Endpoints { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.IPRange> IPAllowedIPs { get { throw null; } }
        public string PreviewLocator { get { throw null; } set { } }
        public string StreamingPolicyName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.LiveEventPreview System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.LiveEventPreview>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.LiveEventPreview>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.LiveEventPreview System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventPreview>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventPreview>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventPreview>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LiveEventResourceState : System.IEquatable<Azure.ResourceManager.Media.Models.LiveEventResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LiveEventResourceState(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.LiveEventResourceState Allocating { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveEventResourceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveEventResourceState Running { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveEventResourceState StandBy { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveEventResourceState Starting { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveEventResourceState Stopped { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveEventResourceState Stopping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.LiveEventResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.LiveEventResourceState left, Azure.ResourceManager.Media.Models.LiveEventResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.LiveEventResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.LiveEventResourceState left, Azure.ResourceManager.Media.Models.LiveEventResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LiveEventTranscription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.LiveEventTranscription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventTranscription>
    {
        public LiveEventTranscription() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.LiveEventInputTrackSelection> InputTrackSelection { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public string TrackName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.LiveEventTranscription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.LiveEventTranscription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.LiveEventTranscription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.LiveEventTranscription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventTranscription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventTranscription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.LiveEventTranscription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LiveOutputResourceState : System.IEquatable<Azure.ResourceManager.Media.Models.LiveOutputResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LiveOutputResourceState(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.LiveOutputResourceState Creating { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveOutputResourceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveOutputResourceState Running { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.LiveOutputResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.LiveOutputResourceState left, Azure.ResourceManager.Media.Models.LiveOutputResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.LiveOutputResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.LiveOutputResourceState left, Azure.ResourceManager.Media.Models.LiveOutputResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaAccessControl : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaAccessControl>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAccessControl>
    {
        public MediaAccessControl() { }
        public Azure.ResourceManager.Media.Models.IPAccessControlDefaultAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Net.IPAddress> IPAllowList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaAccessControl System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaAccessControl>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaAccessControl>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaAccessControl System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAccessControl>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAccessControl>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAccessControl>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaAssetContainerPermission : System.IEquatable<Azure.ResourceManager.Media.Models.MediaAssetContainerPermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaAssetContainerPermission(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaAssetContainerPermission Read { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaAssetContainerPermission ReadWrite { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaAssetContainerPermission ReadWriteDelete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaAssetContainerPermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaAssetContainerPermission left, Azure.ResourceManager.Media.Models.MediaAssetContainerPermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaAssetContainerPermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaAssetContainerPermission left, Azure.ResourceManager.Media.Models.MediaAssetContainerPermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaAssetFileEncryptionMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaAssetFileEncryptionMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAssetFileEncryptionMetadata>
    {
        internal MediaAssetFileEncryptionMetadata() { }
        public System.Guid AssetFileId { get { throw null; } }
        public string AssetFileName { get { throw null; } }
        public string InitializationVector { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaAssetFileEncryptionMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaAssetFileEncryptionMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaAssetFileEncryptionMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaAssetFileEncryptionMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAssetFileEncryptionMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAssetFileEncryptionMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAssetFileEncryptionMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaAssetStorageContainerSasContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaAssetStorageContainerSasContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAssetStorageContainerSasContent>
    {
        public MediaAssetStorageContainerSasContent() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.MediaAssetContainerPermission? Permissions { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaAssetStorageContainerSasContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaAssetStorageContainerSasContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaAssetStorageContainerSasContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaAssetStorageContainerSasContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAssetStorageContainerSasContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAssetStorageContainerSasContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAssetStorageContainerSasContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaAssetStorageEncryptionFormat : System.IEquatable<Azure.ResourceManager.Media.Models.MediaAssetStorageEncryptionFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaAssetStorageEncryptionFormat(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaAssetStorageEncryptionFormat MediaStorageClientEncryption { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaAssetStorageEncryptionFormat None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaAssetStorageEncryptionFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaAssetStorageEncryptionFormat left, Azure.ResourceManager.Media.Models.MediaAssetStorageEncryptionFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaAssetStorageEncryptionFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaAssetStorageEncryptionFormat left, Azure.ResourceManager.Media.Models.MediaAssetStorageEncryptionFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaAssetStreamingLocator : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaAssetStreamingLocator>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAssetStreamingLocator>
    {
        internal MediaAssetStreamingLocator() { }
        public string AssetName { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DefaultContentKeyPolicyName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public System.Guid? StreamingLocatorId { get { throw null; } }
        public string StreamingPolicyName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaAssetStreamingLocator System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaAssetStreamingLocator>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaAssetStreamingLocator>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaAssetStreamingLocator System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAssetStreamingLocator>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAssetStreamingLocator>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAssetStreamingLocator>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MediaAssetTrackBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaAssetTrackBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAssetTrackBase>
    {
        protected MediaAssetTrackBase() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaAssetTrackBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaAssetTrackBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaAssetTrackBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaAssetTrackBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAssetTrackBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAssetTrackBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAssetTrackBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaAudioBase : Azure.ResourceManager.Media.Models.MediaCodecBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaAudioBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAudioBase>
    {
        public MediaAudioBase() { }
        public int? Bitrate { get { throw null; } set { } }
        public int? Channels { get { throw null; } set { } }
        public int? SamplingRate { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaAudioBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaAudioBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaAudioBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaAudioBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAudioBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAudioBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaAudioBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MediaCodecBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaCodecBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaCodecBase>
    {
        protected MediaCodecBase() { }
        public string Label { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaCodecBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaCodecBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaCodecBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaCodecBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaCodecBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaCodecBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaCodecBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaEnabledProtocols : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaEnabledProtocols>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaEnabledProtocols>
    {
        public MediaEnabledProtocols(bool isDownloadEnabled, bool isDashEnabled, bool isHlsEnabled, bool isSmoothStreamingEnabled) { }
        public bool IsDashEnabled { get { throw null; } set { } }
        public bool IsDownloadEnabled { get { throw null; } set { } }
        public bool IsHlsEnabled { get { throw null; } set { } }
        public bool IsSmoothStreamingEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaEnabledProtocols System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaEnabledProtocols>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaEnabledProtocols>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaEnabledProtocols System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaEnabledProtocols>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaEnabledProtocols>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaEnabledProtocols>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MediaFormatBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaFormatBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaFormatBase>
    {
        protected MediaFormatBase(string filenamePattern) { }
        public string FilenamePattern { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaFormatBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaFormatBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaFormatBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaFormatBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaFormatBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaFormatBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaFormatBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaImageBase : Azure.ResourceManager.Media.Models.MediaVideoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaImageBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaImageBase>
    {
        public MediaImageBase(string start) { }
        public string Range { get { throw null; } set { } }
        public string Start { get { throw null; } set { } }
        public string Step { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaImageBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaImageBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaImageBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaImageBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaImageBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaImageBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaImageBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobError>
    {
        internal MediaJobError() { }
        public Azure.ResourceManager.Media.Models.MediaJobErrorCategory? Category { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaJobErrorCode? Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Media.Models.MediaJobErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaJobRetry? Retry { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaJobErrorCategory : System.IEquatable<Azure.ResourceManager.Media.Models.MediaJobErrorCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaJobErrorCategory(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaJobErrorCategory Account { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaJobErrorCategory Configuration { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaJobErrorCategory Content { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaJobErrorCategory Download { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaJobErrorCategory Service { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaJobErrorCategory Upload { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaJobErrorCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaJobErrorCategory left, Azure.ResourceManager.Media.Models.MediaJobErrorCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaJobErrorCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaJobErrorCategory left, Azure.ResourceManager.Media.Models.MediaJobErrorCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaJobErrorCode : System.IEquatable<Azure.ResourceManager.Media.Models.MediaJobErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaJobErrorCode(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaJobErrorCode ConfigurationUnsupported { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaJobErrorCode ContentMalformed { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaJobErrorCode ContentUnsupported { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaJobErrorCode DownloadNotAccessible { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaJobErrorCode DownloadTransientError { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaJobErrorCode IdentityUnsupported { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaJobErrorCode ServiceError { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaJobErrorCode ServiceTransientError { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaJobErrorCode UploadNotAccessible { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaJobErrorCode UploadTransientError { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaJobErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaJobErrorCode left, Azure.ResourceManager.Media.Models.MediaJobErrorCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaJobErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaJobErrorCode left, Azure.ResourceManager.Media.Models.MediaJobErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaJobErrorDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobErrorDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobErrorDetail>
    {
        internal MediaJobErrorDetail() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobErrorDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobErrorDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobErrorDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobErrorDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobErrorDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobErrorDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobErrorDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobInputAsset : Azure.ResourceManager.Media.Models.MediaJobInputClip, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputAsset>
    {
        public MediaJobInputAsset(string assetName) { }
        public string AssetName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobInputAsset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobInputAsset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MediaJobInputBasicProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputBasicProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputBasicProperties>
    {
        protected MediaJobInputBasicProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobInputBasicProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputBasicProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputBasicProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobInputBasicProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputBasicProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputBasicProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputBasicProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobInputClip : Azure.ResourceManager.Media.Models.MediaJobInputBasicProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputClip>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputClip>
    {
        public MediaJobInputClip() { }
        public Azure.ResourceManager.Media.Models.ClipTime End { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Files { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaJobInputDefinition> InputDefinitions { get { throw null; } }
        public string Label { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ClipTime Start { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobInputClip System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputClip>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputClip>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobInputClip System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputClip>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputClip>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputClip>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MediaJobInputDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputDefinition>
    {
        protected MediaJobInputDefinition() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.TrackDescriptor> IncludedTracks { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobInputDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobInputDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobInputFile : Azure.ResourceManager.Media.Models.MediaJobInputDefinition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputFile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputFile>
    {
        public MediaJobInputFile() { }
        public string Filename { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobInputFile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobInputFile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobInputHttp : Azure.ResourceManager.Media.Models.MediaJobInputClip, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputHttp>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputHttp>
    {
        public MediaJobInputHttp() { }
        public System.Uri BaseUri { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobInputHttp System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputHttp>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputHttp>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobInputHttp System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputHttp>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputHttp>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputHttp>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobInputs : Azure.ResourceManager.Media.Models.MediaJobInputBasicProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputs>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputs>
    {
        public MediaJobInputs() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaJobInputBasicProperties> Inputs { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobInputs System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobInputs System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobInputSequence : Azure.ResourceManager.Media.Models.MediaJobInputBasicProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputSequence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputSequence>
    {
        public MediaJobInputSequence() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaJobInputClip> Inputs { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobInputSequence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputSequence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobInputSequence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobInputSequence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputSequence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputSequence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobInputSequence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MediaJobOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobOutput>
    {
        protected MediaJobOutput() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaJobError Error { get { throw null; } }
        public string Label { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.MediaTransformPreset PresetOverride { get { throw null; } set { } }
        public int? Progress { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaJobState? State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobOutputAsset : Azure.ResourceManager.Media.Models.MediaJobOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobOutputAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobOutputAsset>
    {
        public MediaJobOutputAsset(string assetName) { }
        public string AssetName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobOutputAsset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobOutputAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaJobOutputAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaJobOutputAsset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobOutputAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobOutputAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaJobOutputAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaJobPriority : System.IEquatable<Azure.ResourceManager.Media.Models.MediaJobPriority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaJobPriority(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaJobPriority High { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaJobPriority Low { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaJobPriority Normal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaJobPriority other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaJobPriority left, Azure.ResourceManager.Media.Models.MediaJobPriority right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaJobPriority (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaJobPriority left, Azure.ResourceManager.Media.Models.MediaJobPriority right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaJobRetry : System.IEquatable<Azure.ResourceManager.Media.Models.MediaJobRetry>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaJobRetry(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaJobRetry DoNotRetry { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaJobRetry MayRetry { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaJobRetry other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaJobRetry left, Azure.ResourceManager.Media.Models.MediaJobRetry right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaJobRetry (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaJobRetry left, Azure.ResourceManager.Media.Models.MediaJobRetry right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaJobState : System.IEquatable<Azure.ResourceManager.Media.Models.MediaJobState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaJobState(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaJobState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaJobState Canceling { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaJobState Error { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaJobState Finished { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaJobState Processing { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaJobState Queued { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaJobState Scheduled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaJobState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaJobState left, Azure.ResourceManager.Media.Models.MediaJobState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaJobState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaJobState left, Azure.ResourceManager.Media.Models.MediaJobState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaLayerBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaLayerBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaLayerBase>
    {
        public MediaLayerBase() { }
        public string Height { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
        public string Width { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaLayerBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaLayerBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaLayerBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaLayerBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaLayerBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaLayerBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaLayerBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaOutputFile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaOutputFile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaOutputFile>
    {
        public MediaOutputFile(System.Collections.Generic.IEnumerable<string> labels) { }
        public System.Collections.Generic.IList<string> Labels { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaOutputFile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaOutputFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaOutputFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaOutputFile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaOutputFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaOutputFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaOutputFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MediaOverlayBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaOverlayBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaOverlayBase>
    {
        protected MediaOverlayBase(string inputLabel) { }
        public double? AudioGainLevel { get { throw null; } set { } }
        public System.TimeSpan? End { get { throw null; } set { } }
        public System.TimeSpan? FadeInDuration { get { throw null; } set { } }
        public System.TimeSpan? FadeOutDuration { get { throw null; } set { } }
        public string InputLabel { get { throw null; } set { } }
        public System.TimeSpan? Start { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaOverlayBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaOverlayBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaOverlayBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaOverlayBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaOverlayBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaOverlayBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaOverlayBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Media.Models.MediaPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Media.Models.MediaPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Media.Models.MediaPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaPrivateLinkServiceConnectionState>
    {
        public MediaPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.MediaPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaServicesAccountPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaServicesAccountPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaServicesAccountPatch>
    {
        public MediaServicesAccountPatch() { }
        public Azure.ResourceManager.Media.Models.AccountEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.MediaAccessControl KeyDeliveryAccessControl { get { throw null; } set { } }
        public System.Guid? MediaServiceId { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaServicesMinimumTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaServicesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaServicesPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaServicesStorageAccount> StorageAccounts { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaStorageAuthentication? StorageAuthentication { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaServicesAccountPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaServicesAccountPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaServicesAccountPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaServicesAccountPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaServicesAccountPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaServicesAccountPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaServicesAccountPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaServicesEdgePolicies : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaServicesEdgePolicies>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaServicesEdgePolicies>
    {
        internal MediaServicesEdgePolicies() { }
        public Azure.ResourceManager.Media.Models.EdgeUsageDataCollectionPolicy UsageDataCollectionPolicy { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaServicesEdgePolicies System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaServicesEdgePolicies>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaServicesEdgePolicies>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaServicesEdgePolicies System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaServicesEdgePolicies>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaServicesEdgePolicies>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaServicesEdgePolicies>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaServicesMinimumTlsVersion : System.IEquatable<Azure.ResourceManager.Media.Models.MediaServicesMinimumTlsVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaServicesMinimumTlsVersion(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaServicesMinimumTlsVersion Tls10 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaServicesMinimumTlsVersion Tls11 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaServicesMinimumTlsVersion Tls12 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaServicesMinimumTlsVersion Tls13 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaServicesMinimumTlsVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaServicesMinimumTlsVersion left, Azure.ResourceManager.Media.Models.MediaServicesMinimumTlsVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaServicesMinimumTlsVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaServicesMinimumTlsVersion left, Azure.ResourceManager.Media.Models.MediaServicesMinimumTlsVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaServicesNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityContent>
    {
        public MediaServicesNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaServicesNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityResult>
    {
        internal MediaServicesNameAvailabilityResult() { }
        public bool IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaServicesNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaServicesProvisioningState : System.IEquatable<Azure.ResourceManager.Media.Models.MediaServicesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaServicesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaServicesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaServicesProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaServicesProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaServicesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaServicesProvisioningState left, Azure.ResourceManager.Media.Models.MediaServicesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaServicesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaServicesProvisioningState left, Azure.ResourceManager.Media.Models.MediaServicesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaServicesPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Media.Models.MediaServicesPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaServicesPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaServicesPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaServicesPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaServicesPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaServicesPublicNetworkAccess left, Azure.ResourceManager.Media.Models.MediaServicesPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaServicesPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaServicesPublicNetworkAccess left, Azure.ResourceManager.Media.Models.MediaServicesPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaServicesStorageAccount : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaServicesStorageAccount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaServicesStorageAccount>
    {
        public MediaServicesStorageAccount(Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType accountType) { }
        public Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType AccountType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ResourceIdentity Identity { get { throw null; } set { } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaServicesStorageAccount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaServicesStorageAccount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaServicesStorageAccount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaServicesStorageAccount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaServicesStorageAccount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaServicesStorageAccount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaServicesStorageAccount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaServicesStorageAccountType : System.IEquatable<Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaServicesStorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType Primary { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType left, Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType left, Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaStorageAuthentication : System.IEquatable<Azure.ResourceManager.Media.Models.MediaStorageAuthentication>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaStorageAuthentication(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaStorageAuthentication ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaStorageAuthentication System { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaStorageAuthentication other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaStorageAuthentication left, Azure.ResourceManager.Media.Models.MediaStorageAuthentication right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaStorageAuthentication (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaStorageAuthentication left, Azure.ResourceManager.Media.Models.MediaStorageAuthentication right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaTrackSelection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaTrackSelection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaTrackSelection>
    {
        public MediaTrackSelection() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.TrackPropertyCondition> TrackSelections { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaTrackSelection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaTrackSelection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaTrackSelection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaTrackSelection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaTrackSelection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaTrackSelection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaTrackSelection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaTransformOnErrorType : System.IEquatable<Azure.ResourceManager.Media.Models.MediaTransformOnErrorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaTransformOnErrorType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaTransformOnErrorType ContinueJob { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaTransformOnErrorType StopProcessingJob { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaTransformOnErrorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaTransformOnErrorType left, Azure.ResourceManager.Media.Models.MediaTransformOnErrorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaTransformOnErrorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaTransformOnErrorType left, Azure.ResourceManager.Media.Models.MediaTransformOnErrorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaTransformOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaTransformOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaTransformOutput>
    {
        public MediaTransformOutput(Azure.ResourceManager.Media.Models.MediaTransformPreset preset) { }
        public Azure.ResourceManager.Media.Models.MediaTransformOnErrorType? OnError { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.MediaTransformPreset Preset { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.MediaJobPriority? RelativePriority { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaTransformOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaTransformOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaTransformOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaTransformOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaTransformOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaTransformOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaTransformOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MediaTransformPreset : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaTransformPreset>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaTransformPreset>
    {
        protected MediaTransformPreset() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaTransformPreset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaTransformPreset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaTransformPreset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaTransformPreset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaTransformPreset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaTransformPreset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaTransformPreset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaVideoBase : Azure.ResourceManager.Media.Models.MediaCodecBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaVideoBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaVideoBase>
    {
        public MediaVideoBase() { }
        public System.TimeSpan? KeyFrameInterval { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.InputVideoStretchMode? StretchMode { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.VideoSyncMode? SyncMode { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaVideoBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaVideoBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MediaVideoBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MediaVideoBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaVideoBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaVideoBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MediaVideoBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Mp4Format : Azure.ResourceManager.Media.Models.MultiBitrateFormat, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.Mp4Format>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.Mp4Format>
    {
        public Mp4Format(string filenamePattern) : base (default(string)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.Mp4Format System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.Mp4Format>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.Mp4Format>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.Mp4Format System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.Mp4Format>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.Mp4Format>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.Mp4Format>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultiBitrateFormat : Azure.ResourceManager.Media.Models.MediaFormatBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MultiBitrateFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MultiBitrateFormat>
    {
        public MultiBitrateFormat(string filenamePattern) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaOutputFile> OutputFiles { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MultiBitrateFormat System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MultiBitrateFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.MultiBitrateFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.MultiBitrateFormat System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MultiBitrateFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MultiBitrateFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.MultiBitrateFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OutputImageFileFormat : Azure.ResourceManager.Media.Models.MediaFormatBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.OutputImageFileFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.OutputImageFileFormat>
    {
        public OutputImageFileFormat(string filenamePattern) : base (default(string)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.OutputImageFileFormat System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.OutputImageFileFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.OutputImageFileFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.OutputImageFileFormat System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.OutputImageFileFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.OutputImageFileFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.OutputImageFileFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlayerVisibility : System.IEquatable<Azure.ResourceManager.Media.Models.PlayerVisibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlayerVisibility(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.PlayerVisibility Hidden { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.PlayerVisibility Visible { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.PlayerVisibility other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.PlayerVisibility left, Azure.ResourceManager.Media.Models.PlayerVisibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.PlayerVisibility (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.PlayerVisibility left, Azure.ResourceManager.Media.Models.PlayerVisibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlayReadySecurityLevel : System.IEquatable<Azure.ResourceManager.Media.Models.PlayReadySecurityLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlayReadySecurityLevel(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.PlayReadySecurityLevel SL150 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.PlayReadySecurityLevel SL2000 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.PlayReadySecurityLevel SL3000 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.PlayReadySecurityLevel Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.PlayReadySecurityLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.PlayReadySecurityLevel left, Azure.ResourceManager.Media.Models.PlayReadySecurityLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.PlayReadySecurityLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.PlayReadySecurityLevel left, Azure.ResourceManager.Media.Models.PlayReadySecurityLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PngFormat : Azure.ResourceManager.Media.Models.OutputImageFileFormat, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.PngFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.PngFormat>
    {
        public PngFormat(string filenamePattern) : base (default(string)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.PngFormat System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.PngFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.PngFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.PngFormat System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.PngFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.PngFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.PngFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PngImage : Azure.ResourceManager.Media.Models.MediaImageBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.PngImage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.PngImage>
    {
        public PngImage(string start) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.PngLayer> Layers { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.PngImage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.PngImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.PngImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.PngImage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.PngImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.PngImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.PngImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PngLayer : Azure.ResourceManager.Media.Models.MediaLayerBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.PngLayer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.PngLayer>
    {
        public PngLayer() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.PngLayer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.PngLayer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.PngLayer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.PngLayer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.PngLayer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.PngLayer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.PngLayer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PresentationTimeRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.PresentationTimeRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.PresentationTimeRange>
    {
        public PresentationTimeRange() { }
        public long? EndTimestamp { get { throw null; } set { } }
        public bool? ForceEndTimestamp { get { throw null; } set { } }
        public long? LiveBackoffDuration { get { throw null; } set { } }
        public long? PresentationWindowDuration { get { throw null; } set { } }
        public long? StartTimestamp { get { throw null; } set { } }
        public long? Timescale { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.PresentationTimeRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.PresentationTimeRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.PresentationTimeRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.PresentationTimeRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.PresentationTimeRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.PresentationTimeRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.PresentationTimeRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RectangularWindow : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.RectangularWindow>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.RectangularWindow>
    {
        public RectangularWindow() { }
        public string Height { get { throw null; } set { } }
        public string Left { get { throw null; } set { } }
        public string Top { get { throw null; } set { } }
        public string Width { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.RectangularWindow System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.RectangularWindow>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.RectangularWindow>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.RectangularWindow System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.RectangularWindow>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.RectangularWindow>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.RectangularWindow>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ResourceIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ResourceIdentity>
    {
        public ResourceIdentity(bool useSystemAssignedIdentity) { }
        public string UserAssignedIdentity { get { throw null; } set { } }
        public bool UseSystemAssignedIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ResourceIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ResourceIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.ResourceIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.ResourceIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ResourceIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ResourceIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.ResourceIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RotationSetting : System.IEquatable<Azure.ResourceManager.Media.Models.RotationSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RotationSetting(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.RotationSetting Auto { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.RotationSetting None { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.RotationSetting Rotate0 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.RotationSetting Rotate180 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.RotationSetting Rotate270 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.RotationSetting Rotate90 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.RotationSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.RotationSetting left, Azure.ResourceManager.Media.Models.RotationSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.RotationSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.RotationSetting left, Azure.ResourceManager.Media.Models.RotationSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SelectAudioTrackByAttribute : Azure.ResourceManager.Media.Models.AudioTrackDescriptor, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.SelectAudioTrackByAttribute>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.SelectAudioTrackByAttribute>
    {
        public SelectAudioTrackByAttribute(Azure.ResourceManager.Media.Models.TrackAttribute attribute, Azure.ResourceManager.Media.Models.TrackAttributeFilter filter) { }
        public Azure.ResourceManager.Media.Models.TrackAttribute Attribute { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.TrackAttributeFilter Filter { get { throw null; } set { } }
        public string FilterValue { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.SelectAudioTrackByAttribute System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.SelectAudioTrackByAttribute>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.SelectAudioTrackByAttribute>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.SelectAudioTrackByAttribute System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.SelectAudioTrackByAttribute>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.SelectAudioTrackByAttribute>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.SelectAudioTrackByAttribute>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SelectAudioTrackById : Azure.ResourceManager.Media.Models.AudioTrackDescriptor, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.SelectAudioTrackById>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.SelectAudioTrackById>
    {
        public SelectAudioTrackById(long trackId) { }
        public long TrackId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.SelectAudioTrackById System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.SelectAudioTrackById>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.SelectAudioTrackById>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.SelectAudioTrackById System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.SelectAudioTrackById>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.SelectAudioTrackById>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.SelectAudioTrackById>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SelectVideoTrackByAttribute : Azure.ResourceManager.Media.Models.VideoTrackDescriptor, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.SelectVideoTrackByAttribute>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.SelectVideoTrackByAttribute>
    {
        public SelectVideoTrackByAttribute(Azure.ResourceManager.Media.Models.TrackAttribute attribute, Azure.ResourceManager.Media.Models.TrackAttributeFilter filter) { }
        public Azure.ResourceManager.Media.Models.TrackAttribute Attribute { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.TrackAttributeFilter Filter { get { throw null; } set { } }
        public string FilterValue { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.SelectVideoTrackByAttribute System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.SelectVideoTrackByAttribute>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.SelectVideoTrackByAttribute>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.SelectVideoTrackByAttribute System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.SelectVideoTrackByAttribute>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.SelectVideoTrackByAttribute>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.SelectVideoTrackByAttribute>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SelectVideoTrackById : Azure.ResourceManager.Media.Models.VideoTrackDescriptor, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.SelectVideoTrackById>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.SelectVideoTrackById>
    {
        public SelectVideoTrackById(long trackId) { }
        public long TrackId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.SelectVideoTrackById System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.SelectVideoTrackById>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.SelectVideoTrackById>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.SelectVideoTrackById System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.SelectVideoTrackById>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.SelectVideoTrackById>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.SelectVideoTrackById>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandardEncoderPreset : Azure.ResourceManager.Media.Models.MediaTransformPreset, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StandardEncoderPreset>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StandardEncoderPreset>
    {
        public StandardEncoderPreset(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.MediaCodecBase> codecs, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.MediaFormatBase> formats) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaCodecBase> Codecs { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ExperimentalOptions { get { throw null; } }
        public Azure.ResourceManager.Media.Models.FilteringOperations Filters { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaFormatBase> Formats { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StandardEncoderPreset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StandardEncoderPreset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StandardEncoderPreset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StandardEncoderPreset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StandardEncoderPreset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StandardEncoderPreset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StandardEncoderPreset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageEncryptedAssetDecryptionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StorageEncryptedAssetDecryptionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StorageEncryptedAssetDecryptionInfo>
    {
        internal StorageEncryptedAssetDecryptionInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Media.Models.MediaAssetFileEncryptionMetadata> AssetFileEncryptionMetadata { get { throw null; } }
        public byte[] Key { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StorageEncryptedAssetDecryptionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StorageEncryptedAssetDecryptionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StorageEncryptedAssetDecryptionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StorageEncryptedAssetDecryptionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StorageEncryptedAssetDecryptionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StorageEncryptedAssetDecryptionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StorageEncryptedAssetDecryptionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingEndpointAccessControl : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingEndpointAccessControl>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingEndpointAccessControl>
    {
        public StreamingEndpointAccessControl() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.AkamaiSignatureHeaderAuthenticationKey> AkamaiSignatureHeaderAuthenticationKeyList { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.IPRange> AllowedIPs { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingEndpointAccessControl System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingEndpointAccessControl>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingEndpointAccessControl>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingEndpointAccessControl System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingEndpointAccessControl>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingEndpointAccessControl>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingEndpointAccessControl>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingEndpointCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingEndpointCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingEndpointCapacity>
    {
        internal StreamingEndpointCapacity() { }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int? Minimum { get { throw null; } }
        public string ScaleType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingEndpointCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingEndpointCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingEndpointCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingEndpointCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingEndpointCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingEndpointCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingEndpointCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingEndpointCurrentSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingEndpointCurrentSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingEndpointCurrentSku>
    {
        public StreamingEndpointCurrentSku() { }
        public int? Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingEndpointCurrentSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingEndpointCurrentSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingEndpointCurrentSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingEndpointCurrentSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingEndpointCurrentSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingEndpointCurrentSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingEndpointCurrentSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamingEndpointResourceState : System.IEquatable<Azure.ResourceManager.Media.Models.StreamingEndpointResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamingEndpointResourceState(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.StreamingEndpointResourceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingEndpointResourceState Running { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingEndpointResourceState Scaling { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingEndpointResourceState Starting { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingEndpointResourceState Stopped { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingEndpointResourceState Stopping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.StreamingEndpointResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.StreamingEndpointResourceState left, Azure.ResourceManager.Media.Models.StreamingEndpointResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.StreamingEndpointResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.StreamingEndpointResourceState left, Azure.ResourceManager.Media.Models.StreamingEndpointResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StreamingEndpointSkuInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingEndpointSkuInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingEndpointSkuInfo>
    {
        internal StreamingEndpointSkuInfo() { }
        public Azure.ResourceManager.Media.Models.StreamingEndpointCapacity Capacity { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public string SkuName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingEndpointSkuInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingEndpointSkuInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingEndpointSkuInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingEndpointSkuInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingEndpointSkuInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingEndpointSkuInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingEndpointSkuInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingEntityScaleUnit : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingEntityScaleUnit>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingEntityScaleUnit>
    {
        public StreamingEntityScaleUnit() { }
        public int? ScaleUnit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingEntityScaleUnit System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingEntityScaleUnit>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingEntityScaleUnit>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingEntityScaleUnit System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingEntityScaleUnit>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingEntityScaleUnit>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingEntityScaleUnit>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingLocatorContentKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingLocatorContentKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingLocatorContentKey>
    {
        public StreamingLocatorContentKey(System.Guid id) { }
        public System.Guid Id { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType? KeyType { get { throw null; } }
        public string LabelReferenceInStreamingPolicy { get { throw null; } set { } }
        public string PolicyName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Media.Models.MediaTrackSelection> Tracks { get { throw null; } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingLocatorContentKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingLocatorContentKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingLocatorContentKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingLocatorContentKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingLocatorContentKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingLocatorContentKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingLocatorContentKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamingLocatorContentKeyType : System.IEquatable<Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamingLocatorContentKeyType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType CommonEncryptionCbcs { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType CommonEncryptionCenc { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType EnvelopeEncryption { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType left, Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType left, Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StreamingPath : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingPath>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPath>
    {
        internal StreamingPath() { }
        public Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme EncryptionScheme { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Paths { get { throw null; } }
        public Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol StreamingProtocol { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingPath System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingPath>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingPath>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingPath System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPath>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPath>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPath>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamingPathEncryptionScheme : System.IEquatable<Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamingPathEncryptionScheme(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme CommonEncryptionCbcs { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme CommonEncryptionCenc { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme EnvelopeEncryption { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme NoEncryption { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme left, Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme left, Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StreamingPathsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingPathsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPathsResult>
    {
        internal StreamingPathsResult() { }
        public System.Collections.Generic.IReadOnlyList<string> DownloadPaths { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Media.Models.StreamingPath> StreamingPaths { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingPathsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingPathsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingPathsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingPathsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPathsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPathsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPathsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingPolicyContentKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingPolicyContentKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPolicyContentKey>
    {
        public StreamingPolicyContentKey() { }
        public string Label { get { throw null; } set { } }
        public string PolicyName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaTrackSelection> Tracks { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingPolicyContentKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingPolicyContentKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingPolicyContentKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingPolicyContentKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPolicyContentKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPolicyContentKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPolicyContentKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingPolicyContentKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingPolicyContentKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPolicyContentKeys>
    {
        public StreamingPolicyContentKeys() { }
        public Azure.ResourceManager.Media.Models.EncryptionSchemeDefaultKey DefaultKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.StreamingPolicyContentKey> KeyToTrackMappings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingPolicyContentKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingPolicyContentKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingPolicyContentKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingPolicyContentKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPolicyContentKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPolicyContentKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPolicyContentKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingPolicyFairPlayConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingPolicyFairPlayConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPolicyFairPlayConfiguration>
    {
        public StreamingPolicyFairPlayConfiguration(bool allowPersistentLicense) { }
        public bool AllowPersistentLicense { get { throw null; } set { } }
        public string CustomLicenseAcquisitionUriTemplate { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingPolicyFairPlayConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingPolicyFairPlayConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingPolicyFairPlayConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingPolicyFairPlayConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPolicyFairPlayConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPolicyFairPlayConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPolicyFairPlayConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingPolicyPlayReadyConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingPolicyPlayReadyConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPolicyPlayReadyConfiguration>
    {
        public StreamingPolicyPlayReadyConfiguration() { }
        public string CustomLicenseAcquisitionUriTemplate { get { throw null; } set { } }
        public string PlayReadyCustomAttributes { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingPolicyPlayReadyConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingPolicyPlayReadyConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.StreamingPolicyPlayReadyConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.StreamingPolicyPlayReadyConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPolicyPlayReadyConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPolicyPlayReadyConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.StreamingPolicyPlayReadyConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamingPolicyStreamingProtocol : System.IEquatable<Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamingPolicyStreamingProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol Dash { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol Download { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol Hls { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol SmoothStreaming { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol left, Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol left, Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamOptionsFlag : System.IEquatable<Azure.ResourceManager.Media.Models.StreamOptionsFlag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamOptionsFlag(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.StreamOptionsFlag Default { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamOptionsFlag LowLatency { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamOptionsFlag LowLatencyV2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.StreamOptionsFlag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.StreamOptionsFlag left, Azure.ResourceManager.Media.Models.StreamOptionsFlag right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.StreamOptionsFlag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.StreamOptionsFlag left, Azure.ResourceManager.Media.Models.StreamOptionsFlag right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SyncStorageKeysContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.SyncStorageKeysContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.SyncStorageKeysContent>
    {
        public SyncStorageKeysContent() { }
        public string Id { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.SyncStorageKeysContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.SyncStorageKeysContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.SyncStorageKeysContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.SyncStorageKeysContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.SyncStorageKeysContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.SyncStorageKeysContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.SyncStorageKeysContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextTrack : Azure.ResourceManager.Media.Models.MediaAssetTrackBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.TextTrack>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.TextTrack>
    {
        public TextTrack() { }
        public string DisplayName { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.HlsSettings HlsSettings { get { throw null; } set { } }
        public string LanguageCode { get { throw null; } }
        public Azure.ResourceManager.Media.Models.PlayerVisibility? PlayerVisibility { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.TextTrack System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.TextTrack>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.TextTrack>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.TextTrack System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.TextTrack>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.TextTrack>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.TextTrack>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrackAttribute : System.IEquatable<Azure.ResourceManager.Media.Models.TrackAttribute>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrackAttribute(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.TrackAttribute Bitrate { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.TrackAttribute Language { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.TrackAttribute other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.TrackAttribute left, Azure.ResourceManager.Media.Models.TrackAttribute right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.TrackAttribute (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.TrackAttribute left, Azure.ResourceManager.Media.Models.TrackAttribute right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrackAttributeFilter : System.IEquatable<Azure.ResourceManager.Media.Models.TrackAttributeFilter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrackAttributeFilter(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.TrackAttributeFilter All { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.TrackAttributeFilter Bottom { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.TrackAttributeFilter Top { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.TrackAttributeFilter ValueEquals { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.TrackAttributeFilter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.TrackAttributeFilter left, Azure.ResourceManager.Media.Models.TrackAttributeFilter right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.TrackAttributeFilter (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.TrackAttributeFilter left, Azure.ResourceManager.Media.Models.TrackAttributeFilter right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class TrackDescriptor : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.TrackDescriptor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.TrackDescriptor>
    {
        protected TrackDescriptor() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.TrackDescriptor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.TrackDescriptor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.TrackDescriptor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.TrackDescriptor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.TrackDescriptor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.TrackDescriptor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.TrackDescriptor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrackPropertyCompareOperation : System.IEquatable<Azure.ResourceManager.Media.Models.TrackPropertyCompareOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrackPropertyCompareOperation(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.TrackPropertyCompareOperation Equal { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.TrackPropertyCompareOperation Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.TrackPropertyCompareOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.TrackPropertyCompareOperation left, Azure.ResourceManager.Media.Models.TrackPropertyCompareOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.TrackPropertyCompareOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.TrackPropertyCompareOperation left, Azure.ResourceManager.Media.Models.TrackPropertyCompareOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrackPropertyCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.TrackPropertyCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.TrackPropertyCondition>
    {
        public TrackPropertyCondition(Azure.ResourceManager.Media.Models.TrackPropertyType property, Azure.ResourceManager.Media.Models.TrackPropertyCompareOperation operation) { }
        public Azure.ResourceManager.Media.Models.TrackPropertyCompareOperation Operation { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.TrackPropertyType Property { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.TrackPropertyCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.TrackPropertyCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.TrackPropertyCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.TrackPropertyCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.TrackPropertyCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.TrackPropertyCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.TrackPropertyCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrackPropertyType : System.IEquatable<Azure.ResourceManager.Media.Models.TrackPropertyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrackPropertyType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.TrackPropertyType FourCC { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.TrackPropertyType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.TrackPropertyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.TrackPropertyType left, Azure.ResourceManager.Media.Models.TrackPropertyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.TrackPropertyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.TrackPropertyType left, Azure.ResourceManager.Media.Models.TrackPropertyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TransportStreamFormat : Azure.ResourceManager.Media.Models.MultiBitrateFormat, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.TransportStreamFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.TransportStreamFormat>
    {
        public TransportStreamFormat(string filenamePattern) : base (default(string)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.TransportStreamFormat System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.TransportStreamFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.TransportStreamFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.TransportStreamFormat System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.TransportStreamFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.TransportStreamFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.TransportStreamFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UtcClipTime : Azure.ResourceManager.Media.Models.ClipTime, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.UtcClipTime>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.UtcClipTime>
    {
        public UtcClipTime(System.DateTimeOffset time) { }
        public System.DateTimeOffset Time { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.UtcClipTime System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.UtcClipTime>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.UtcClipTime>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.UtcClipTime System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.UtcClipTime>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.UtcClipTime>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.UtcClipTime>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VideoAnalyzerPreset : Azure.ResourceManager.Media.Models.AudioAnalyzerPreset, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.VideoAnalyzerPreset>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.VideoAnalyzerPreset>
    {
        public VideoAnalyzerPreset() { }
        public Azure.ResourceManager.Media.Models.InsightsType? InsightsToExtract { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.VideoAnalyzerPreset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.VideoAnalyzerPreset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.VideoAnalyzerPreset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.VideoAnalyzerPreset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.VideoAnalyzerPreset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.VideoAnalyzerPreset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.VideoAnalyzerPreset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VideoLayer : Azure.ResourceManager.Media.Models.MediaLayerBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.VideoLayer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.VideoLayer>
    {
        public VideoLayer(int bitrate) { }
        public int? BFrames { get { throw null; } set { } }
        public int Bitrate { get { throw null; } set { } }
        public string FrameRate { get { throw null; } set { } }
        public int? MaxBitrate { get { throw null; } set { } }
        public int? Slices { get { throw null; } set { } }
        public bool? UseAdaptiveBFrame { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.VideoLayer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.VideoLayer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.VideoLayer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.VideoLayer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.VideoLayer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.VideoLayer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.VideoLayer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VideoOverlay : Azure.ResourceManager.Media.Models.MediaOverlayBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.VideoOverlay>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.VideoOverlay>
    {
        public VideoOverlay(string inputLabel) : base (default(string)) { }
        public Azure.ResourceManager.Media.Models.RectangularWindow CropRectangle { get { throw null; } set { } }
        public double? Opacity { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.RectangularWindow Position { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.VideoOverlay System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.VideoOverlay>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.VideoOverlay>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.VideoOverlay System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.VideoOverlay>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.VideoOverlay>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.VideoOverlay>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VideoSyncMode : System.IEquatable<Azure.ResourceManager.Media.Models.VideoSyncMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VideoSyncMode(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.VideoSyncMode Auto { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.VideoSyncMode Cfr { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.VideoSyncMode Passthrough { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.VideoSyncMode Vfr { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.VideoSyncMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.VideoSyncMode left, Azure.ResourceManager.Media.Models.VideoSyncMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.VideoSyncMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.VideoSyncMode left, Azure.ResourceManager.Media.Models.VideoSyncMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VideoTrack : Azure.ResourceManager.Media.Models.MediaAssetTrackBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.VideoTrack>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.VideoTrack>
    {
        public VideoTrack() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.VideoTrack System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.VideoTrack>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.VideoTrack>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.VideoTrack System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.VideoTrack>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.VideoTrack>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.VideoTrack>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VideoTrackDescriptor : Azure.ResourceManager.Media.Models.TrackDescriptor, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.VideoTrackDescriptor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.VideoTrackDescriptor>
    {
        public VideoTrackDescriptor() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.VideoTrackDescriptor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.VideoTrackDescriptor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Media.Models.VideoTrackDescriptor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Media.Models.VideoTrackDescriptor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.VideoTrackDescriptor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.VideoTrackDescriptor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Media.Models.VideoTrackDescriptor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
