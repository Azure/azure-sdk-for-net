namespace Azure.ResourceManager.Gallery
{
    public partial class CommunityGalleryCollection : Azure.ResourceManager.ArmCollection
    {
        protected CommunityGalleryCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation location, string publicGalleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation location, string publicGalleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.CommunityGalleryResource> Get(Azure.Core.AzureLocation location, string publicGalleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.CommunityGalleryResource>> GetAsync(Azure.Core.AzureLocation location, string publicGalleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Gallery.CommunityGalleryResource> GetIfExists(Azure.Core.AzureLocation location, string publicGalleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Gallery.CommunityGalleryResource>> GetIfExistsAsync(Azure.Core.AzureLocation location, string publicGalleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommunityGalleryData : Azure.ResourceManager.Gallery.Models.PirCommunityGalleryResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.CommunityGalleryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryData>
    {
        internal CommunityGalleryData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ArtifactTags { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.CommunityGalleryMetadata CommunityMetadata { get { throw null; } }
        public string Disclaimer { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        Azure.ResourceManager.Gallery.CommunityGalleryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.CommunityGalleryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.CommunityGalleryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.CommunityGalleryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommunityGalleryImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Gallery.CommunityGalleryImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.CommunityGalleryImageResource>, System.Collections.IEnumerable
    {
        protected CommunityGalleryImageCollection() { }
        public virtual Azure.Response<bool> Exists(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.CommunityGalleryImageResource> Get(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Gallery.CommunityGalleryImageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Gallery.CommunityGalleryImageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.CommunityGalleryImageResource>> GetAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Gallery.CommunityGalleryImageResource> GetIfExists(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Gallery.CommunityGalleryImageResource>> GetIfExistsAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Gallery.CommunityGalleryImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Gallery.CommunityGalleryImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Gallery.CommunityGalleryImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.CommunityGalleryImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CommunityGalleryImageData : Azure.ResourceManager.Gallery.Models.PirCommunityGalleryResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.CommunityGalleryImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryImageData>
    {
        internal CommunityGalleryImageData() { }
        public Azure.ResourceManager.Gallery.Models.ArchitectureType? Architecture { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ArtifactTags { get { throw null; } }
        public System.Collections.Generic.IList<string> DisallowedDiskTypes { get { throw null; } }
        public string Disclaimer { get { throw null; } }
        public System.DateTimeOffset? EndOfLifeOn { get { throw null; } }
        public string Eula { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Gallery.Models.GalleryImageFeature> Features { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.HyperVGeneration? HyperVGeneration { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.CommunityGalleryImageIdentifier ImageIdentifier { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.OperatingSystemStateType? OSState { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.SupportedOperatingSystemType? OSType { get { throw null; } }
        public System.Uri PrivacyStatementUri { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.ImagePurchasePlan PurchasePlan { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.RecommendedMachineConfiguration Recommended { get { throw null; } }
        Azure.ResourceManager.Gallery.CommunityGalleryImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.CommunityGalleryImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.CommunityGalleryImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.CommunityGalleryImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommunityGalleryImageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.CommunityGalleryImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryImageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CommunityGalleryImageResource() { }
        public virtual Azure.ResourceManager.Gallery.CommunityGalleryImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string publicGalleryName, string galleryImageName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.CommunityGalleryImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.CommunityGalleryImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionResource> GetCommunityGalleryImageVersion(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionResource>> GetCommunityGalleryImageVersionAsync(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Gallery.CommunityGalleryImageVersionCollection GetCommunityGalleryImageVersions() { throw null; }
        Azure.ResourceManager.Gallery.CommunityGalleryImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.CommunityGalleryImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.CommunityGalleryImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.CommunityGalleryImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommunityGalleryImageVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionResource>, System.Collections.IEnumerable
    {
        protected CommunityGalleryImageVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionResource> Get(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionResource>> GetAsync(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionResource> GetIfExists(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionResource>> GetIfExistsAsync(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CommunityGalleryImageVersionData : Azure.ResourceManager.Gallery.Models.PirCommunityGalleryResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionData>
    {
        internal CommunityGalleryImageVersionData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ArtifactTags { get { throw null; } }
        public string Disclaimer { get { throw null; } }
        public System.DateTimeOffset? EndOfLifeOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public bool? IsExcludedFromLatest { get { throw null; } }
        public System.DateTimeOffset? PublishedOn { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.SharedGalleryImageVersionStorageProfile StorageProfile { get { throw null; } }
        Azure.ResourceManager.Gallery.CommunityGalleryImageVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.CommunityGalleryImageVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommunityGalleryImageVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CommunityGalleryImageVersionResource() { }
        public virtual Azure.ResourceManager.Gallery.CommunityGalleryImageVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string publicGalleryName, string galleryImageName, string galleryImageVersionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Gallery.CommunityGalleryImageVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.CommunityGalleryImageVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryImageVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommunityGalleryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.CommunityGalleryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CommunityGalleryResource() { }
        public virtual Azure.ResourceManager.Gallery.CommunityGalleryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string publicGalleryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.CommunityGalleryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.CommunityGalleryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.CommunityGalleryImageResource> GetCommunityGalleryImage(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.CommunityGalleryImageResource>> GetCommunityGalleryImageAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Gallery.CommunityGalleryImageCollection GetCommunityGalleryImages() { throw null; }
        Azure.ResourceManager.Gallery.CommunityGalleryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.CommunityGalleryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.CommunityGalleryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.CommunityGalleryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.CommunityGalleryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryApplicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Gallery.GalleryApplicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.GalleryApplicationResource>, System.Collections.IEnumerable
    {
        protected GalleryApplicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Gallery.GalleryApplicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string galleryApplicationName, Azure.ResourceManager.Gallery.GalleryApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Gallery.GalleryApplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string galleryApplicationName, Azure.ResourceManager.Gallery.GalleryApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationResource> Get(string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Gallery.GalleryApplicationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Gallery.GalleryApplicationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationResource>> GetAsync(string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Gallery.GalleryApplicationResource> GetIfExists(string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Gallery.GalleryApplicationResource>> GetIfExistsAsync(string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Gallery.GalleryApplicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Gallery.GalleryApplicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Gallery.GalleryApplicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.GalleryApplicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GalleryApplicationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryApplicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryApplicationData>
    {
        public GalleryApplicationData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomAction> CustomActions { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? EndOfLifeOn { get { throw null; } set { } }
        public string Eula { get { throw null; } set { } }
        public System.Uri PrivacyStatementUri { get { throw null; } set { } }
        public System.Uri ReleaseNoteUri { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.SupportedOperatingSystemType? SupportedOSType { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.GalleryApplicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryApplicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryApplicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.GalleryApplicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryApplicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryApplicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryApplicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryApplicationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryApplicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryApplicationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GalleryApplicationResource() { }
        public virtual Azure.ResourceManager.Gallery.GalleryApplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string galleryName, string galleryApplicationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource> GetGalleryApplicationVersion(string galleryApplicationVersionName, Azure.ResourceManager.Gallery.Models.ReplicationStatusType? expand = default(Azure.ResourceManager.Gallery.Models.ReplicationStatusType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource>> GetGalleryApplicationVersionAsync(string galleryApplicationVersionName, Azure.ResourceManager.Gallery.Models.ReplicationStatusType? expand = default(Azure.ResourceManager.Gallery.Models.ReplicationStatusType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Gallery.GalleryApplicationVersionCollection GetGalleryApplicationVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Gallery.GalleryApplicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryApplicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryApplicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.GalleryApplicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryApplicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryApplicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryApplicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Gallery.GalleryApplicationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Gallery.Models.GalleryApplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Gallery.GalleryApplicationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Gallery.Models.GalleryApplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryApplicationVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource>, System.Collections.IEnumerable
    {
        protected GalleryApplicationVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string galleryApplicationVersionName, Azure.ResourceManager.Gallery.GalleryApplicationVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string galleryApplicationVersionName, Azure.ResourceManager.Gallery.GalleryApplicationVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string galleryApplicationVersionName, Azure.ResourceManager.Gallery.Models.ReplicationStatusType? expand = default(Azure.ResourceManager.Gallery.Models.ReplicationStatusType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryApplicationVersionName, Azure.ResourceManager.Gallery.Models.ReplicationStatusType? expand = default(Azure.ResourceManager.Gallery.Models.ReplicationStatusType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource> Get(string galleryApplicationVersionName, Azure.ResourceManager.Gallery.Models.ReplicationStatusType? expand = default(Azure.ResourceManager.Gallery.Models.ReplicationStatusType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource>> GetAsync(string galleryApplicationVersionName, Azure.ResourceManager.Gallery.Models.ReplicationStatusType? expand = default(Azure.ResourceManager.Gallery.Models.ReplicationStatusType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource> GetIfExists(string galleryApplicationVersionName, Azure.ResourceManager.Gallery.Models.ReplicationStatusType? expand = default(Azure.ResourceManager.Gallery.Models.ReplicationStatusType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource>> GetIfExistsAsync(string galleryApplicationVersionName, Azure.ResourceManager.Gallery.Models.ReplicationStatusType? expand = default(Azure.ResourceManager.Gallery.Models.ReplicationStatusType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GalleryApplicationVersionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryApplicationVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryApplicationVersionData>
    {
        public GalleryApplicationVersionData(Azure.Core.AzureLocation location) { }
        public bool? AllowDeletionOfReplicatedLocations { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.GalleryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPublishingProfile PublishingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.ReplicationStatus ReplicationStatus { get { throw null; } }
        Azure.ResourceManager.Gallery.GalleryApplicationVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryApplicationVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryApplicationVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.GalleryApplicationVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryApplicationVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryApplicationVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryApplicationVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryApplicationVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryApplicationVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryApplicationVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GalleryApplicationVersionResource() { }
        public virtual Azure.ResourceManager.Gallery.GalleryApplicationVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string galleryName, string galleryApplicationName, string galleryApplicationVersionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource> Get(Azure.ResourceManager.Gallery.Models.ReplicationStatusType? expand = default(Azure.ResourceManager.Gallery.Models.ReplicationStatusType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource>> GetAsync(Azure.ResourceManager.Gallery.Models.ReplicationStatusType? expand = default(Azure.ResourceManager.Gallery.Models.ReplicationStatusType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Gallery.GalleryApplicationVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryApplicationVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryApplicationVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.GalleryApplicationVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryApplicationVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryApplicationVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryApplicationVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Gallery.GalleryApplicationVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Gallery.GalleryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.GalleryResource>, System.Collections.IEnumerable
    {
        protected GalleryCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Gallery.GalleryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string galleryName, Azure.ResourceManager.Gallery.GalleryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Gallery.GalleryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string galleryName, Azure.ResourceManager.Gallery.GalleryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string galleryName, Azure.ResourceManager.Gallery.Models.SelectPermission? select = default(Azure.ResourceManager.Gallery.Models.SelectPermission?), Azure.ResourceManager.Gallery.Models.GalleryExpand? expand = default(Azure.ResourceManager.Gallery.Models.GalleryExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryName, Azure.ResourceManager.Gallery.Models.SelectPermission? select = default(Azure.ResourceManager.Gallery.Models.SelectPermission?), Azure.ResourceManager.Gallery.Models.GalleryExpand? expand = default(Azure.ResourceManager.Gallery.Models.GalleryExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryResource> Get(string galleryName, Azure.ResourceManager.Gallery.Models.SelectPermission? select = default(Azure.ResourceManager.Gallery.Models.SelectPermission?), Azure.ResourceManager.Gallery.Models.GalleryExpand? expand = default(Azure.ResourceManager.Gallery.Models.GalleryExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Gallery.GalleryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Gallery.GalleryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryResource>> GetAsync(string galleryName, Azure.ResourceManager.Gallery.Models.SelectPermission? select = default(Azure.ResourceManager.Gallery.Models.SelectPermission?), Azure.ResourceManager.Gallery.Models.GalleryExpand? expand = default(Azure.ResourceManager.Gallery.Models.GalleryExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Gallery.GalleryResource> GetIfExists(string galleryName, Azure.ResourceManager.Gallery.Models.SelectPermission? select = default(Azure.ResourceManager.Gallery.Models.SelectPermission?), Azure.ResourceManager.Gallery.Models.GalleryExpand? expand = default(Azure.ResourceManager.Gallery.Models.GalleryExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Gallery.GalleryResource>> GetIfExistsAsync(string galleryName, Azure.ResourceManager.Gallery.Models.SelectPermission? select = default(Azure.ResourceManager.Gallery.Models.SelectPermission?), Azure.ResourceManager.Gallery.Models.GalleryExpand? expand = default(Azure.ResourceManager.Gallery.Models.GalleryExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Gallery.GalleryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Gallery.GalleryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Gallery.GalleryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.GalleryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GalleryData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryData>
    {
        public GalleryData(Azure.Core.AzureLocation location) { }
        public string Description { get { throw null; } set { } }
        public string IdentifierUniqueName { get { throw null; } }
        public bool? IsSoftDeleteEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.GalleryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.SharingProfile SharingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.SharingStatus SharingStatus { get { throw null; } }
        Azure.ResourceManager.Gallery.GalleryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.GalleryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class GalleryExtensions
    {
        public static Azure.ResourceManager.Gallery.CommunityGalleryCollection GetCommunityGalleries(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Gallery.CommunityGalleryResource> GetCommunityGallery(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publicGalleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.CommunityGalleryResource>> GetCommunityGalleryAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publicGalleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Gallery.CommunityGalleryImageResource GetCommunityGalleryImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Gallery.CommunityGalleryImageVersionResource GetCommunityGalleryImageVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Gallery.CommunityGalleryResource GetCommunityGalleryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Gallery.GalleryCollection GetGalleries(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Gallery.GalleryResource> GetGalleries(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Gallery.GalleryResource> GetGalleriesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Gallery.GalleryResource> GetGallery(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string galleryName, Azure.ResourceManager.Gallery.Models.SelectPermission? select = default(Azure.ResourceManager.Gallery.Models.SelectPermission?), Azure.ResourceManager.Gallery.Models.GalleryExpand? expand = default(Azure.ResourceManager.Gallery.Models.GalleryExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Gallery.GalleryApplicationResource GetGalleryApplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Gallery.GalleryApplicationVersionResource GetGalleryApplicationVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryResource>> GetGalleryAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string galleryName, Azure.ResourceManager.Gallery.Models.SelectPermission? select = default(Azure.ResourceManager.Gallery.Models.SelectPermission?), Azure.ResourceManager.Gallery.Models.GalleryExpand? expand = default(Azure.ResourceManager.Gallery.Models.GalleryExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Gallery.GalleryImageResource GetGalleryImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Gallery.GalleryImageVersionResource GetGalleryImageVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Gallery.GalleryResource GetGalleryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Gallery.SharedGalleryCollection GetSharedGalleries(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Gallery.SharedGalleryResource> GetSharedGallery(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string galleryUniqueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.SharedGalleryResource>> GetSharedGalleryAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string galleryUniqueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Gallery.SharedGalleryImageResource GetSharedGalleryImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Gallery.SharedGalleryImageVersionResource GetSharedGalleryImageVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Gallery.SharedGalleryResource GetSharedGalleryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class GalleryImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Gallery.GalleryImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.GalleryImageResource>, System.Collections.IEnumerable
    {
        protected GalleryImageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Gallery.GalleryImageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string galleryImageName, Azure.ResourceManager.Gallery.GalleryImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Gallery.GalleryImageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string galleryImageName, Azure.ResourceManager.Gallery.GalleryImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryImageResource> Get(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Gallery.GalleryImageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Gallery.GalleryImageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryImageResource>> GetAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Gallery.GalleryImageResource> GetIfExists(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Gallery.GalleryImageResource>> GetIfExistsAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Gallery.GalleryImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Gallery.GalleryImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Gallery.GalleryImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.GalleryImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GalleryImageData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryImageData>
    {
        public GalleryImageData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Gallery.Models.ArchitectureType? Architecture { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DisallowedDiskTypes { get { throw null; } }
        public System.DateTimeOffset? EndOfLifeOn { get { throw null; } set { } }
        public string Eula { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Gallery.Models.GalleryImageFeature> Features { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.GalleryImageIdentifier Identifier { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.OperatingSystemStateType? OSState { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.SupportedOperatingSystemType? OSType { get { throw null; } set { } }
        public System.Uri PrivacyStatementUri { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.GalleryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.ImagePurchasePlan PurchasePlan { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.RecommendedMachineConfiguration Recommended { get { throw null; } set { } }
        public System.Uri ReleaseNoteUri { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.GalleryImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.GalleryImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryImageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryImageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GalleryImageResource() { }
        public virtual Azure.ResourceManager.Gallery.GalleryImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryImageResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryImageResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string galleryName, string galleryImageName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryImageVersionResource> GetGalleryImageVersion(string galleryImageVersionName, Azure.ResourceManager.Gallery.Models.ReplicationStatusType? expand = default(Azure.ResourceManager.Gallery.Models.ReplicationStatusType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryImageVersionResource>> GetGalleryImageVersionAsync(string galleryImageVersionName, Azure.ResourceManager.Gallery.Models.ReplicationStatusType? expand = default(Azure.ResourceManager.Gallery.Models.ReplicationStatusType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Gallery.GalleryImageVersionCollection GetGalleryImageVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryImageResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryImageResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryImageResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryImageResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Gallery.GalleryImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.GalleryImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Gallery.GalleryImageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Gallery.Models.GalleryImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Gallery.GalleryImageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Gallery.Models.GalleryImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryImageVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Gallery.GalleryImageVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.GalleryImageVersionResource>, System.Collections.IEnumerable
    {
        protected GalleryImageVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Gallery.GalleryImageVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string galleryImageVersionName, Azure.ResourceManager.Gallery.GalleryImageVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Gallery.GalleryImageVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string galleryImageVersionName, Azure.ResourceManager.Gallery.GalleryImageVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string galleryImageVersionName, Azure.ResourceManager.Gallery.Models.ReplicationStatusType? expand = default(Azure.ResourceManager.Gallery.Models.ReplicationStatusType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryImageVersionName, Azure.ResourceManager.Gallery.Models.ReplicationStatusType? expand = default(Azure.ResourceManager.Gallery.Models.ReplicationStatusType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryImageVersionResource> Get(string galleryImageVersionName, Azure.ResourceManager.Gallery.Models.ReplicationStatusType? expand = default(Azure.ResourceManager.Gallery.Models.ReplicationStatusType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Gallery.GalleryImageVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Gallery.GalleryImageVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryImageVersionResource>> GetAsync(string galleryImageVersionName, Azure.ResourceManager.Gallery.Models.ReplicationStatusType? expand = default(Azure.ResourceManager.Gallery.Models.ReplicationStatusType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Gallery.GalleryImageVersionResource> GetIfExists(string galleryImageVersionName, Azure.ResourceManager.Gallery.Models.ReplicationStatusType? expand = default(Azure.ResourceManager.Gallery.Models.ReplicationStatusType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Gallery.GalleryImageVersionResource>> GetIfExistsAsync(string galleryImageVersionName, Azure.ResourceManager.Gallery.Models.ReplicationStatusType? expand = default(Azure.ResourceManager.Gallery.Models.ReplicationStatusType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Gallery.GalleryImageVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Gallery.GalleryImageVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Gallery.GalleryImageVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.GalleryImageVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GalleryImageVersionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryImageVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryImageVersionData>
    {
        public GalleryImageVersionData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Gallery.Models.GalleryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.GalleryImageVersionPublishingProfile PublishingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.ReplicationStatus ReplicationStatus { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.GalleryImageVersionSafetyProfile SafetyProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.GalleryImageVersionUefiSettings SecurityUefiSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.GalleryImageVersionStorageProfile StorageProfile { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.GalleryImageVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryImageVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryImageVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.GalleryImageVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryImageVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryImageVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryImageVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryImageVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryImageVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryImageVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GalleryImageVersionResource() { }
        public virtual Azure.ResourceManager.Gallery.GalleryImageVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryImageVersionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryImageVersionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryImageVersionResource> Get(Azure.ResourceManager.Gallery.Models.ReplicationStatusType? expand = default(Azure.ResourceManager.Gallery.Models.ReplicationStatusType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryImageVersionResource>> GetAsync(Azure.ResourceManager.Gallery.Models.ReplicationStatusType? expand = default(Azure.ResourceManager.Gallery.Models.ReplicationStatusType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryImageVersionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryImageVersionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryImageVersionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryImageVersionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Gallery.GalleryImageVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryImageVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryImageVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.GalleryImageVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryImageVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryImageVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryImageVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Gallery.GalleryImageVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Gallery.Models.GalleryImageVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Gallery.GalleryImageVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Gallery.Models.GalleryImageVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GalleryResource() { }
        public virtual Azure.ResourceManager.Gallery.GalleryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string galleryName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryResource> Get(Azure.ResourceManager.Gallery.Models.SelectPermission? select = default(Azure.ResourceManager.Gallery.Models.SelectPermission?), Azure.ResourceManager.Gallery.Models.GalleryExpand? expand = default(Azure.ResourceManager.Gallery.Models.GalleryExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryResource>> GetAsync(Azure.ResourceManager.Gallery.Models.SelectPermission? select = default(Azure.ResourceManager.Gallery.Models.SelectPermission?), Azure.ResourceManager.Gallery.Models.GalleryExpand? expand = default(Azure.ResourceManager.Gallery.Models.GalleryExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationResource> GetGalleryApplication(string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryApplicationResource>> GetGalleryApplicationAsync(string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Gallery.GalleryApplicationCollection GetGalleryApplications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryImageResource> GetGalleryImage(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryImageResource>> GetGalleryImageAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Gallery.GalleryImageCollection GetGalleryImages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Gallery.GalleryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.GalleryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.GalleryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.GalleryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Gallery.GalleryResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Gallery.Models.GalleryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Gallery.GalleryResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Gallery.Models.GalleryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Gallery.Models.SharingUpdate> UpdateSharingProfile(Azure.WaitUntil waitUntil, Azure.ResourceManager.Gallery.Models.SharingUpdate sharingUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Gallery.Models.SharingUpdate>> UpdateSharingProfileAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Gallery.Models.SharingUpdate sharingUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SharedGalleryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Gallery.SharedGalleryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.SharedGalleryResource>, System.Collections.IEnumerable
    {
        protected SharedGalleryCollection() { }
        public virtual Azure.Response<bool> Exists(string galleryUniqueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryUniqueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.SharedGalleryResource> Get(string galleryUniqueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Gallery.SharedGalleryResource> GetAll(Azure.ResourceManager.Gallery.Models.SharedToValue? sharedTo = default(Azure.ResourceManager.Gallery.Models.SharedToValue?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Gallery.SharedGalleryResource> GetAllAsync(Azure.ResourceManager.Gallery.Models.SharedToValue? sharedTo = default(Azure.ResourceManager.Gallery.Models.SharedToValue?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.SharedGalleryResource>> GetAsync(string galleryUniqueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Gallery.SharedGalleryResource> GetIfExists(string galleryUniqueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Gallery.SharedGalleryResource>> GetIfExistsAsync(string galleryUniqueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Gallery.SharedGalleryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Gallery.SharedGalleryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Gallery.SharedGalleryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.SharedGalleryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SharedGalleryData : Azure.ResourceManager.Gallery.Models.PirSharedGalleryResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.SharedGalleryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryData>
    {
        internal SharedGalleryData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ArtifactTags { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        Azure.ResourceManager.Gallery.SharedGalleryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.SharedGalleryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.SharedGalleryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.SharedGalleryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharedGalleryImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Gallery.SharedGalleryImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.SharedGalleryImageResource>, System.Collections.IEnumerable
    {
        protected SharedGalleryImageCollection() { }
        public virtual Azure.Response<bool> Exists(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.SharedGalleryImageResource> Get(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Gallery.SharedGalleryImageResource> GetAll(Azure.ResourceManager.Gallery.Models.SharedToValue? sharedTo = default(Azure.ResourceManager.Gallery.Models.SharedToValue?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Gallery.SharedGalleryImageResource> GetAllAsync(Azure.ResourceManager.Gallery.Models.SharedToValue? sharedTo = default(Azure.ResourceManager.Gallery.Models.SharedToValue?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.SharedGalleryImageResource>> GetAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Gallery.SharedGalleryImageResource> GetIfExists(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Gallery.SharedGalleryImageResource>> GetIfExistsAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Gallery.SharedGalleryImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Gallery.SharedGalleryImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Gallery.SharedGalleryImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.SharedGalleryImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SharedGalleryImageData : Azure.ResourceManager.Gallery.Models.PirSharedGalleryResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.SharedGalleryImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryImageData>
    {
        internal SharedGalleryImageData() { }
        public Azure.ResourceManager.Gallery.Models.ArchitectureType? Architecture { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ArtifactTags { get { throw null; } }
        public System.Collections.Generic.IList<string> DisallowedDiskTypes { get { throw null; } }
        public System.DateTimeOffset? EndOfLifeOn { get { throw null; } }
        public string Eula { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Gallery.Models.GalleryImageFeature> Features { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.HyperVGeneration? HyperVGeneration { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.GalleryImageIdentifier Identifier { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.OperatingSystemStateType? OSState { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.SupportedOperatingSystemType? OSType { get { throw null; } }
        public System.Uri PrivacyStatementUri { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.ImagePurchasePlan PurchasePlan { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.RecommendedMachineConfiguration Recommended { get { throw null; } }
        Azure.ResourceManager.Gallery.SharedGalleryImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.SharedGalleryImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.SharedGalleryImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.SharedGalleryImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharedGalleryImageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.SharedGalleryImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryImageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SharedGalleryImageResource() { }
        public virtual Azure.ResourceManager.Gallery.SharedGalleryImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string galleryUniqueName, string galleryImageName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.SharedGalleryImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.SharedGalleryImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.SharedGalleryImageVersionResource> GetSharedGalleryImageVersion(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.SharedGalleryImageVersionResource>> GetSharedGalleryImageVersionAsync(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Gallery.SharedGalleryImageVersionCollection GetSharedGalleryImageVersions() { throw null; }
        Azure.ResourceManager.Gallery.SharedGalleryImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.SharedGalleryImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.SharedGalleryImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.SharedGalleryImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharedGalleryImageVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Gallery.SharedGalleryImageVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.SharedGalleryImageVersionResource>, System.Collections.IEnumerable
    {
        protected SharedGalleryImageVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.SharedGalleryImageVersionResource> Get(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Gallery.SharedGalleryImageVersionResource> GetAll(Azure.ResourceManager.Gallery.Models.SharedToValue? sharedTo = default(Azure.ResourceManager.Gallery.Models.SharedToValue?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Gallery.SharedGalleryImageVersionResource> GetAllAsync(Azure.ResourceManager.Gallery.Models.SharedToValue? sharedTo = default(Azure.ResourceManager.Gallery.Models.SharedToValue?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.SharedGalleryImageVersionResource>> GetAsync(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Gallery.SharedGalleryImageVersionResource> GetIfExists(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Gallery.SharedGalleryImageVersionResource>> GetIfExistsAsync(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Gallery.SharedGalleryImageVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Gallery.SharedGalleryImageVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Gallery.SharedGalleryImageVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.SharedGalleryImageVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SharedGalleryImageVersionData : Azure.ResourceManager.Gallery.Models.PirSharedGalleryResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.SharedGalleryImageVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryImageVersionData>
    {
        internal SharedGalleryImageVersionData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ArtifactTags { get { throw null; } }
        public System.DateTimeOffset? EndOfLifeOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public bool? IsExcludedFromLatest { get { throw null; } }
        public System.DateTimeOffset? PublishedOn { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.SharedGalleryImageVersionStorageProfile StorageProfile { get { throw null; } }
        Azure.ResourceManager.Gallery.SharedGalleryImageVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.SharedGalleryImageVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.SharedGalleryImageVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.SharedGalleryImageVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryImageVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryImageVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryImageVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharedGalleryImageVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.SharedGalleryImageVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryImageVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SharedGalleryImageVersionResource() { }
        public virtual Azure.ResourceManager.Gallery.SharedGalleryImageVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string galleryUniqueName, string galleryImageName, string galleryImageVersionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.SharedGalleryImageVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.SharedGalleryImageVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Gallery.SharedGalleryImageVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.SharedGalleryImageVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.SharedGalleryImageVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.SharedGalleryImageVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryImageVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryImageVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryImageVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharedGalleryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.SharedGalleryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SharedGalleryResource() { }
        public virtual Azure.ResourceManager.Gallery.SharedGalleryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string galleryUniqueName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.SharedGalleryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.SharedGalleryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.SharedGalleryImageResource> GetSharedGalleryImage(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.SharedGalleryImageResource>> GetSharedGalleryImageAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Gallery.SharedGalleryImageCollection GetSharedGalleryImages() { throw null; }
        Azure.ResourceManager.Gallery.SharedGalleryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.SharedGalleryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.SharedGalleryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.SharedGalleryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.SharedGalleryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.Gallery.Mocking
{
    public partial class MockableGalleryArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableGalleryArmClient() { }
        public virtual Azure.ResourceManager.Gallery.CommunityGalleryImageResource GetCommunityGalleryImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Gallery.CommunityGalleryImageVersionResource GetCommunityGalleryImageVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Gallery.CommunityGalleryResource GetCommunityGalleryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Gallery.GalleryApplicationResource GetGalleryApplicationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Gallery.GalleryApplicationVersionResource GetGalleryApplicationVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Gallery.GalleryImageResource GetGalleryImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Gallery.GalleryImageVersionResource GetGalleryImageVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Gallery.GalleryResource GetGalleryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Gallery.SharedGalleryImageResource GetSharedGalleryImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Gallery.SharedGalleryImageVersionResource GetSharedGalleryImageVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Gallery.SharedGalleryResource GetSharedGalleryResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableGalleryResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableGalleryResourceGroupResource() { }
        public virtual Azure.ResourceManager.Gallery.GalleryCollection GetGalleries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.GalleryResource> GetGallery(string galleryName, Azure.ResourceManager.Gallery.Models.SelectPermission? select = default(Azure.ResourceManager.Gallery.Models.SelectPermission?), Azure.ResourceManager.Gallery.Models.GalleryExpand? expand = default(Azure.ResourceManager.Gallery.Models.GalleryExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.GalleryResource>> GetGalleryAsync(string galleryName, Azure.ResourceManager.Gallery.Models.SelectPermission? select = default(Azure.ResourceManager.Gallery.Models.SelectPermission?), Azure.ResourceManager.Gallery.Models.GalleryExpand? expand = default(Azure.ResourceManager.Gallery.Models.GalleryExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableGallerySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableGallerySubscriptionResource() { }
        public virtual Azure.ResourceManager.Gallery.CommunityGalleryCollection GetCommunityGalleries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.CommunityGalleryResource> GetCommunityGallery(Azure.Core.AzureLocation location, string publicGalleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.CommunityGalleryResource>> GetCommunityGalleryAsync(Azure.Core.AzureLocation location, string publicGalleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Gallery.GalleryResource> GetGalleries(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Gallery.GalleryResource> GetGalleriesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Gallery.SharedGalleryCollection GetSharedGalleries(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Gallery.SharedGalleryResource> GetSharedGallery(Azure.Core.AzureLocation location, string galleryUniqueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Gallery.SharedGalleryResource>> GetSharedGalleryAsync(Azure.Core.AzureLocation location, string galleryUniqueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Gallery.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AggregatedReplicationState : System.IEquatable<Azure.ResourceManager.Gallery.Models.AggregatedReplicationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AggregatedReplicationState(string value) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.AggregatedReplicationState Completed { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.AggregatedReplicationState Failed { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.AggregatedReplicationState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.AggregatedReplicationState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Gallery.Models.AggregatedReplicationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Gallery.Models.AggregatedReplicationState left, Azure.ResourceManager.Gallery.Models.AggregatedReplicationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Gallery.Models.AggregatedReplicationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Gallery.Models.AggregatedReplicationState left, Azure.ResourceManager.Gallery.Models.AggregatedReplicationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArchitectureType : System.IEquatable<Azure.ResourceManager.Gallery.Models.ArchitectureType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArchitectureType(string value) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.ArchitectureType Arm64 { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.ArchitectureType X64 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Gallery.Models.ArchitectureType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Gallery.Models.ArchitectureType left, Azure.ResourceManager.Gallery.Models.ArchitectureType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Gallery.Models.ArchitectureType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Gallery.Models.ArchitectureType left, Azure.ResourceManager.Gallery.Models.ArchitectureType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmGalleryModelFactory
    {
        public static Azure.ResourceManager.Gallery.CommunityGalleryData CommunityGalleryData(string name = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), string uniqueId = null, string disclaimer = null, System.Collections.Generic.IReadOnlyDictionary<string, string> artifactTags = null, Azure.ResourceManager.Gallery.Models.CommunityGalleryMetadata communityMetadata = null) { throw null; }
        public static Azure.ResourceManager.Gallery.CommunityGalleryImageData CommunityGalleryImageData(string name = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), string uniqueId = null, Azure.ResourceManager.Gallery.Models.SupportedOperatingSystemType? osType = default(Azure.ResourceManager.Gallery.Models.SupportedOperatingSystemType?), Azure.ResourceManager.Gallery.Models.OperatingSystemStateType? osState = default(Azure.ResourceManager.Gallery.Models.OperatingSystemStateType?), System.DateTimeOffset? endOfLifeOn = default(System.DateTimeOffset?), Azure.ResourceManager.Gallery.Models.CommunityGalleryImageIdentifier imageIdentifier = null, Azure.ResourceManager.Gallery.Models.RecommendedMachineConfiguration recommended = null, System.Collections.Generic.IEnumerable<string> disallowedDiskTypes = null, Azure.ResourceManager.Gallery.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Gallery.Models.HyperVGeneration?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.Models.GalleryImageFeature> features = null, Azure.ResourceManager.Gallery.Models.ImagePurchasePlan purchasePlan = null, Azure.ResourceManager.Gallery.Models.ArchitectureType? architecture = default(Azure.ResourceManager.Gallery.Models.ArchitectureType?), System.Uri privacyStatementUri = null, string eula = null, string disclaimer = null, System.Collections.Generic.IReadOnlyDictionary<string, string> artifactTags = null) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.CommunityGalleryImageIdentifier CommunityGalleryImageIdentifier(string publisher = null, string offer = null, string sku = null) { throw null; }
        public static Azure.ResourceManager.Gallery.CommunityGalleryImageVersionData CommunityGalleryImageVersionData(string name = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), string uniqueId = null, System.DateTimeOffset? publishedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOfLifeOn = default(System.DateTimeOffset?), bool? isExcludedFromLatest = default(bool?), Azure.ResourceManager.Gallery.Models.SharedGalleryImageVersionStorageProfile storageProfile = null, string disclaimer = null, System.Collections.Generic.IReadOnlyDictionary<string, string> artifactTags = null) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.CommunityGalleryInfo CommunityGalleryInfo(string publisherUriString = null, string publisherContact = null, string eula = null, string publicNamePrefix = null, bool? communityGalleryEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> publicNames = null) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.CommunityGalleryMetadata CommunityGalleryMetadata(System.Uri publisherUri = null, string publisherContact = null, string eula = null, System.Collections.Generic.IEnumerable<string> publicNames = null, System.Uri privacyStatementUri = null) { throw null; }
        public static Azure.ResourceManager.Gallery.GalleryApplicationData GalleryApplicationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string description = null, string eula = null, System.Uri privacyStatementUri = null, System.Uri releaseNoteUri = null, System.DateTimeOffset? endOfLifeOn = default(System.DateTimeOffset?), Azure.ResourceManager.Gallery.Models.SupportedOperatingSystemType? supportedOSType = default(Azure.ResourceManager.Gallery.Models.SupportedOperatingSystemType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomAction> customActions = null) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.GalleryApplicationPatch GalleryApplicationPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, string eula = null, System.Uri privacyStatementUri = null, System.Uri releaseNoteUri = null, System.DateTimeOffset? endOfLifeOn = default(System.DateTimeOffset?), Azure.ResourceManager.Gallery.Models.SupportedOperatingSystemType? supportedOSType = default(Azure.ResourceManager.Gallery.Models.SupportedOperatingSystemType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomAction> customActions = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Gallery.GalleryApplicationVersionData GalleryApplicationVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPublishingProfile publishingProfile = null, bool? allowDeletionOfReplicatedLocations = default(bool?), Azure.ResourceManager.Gallery.Models.GalleryProvisioningState? provisioningState = default(Azure.ResourceManager.Gallery.Models.GalleryProvisioningState?), Azure.ResourceManager.Gallery.Models.ReplicationStatus replicationStatus = null) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPatch GalleryApplicationVersionPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPublishingProfile publishingProfile = null, bool? allowDeletionOfReplicatedLocations = default(bool?), Azure.ResourceManager.Gallery.Models.GalleryProvisioningState? provisioningState = default(Azure.ResourceManager.Gallery.Models.GalleryProvisioningState?), Azure.ResourceManager.Gallery.Models.ReplicationStatus replicationStatus = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPublishingProfile GalleryApplicationVersionPublishingProfile(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.Models.TargetRegion> targetRegions = null, int? replicaCount = default(int?), bool? isExcludedFromLatest = default(bool?), System.DateTimeOffset? publishedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOfLifeOn = default(System.DateTimeOffset?), Azure.ResourceManager.Gallery.Models.ImageStorageAccountType? storageAccountType = default(Azure.ResourceManager.Gallery.Models.ImageStorageAccountType?), Azure.ResourceManager.Gallery.Models.GalleryReplicationMode? replicationMode = default(Azure.ResourceManager.Gallery.Models.GalleryReplicationMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.Models.GalleryTargetExtendedLocation> targetExtendedLocations = null, Azure.ResourceManager.Gallery.Models.UserArtifactSource source = null, Azure.ResourceManager.Gallery.Models.UserArtifactManagement manageActions = null, Azure.ResourceManager.Gallery.Models.UserArtifactSettings settings = null, System.Collections.Generic.IDictionary<string, string> advancedSettings = null, bool? enableHealthCheck = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomAction> customActions = null) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.GalleryArtifactPublishingProfileBase GalleryArtifactPublishingProfileBase(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.Models.TargetRegion> targetRegions = null, int? replicaCount = default(int?), bool? isExcludedFromLatest = default(bool?), System.DateTimeOffset? publishedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOfLifeOn = default(System.DateTimeOffset?), Azure.ResourceManager.Gallery.Models.ImageStorageAccountType? storageAccountType = default(Azure.ResourceManager.Gallery.Models.ImageStorageAccountType?), Azure.ResourceManager.Gallery.Models.GalleryReplicationMode? replicationMode = default(Azure.ResourceManager.Gallery.Models.GalleryReplicationMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.Models.GalleryTargetExtendedLocation> targetExtendedLocations = null) { throw null; }
        public static Azure.ResourceManager.Gallery.GalleryData GalleryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string description = null, string identifierUniqueName = null, Azure.ResourceManager.Gallery.Models.GalleryProvisioningState? provisioningState = default(Azure.ResourceManager.Gallery.Models.GalleryProvisioningState?), Azure.ResourceManager.Gallery.Models.SharingProfile sharingProfile = null, bool? isSoftDeleteEnabled = default(bool?), Azure.ResourceManager.Gallery.Models.SharingStatus sharingStatus = null) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.GalleryDataDiskImage GalleryDataDiskImage(int? sizeInGB = default(int?), Azure.ResourceManager.Gallery.Models.HostCaching? hostCaching = default(Azure.ResourceManager.Gallery.Models.HostCaching?), Azure.ResourceManager.Gallery.Models.GalleryDiskImageSource gallerySource = null, int lun = 0) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.GalleryDiskImage GalleryDiskImage(int? sizeInGB = default(int?), Azure.ResourceManager.Gallery.Models.HostCaching? hostCaching = default(Azure.ResourceManager.Gallery.Models.HostCaching?), Azure.ResourceManager.Gallery.Models.GalleryDiskImageSource gallerySource = null) { throw null; }
        public static Azure.ResourceManager.Gallery.GalleryImageData GalleryImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string description = null, string eula = null, System.Uri privacyStatementUri = null, System.Uri releaseNoteUri = null, Azure.ResourceManager.Gallery.Models.SupportedOperatingSystemType? osType = default(Azure.ResourceManager.Gallery.Models.SupportedOperatingSystemType?), Azure.ResourceManager.Gallery.Models.OperatingSystemStateType? osState = default(Azure.ResourceManager.Gallery.Models.OperatingSystemStateType?), Azure.ResourceManager.Gallery.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Gallery.Models.HyperVGeneration?), System.DateTimeOffset? endOfLifeOn = default(System.DateTimeOffset?), Azure.ResourceManager.Gallery.Models.GalleryImageIdentifier identifier = null, Azure.ResourceManager.Gallery.Models.RecommendedMachineConfiguration recommended = null, System.Collections.Generic.IEnumerable<string> disallowedDiskTypes = null, Azure.ResourceManager.Gallery.Models.ImagePurchasePlan purchasePlan = null, Azure.ResourceManager.Gallery.Models.GalleryProvisioningState? provisioningState = default(Azure.ResourceManager.Gallery.Models.GalleryProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.Models.GalleryImageFeature> features = null, Azure.ResourceManager.Gallery.Models.ArchitectureType? architecture = default(Azure.ResourceManager.Gallery.Models.ArchitectureType?)) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.GalleryImagePatch GalleryImagePatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, string eula = null, System.Uri privacyStatementUri = null, System.Uri releaseNoteUri = null, Azure.ResourceManager.Gallery.Models.SupportedOperatingSystemType? osType = default(Azure.ResourceManager.Gallery.Models.SupportedOperatingSystemType?), Azure.ResourceManager.Gallery.Models.OperatingSystemStateType? osState = default(Azure.ResourceManager.Gallery.Models.OperatingSystemStateType?), Azure.ResourceManager.Gallery.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Gallery.Models.HyperVGeneration?), System.DateTimeOffset? endOfLifeOn = default(System.DateTimeOffset?), Azure.ResourceManager.Gallery.Models.GalleryImageIdentifier identifier = null, Azure.ResourceManager.Gallery.Models.RecommendedMachineConfiguration recommended = null, System.Collections.Generic.IEnumerable<string> disallowedDiskTypes = null, Azure.ResourceManager.Gallery.Models.ImagePurchasePlan purchasePlan = null, Azure.ResourceManager.Gallery.Models.GalleryProvisioningState? provisioningState = default(Azure.ResourceManager.Gallery.Models.GalleryProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.Models.GalleryImageFeature> features = null, Azure.ResourceManager.Gallery.Models.ArchitectureType? architecture = default(Azure.ResourceManager.Gallery.Models.ArchitectureType?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Gallery.GalleryImageVersionData GalleryImageVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Gallery.Models.GalleryImageVersionPublishingProfile publishingProfile = null, Azure.ResourceManager.Gallery.Models.GalleryProvisioningState? provisioningState = default(Azure.ResourceManager.Gallery.Models.GalleryProvisioningState?), Azure.ResourceManager.Gallery.Models.GalleryImageVersionStorageProfile storageProfile = null, Azure.ResourceManager.Gallery.Models.GalleryImageVersionSafetyProfile safetyProfile = null, Azure.ResourceManager.Gallery.Models.ReplicationStatus replicationStatus = null, Azure.ResourceManager.Gallery.Models.GalleryImageVersionUefiSettings securityUefiSettings = null) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.GalleryImageVersionPatch GalleryImageVersionPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Gallery.Models.GalleryImageVersionPublishingProfile publishingProfile = null, Azure.ResourceManager.Gallery.Models.GalleryProvisioningState? provisioningState = default(Azure.ResourceManager.Gallery.Models.GalleryProvisioningState?), Azure.ResourceManager.Gallery.Models.GalleryImageVersionStorageProfile storageProfile = null, Azure.ResourceManager.Gallery.Models.GalleryImageVersionSafetyProfile safetyProfile = null, Azure.ResourceManager.Gallery.Models.ReplicationStatus replicationStatus = null, Azure.ResourceManager.Gallery.Models.GalleryImageVersionUefiSettings securityUefiSettings = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolation GalleryImageVersionPolicyViolation(Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolationCategory? category = default(Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolationCategory?), string details = null) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.GalleryImageVersionPublishingProfile GalleryImageVersionPublishingProfile(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.Models.TargetRegion> targetRegions = null, int? replicaCount = default(int?), bool? isExcludedFromLatest = default(bool?), System.DateTimeOffset? publishedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOfLifeOn = default(System.DateTimeOffset?), Azure.ResourceManager.Gallery.Models.ImageStorageAccountType? storageAccountType = default(Azure.ResourceManager.Gallery.Models.ImageStorageAccountType?), Azure.ResourceManager.Gallery.Models.GalleryReplicationMode? replicationMode = default(Azure.ResourceManager.Gallery.Models.GalleryReplicationMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.Models.GalleryTargetExtendedLocation> targetExtendedLocations = null) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.GalleryImageVersionSafetyProfile GalleryImageVersionSafetyProfile(bool? allowDeletionOfReplicatedLocations = default(bool?), bool? isReportedForPolicyViolation = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolation> policyViolations = null) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.GalleryOSDiskImage GalleryOSDiskImage(int? sizeInGB = default(int?), Azure.ResourceManager.Gallery.Models.HostCaching? hostCaching = default(Azure.ResourceManager.Gallery.Models.HostCaching?), Azure.ResourceManager.Gallery.Models.GalleryDiskImageSource gallerySource = null) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.GalleryPatch GalleryPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, string identifierUniqueName = null, Azure.ResourceManager.Gallery.Models.GalleryProvisioningState? provisioningState = default(Azure.ResourceManager.Gallery.Models.GalleryProvisioningState?), Azure.ResourceManager.Gallery.Models.SharingProfile sharingProfile = null, bool? isSoftDeleteEnabled = default(bool?), Azure.ResourceManager.Gallery.Models.SharingStatus sharingStatus = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.PirCommunityGalleryResourceData PirCommunityGalleryResourceData(string name = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), string uniqueId = null) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.PirResourceData PirResourceData(string name = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.PirSharedGalleryResourceData PirSharedGalleryResourceData(string name = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string uniqueId = null) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.RegionalReplicationStatus RegionalReplicationStatus(string region = null, Azure.ResourceManager.Gallery.Models.RegionalReplicationState? state = default(Azure.ResourceManager.Gallery.Models.RegionalReplicationState?), string details = null, int? progress = default(int?)) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.RegionalSharingStatus RegionalSharingStatus(string region = null, Azure.ResourceManager.Gallery.Models.SharingState? state = default(Azure.ResourceManager.Gallery.Models.SharingState?), string details = null) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.ReplicationStatus ReplicationStatus(Azure.ResourceManager.Gallery.Models.AggregatedReplicationState? aggregatedState = default(Azure.ResourceManager.Gallery.Models.AggregatedReplicationState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.Models.RegionalReplicationStatus> summary = null) { throw null; }
        public static Azure.ResourceManager.Gallery.SharedGalleryData SharedGalleryData(string name = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string uniqueId = null, System.Collections.Generic.IReadOnlyDictionary<string, string> artifactTags = null) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.SharedGalleryDataDiskImage SharedGalleryDataDiskImage(int? diskSizeGB = default(int?), Azure.ResourceManager.Gallery.Models.SharedGalleryHostCaching? hostCaching = default(Azure.ResourceManager.Gallery.Models.SharedGalleryHostCaching?), int lun = 0) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.SharedGalleryDiskImage SharedGalleryDiskImage(int? diskSizeGB = default(int?), Azure.ResourceManager.Gallery.Models.SharedGalleryHostCaching? hostCaching = default(Azure.ResourceManager.Gallery.Models.SharedGalleryHostCaching?)) { throw null; }
        public static Azure.ResourceManager.Gallery.SharedGalleryImageData SharedGalleryImageData(string name = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string uniqueId = null, Azure.ResourceManager.Gallery.Models.SupportedOperatingSystemType? osType = default(Azure.ResourceManager.Gallery.Models.SupportedOperatingSystemType?), Azure.ResourceManager.Gallery.Models.OperatingSystemStateType? osState = default(Azure.ResourceManager.Gallery.Models.OperatingSystemStateType?), System.DateTimeOffset? endOfLifeOn = default(System.DateTimeOffset?), Azure.ResourceManager.Gallery.Models.GalleryImageIdentifier identifier = null, Azure.ResourceManager.Gallery.Models.RecommendedMachineConfiguration recommended = null, System.Collections.Generic.IEnumerable<string> disallowedDiskTypes = null, Azure.ResourceManager.Gallery.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Gallery.Models.HyperVGeneration?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.Models.GalleryImageFeature> features = null, Azure.ResourceManager.Gallery.Models.ImagePurchasePlan purchasePlan = null, Azure.ResourceManager.Gallery.Models.ArchitectureType? architecture = default(Azure.ResourceManager.Gallery.Models.ArchitectureType?), System.Uri privacyStatementUri = null, string eula = null, System.Collections.Generic.IReadOnlyDictionary<string, string> artifactTags = null) { throw null; }
        public static Azure.ResourceManager.Gallery.SharedGalleryImageVersionData SharedGalleryImageVersionData(string name = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string uniqueId = null, System.DateTimeOffset? publishedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOfLifeOn = default(System.DateTimeOffset?), bool? isExcludedFromLatest = default(bool?), Azure.ResourceManager.Gallery.Models.SharedGalleryImageVersionStorageProfile storageProfile = null, System.Collections.Generic.IReadOnlyDictionary<string, string> artifactTags = null) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.SharedGalleryImageVersionStorageProfile SharedGalleryImageVersionStorageProfile(Azure.ResourceManager.Gallery.Models.SharedGalleryOSDiskImage osDiskImage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.Models.SharedGalleryDataDiskImage> dataDiskImages = null) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.SharedGalleryOSDiskImage SharedGalleryOSDiskImage(int? diskSizeGB = default(int?), Azure.ResourceManager.Gallery.Models.SharedGalleryHostCaching? hostCaching = default(Azure.ResourceManager.Gallery.Models.SharedGalleryHostCaching?)) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.SharingProfile SharingProfile(Azure.ResourceManager.Gallery.Models.GallerySharingPermissionType? permission = default(Azure.ResourceManager.Gallery.Models.GallerySharingPermissionType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.Models.SharingProfileGroup> groups = null, Azure.ResourceManager.Gallery.Models.CommunityGalleryInfo communityGalleryInfo = null) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.SharingStatus SharingStatus(Azure.ResourceManager.Gallery.Models.SharingState? aggregatedState = default(Azure.ResourceManager.Gallery.Models.SharingState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Gallery.Models.RegionalSharingStatus> summary = null) { throw null; }
    }
    public partial class CommunityGalleryImageIdentifier : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.CommunityGalleryImageIdentifier>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.CommunityGalleryImageIdentifier>
    {
        internal CommunityGalleryImageIdentifier() { }
        public string Offer { get { throw null; } }
        public string Publisher { get { throw null; } }
        public string Sku { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.CommunityGalleryImageIdentifier System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.CommunityGalleryImageIdentifier>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.CommunityGalleryImageIdentifier>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.CommunityGalleryImageIdentifier System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.CommunityGalleryImageIdentifier>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.CommunityGalleryImageIdentifier>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.CommunityGalleryImageIdentifier>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommunityGalleryInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.CommunityGalleryInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.CommunityGalleryInfo>
    {
        public CommunityGalleryInfo() { }
        public bool? CommunityGalleryEnabled { get { throw null; } }
        public string Eula { get { throw null; } set { } }
        public string PublicNamePrefix { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> PublicNames { get { throw null; } }
        public string PublisherContact { get { throw null; } set { } }
        public string PublisherUriString { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.CommunityGalleryInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.CommunityGalleryInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.CommunityGalleryInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.CommunityGalleryInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.CommunityGalleryInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.CommunityGalleryInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.CommunityGalleryInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommunityGalleryMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.CommunityGalleryMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.CommunityGalleryMetadata>
    {
        internal CommunityGalleryMetadata() { }
        public string Eula { get { throw null; } }
        public System.Uri PrivacyStatementUri { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PublicNames { get { throw null; } }
        public string PublisherContact { get { throw null; } }
        public System.Uri PublisherUri { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.CommunityGalleryMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.CommunityGalleryMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.CommunityGalleryMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.CommunityGalleryMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.CommunityGalleryMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.CommunityGalleryMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.CommunityGalleryMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialVmEncryptionType : System.IEquatable<Azure.ResourceManager.Gallery.Models.ConfidentialVmEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialVmEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.ConfidentialVmEncryptionType EncryptedVmGuestStateOnlyWithPmk { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.ConfidentialVmEncryptionType EncryptedWithCmk { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.ConfidentialVmEncryptionType EncryptedWithPmk { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.ConfidentialVmEncryptionType NonPersistedTPM { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Gallery.Models.ConfidentialVmEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Gallery.Models.ConfidentialVmEncryptionType left, Azure.ResourceManager.Gallery.Models.ConfidentialVmEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Gallery.Models.ConfidentialVmEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Gallery.Models.ConfidentialVmEncryptionType left, Azure.ResourceManager.Gallery.Models.ConfidentialVmEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataDiskImageEncryption : Azure.ResourceManager.Gallery.Models.DiskImageEncryption, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.DataDiskImageEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.DataDiskImageEncryption>
    {
        public DataDiskImageEncryption(int lun) { }
        public int Lun { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.DataDiskImageEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.DataDiskImageEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.DataDiskImageEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.DataDiskImageEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.DataDiskImageEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.DataDiskImageEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.DataDiskImageEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskImageEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.DiskImageEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.DiskImageEncryption>
    {
        public DiskImageEncryption() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.DiskImageEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.DiskImageEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.DiskImageEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.DiskImageEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.DiskImageEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.DiskImageEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.DiskImageEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeZoneStorageAccountType : System.IEquatable<Azure.ResourceManager.Gallery.Models.EdgeZoneStorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeZoneStorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.EdgeZoneStorageAccountType PremiumLrs { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.EdgeZoneStorageAccountType StandardLrs { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.EdgeZoneStorageAccountType StandardSsdLrs { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.EdgeZoneStorageAccountType StandardZrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Gallery.Models.EdgeZoneStorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Gallery.Models.EdgeZoneStorageAccountType left, Azure.ResourceManager.Gallery.Models.EdgeZoneStorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Gallery.Models.EdgeZoneStorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Gallery.Models.EdgeZoneStorageAccountType left, Azure.ResourceManager.Gallery.Models.EdgeZoneStorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EncryptionImages : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.EncryptionImages>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.EncryptionImages>
    {
        public EncryptionImages() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Gallery.Models.DataDiskImageEncryption> DataDiskImages { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.OSDiskImageEncryption OSDiskImage { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.EncryptionImages System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.EncryptionImages>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.EncryptionImages>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.EncryptionImages System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.EncryptionImages>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.EncryptionImages>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.EncryptionImages>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryApplicationCustomAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomAction>
    {
        public GalleryApplicationCustomAction(string name, string script) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomActionParameter> Parameters { get { throw null; } }
        public string Script { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryApplicationCustomActionParameter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomActionParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomActionParameter>
    {
        public GalleryApplicationCustomActionParameter(string name) { }
        public string DefaultValue { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? IsRequired { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomActionParameterType? ParameterType { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomActionParameter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomActionParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomActionParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomActionParameter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomActionParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomActionParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomActionParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum GalleryApplicationCustomActionParameterType
    {
        String = 0,
        ConfigurationDataBlob = 1,
        LogOutputBlob = 2,
    }
    public partial class GalleryApplicationPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationPatch>
    {
        public GalleryApplicationPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomAction> CustomActions { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? EndOfLifeOn { get { throw null; } set { } }
        public string Eula { get { throw null; } set { } }
        public System.Uri PrivacyStatementUri { get { throw null; } set { } }
        public System.Uri ReleaseNoteUri { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.SupportedOperatingSystemType? SupportedOSType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.GalleryApplicationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryApplicationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryApplicationVersionPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPatch>
    {
        public GalleryApplicationVersionPatch() { }
        public bool? AllowDeletionOfReplicatedLocations { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.GalleryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPublishingProfile PublishingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.ReplicationStatus ReplicationStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryApplicationVersionPublishingProfile : Azure.ResourceManager.Gallery.Models.GalleryArtifactPublishingProfileBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPublishingProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPublishingProfile>
    {
        public GalleryApplicationVersionPublishingProfile(Azure.ResourceManager.Gallery.Models.UserArtifactSource source) { }
        public System.Collections.Generic.IDictionary<string, string> AdvancedSettings { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Gallery.Models.GalleryApplicationCustomAction> CustomActions { get { throw null; } }
        public bool? EnableHealthCheck { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.UserArtifactManagement ManageActions { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.UserArtifactSettings Settings { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.UserArtifactSource Source { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPublishingProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPublishingProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPublishingProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPublishingProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPublishingProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPublishingProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryApplicationVersionPublishingProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryArtifactPublishingProfileBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactPublishingProfileBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactPublishingProfileBase>
    {
        public GalleryArtifactPublishingProfileBase() { }
        public System.DateTimeOffset? EndOfLifeOn { get { throw null; } set { } }
        public bool? IsExcludedFromLatest { get { throw null; } set { } }
        public System.DateTimeOffset? PublishedOn { get { throw null; } }
        public int? ReplicaCount { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.GalleryReplicationMode? ReplicationMode { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.ImageStorageAccountType? StorageAccountType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Gallery.Models.GalleryTargetExtendedLocation> TargetExtendedLocations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Gallery.Models.TargetRegion> TargetRegions { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.GalleryArtifactPublishingProfileBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactPublishingProfileBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactPublishingProfileBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryArtifactPublishingProfileBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactPublishingProfileBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactPublishingProfileBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactPublishingProfileBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryArtifactSafetyProfileBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactSafetyProfileBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactSafetyProfileBase>
    {
        public GalleryArtifactSafetyProfileBase() { }
        public bool? AllowDeletionOfReplicatedLocations { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.GalleryArtifactSafetyProfileBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactSafetyProfileBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactSafetyProfileBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryArtifactSafetyProfileBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactSafetyProfileBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactSafetyProfileBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactSafetyProfileBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryArtifactVersionFullSource : Azure.ResourceManager.Gallery.Models.GalleryArtifactVersionSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactVersionFullSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactVersionFullSource>
    {
        public GalleryArtifactVersionFullSource() { }
        public string CommunityGalleryImageId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualMachineId { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.GalleryArtifactVersionFullSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactVersionFullSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactVersionFullSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryArtifactVersionFullSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactVersionFullSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactVersionFullSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactVersionFullSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryArtifactVersionSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactVersionSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactVersionSource>
    {
        public GalleryArtifactVersionSource() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.GalleryArtifactVersionSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactVersionSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactVersionSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryArtifactVersionSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactVersionSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactVersionSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryArtifactVersionSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryDataDiskImage : Azure.ResourceManager.Gallery.Models.GalleryDiskImage, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryDataDiskImage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryDataDiskImage>
    {
        public GalleryDataDiskImage(int lun) { }
        public int Lun { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.GalleryDataDiskImage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryDataDiskImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryDataDiskImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryDataDiskImage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryDataDiskImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryDataDiskImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryDataDiskImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryDiskImage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryDiskImage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryDiskImage>
    {
        public GalleryDiskImage() { }
        public Azure.ResourceManager.Gallery.Models.GalleryDiskImageSource GallerySource { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.HostCaching? HostCaching { get { throw null; } set { } }
        public int? SizeInGB { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.GalleryDiskImage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryDiskImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryDiskImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryDiskImage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryDiskImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryDiskImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryDiskImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryDiskImageSource : Azure.ResourceManager.Gallery.Models.GalleryArtifactVersionSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryDiskImageSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryDiskImageSource>
    {
        public GalleryDiskImageSource() { }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.GalleryDiskImageSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryDiskImageSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryDiskImageSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryDiskImageSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryDiskImageSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryDiskImageSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryDiskImageSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GalleryExpand : System.IEquatable<Azure.ResourceManager.Gallery.Models.GalleryExpand>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GalleryExpand(string value) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.GalleryExpand SharingProfileGroups { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Gallery.Models.GalleryExpand other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Gallery.Models.GalleryExpand left, Azure.ResourceManager.Gallery.Models.GalleryExpand right) { throw null; }
        public static implicit operator Azure.ResourceManager.Gallery.Models.GalleryExpand (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Gallery.Models.GalleryExpand left, Azure.ResourceManager.Gallery.Models.GalleryExpand right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GalleryExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryExtendedLocation>
    {
        public GalleryExtendedLocation() { }
        public Azure.ResourceManager.Gallery.Models.GalleryExtendedLocationType? ExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.GalleryExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryExtendedLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryExtendedLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryExtendedLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GalleryExtendedLocationType : System.IEquatable<Azure.ResourceManager.Gallery.Models.GalleryExtendedLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GalleryExtendedLocationType(string value) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.GalleryExtendedLocationType EdgeZone { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.GalleryExtendedLocationType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Gallery.Models.GalleryExtendedLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Gallery.Models.GalleryExtendedLocationType left, Azure.ResourceManager.Gallery.Models.GalleryExtendedLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Gallery.Models.GalleryExtendedLocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Gallery.Models.GalleryExtendedLocationType left, Azure.ResourceManager.Gallery.Models.GalleryExtendedLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GalleryImageFeature : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageFeature>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageFeature>
    {
        public GalleryImageFeature() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.GalleryImageFeature System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageFeature>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageFeature>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryImageFeature System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageFeature>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageFeature>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageFeature>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryImageIdentifier : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageIdentifier>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageIdentifier>
    {
        public GalleryImageIdentifier(string publisher, string offer, string sku) { }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.GalleryImageIdentifier System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageIdentifier>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageIdentifier>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryImageIdentifier System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageIdentifier>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageIdentifier>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageIdentifier>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryImagePatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImagePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImagePatch>
    {
        public GalleryImagePatch() { }
        public Azure.ResourceManager.Gallery.Models.ArchitectureType? Architecture { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DisallowedDiskTypes { get { throw null; } }
        public System.DateTimeOffset? EndOfLifeOn { get { throw null; } set { } }
        public string Eula { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Gallery.Models.GalleryImageFeature> Features { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.GalleryImageIdentifier Identifier { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.OperatingSystemStateType? OSState { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.SupportedOperatingSystemType? OSType { get { throw null; } set { } }
        public System.Uri PrivacyStatementUri { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.GalleryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.ImagePurchasePlan PurchasePlan { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.RecommendedMachineConfiguration Recommended { get { throw null; } set { } }
        public System.Uri ReleaseNoteUri { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.GalleryImagePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImagePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImagePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryImagePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImagePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImagePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImagePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryImageVersionPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPatch>
    {
        public GalleryImageVersionPatch() { }
        public Azure.ResourceManager.Gallery.Models.GalleryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.GalleryImageVersionPublishingProfile PublishingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.ReplicationStatus ReplicationStatus { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.GalleryImageVersionSafetyProfile SafetyProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.GalleryImageVersionUefiSettings SecurityUefiSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.GalleryImageVersionStorageProfile StorageProfile { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.GalleryImageVersionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryImageVersionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryImageVersionPolicyViolation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolation>
    {
        internal GalleryImageVersionPolicyViolation() { }
        public Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolationCategory? Category { get { throw null; } }
        public string Details { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GalleryImageVersionPolicyViolationCategory : System.IEquatable<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolationCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GalleryImageVersionPolicyViolationCategory(string value) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolationCategory CopyrightValidation { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolationCategory ImageFlaggedUnsafe { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolationCategory IPTheft { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolationCategory Other { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolationCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolationCategory left, Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolationCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolationCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolationCategory left, Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolationCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GalleryImageVersionPublishingProfile : Azure.ResourceManager.Gallery.Models.GalleryArtifactPublishingProfileBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPublishingProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPublishingProfile>
    {
        public GalleryImageVersionPublishingProfile() { }
        Azure.ResourceManager.Gallery.Models.GalleryImageVersionPublishingProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPublishingProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPublishingProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryImageVersionPublishingProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPublishingProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPublishingProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPublishingProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryImageVersionSafetyProfile : Azure.ResourceManager.Gallery.Models.GalleryArtifactSafetyProfileBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionSafetyProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionSafetyProfile>
    {
        public GalleryImageVersionSafetyProfile() { }
        public bool? IsReportedForPolicyViolation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Gallery.Models.GalleryImageVersionPolicyViolation> PolicyViolations { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.GalleryImageVersionSafetyProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionSafetyProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionSafetyProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryImageVersionSafetyProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionSafetyProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionSafetyProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionSafetyProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryImageVersionStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionStorageProfile>
    {
        public GalleryImageVersionStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Gallery.Models.GalleryDataDiskImage> DataDiskImages { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.GalleryArtifactVersionFullSource GallerySource { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.GalleryOSDiskImage OSDiskImage { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.GalleryImageVersionStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryImageVersionStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryImageVersionUefiSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionUefiSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionUefiSettings>
    {
        public GalleryImageVersionUefiSettings() { }
        public Azure.ResourceManager.Gallery.Models.UefiKeySignatures AdditionalSignatures { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Gallery.Models.UefiSignatureTemplateName> SignatureTemplateNames { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.GalleryImageVersionUefiSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionUefiSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionUefiSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryImageVersionUefiSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionUefiSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionUefiSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryImageVersionUefiSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryOSDiskImage : Azure.ResourceManager.Gallery.Models.GalleryDiskImage, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryOSDiskImage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryOSDiskImage>
    {
        public GalleryOSDiskImage() { }
        Azure.ResourceManager.Gallery.Models.GalleryOSDiskImage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryOSDiskImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryOSDiskImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryOSDiskImage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryOSDiskImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryOSDiskImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryOSDiskImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryPatch>
    {
        public GalleryPatch() { }
        public string Description { get { throw null; } set { } }
        public string IdentifierUniqueName { get { throw null; } }
        public bool? IsSoftDeleteEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.GalleryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.SharingProfile SharingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.SharingStatus SharingStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.GalleryPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GalleryProvisioningState : System.IEquatable<Azure.ResourceManager.Gallery.Models.GalleryProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GalleryProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.GalleryProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.GalleryProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.GalleryProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.GalleryProvisioningState Migrating { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.GalleryProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.GalleryProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Gallery.Models.GalleryProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Gallery.Models.GalleryProvisioningState left, Azure.ResourceManager.Gallery.Models.GalleryProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Gallery.Models.GalleryProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Gallery.Models.GalleryProvisioningState left, Azure.ResourceManager.Gallery.Models.GalleryProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GalleryReplicationMode : System.IEquatable<Azure.ResourceManager.Gallery.Models.GalleryReplicationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GalleryReplicationMode(string value) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.GalleryReplicationMode Full { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.GalleryReplicationMode Shallow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Gallery.Models.GalleryReplicationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Gallery.Models.GalleryReplicationMode left, Azure.ResourceManager.Gallery.Models.GalleryReplicationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Gallery.Models.GalleryReplicationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Gallery.Models.GalleryReplicationMode left, Azure.ResourceManager.Gallery.Models.GalleryReplicationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GallerySharingPermissionType : System.IEquatable<Azure.ResourceManager.Gallery.Models.GallerySharingPermissionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GallerySharingPermissionType(string value) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.GallerySharingPermissionType Community { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.GallerySharingPermissionType Groups { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.GallerySharingPermissionType Private { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Gallery.Models.GallerySharingPermissionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Gallery.Models.GallerySharingPermissionType left, Azure.ResourceManager.Gallery.Models.GallerySharingPermissionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Gallery.Models.GallerySharingPermissionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Gallery.Models.GallerySharingPermissionType left, Azure.ResourceManager.Gallery.Models.GallerySharingPermissionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GalleryTargetExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryTargetExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryTargetExtendedLocation>
    {
        public GalleryTargetExtendedLocation() { }
        public Azure.ResourceManager.Gallery.Models.EncryptionImages Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.GalleryExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public int? ExtendedLocationReplicaCount { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.EdgeZoneStorageAccountType? GalleryStorageAccountType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.GalleryTargetExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryTargetExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.GalleryTargetExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.GalleryTargetExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryTargetExtendedLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryTargetExtendedLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.GalleryTargetExtendedLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum HostCaching
    {
        None = 0,
        ReadOnly = 1,
        ReadWrite = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HyperVGeneration : System.IEquatable<Azure.ResourceManager.Gallery.Models.HyperVGeneration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HyperVGeneration(string value) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.HyperVGeneration V1 { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.HyperVGeneration V2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Gallery.Models.HyperVGeneration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Gallery.Models.HyperVGeneration left, Azure.ResourceManager.Gallery.Models.HyperVGeneration right) { throw null; }
        public static implicit operator Azure.ResourceManager.Gallery.Models.HyperVGeneration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Gallery.Models.HyperVGeneration left, Azure.ResourceManager.Gallery.Models.HyperVGeneration right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImagePurchasePlan : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.ImagePurchasePlan>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.ImagePurchasePlan>
    {
        public ImagePurchasePlan() { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.ImagePurchasePlan System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.ImagePurchasePlan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.ImagePurchasePlan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.ImagePurchasePlan System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.ImagePurchasePlan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.ImagePurchasePlan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.ImagePurchasePlan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageStorageAccountType : System.IEquatable<Azure.ResourceManager.Gallery.Models.ImageStorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageStorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.ImageStorageAccountType PremiumLrs { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.ImageStorageAccountType StandardLrs { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.ImageStorageAccountType StandardZrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Gallery.Models.ImageStorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Gallery.Models.ImageStorageAccountType left, Azure.ResourceManager.Gallery.Models.ImageStorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Gallery.Models.ImageStorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Gallery.Models.ImageStorageAccountType left, Azure.ResourceManager.Gallery.Models.ImageStorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum OperatingSystemStateType
    {
        Generalized = 0,
        Specialized = 1,
    }
    public partial class OSDiskImageEncryption : Azure.ResourceManager.Gallery.Models.DiskImageEncryption, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.OSDiskImageEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.OSDiskImageEncryption>
    {
        public OSDiskImageEncryption() { }
        public Azure.ResourceManager.Gallery.Models.OSDiskImageSecurityProfile SecurityProfile { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.OSDiskImageEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.OSDiskImageEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.OSDiskImageEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.OSDiskImageEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.OSDiskImageEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.OSDiskImageEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.OSDiskImageEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OSDiskImageSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.OSDiskImageSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.OSDiskImageSecurityProfile>
    {
        public OSDiskImageSecurityProfile() { }
        public Azure.ResourceManager.Gallery.Models.ConfidentialVmEncryptionType? ConfidentialVmEncryptionType { get { throw null; } set { } }
        public string SecureVmDiskEncryptionSetId { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.OSDiskImageSecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.OSDiskImageSecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.OSDiskImageSecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.OSDiskImageSecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.OSDiskImageSecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.OSDiskImageSecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.OSDiskImageSecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PirCommunityGalleryResourceData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.PirCommunityGalleryResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.PirCommunityGalleryResourceData>
    {
        internal PirCommunityGalleryResourceData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public string UniqueId { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.PirCommunityGalleryResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.PirCommunityGalleryResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.PirCommunityGalleryResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.PirCommunityGalleryResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.PirCommunityGalleryResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.PirCommunityGalleryResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.PirCommunityGalleryResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PirResourceData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.PirResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.PirResourceData>
    {
        internal PirResourceData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string Name { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.PirResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.PirResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.PirResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.PirResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.PirResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.PirResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.PirResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PirSharedGalleryResourceData : Azure.ResourceManager.Gallery.Models.PirResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.PirSharedGalleryResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.PirSharedGalleryResourceData>
    {
        internal PirSharedGalleryResourceData() { }
        public string UniqueId { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.PirSharedGalleryResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.PirSharedGalleryResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.PirSharedGalleryResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.PirSharedGalleryResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.PirSharedGalleryResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.PirSharedGalleryResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.PirSharedGalleryResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendedMachineConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.RecommendedMachineConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.RecommendedMachineConfiguration>
    {
        public RecommendedMachineConfiguration() { }
        public Azure.ResourceManager.Gallery.Models.ResourceRange Memory { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.ResourceRange VCpus { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.RecommendedMachineConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.RecommendedMachineConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.RecommendedMachineConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.RecommendedMachineConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.RecommendedMachineConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.RecommendedMachineConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.RecommendedMachineConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegionalReplicationState : System.IEquatable<Azure.ResourceManager.Gallery.Models.RegionalReplicationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegionalReplicationState(string value) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.RegionalReplicationState Completed { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.RegionalReplicationState Failed { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.RegionalReplicationState Replicating { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.RegionalReplicationState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Gallery.Models.RegionalReplicationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Gallery.Models.RegionalReplicationState left, Azure.ResourceManager.Gallery.Models.RegionalReplicationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Gallery.Models.RegionalReplicationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Gallery.Models.RegionalReplicationState left, Azure.ResourceManager.Gallery.Models.RegionalReplicationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegionalReplicationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.RegionalReplicationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.RegionalReplicationStatus>
    {
        internal RegionalReplicationStatus() { }
        public string Details { get { throw null; } }
        public int? Progress { get { throw null; } }
        public string Region { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.RegionalReplicationState? State { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.RegionalReplicationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.RegionalReplicationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.RegionalReplicationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.RegionalReplicationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.RegionalReplicationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.RegionalReplicationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.RegionalReplicationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegionalSharingStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.RegionalSharingStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.RegionalSharingStatus>
    {
        internal RegionalSharingStatus() { }
        public string Details { get { throw null; } }
        public string Region { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.SharingState? State { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.RegionalSharingStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.RegionalSharingStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.RegionalSharingStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.RegionalSharingStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.RegionalSharingStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.RegionalSharingStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.RegionalSharingStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReplicationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.ReplicationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.ReplicationStatus>
    {
        internal ReplicationStatus() { }
        public Azure.ResourceManager.Gallery.Models.AggregatedReplicationState? AggregatedState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Gallery.Models.RegionalReplicationStatus> Summary { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.ReplicationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.ReplicationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.ReplicationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.ReplicationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.ReplicationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.ReplicationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.ReplicationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReplicationStatusType : System.IEquatable<Azure.ResourceManager.Gallery.Models.ReplicationStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReplicationStatusType(string value) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.ReplicationStatusType ReplicationStatus { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.ReplicationStatusType UefiSettings { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Gallery.Models.ReplicationStatusType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Gallery.Models.ReplicationStatusType left, Azure.ResourceManager.Gallery.Models.ReplicationStatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Gallery.Models.ReplicationStatusType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Gallery.Models.ReplicationStatusType left, Azure.ResourceManager.Gallery.Models.ReplicationStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.ResourceRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.ResourceRange>
    {
        public ResourceRange() { }
        public int? Max { get { throw null; } set { } }
        public int? Min { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.ResourceRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.ResourceRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.ResourceRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.ResourceRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.ResourceRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.ResourceRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.ResourceRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SelectPermission : System.IEquatable<Azure.ResourceManager.Gallery.Models.SelectPermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SelectPermission(string value) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.SelectPermission Permissions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Gallery.Models.SelectPermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Gallery.Models.SelectPermission left, Azure.ResourceManager.Gallery.Models.SelectPermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.Gallery.Models.SelectPermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Gallery.Models.SelectPermission left, Azure.ResourceManager.Gallery.Models.SelectPermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SharedGalleryDataDiskImage : Azure.ResourceManager.Gallery.Models.SharedGalleryDiskImage, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharedGalleryDataDiskImage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharedGalleryDataDiskImage>
    {
        internal SharedGalleryDataDiskImage() { }
        public int Lun { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.SharedGalleryDataDiskImage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharedGalleryDataDiskImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharedGalleryDataDiskImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.SharedGalleryDataDiskImage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharedGalleryDataDiskImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharedGalleryDataDiskImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharedGalleryDataDiskImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharedGalleryDiskImage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharedGalleryDiskImage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharedGalleryDiskImage>
    {
        internal SharedGalleryDiskImage() { }
        public int? DiskSizeGB { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.SharedGalleryHostCaching? HostCaching { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.SharedGalleryDiskImage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharedGalleryDiskImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharedGalleryDiskImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.SharedGalleryDiskImage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharedGalleryDiskImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharedGalleryDiskImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharedGalleryDiskImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SharedGalleryHostCaching : System.IEquatable<Azure.ResourceManager.Gallery.Models.SharedGalleryHostCaching>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SharedGalleryHostCaching(string value) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.SharedGalleryHostCaching None { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.SharedGalleryHostCaching ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.SharedGalleryHostCaching ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Gallery.Models.SharedGalleryHostCaching other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Gallery.Models.SharedGalleryHostCaching left, Azure.ResourceManager.Gallery.Models.SharedGalleryHostCaching right) { throw null; }
        public static implicit operator Azure.ResourceManager.Gallery.Models.SharedGalleryHostCaching (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Gallery.Models.SharedGalleryHostCaching left, Azure.ResourceManager.Gallery.Models.SharedGalleryHostCaching right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SharedGalleryImageVersionStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharedGalleryImageVersionStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharedGalleryImageVersionStorageProfile>
    {
        internal SharedGalleryImageVersionStorageProfile() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Gallery.Models.SharedGalleryDataDiskImage> DataDiskImages { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.SharedGalleryOSDiskImage OSDiskImage { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.SharedGalleryImageVersionStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharedGalleryImageVersionStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharedGalleryImageVersionStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.SharedGalleryImageVersionStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharedGalleryImageVersionStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharedGalleryImageVersionStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharedGalleryImageVersionStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharedGalleryOSDiskImage : Azure.ResourceManager.Gallery.Models.SharedGalleryDiskImage, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharedGalleryOSDiskImage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharedGalleryOSDiskImage>
    {
        internal SharedGalleryOSDiskImage() { }
        Azure.ResourceManager.Gallery.Models.SharedGalleryOSDiskImage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharedGalleryOSDiskImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharedGalleryOSDiskImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.SharedGalleryOSDiskImage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharedGalleryOSDiskImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharedGalleryOSDiskImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharedGalleryOSDiskImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SharedToValue : System.IEquatable<Azure.ResourceManager.Gallery.Models.SharedToValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SharedToValue(string value) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.SharedToValue Tenant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Gallery.Models.SharedToValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Gallery.Models.SharedToValue left, Azure.ResourceManager.Gallery.Models.SharedToValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.Gallery.Models.SharedToValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Gallery.Models.SharedToValue left, Azure.ResourceManager.Gallery.Models.SharedToValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SharingProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharingProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharingProfile>
    {
        public SharingProfile() { }
        public Azure.ResourceManager.Gallery.Models.CommunityGalleryInfo CommunityGalleryInfo { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Gallery.Models.SharingProfileGroup> Groups { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.GallerySharingPermissionType? Permission { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.SharingProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharingProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharingProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.SharingProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharingProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharingProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharingProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharingProfileGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharingProfileGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharingProfileGroup>
    {
        public SharingProfileGroup() { }
        public Azure.ResourceManager.Gallery.Models.SharingProfileGroupType? GroupType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Ids { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.SharingProfileGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharingProfileGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharingProfileGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.SharingProfileGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharingProfileGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharingProfileGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharingProfileGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SharingProfileGroupType : System.IEquatable<Azure.ResourceManager.Gallery.Models.SharingProfileGroupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SharingProfileGroupType(string value) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.SharingProfileGroupType AADTenants { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.SharingProfileGroupType Subscriptions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Gallery.Models.SharingProfileGroupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Gallery.Models.SharingProfileGroupType left, Azure.ResourceManager.Gallery.Models.SharingProfileGroupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Gallery.Models.SharingProfileGroupType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Gallery.Models.SharingProfileGroupType left, Azure.ResourceManager.Gallery.Models.SharingProfileGroupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SharingState : System.IEquatable<Azure.ResourceManager.Gallery.Models.SharingState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SharingState(string value) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.SharingState Failed { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.SharingState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.SharingState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.SharingState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Gallery.Models.SharingState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Gallery.Models.SharingState left, Azure.ResourceManager.Gallery.Models.SharingState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Gallery.Models.SharingState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Gallery.Models.SharingState left, Azure.ResourceManager.Gallery.Models.SharingState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SharingStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharingStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharingStatus>
    {
        internal SharingStatus() { }
        public Azure.ResourceManager.Gallery.Models.SharingState? AggregatedState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Gallery.Models.RegionalSharingStatus> Summary { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.SharingStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharingStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharingStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.SharingStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharingStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharingStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharingStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharingUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharingUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharingUpdate>
    {
        public SharingUpdate(Azure.ResourceManager.Gallery.Models.SharingUpdateOperationType operationType) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Gallery.Models.SharingProfileGroup> Groups { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.SharingUpdateOperationType OperationType { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.SharingUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharingUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.SharingUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.SharingUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharingUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharingUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.SharingUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SharingUpdateOperationType : System.IEquatable<Azure.ResourceManager.Gallery.Models.SharingUpdateOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SharingUpdateOperationType(string value) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.SharingUpdateOperationType Add { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.SharingUpdateOperationType EnableCommunity { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.SharingUpdateOperationType Remove { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.SharingUpdateOperationType Reset { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Gallery.Models.SharingUpdateOperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Gallery.Models.SharingUpdateOperationType left, Azure.ResourceManager.Gallery.Models.SharingUpdateOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Gallery.Models.SharingUpdateOperationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Gallery.Models.SharingUpdateOperationType left, Azure.ResourceManager.Gallery.Models.SharingUpdateOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SupportedOperatingSystemType
    {
        Windows = 0,
        Linux = 1,
    }
    public partial class TargetRegion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.TargetRegion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.TargetRegion>
    {
        public TargetRegion(string name) { }
        public Azure.ResourceManager.Gallery.Models.EncryptionImages Encryption { get { throw null; } set { } }
        public bool? IsExcludedFromLatest { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int? RegionalReplicaCount { get { throw null; } set { } }
        public Azure.ResourceManager.Gallery.Models.ImageStorageAccountType? StorageAccountType { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.TargetRegion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.TargetRegion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.TargetRegion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.TargetRegion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.TargetRegion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.TargetRegion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.TargetRegion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UefiKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.UefiKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.UefiKey>
    {
        public UefiKey() { }
        public Azure.ResourceManager.Gallery.Models.UefiKeyType? KeyType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Value { get { throw null; } }
        Azure.ResourceManager.Gallery.Models.UefiKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.UefiKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.UefiKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.UefiKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.UefiKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.UefiKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.UefiKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UefiKeySignatures : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.UefiKeySignatures>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.UefiKeySignatures>
    {
        public UefiKeySignatures() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Gallery.Models.UefiKey> Db { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Gallery.Models.UefiKey> Dbx { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Gallery.Models.UefiKey> Kek { get { throw null; } }
        public Azure.ResourceManager.Gallery.Models.UefiKey Pk { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.UefiKeySignatures System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.UefiKeySignatures>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.UefiKeySignatures>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.UefiKeySignatures System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.UefiKeySignatures>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.UefiKeySignatures>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.UefiKeySignatures>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UefiKeyType : System.IEquatable<Azure.ResourceManager.Gallery.Models.UefiKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UefiKeyType(string value) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.UefiKeyType Sha256 { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.UefiKeyType X509 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Gallery.Models.UefiKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Gallery.Models.UefiKeyType left, Azure.ResourceManager.Gallery.Models.UefiKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Gallery.Models.UefiKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Gallery.Models.UefiKeyType left, Azure.ResourceManager.Gallery.Models.UefiKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UefiSignatureTemplateName : System.IEquatable<Azure.ResourceManager.Gallery.Models.UefiSignatureTemplateName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UefiSignatureTemplateName(string value) { throw null; }
        public static Azure.ResourceManager.Gallery.Models.UefiSignatureTemplateName MicrosoftUefiCertificateAuthorityTemplate { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.UefiSignatureTemplateName MicrosoftWindowsTemplate { get { throw null; } }
        public static Azure.ResourceManager.Gallery.Models.UefiSignatureTemplateName NoSignatureTemplate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Gallery.Models.UefiSignatureTemplateName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Gallery.Models.UefiSignatureTemplateName left, Azure.ResourceManager.Gallery.Models.UefiSignatureTemplateName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Gallery.Models.UefiSignatureTemplateName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Gallery.Models.UefiSignatureTemplateName left, Azure.ResourceManager.Gallery.Models.UefiSignatureTemplateName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserArtifactManagement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.UserArtifactManagement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.UserArtifactManagement>
    {
        public UserArtifactManagement(string install, string remove) { }
        public string Install { get { throw null; } set { } }
        public string Remove { get { throw null; } set { } }
        public string Update { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.UserArtifactManagement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.UserArtifactManagement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.UserArtifactManagement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.UserArtifactManagement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.UserArtifactManagement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.UserArtifactManagement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.UserArtifactManagement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserArtifactSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.UserArtifactSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.UserArtifactSettings>
    {
        public UserArtifactSettings() { }
        public string ConfigFileName { get { throw null; } set { } }
        public string PackageFileName { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.UserArtifactSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.UserArtifactSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.UserArtifactSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.UserArtifactSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.UserArtifactSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.UserArtifactSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.UserArtifactSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserArtifactSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.UserArtifactSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.UserArtifactSource>
    {
        public UserArtifactSource(string mediaLink) { }
        public string DefaultConfigurationLink { get { throw null; } set { } }
        public string MediaLink { get { throw null; } set { } }
        Azure.ResourceManager.Gallery.Models.UserArtifactSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.UserArtifactSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Gallery.Models.UserArtifactSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Gallery.Models.UserArtifactSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.UserArtifactSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.UserArtifactSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Gallery.Models.UserArtifactSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
