namespace Azure.ResourceManager.DisconnectedOperations
{
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingResource> GetDisconnectedOperationsHardwareSetting(string hardwareSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingResource>> GetDisconnectedOperationsHardwareSettingAsync(string hardwareSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingCollection GetDisconnectedOperationsHardwareSettings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageResource> GetDisconnectedOperationsImage(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageResource>> GetDisconnectedOperationsImageAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageCollection GetDisconnectedOperationsImages() { throw null; }
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
    public partial class DisconnectedOperationsArtifactCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactResource>, System.Collections.IEnumerable
    {
        protected DisconnectedOperationsArtifactCollection() { }
        public virtual Azure.Response<bool> Exists(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactResource> Get(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactResource>> GetAsync(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactResource> GetIfExists(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactResource>> GetIfExistsAsync(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DisconnectedOperationsArtifactData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactData>
    {
        internal DisconnectedOperationsArtifactData() { }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DisconnectedOperationsArtifactResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DisconnectedOperationsArtifactResource() { }
        public virtual Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string imageName, string artifactName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactDownloadResult> GetDownloadUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactDownloadResult>> GetDownloadUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class DisconnectedOperationsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource> GetDisconnectedOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource>> GetDisconnectedOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource GetDisconnectedOperationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationCollection GetDisconnectedOperations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource> GetDisconnectedOperations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactResource GetDisconnectedOperationsArtifactResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource> GetDisconnectedOperationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingResource GetDisconnectedOperationsHardwareSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageResource GetDisconnectedOperationsImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DisconnectedOperationsHardwareSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingResource>, System.Collections.IEnumerable
    {
        protected DisconnectedOperationsHardwareSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hardwareSettingName, Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hardwareSettingName, Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hardwareSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hardwareSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingResource> Get(string hardwareSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingResource>> GetAsync(string hardwareSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingResource> GetIfExists(string hardwareSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingResource>> GetIfExistsAsync(string hardwareSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DisconnectedOperationsHardwareSettingData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData>
    {
        public DisconnectedOperationsHardwareSettingData() { }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsHardwareSettingProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DisconnectedOperationsHardwareSettingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DisconnectedOperationsHardwareSettingResource() { }
        public virtual Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string hardwareSettingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DisconnectedOperationsImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageResource>, System.Collections.IEnumerable
    {
        protected DisconnectedOperationsImageCollection() { }
        public virtual Azure.Response<bool> Exists(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageResource> Get(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageResource> GetAll(string filter = null, int? maxCount = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageResource> GetAllAsync(string filter = null, int? maxCount = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageResource>> GetAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageResource> GetIfExists(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageResource>> GetIfExistsAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DisconnectedOperationsImageData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageData>
    {
        internal DisconnectedOperationsImageData() { }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DisconnectedOperationsImageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DisconnectedOperationsImageResource() { }
        public virtual Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string imageName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactResource> GetDisconnectedOperationsArtifact(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactResource>> GetDisconnectedOperationsArtifactAsync(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactCollection GetDisconnectedOperationsArtifacts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageDownloadResult> GetDownloadUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageDownloadResult>> GetDownloadUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.DisconnectedOperations.Mocking
{
    public partial class MockableDisconnectedOperationsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDisconnectedOperationsArmClient() { }
        public virtual Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationResource GetDisconnectedOperationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactResource GetDisconnectedOperationsArtifactResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingResource GetDisconnectedOperationsHardwareSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageResource GetDisconnectedOperationsImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public static Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationData DisconnectedOperationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationDeploymentManifest DisconnectedOperationDeploymentManifest(Azure.Core.ResourceIdentifier resourceId = null, string resourceName = null, string stampId = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingModel billingModel = default(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingModel), Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionIntent connectionIntent = default(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionIntent), string cloud = null, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingConfiguration billingConfiguration = null, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlans benefitPlans = null) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationPatch DisconnectedOperationPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties DisconnectedOperationProperties(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState?), string stampId = null, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingModel billingModel = default(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingModel), Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionIntent connectionIntent = default(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionIntent), Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionStatus? connectionStatus = default(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionStatus?), Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsRegistrationStatus? registrationStatus = default(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsRegistrationStatus?), string deviceVersion = null, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingConfiguration billingConfiguration = null, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlans benefitPlans = null) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsArtifactData DisconnectedOperationsArtifactData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactDownloadResult DisconnectedOperationsArtifactDownloadResult(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState?), int artifactOrder = 0, string title = null, string description = null, long? size = default(long?), System.Uri downloadLink = null, System.DateTimeOffset linkExpiresOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactProperties DisconnectedOperationsArtifactProperties(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState?), int artifactOrder = 0, string title = null, string description = null, long? size = default(long?)) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingConfiguration DisconnectedOperationsBillingConfiguration(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsAutoRenew autoRenew = default(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsAutoRenew), Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingStatus billingStatus = default(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingStatus), Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingPeriod current = null, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingPeriod upcoming = null) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingPeriod DisconnectedOperationsBillingPeriod(int cores = 0, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsPricingModel pricingModel = default(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsPricingModel), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsHardwareSettingData DisconnectedOperationsHardwareSettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsHardwareSettingProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsHardwareSettingProperties DisconnectedOperationsHardwareSettingProperties(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState?), int totalCores = 0, int diskSpaceInGb = 0, int memoryInGb = 0, string oem = null, string hardwareSku = null, int nodes = 0, string versionAtRegistration = null, string solutionBuilderExtension = null, System.Guid deviceId = default(System.Guid)) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.DisconnectedOperationsImageData DisconnectedOperationsImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageDownloadResult DisconnectedOperationsImageDownloadResult(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState?), string releaseVersion = null, string releaseDisplayName = null, string releaseNotes = null, System.DateTimeOffset releaseOn = default(System.DateTimeOffset), Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsReleaseType releaseType = default(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsReleaseType), System.Collections.Generic.IEnumerable<string> compatibleVersions = null, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageUpdateProperties updateProperties = null, string transactionId = null, System.Uri downloadLink = null, System.DateTimeOffset linkExpiresOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageProperties DisconnectedOperationsImageProperties(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState?), string releaseVersion = null, string releaseDisplayName = null, string releaseNotes = null, System.DateTimeOffset releaseOn = default(System.DateTimeOffset), Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsReleaseType releaseType = default(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsReleaseType), System.Collections.Generic.IEnumerable<string> compatibleVersions = null, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageUpdateProperties updateProperties = null) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageUpdateProperties DisconnectedOperationsImageUpdateProperties(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsSystemReboot systemReboot = default(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsSystemReboot), string securityUpdates = null, string osVersion = null, string agentVersion = null, string featureUpdates = null) { throw null; }
    }
    public partial class DisconnectedOperationDeploymentManifest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationDeploymentManifest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationDeploymentManifest>
    {
        internal DisconnectedOperationDeploymentManifest() { }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlans BenefitPlans { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingConfiguration BillingConfiguration { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingModel BillingModel { get { throw null; } }
        public string Cloud { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionIntent ConnectionIntent { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string StampId { get { throw null; } }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationDeploymentManifest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationDeploymentManifest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DisconnectedOperationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties>
    {
        public DisconnectedOperationProperties(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionIntent connectionIntent) { }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlans BenefitPlans { get { throw null; } set { } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingConfiguration BillingConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingModel BillingModel { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionIntent ConnectionIntent { get { throw null; } set { } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionStatus? ConnectionStatus { get { throw null; } }
        public string DeviceVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsRegistrationStatus? RegistrationStatus { get { throw null; } set { } }
        public string StampId { get { throw null; } }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DisconnectedOperationsArtifactDownloadResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactDownloadResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactDownloadResult>
    {
        internal DisconnectedOperationsArtifactDownloadResult() { }
        public int ArtifactOrder { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Uri DownloadLink { get { throw null; } }
        public System.DateTimeOffset LinkExpiresOn { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState? ProvisioningState { get { throw null; } }
        public long? Size { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactDownloadResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactDownloadResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactDownloadResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactDownloadResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactDownloadResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactDownloadResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactDownloadResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactDownloadResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactDownloadResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DisconnectedOperationsArtifactProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactProperties>
    {
        internal DisconnectedOperationsArtifactProperties() { }
        public int ArtifactOrder { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState? ProvisioningState { get { throw null; } }
        public long? Size { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsArtifactProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DisconnectedOperationsAutoRenew : System.IEquatable<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsAutoRenew>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DisconnectedOperationsAutoRenew(string value) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsAutoRenew Disabled { get { throw null; } }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsAutoRenew Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsAutoRenew other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsAutoRenew left, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsAutoRenew right) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsAutoRenew (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsAutoRenew? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsAutoRenew left, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsAutoRenew right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DisconnectedOperationsBenefitPlans : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlans>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlans>
    {
        public DisconnectedOperationsBenefitPlans() { }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlanStatus? AzureHybridWindowsServerBenefit { get { throw null; } set { } }
        public int? WindowsServerVmCount { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlans JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlans PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlans System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlans>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlans>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlans System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlans>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlans>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlans>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DisconnectedOperationsBenefitPlanStatus : System.IEquatable<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlanStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DisconnectedOperationsBenefitPlanStatus(string value) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlanStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlanStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlanStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlanStatus left, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlanStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlanStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlanStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlanStatus left, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlanStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DisconnectedOperationsBillingConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingConfiguration>
    {
        public DisconnectedOperationsBillingConfiguration(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsAutoRenew autoRenew, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingPeriod current) { }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsAutoRenew AutoRenew { get { throw null; } set { } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingStatus BillingStatus { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingPeriod Current { get { throw null; } set { } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingPeriod Upcoming { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DisconnectedOperationsBillingModel : System.IEquatable<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DisconnectedOperationsBillingModel(string value) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingModel Capacity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingModel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingModel left, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingModel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingModel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingModel left, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DisconnectedOperationsBillingPeriod : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingPeriod>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingPeriod>
    {
        public DisconnectedOperationsBillingPeriod(int cores, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsPricingModel pricingModel) { }
        public int Cores { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsPricingModel PricingModel { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingPeriod JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingPeriod PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingPeriod System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingPeriod>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingPeriod>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingPeriod System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingPeriod>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingPeriod>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingPeriod>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DisconnectedOperationsBillingStatus : System.IEquatable<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DisconnectedOperationsBillingStatus(string value) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingStatus Enabled { get { throw null; } }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingStatus Stopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingStatus left, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingStatus left, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DisconnectedOperationsConnectionIntent : System.IEquatable<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionIntent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DisconnectedOperationsConnectionIntent(string value) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionIntent Connected { get { throw null; } }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionIntent Disconnected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionIntent other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionIntent left, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionIntent right) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionIntent (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionIntent? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionIntent left, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionIntent right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DisconnectedOperationsConnectionStatus : System.IEquatable<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DisconnectedOperationsConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionStatus Connected { get { throw null; } }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionStatus Disconnected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionStatus left, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionStatus left, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DisconnectedOperationsHardwareSettingProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsHardwareSettingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsHardwareSettingProperties>
    {
        public DisconnectedOperationsHardwareSettingProperties(int totalCores, int diskSpaceInGb, int memoryInGb, string oem, string hardwareSku, int nodes, string versionAtRegistration, string solutionBuilderExtension, System.Guid deviceId) { }
        public System.Guid DeviceId { get { throw null; } set { } }
        public int DiskSpaceInGb { get { throw null; } set { } }
        public string HardwareSku { get { throw null; } set { } }
        public int MemoryInGb { get { throw null; } set { } }
        public int Nodes { get { throw null; } set { } }
        public string Oem { get { throw null; } set { } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string SolutionBuilderExtension { get { throw null; } set { } }
        public int TotalCores { get { throw null; } set { } }
        public string VersionAtRegistration { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsHardwareSettingProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsHardwareSettingProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsHardwareSettingProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsHardwareSettingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsHardwareSettingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsHardwareSettingProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsHardwareSettingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsHardwareSettingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsHardwareSettingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DisconnectedOperationsImageDownloadResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageDownloadResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageDownloadResult>
    {
        internal DisconnectedOperationsImageDownloadResult() { }
        public System.Collections.Generic.IReadOnlyList<string> CompatibleVersions { get { throw null; } }
        public System.Uri DownloadLink { get { throw null; } }
        public System.DateTimeOffset LinkExpiresOn { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string ReleaseDisplayName { get { throw null; } }
        public string ReleaseNotes { get { throw null; } }
        public System.DateTimeOffset ReleaseOn { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsReleaseType ReleaseType { get { throw null; } }
        public string ReleaseVersion { get { throw null; } }
        public string TransactionId { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageUpdateProperties UpdateProperties { get { throw null; } }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageDownloadResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageDownloadResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageDownloadResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageDownloadResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageDownloadResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageDownloadResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageDownloadResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageDownloadResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageDownloadResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DisconnectedOperationsImageProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageProperties>
    {
        internal DisconnectedOperationsImageProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> CompatibleVersions { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string ReleaseDisplayName { get { throw null; } }
        public string ReleaseNotes { get { throw null; } }
        public System.DateTimeOffset ReleaseOn { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsReleaseType ReleaseType { get { throw null; } }
        public string ReleaseVersion { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageUpdateProperties UpdateProperties { get { throw null; } }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DisconnectedOperationsImageUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageUpdateProperties>
    {
        internal DisconnectedOperationsImageUpdateProperties() { }
        public string AgentVersion { get { throw null; } }
        public string FeatureUpdates { get { throw null; } }
        public string OsVersion { get { throw null; } }
        public string SecurityUpdates { get { throw null; } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsSystemReboot SystemReboot { get { throw null; } }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsImageUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DisconnectedOperationsPricingModel : System.IEquatable<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsPricingModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DisconnectedOperationsPricingModel(string value) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsPricingModel Annual { get { throw null; } }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsPricingModel Trial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsPricingModel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsPricingModel left, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsPricingModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsPricingModel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsPricingModel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsPricingModel left, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsPricingModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DisconnectedOperationsRegistrationStatus : System.IEquatable<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsRegistrationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DisconnectedOperationsRegistrationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsRegistrationStatus Registered { get { throw null; } }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsRegistrationStatus Unregistered { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsRegistrationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsRegistrationStatus left, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsRegistrationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsRegistrationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsRegistrationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsRegistrationStatus left, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsRegistrationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DisconnectedOperationsReleaseType : System.IEquatable<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsReleaseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DisconnectedOperationsReleaseType(string value) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsReleaseType Install { get { throw null; } }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsReleaseType Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsReleaseType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsReleaseType left, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsReleaseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsReleaseType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsReleaseType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsReleaseType left, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsReleaseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DisconnectedOperationsResourceProvisioningState : System.IEquatable<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DisconnectedOperationsResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState left, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState left, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DisconnectedOperationsSystemReboot : System.IEquatable<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsSystemReboot>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DisconnectedOperationsSystemReboot(string value) { throw null; }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsSystemReboot NotRequired { get { throw null; } }
        public static Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsSystemReboot Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsSystemReboot other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsSystemReboot left, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsSystemReboot right) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsSystemReboot (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsSystemReboot? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsSystemReboot left, Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsSystemReboot right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DisconnectedOperationUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties>
    {
        public DisconnectedOperationUpdateProperties() { }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBenefitPlans BenefitPlans { get { throw null; } set { } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsBillingConfiguration BillingConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsConnectionIntent? ConnectionIntent { get { throw null; } set { } }
        public string DeviceVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationsRegistrationStatus? RegistrationStatus { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
