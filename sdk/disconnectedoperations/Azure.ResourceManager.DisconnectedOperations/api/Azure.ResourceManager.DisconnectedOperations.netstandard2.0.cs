namespace Azure.ResourceManager.DisconnectedOperations
{
    public partial class ArtifactCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DisconnectedOperations.ArtifactResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DisconnectedOperations.ArtifactResource>, System.Collections.IEnumerable
    {
        protected ArtifactCollection() { }
        public virtual Azure.Response<bool> Exists(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.ArtifactResource> Get(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DisconnectedOperations.ArtifactResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DisconnectedOperations.ArtifactResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.ArtifactResource>> GetAsync(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DisconnectedOperations.ArtifactResource> GetIfExists(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DisconnectedOperations.ArtifactResource>> GetIfExistsAsync(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DisconnectedOperations.ArtifactResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DisconnectedOperations.ArtifactResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DisconnectedOperations.ArtifactResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DisconnectedOperations.ArtifactResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArtifactData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.ArtifactData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.ArtifactData>
    {
        internal ArtifactData() { }
        public Azure.ResourceManager.DisconnectedOperations.Models.ArtifactProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.ArtifactData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.ArtifactData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.ArtifactData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.ArtifactData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.ArtifactData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.ArtifactData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.ArtifactData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArtifactResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.ArtifactData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.ArtifactData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArtifactResource() { }
        public virtual Azure.ResourceManager.DisconnectedOperations.ArtifactData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string imageName, string artifactName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.ArtifactResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.ArtifactResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.Models.ArtifactDownloadResult> GetDownloadUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.Models.ArtifactDownloadResult>> GetDownloadUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DisconnectedOperations.ArtifactData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.ArtifactData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.ArtifactData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.ArtifactData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.ArtifactData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.ArtifactData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.ArtifactData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureResourceManagerDisconnectedOperationsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDisconnectedOperationsContext() { }
        public static Azure.ResourceManager.DisconnectedOperations.AzureResourceManagerDisconnectedOperationsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DisconnectedOperationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource>, System.Collections.IEnumerable
    {
        protected DisconnectedOperationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DisconnectedOperationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationData>
    {
        public DisconnectedOperationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DisconnectedOperationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DisconnectedOperationResource() { }
        public virtual Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationDeploymentManifest> GetDeploymentManifest(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationDeploymentManifest>> GetDeploymentManifestAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.ImageResource> GetImage(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.ImageResource>> GetImageAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DisconnectedOperations.ImageCollection GetImages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource> Update(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource>> UpdateAsync(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DisconnectedOperationsExtensions
    {
        public static Azure.ResourceManager.DisconnectedOperations.ArtifactResource GetArtifactResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource> GetDisconnectedOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource>> GetDisconnectedOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource GetDisconnectedOperationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationCollection GetDisconnectedOperations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource> GetDisconnectedOperations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource> GetDisconnectedOperationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.ImageResource GetImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DisconnectedOperations.ImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DisconnectedOperations.ImageResource>, System.Collections.IEnumerable
    {
        protected ImageCollection() { }
        public virtual Azure.Response<bool> Exists(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.ImageResource> Get(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DisconnectedOperations.ImageResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DisconnectedOperations.ImageResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.ImageResource>> GetAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DisconnectedOperations.ImageResource> GetIfExists(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DisconnectedOperations.ImageResource>> GetIfExistsAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DisconnectedOperations.ImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DisconnectedOperations.ImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DisconnectedOperations.ImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DisconnectedOperations.ImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ImageData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.ImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.ImageData>
    {
        internal ImageData() { }
        public Azure.ResourceManager.DisconnectedOperations.Models.ImageProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.ImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.ImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.ImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.ImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.ImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.ImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.ImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.ImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.ImageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ImageResource() { }
        public virtual Azure.ResourceManager.DisconnectedOperations.ImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string imageName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.ImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.ArtifactResource> GetArtifact(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.ArtifactResource>> GetArtifactAsync(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DisconnectedOperations.ArtifactCollection GetArtifacts() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.ImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.Models.ImageDownloadResult> GetDownloadUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.Models.ImageDownloadResult>> GetDownloadUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DisconnectedOperations.ImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.ImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.ImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.ImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.ImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.ImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.ImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.DisconnectedOperations.Mocking
{
    public partial class MockableDisconnectedOperationsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDisconnectedOperationsArmClient() { }
        public virtual Azure.ResourceManager.DisconnectedOperations.ArtifactResource GetArtifactResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource GetDisconnectedOperationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DisconnectedOperations.ImageResource GetImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDisconnectedOperationsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDisconnectedOperationsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource> GetDisconnectedOperation(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource>> GetDisconnectedOperationAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationCollection GetDisconnectedOperations() { throw null; }
    }
    public partial class MockableDisconnectedOperationsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDisconnectedOperationsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource> GetDisconnectedOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource> GetDisconnectedOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DisconnectedOperations.Models
{
    public static partial class ArmDisconnectedOperationsModelFactory
    {
        public static Azure.ResourceManager.DisconnectedOperations.ArtifactData ArtifactData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DisconnectedOperations.Models.ArtifactProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.ArtifactDownloadResult ArtifactDownloadResult(Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState?), int artifactOrder = 0, string title = null, string description = null, long? size = default(long?), System.Uri downloadLink = null, System.DateTimeOffset linkExpiry = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.ArtifactProperties ArtifactProperties(Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState?), int artifactOrder = 0, string title = null, string description = null, long? size = default(long?)) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationData DisconnectedOperationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationDeploymentManifest DisconnectedOperationDeploymentManifest(Azure.Core.ResourceIdentifier resourceId = null, string resourceName = null, string stampId = null, string location = null, Azure.ResourceManager.DisconnectedOperations.Models.BillingModel billingModel = default(Azure.ResourceManager.DisconnectedOperations.Models.BillingModel), Azure.ResourceManager.DisconnectedOperations.Models.ConnectionIntent connectionIntent = default(Azure.ResourceManager.DisconnectedOperations.Models.ConnectionIntent), string cloud = null) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties DisconnectedOperationProperties(Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState?), string stampId = null, Azure.ResourceManager.DisconnectedOperations.Models.BillingModel billingModel = default(Azure.ResourceManager.DisconnectedOperations.Models.BillingModel), Azure.ResourceManager.DisconnectedOperations.Models.ConnectionIntent connectionIntent = default(Azure.ResourceManager.DisconnectedOperations.Models.ConnectionIntent), Azure.ResourceManager.DisconnectedOperations.Models.ConnectionStatus? connectionStatus = default(Azure.ResourceManager.DisconnectedOperations.Models.ConnectionStatus?), Azure.ResourceManager.DisconnectedOperations.Models.RegistrationStatus? registrationStatus = default(Azure.ResourceManager.DisconnectedOperations.Models.RegistrationStatus?), string deviceVersion = null) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.ImageData ImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DisconnectedOperations.Models.ImageProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.ImageDownloadResult ImageDownloadResult(Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState?), string releaseVersion = null, string releaseDisplayName = null, string releaseNotes = null, System.DateTimeOffset releaseOn = default(System.DateTimeOffset), Azure.ResourceManager.DisconnectedOperations.Models.ReleaseType releaseType = default(Azure.ResourceManager.DisconnectedOperations.Models.ReleaseType), System.Collections.Generic.IEnumerable<string> compatibleVersions = null, string transactionId = null, System.Uri downloadLink = null, System.DateTimeOffset linkExpiry = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.ImageProperties ImageProperties(Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState?), string releaseVersion = null, string releaseDisplayName = null, string releaseNotes = null, System.DateTimeOffset releaseOn = default(System.DateTimeOffset), Azure.ResourceManager.DisconnectedOperations.Models.ReleaseType releaseType = default(Azure.ResourceManager.DisconnectedOperations.Models.ReleaseType), System.Collections.Generic.IEnumerable<string> compatibleVersions = null) { throw null; }
    }
    public partial class ArtifactDownloadResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.ArtifactDownloadResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.ArtifactDownloadResult>
    {
        internal ArtifactDownloadResult() { }
        public int ArtifactOrder { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Uri DownloadLink { get { throw null; } }
        public System.DateTimeOffset LinkExpiry { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public long? Size { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.ArtifactDownloadResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.ArtifactDownloadResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.ArtifactDownloadResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.ArtifactDownloadResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.ArtifactDownloadResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.ArtifactDownloadResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.ArtifactDownloadResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArtifactProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.ArtifactProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.ArtifactProperties>
    {
        internal ArtifactProperties() { }
        public int ArtifactOrder { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public long? Size { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.ArtifactProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.ArtifactProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.ArtifactProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.ArtifactProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.ArtifactProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.ArtifactProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.ArtifactProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingModel : System.IEquatable<Azure.ResourceManager.DisconnectedOperations.Models.BillingModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingModel(string value) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.BillingModel Capacity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DisconnectedOperations.Models.BillingModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DisconnectedOperations.Models.BillingModel left, Azure.ResourceManager.DisconnectedOperations.Models.BillingModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.BillingModel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DisconnectedOperations.Models.BillingModel left, Azure.ResourceManager.DisconnectedOperations.Models.BillingModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionIntent : System.IEquatable<Azure.ResourceManager.DisconnectedOperations.Models.ConnectionIntent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionIntent(string value) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.ConnectionIntent Connected { get { throw null; } }
        public static Azure.ResourceManager.DisconnectedOperations.Models.ConnectionIntent Disconnected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DisconnectedOperations.Models.ConnectionIntent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DisconnectedOperations.Models.ConnectionIntent left, Azure.ResourceManager.DisconnectedOperations.Models.ConnectionIntent right) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.ConnectionIntent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DisconnectedOperations.Models.ConnectionIntent left, Azure.ResourceManager.DisconnectedOperations.Models.ConnectionIntent right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionStatus : System.IEquatable<Azure.ResourceManager.DisconnectedOperations.Models.ConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.ConnectionStatus Connected { get { throw null; } }
        public static Azure.ResourceManager.DisconnectedOperations.Models.ConnectionStatus Disconnected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DisconnectedOperations.Models.ConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DisconnectedOperations.Models.ConnectionStatus left, Azure.ResourceManager.DisconnectedOperations.Models.ConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.ConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DisconnectedOperations.Models.ConnectionStatus left, Azure.ResourceManager.DisconnectedOperations.Models.ConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DisconnectedOperationDeploymentManifest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationDeploymentManifest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationDeploymentManifest>
    {
        internal DisconnectedOperationDeploymentManifest() { }
        public Azure.ResourceManager.DisconnectedOperations.Models.BillingModel BillingModel { get { throw null; } }
        public string Cloud { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.ConnectionIntent ConnectionIntent { get { throw null; } }
        public string Location { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string StampId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationDeploymentManifest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationDeploymentManifest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationDeploymentManifest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationDeploymentManifest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationDeploymentManifest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationDeploymentManifest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationDeploymentManifest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DisconnectedOperationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationPatch>
    {
        public DisconnectedOperationPatch() { }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DisconnectedOperationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties>
    {
        public DisconnectedOperationProperties(string stampId, Azure.ResourceManager.DisconnectedOperations.Models.BillingModel billingModel, Azure.ResourceManager.DisconnectedOperations.Models.ConnectionIntent connectionIntent) { }
        public Azure.ResourceManager.DisconnectedOperations.Models.BillingModel BillingModel { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.ConnectionIntent ConnectionIntent { get { throw null; } set { } }
        public Azure.ResourceManager.DisconnectedOperations.Models.ConnectionStatus? ConnectionStatus { get { throw null; } }
        public string DeviceVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.RegistrationStatus? RegistrationStatus { get { throw null; } set { } }
        public string StampId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DisconnectedOperationUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties>
    {
        public DisconnectedOperationUpdateProperties() { }
        public Azure.ResourceManager.DisconnectedOperations.Models.ConnectionIntent? ConnectionIntent { get { throw null; } set { } }
        public string DeviceVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DisconnectedOperations.Models.RegistrationStatus? RegistrationStatus { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageDownloadResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.ImageDownloadResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.ImageDownloadResult>
    {
        internal ImageDownloadResult() { }
        public System.Collections.Generic.IReadOnlyList<string> CompatibleVersions { get { throw null; } }
        public System.Uri DownloadLink { get { throw null; } }
        public System.DateTimeOffset LinkExpiry { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string ReleaseDisplayName { get { throw null; } }
        public string ReleaseNotes { get { throw null; } }
        public System.DateTimeOffset ReleaseOn { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.ReleaseType ReleaseType { get { throw null; } }
        public string ReleaseVersion { get { throw null; } }
        public string TransactionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.ImageDownloadResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.ImageDownloadResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.ImageDownloadResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.ImageDownloadResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.ImageDownloadResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.ImageDownloadResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.ImageDownloadResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.ImageProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.ImageProperties>
    {
        internal ImageProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> CompatibleVersions { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string ReleaseDisplayName { get { throw null; } }
        public string ReleaseNotes { get { throw null; } }
        public System.DateTimeOffset ReleaseOn { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.ReleaseType ReleaseType { get { throw null; } }
        public string ReleaseVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.ImageProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.ImageProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.ImageProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.ImageProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.ImageProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.ImageProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.ImageProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegistrationStatus : System.IEquatable<Azure.ResourceManager.DisconnectedOperations.Models.RegistrationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegistrationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.RegistrationStatus Registered { get { throw null; } }
        public static Azure.ResourceManager.DisconnectedOperations.Models.RegistrationStatus Unregistered { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DisconnectedOperations.Models.RegistrationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DisconnectedOperations.Models.RegistrationStatus left, Azure.ResourceManager.DisconnectedOperations.Models.RegistrationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.RegistrationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DisconnectedOperations.Models.RegistrationStatus left, Azure.ResourceManager.DisconnectedOperations.Models.RegistrationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReleaseType : System.IEquatable<Azure.ResourceManager.DisconnectedOperations.Models.ReleaseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReleaseType(string value) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.ReleaseType Install { get { throw null; } }
        public static Azure.ResourceManager.DisconnectedOperations.Models.ReleaseType Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DisconnectedOperations.Models.ReleaseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DisconnectedOperations.Models.ReleaseType left, Azure.ResourceManager.DisconnectedOperations.Models.ReleaseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.ReleaseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DisconnectedOperations.Models.ReleaseType left, Azure.ResourceManager.DisconnectedOperations.Models.ReleaseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState left, Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState left, Azure.ResourceManager.DisconnectedOperations.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
