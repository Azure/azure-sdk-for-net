namespace Azure.ResourceManager.ContainerRegistry
{
    public partial class AzureResourceManagerContainerRegistryContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerContainerRegistryContext() { }
        public static Azure.ResourceManager.ContainerRegistry.AzureResourceManagerContainerRegistryContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ConnectedRegistryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource>, System.Collections.IEnumerable
    {
        protected ConnectedRegistryCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectedRegistryName, Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectedRegistryName, Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectedRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectedRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource> Get(string connectedRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource>> GetAsync(string connectedRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource> GetIfExists(string connectedRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource>> GetIfExistsAsync(string connectedRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConnectedRegistryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>
    {
        public ConnectedRegistryData() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus? ActivationStatus { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ClientTokenIds { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState? ConnectionState { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties GarbageCollection { get { throw null; } set { } }
        public System.DateTimeOffset? LastActivityOn { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging Logging { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer LoginServer { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode Mode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NotificationsList { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent Parent { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail> StatusDetails { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedRegistryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConnectedRegistryResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string connectedRegistryName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Deactivate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeactivateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryArchiveCollection : Azure.ResourceManager.ArmCollection
    {
        protected ContainerRegistryArchiveCollection() { }
        public virtual Azure.Response<bool> Exists(string packageType, string archiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string packageType, string archiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveResource> Get(string packageType, string archiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveResource>> GetAsync(string packageType, string archiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveResource> GetIfExists(string packageType, string archiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveResource>> GetIfExistsAsync(string packageType, string archiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryArchiveData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData>
    {
        public ContainerRegistryArchiveData() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ArchiveProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryArchiveResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryArchiveResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string packageType, string archiveName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionResource> GetContainerRegistryArchiveVersion(string archiveVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionResource>> GetContainerRegistryArchiveVersionAsync(string archiveVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionCollection GetContainerRegistryArchiveVersions() { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryArchiveVersionCollection : Azure.ResourceManager.ArmCollection
    {
        protected ContainerRegistryArchiveVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string archiveVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string archiveVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionResource> Get(string archiveVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionResource>> GetAsync(string archiveVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionResource> GetIfExists(string archiveVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionResource>> GetIfExistsAsync(string archiveVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryArchiveVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionData>
    {
        internal ContainerRegistryArchiveVersionData() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ArchiveVersionProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryArchiveVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryArchiveVersionResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string packageType, string archiveName, string archiveVersionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryCacheRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryCacheRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cacheRuleName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cacheRuleName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cacheRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cacheRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource> Get(string cacheRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource>> GetAsync(string cacheRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource> GetIfExists(string cacheRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource>> GetIfExistsAsync(string cacheRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryCacheRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>
    {
        public ContainerRegistryCacheRuleData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string CredentialSetResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public string SourceRepository { get { throw null; } set { } }
        public string TargetRepository { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryCacheRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryCacheRuleResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string cacheRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string registryName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string registryName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> Get(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>> GetAsync(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> GetIfExists(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>> GetIfExistsAsync(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryCredentialSetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryCredentialSetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string credentialSetName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string credentialSetName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string credentialSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string credentialSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource> Get(string credentialSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource>> GetAsync(string credentialSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource> GetIfExists(string credentialSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource>> GetIfExistsAsync(string credentialSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryCredentialSetData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>
    {
        public ContainerRegistryCredentialSetData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential> AuthCredentials { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string LoginServer { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryCredentialSetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryCredentialSetResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string credentialSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>
    {
        public ContainerRegistryData(Azure.Core.AzureLocation location, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku sku) { }
        public bool? AdminUserEnabled { get { throw null; } set { } }
        public bool? AnonymousPullEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope? AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public bool? DataEndpointEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> DataEndpointHostNames { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string LoginServer { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.MetadataSearch? MetadataSearch { get { throw null; } set { } }
        public bool? NetworkRuleBypassAllowedForTasks { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption? NetworkRuleBypassOptions { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies Policies { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode? RoleAssignmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus Status { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy? ZoneRedundancy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ContainerRegistryExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult> CheckContainerRegistryNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult>> CheckContainerRegistryNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveResource> Create(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string registryName, string packageType, string archiveName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionResource> Create(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string registryName, string packageType, string archiveName, string archiveVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveResource>> CreateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string registryName, string packageType, string archiveName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionResource>> CreateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string registryName, string packageType, string archiveName, string archiveVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation Delete(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string registryName, string packageType, string archiveName, string archiveVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation Delete(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string registryName, string packageType, string archiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string registryName, string packageType, string archiveName, string archiveVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string registryName, string packageType, string archiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionResource> GetAll(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string packageType, string archiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveResource> GetAll(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string packageType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerRegistry.Models.OperationDefinition> GetAll(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionResource> GetAllAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string packageType, string archiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveResource> GetAllAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string packageType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.Models.OperationDefinition> GetAllAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource GetConnectedRegistryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryCollection GetContainerRegistries(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> GetContainerRegistries(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> GetContainerRegistriesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> GetContainerRegistry(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveResource GetContainerRegistryArchiveResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionResource GetContainerRegistryArchiveVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>> GetContainerRegistryAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource GetContainerRegistryCacheRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource GetContainerRegistryCredentialSetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataResource GetContainerRegistryPrivateEndpointConnectionDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource GetContainerRegistryReplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource GetContainerRegistryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource GetContainerRegistryTokenResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource GetContainerRegistryWebhookResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ExportPipelineResource GetExportPipelineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ImportPipelineResource GetImportPipelineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.PipelineRunResource GetPipelineRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResource> GetPrivateLinkResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResource>> GetPrivateLinkResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResource> GetPrivateLinkResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResource> GetPrivateLinkResourcesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ScopeMapResource GetScopeMapResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveResource> Update(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string packageType, string archiveName, Azure.ResourceManager.ContainerRegistry.Models.ArchiveUpdateParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveResource>> UpdateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string packageType, string archiveName, Azure.ResourceManager.ContainerRegistry.Models.ArchiveUpdateParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryPrivateEndpointConnectionDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryPrivateEndpointConnectionDataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryPrivateEndpointConnectionDataData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData>
    {
        public ContainerRegistryPrivateEndpointConnectionDataData() { }
        public Azure.ResourceManager.ContainerRegistry.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryPrivateEndpointConnectionDataResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryPrivateEndpointConnectionDataResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryReplicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryReplicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string replicationName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string replicationName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string replicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string replicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> Get(string replicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>> GetAsync(string replicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> GetIfExists(string replicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>> GetIfExistsAsync(string replicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryReplicationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>
    {
        public ContainerRegistryReplicationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ReplicationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryReplicationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryReplicationResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string replicationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult> GenerateCredentials(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult>> GenerateCredentialsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ConnectedRegistryCollection GetConnectedRegistries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource> GetConnectedRegistry(string connectedRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource>> GetConnectedRegistryAsync(string connectedRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveResource> GetContainerRegistryArchive(string packageType, string archiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveResource>> GetContainerRegistryArchiveAsync(string packageType, string archiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveCollection GetContainerRegistryArchives() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource> GetContainerRegistryCacheRule(string cacheRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource>> GetContainerRegistryCacheRuleAsync(string cacheRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleCollection GetContainerRegistryCacheRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource> GetContainerRegistryCredentialSet(string credentialSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource>> GetContainerRegistryCredentialSetAsync(string credentialSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetCollection GetContainerRegistryCredentialSets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataResource> GetContainerRegistryPrivateEndpointConnectionData(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataResource>> GetContainerRegistryPrivateEndpointConnectionDataAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataCollection GetContainerRegistryPrivateEndpointConnectionDatas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> GetContainerRegistryReplication(string replicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>> GetContainerRegistryReplicationAsync(string replicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationCollection GetContainerRegistryReplications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource> GetContainerRegistryToken(string tokenName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource>> GetContainerRegistryTokenAsync(string tokenName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenCollection GetContainerRegistryTokens() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> GetContainerRegistryWebhook(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>> GetContainerRegistryWebhookAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookCollection GetContainerRegistryWebhooks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult> GetCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult>> GetCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ExportPipelineResource> GetExportPipeline(string exportPipelineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ExportPipelineResource>> GetExportPipelineAsync(string exportPipelineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ExportPipelineCollection GetExportPipelines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ImportPipelineResource> GetImportPipeline(string importPipelineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ImportPipelineResource>> GetImportPipelineAsync(string importPipelineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ImportPipelineCollection GetImportPipelines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.PipelineRunResource> GetPipelineRun(string pipelineRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.PipelineRunResource>> GetPipelineRunAsync(string pipelineRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.PipelineRunCollection GetPipelineRuns() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ScopeMapResource> GetScopeMap(string scopeMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ScopeMapResource>> GetScopeMapAsync(string scopeMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ScopeMapCollection GetScopeMaps() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageListResult> GetUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageListResult>> GetUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ImportImage(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageParameters containerRegistryImportImageParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ImportImageAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageParameters containerRegistryImportImageParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult> RegenerateCredential(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult>> RegenerateCredentialAsync(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryTokenCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryTokenCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string tokenName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string tokenName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tokenName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tokenName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource> Get(string tokenName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource>> GetAsync(string tokenName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource> GetIfExists(string tokenName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource>> GetIfExistsAsync(string tokenName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryTokenData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>
    {
        public ContainerRegistryTokenData() { }
        public Azure.ResourceManager.ContainerRegistry.Models.TokenProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTokenResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryTokenResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string tokenName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryWebhookCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryWebhookCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string webhookName, Azure.ResourceManager.ContainerRegistry.Models.WebhookCreateParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string webhookName, Azure.ResourceManager.ContainerRegistry.Models.WebhookCreateParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> Get(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>> GetAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> GetIfExists(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>> GetIfExistsAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryWebhookData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>
    {
        internal ContainerRegistryWebhookData() { }
        public Azure.ResourceManager.ContainerRegistry.Models.WebhookProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryWebhookResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryWebhookResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string webhookName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig> GetCallbackConfig(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig>> GetCallbackConfigAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent> GetEvents(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent> GetEventsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo> Ping(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo>> PingAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExportPipelineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ExportPipelineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ExportPipelineResource>, System.Collections.IEnumerable
    {
        protected ExportPipelineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ExportPipelineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string exportPipelineName, Azure.ResourceManager.ContainerRegistry.ExportPipelineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ExportPipelineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string exportPipelineName, Azure.ResourceManager.ContainerRegistry.ExportPipelineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string exportPipelineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string exportPipelineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ExportPipelineResource> Get(string exportPipelineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ExportPipelineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ExportPipelineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ExportPipelineResource>> GetAsync(string exportPipelineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ExportPipelineResource> GetIfExists(string exportPipelineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ExportPipelineResource>> GetIfExistsAsync(string exportPipelineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ExportPipelineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ExportPipelineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ExportPipelineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ExportPipelineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ExportPipelineData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ExportPipelineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ExportPipelineData>
    {
        public ExportPipelineData() { }
        public Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ExportPipelineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ExportPipelineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ExportPipelineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ExportPipelineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ExportPipelineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ExportPipelineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ExportPipelineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportPipelineResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ExportPipelineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ExportPipelineData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExportPipelineResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ExportPipelineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string exportPipelineName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ExportPipelineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ExportPipelineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ExportPipelineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ExportPipelineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ExportPipelineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ExportPipelineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ExportPipelineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ExportPipelineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ExportPipelineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ExportPipelineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.ExportPipelineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ExportPipelineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.ExportPipelineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ImportPipelineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ImportPipelineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ImportPipelineResource>, System.Collections.IEnumerable
    {
        protected ImportPipelineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ImportPipelineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string importPipelineName, Azure.ResourceManager.ContainerRegistry.ImportPipelineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ImportPipelineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string importPipelineName, Azure.ResourceManager.ContainerRegistry.ImportPipelineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string importPipelineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string importPipelineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ImportPipelineResource> Get(string importPipelineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ImportPipelineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ImportPipelineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ImportPipelineResource>> GetAsync(string importPipelineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ImportPipelineResource> GetIfExists(string importPipelineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ImportPipelineResource>> GetIfExistsAsync(string importPipelineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ImportPipelineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ImportPipelineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ImportPipelineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ImportPipelineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ImportPipelineData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ImportPipelineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ImportPipelineData>
    {
        public ImportPipelineData() { }
        public Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ImportPipelineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ImportPipelineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ImportPipelineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ImportPipelineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ImportPipelineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ImportPipelineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ImportPipelineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImportPipelineResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ImportPipelineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ImportPipelineData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ImportPipelineResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ImportPipelineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string importPipelineName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ImportPipelineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ImportPipelineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ImportPipelineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ImportPipelineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ImportPipelineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ImportPipelineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ImportPipelineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ImportPipelineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ImportPipelineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ImportPipelineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.ImportPipelineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ImportPipelineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.ImportPipelineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PipelineRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.PipelineRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.PipelineRunResource>, System.Collections.IEnumerable
    {
        protected PipelineRunCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.PipelineRunResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string pipelineRunName, Azure.ResourceManager.ContainerRegistry.PipelineRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.PipelineRunResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string pipelineRunName, Azure.ResourceManager.ContainerRegistry.PipelineRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string pipelineRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string pipelineRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.PipelineRunResource> Get(string pipelineRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.PipelineRunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.PipelineRunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.PipelineRunResource>> GetAsync(string pipelineRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.PipelineRunResource> GetIfExists(string pipelineRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.PipelineRunResource>> GetIfExistsAsync(string pipelineRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.PipelineRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.PipelineRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.PipelineRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.PipelineRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PipelineRunData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.PipelineRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.PipelineRunData>
    {
        public PipelineRunData() { }
        public Azure.ResourceManager.ContainerRegistry.Models.PipelineRunProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.PipelineRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.PipelineRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.PipelineRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.PipelineRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.PipelineRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.PipelineRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.PipelineRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineRunResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.PipelineRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.PipelineRunData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PipelineRunResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.PipelineRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string pipelineRunName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.PipelineRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.PipelineRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.PipelineRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.PipelineRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.PipelineRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.PipelineRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.PipelineRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.PipelineRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.PipelineRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.PipelineRunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.PipelineRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.PipelineRunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.PipelineRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScopeMapCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ScopeMapResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ScopeMapResource>, System.Collections.IEnumerable
    {
        protected ScopeMapCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ScopeMapResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scopeMapName, Azure.ResourceManager.ContainerRegistry.ScopeMapData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ScopeMapResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scopeMapName, Azure.ResourceManager.ContainerRegistry.ScopeMapData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scopeMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scopeMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ScopeMapResource> Get(string scopeMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ScopeMapResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ScopeMapResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ScopeMapResource>> GetAsync(string scopeMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ScopeMapResource> GetIfExists(string scopeMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ScopeMapResource>> GetIfExistsAsync(string scopeMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ScopeMapResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ScopeMapResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ScopeMapResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ScopeMapResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScopeMapData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>
    {
        public ScopeMapData() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ScopeMapProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ScopeMapData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ScopeMapData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScopeMapResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScopeMapResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ScopeMapData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string scopeMapName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ScopeMapResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ScopeMapResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ScopeMapData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ScopeMapData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ScopeMapResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ScopeMapResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerRegistry.Mocking
{
    public partial class MockableContainerRegistryArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerRegistryArmClient() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource GetConnectedRegistryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveResource GetContainerRegistryArchiveResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionResource GetContainerRegistryArchiveVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource GetContainerRegistryCacheRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource GetContainerRegistryCredentialSetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataResource GetContainerRegistryPrivateEndpointConnectionDataResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource GetContainerRegistryReplicationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource GetContainerRegistryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource GetContainerRegistryTokenResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource GetContainerRegistryWebhookResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ExportPipelineResource GetExportPipelineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ImportPipelineResource GetImportPipelineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.PipelineRunResource GetPipelineRunResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ScopeMapResource GetScopeMapResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableContainerRegistryResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerRegistryResourceGroupResource() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveResource> Create(Azure.WaitUntil waitUntil, string registryName, string packageType, string archiveName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionResource> Create(Azure.WaitUntil waitUntil, string registryName, string packageType, string archiveName, string archiveVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveResource>> CreateAsync(Azure.WaitUntil waitUntil, string registryName, string packageType, string archiveName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionResource>> CreateAsync(Azure.WaitUntil waitUntil, string registryName, string packageType, string archiveName, string archiveVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string registryName, string packageType, string archiveName, string archiveVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string registryName, string packageType, string archiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string registryName, string packageType, string archiveName, string archiveVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string registryName, string packageType, string archiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionResource> GetAll(string registryName, string packageType, string archiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveResource> GetAll(string registryName, string packageType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionResource> GetAllAsync(string registryName, string packageType, string archiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveResource> GetAllAsync(string registryName, string packageType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryCollection GetContainerRegistries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> GetContainerRegistry(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>> GetContainerRegistryAsync(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResource> GetPrivateLinkResource(string registryName, string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResource>> GetPrivateLinkResourceAsync(string registryName, string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResource> GetPrivateLinkResources(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResource> GetPrivateLinkResourcesAsync(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveResource> Update(string registryName, string packageType, string archiveName, Azure.ResourceManager.ContainerRegistry.Models.ArchiveUpdateParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveResource>> UpdateAsync(string registryName, string packageType, string archiveName, Azure.ResourceManager.ContainerRegistry.Models.ArchiveUpdateParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableContainerRegistrySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerRegistrySubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult> CheckContainerRegistryNameAvailability(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult>> CheckContainerRegistryNameAvailabilityAsync(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> GetContainerRegistries(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> GetContainerRegistriesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableContainerRegistryTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerRegistryTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.Models.OperationDefinition> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.Models.OperationDefinition> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerRegistry.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AadAuthenticationAsArmPolicyStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.AadAuthenticationAsArmPolicyStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AadAuthenticationAsArmPolicyStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.AadAuthenticationAsArmPolicyStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.AadAuthenticationAsArmPolicyStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.AadAuthenticationAsArmPolicyStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.AadAuthenticationAsArmPolicyStatus left, Azure.ResourceManager.ContainerRegistry.Models.AadAuthenticationAsArmPolicyStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.AadAuthenticationAsArmPolicyStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.AadAuthenticationAsArmPolicyStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.AadAuthenticationAsArmPolicyStatus left, Azure.ResourceManager.ContainerRegistry.Models.AadAuthenticationAsArmPolicyStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionsRequiredForPrivateLinkServiceConsumer : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ActionsRequiredForPrivateLinkServiceConsumer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionsRequiredForPrivateLinkServiceConsumer(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ActionsRequiredForPrivateLinkServiceConsumer None { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ActionsRequiredForPrivateLinkServiceConsumer Recreate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ActionsRequiredForPrivateLinkServiceConsumer other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ActionsRequiredForPrivateLinkServiceConsumer left, Azure.ResourceManager.ContainerRegistry.Models.ActionsRequiredForPrivateLinkServiceConsumer right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ActionsRequiredForPrivateLinkServiceConsumer (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ActionsRequiredForPrivateLinkServiceConsumer? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ActionsRequiredForPrivateLinkServiceConsumer left, Azure.ResourceManager.ContainerRegistry.Models.ActionsRequiredForPrivateLinkServiceConsumer right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArchivePackageSourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ArchivePackageSourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ArchivePackageSourceProperties>
    {
        public ArchivePackageSourceProperties() { }
        public Azure.ResourceManager.ContainerRegistry.Models.PackageSourceType? Type { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ArchivePackageSourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ArchivePackageSourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ArchivePackageSourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ArchivePackageSourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ArchivePackageSourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ArchivePackageSourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ArchivePackageSourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ArchivePackageSourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ArchivePackageSourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArchiveProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ArchiveProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ArchiveProperties>
    {
        public ArchiveProperties() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ArchivePackageSourceProperties PackageSource { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public string PublishedVersion { get { throw null; } set { } }
        public string RepositoryEndpoint { get { throw null; } }
        public string RepositoryEndpointPrefix { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ArchiveProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ArchiveProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ArchiveProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ArchiveProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ArchiveProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ArchiveProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ArchiveProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ArchiveProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ArchiveProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArchiveUpdateParameters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ArchiveUpdateParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ArchiveUpdateParameters>
    {
        public ArchiveUpdateParameters() { }
        public string PublishedVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ArchiveUpdateParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ArchiveUpdateParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ArchiveUpdateParameters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ArchiveUpdateParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ArchiveUpdateParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ArchiveUpdateParameters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ArchiveUpdateParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ArchiveUpdateParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ArchiveUpdateParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArchiveVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ArchiveVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ArchiveVersionProperties>
    {
        internal ArchiveVersionProperties() { }
        public string ArchiveVersionErrorMessage { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ArchiveVersionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ArchiveVersionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ArchiveVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ArchiveVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ArchiveVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ArchiveVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ArchiveVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ArchiveVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ArchiveVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmContainerRegistryModelFactory
    {
        public static Azure.ResourceManager.ContainerRegistry.Models.ArchiveProperties ArchiveProperties(Azure.ResourceManager.ContainerRegistry.Models.ArchivePackageSourceProperties packageSource = null, string publishedVersion = null, string repositoryEndpointPrefix = null, string repositoryEndpoint = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ArchiveVersionProperties ArchiveVersionProperties(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?), string archiveVersionErrorMessage = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData ConnectedRegistryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?), Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode? mode = default(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode?), string version = null, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState? connectionState = default(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState?), System.DateTimeOffset? lastActivityOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent parent = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> clientTokenIds = null, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer loginServer = null, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging logging = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail> statusDetails = null, System.Collections.Generic.IEnumerable<string> notificationsList = null, Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties garbageCollection = null, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus? activationStatus = default(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer ConnectedRegistryLoginServer(string host = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties tls = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail ConnectedRegistryStatusDetail(string statusDetailType = null, string code = null, string description = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string correlationId = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties ConnectedRegistrySyncProperties(string tokenId = null, string schedule = null, System.TimeSpan? syncWindow = default(System.TimeSpan?), System.TimeSpan messageTtl = default(System.TimeSpan), System.DateTimeOffset? lastSyncOn = default(System.DateTimeOffset?), string gatewayEndpoint = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveData ContainerRegistryArchiveData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerRegistry.Models.ArchiveProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryArchiveVersionData ContainerRegistryArchiveVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerRegistry.Models.ArchiveVersionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential ContainerRegistryAuthCredential(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialName? name = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialName?), string usernameSecretIdentifier = null, string passwordSecretIdentifier = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth credentialHealth = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData ContainerRegistryCacheRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string credentialSetResourceId = null, string sourceRepository = null, string targetRepository = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth ContainerRegistryCredentialHealth(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus? status = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus?), string errorCode = null, string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent ContainerRegistryCredentialRegenerateContent(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPasswordName name = Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPasswordName.Password) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData ContainerRegistryCredentialSetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string loginServer = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential> authCredentials = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryData ContainerRegistryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string loginServer = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus status = null, bool? adminUserEnabled = default(bool?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet networkRuleSet = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies policies = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption encryption = null, bool? dataEndpointEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> dataEndpointHostNames = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData> privateEndpointConnections = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption? networkRuleBypassOptions = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption?), bool? networkRuleBypassAllowedForTasks = default(bool?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy? zoneRedundancy = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy?), bool? anonymousPullEnabled = default(bool?), Azure.ResourceManager.ContainerRegistry.Models.MetadataSearch? metadataSearch = default(Azure.ResourceManager.ContainerRegistry.Models.MetadataSearch?), Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope? autoGeneratedDomainNameLabelScope = default(Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode? roleAssignmentMode = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku sku = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult ContainerRegistryGenerateCredentialsResult(string username = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword> passwords = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageParameters ContainerRegistryImportImageParameters(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource source = null, System.Collections.Generic.IEnumerable<string> targetTags = null, System.Collections.Generic.IEnumerable<string> untaggedTargetRepositories = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode? mode = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource ContainerRegistryImportSource(string resourceId = null, string registryAddress = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials credentials = null, string sourceImage = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials ContainerRegistryImportSourceCredentials(string username = null, string password = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties ContainerRegistryKeyVaultProperties(string keyIdentifier = null, string versionedKeyIdentifier = null, string identity = null, bool? isKeyRotationEnabled = default(bool?), System.DateTimeOffset? lastKeyRotationTimestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult ContainerRegistryListCredentialsResult(string username = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword> passwords = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent ContainerRegistryNameAvailabilityContent(string name = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType type = Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType.MicrosoftContainerRegistryRegistries, string resourceGroupName = null, Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope? autoGeneratedDomainNameLabelScope = default(Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult ContainerRegistryNameAvailableResult(string availableLoginServerName = null, bool? isNameAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet ContainerRegistryNetworkRuleSet(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction defaultAction = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRule> ipRules = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword ContainerRegistryPassword(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPasswordName? name = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPasswordName?), string value = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch ContainerRegistryPatch(Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties identity = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku sku = null, bool? adminUserEnabled = default(bool?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet networkRuleSet = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies policies = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption encryption = null, bool? dataEndpointEnabled = default(bool?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption? networkRuleBypassOptions = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption?), bool? networkRuleBypassAllowedForTasks = default(bool?), bool? anonymousPullEnabled = default(bool?), Azure.ResourceManager.ContainerRegistry.Models.MetadataSearch? metadataSearch = default(Azure.ResourceManager.ContainerRegistry.Models.MetadataSearch?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode? roleAssignmentMode = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionDataData ContainerRegistryPrivateEndpointConnectionDataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerRegistry.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResource ContainerRegistryPrivateLinkResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResourceProperties ContainerRegistryPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData ContainerRegistryReplicationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ContainerRegistry.Models.ReplicationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch ContainerRegistryReplicationPatch(System.Collections.Generic.IDictionary<string, string> tags = null, bool? regionEndpointEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus ContainerRegistryResourceStatus(string displayStatus = null, string message = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy ContainerRegistryRetentionPolicy(int? days = default(int?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus? status = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku ContainerRegistrySku(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName name = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier? tier = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties ContainerRegistryTlsCertificateProperties(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCertificateType? type = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCertificateType?), string certificateLocation = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties ContainerRegistryTlsProperties(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus? status = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties certificate = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials ContainerRegistryTokenCredentials(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificate> certificates = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword> passwords = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData ContainerRegistryTokenData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerRegistry.Models.TokenProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword ContainerRegistryTokenPassword(System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? expiry = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName? name = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName?), string value = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage ContainerRegistryUsage(string name = null, long? limit = default(long?), long? currentValue = default(long?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit? unit = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageListResult ContainerRegistryUsageListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage> value = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig ContainerRegistryWebhookCallbackConfig(string serviceUri = null, System.Collections.Generic.IReadOnlyDictionary<string, string> customHeaders = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData ContainerRegistryWebhookData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ContainerRegistry.Models.WebhookProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent ContainerRegistryWebhookEvent(string id = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage eventRequestMessage = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage eventResponseMessage = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent ContainerRegistryWebhookEventContent(string id = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string action = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget target = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent request = null, string actorName = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource source = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo ContainerRegistryWebhookEventInfo(string id = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent ContainerRegistryWebhookEventRequestContent(string id = null, string addr = null, string host = null, string method = null, string useragent = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage ContainerRegistryWebhookEventRequestMessage(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent content = null, System.Collections.Generic.IReadOnlyDictionary<string, string> headers = null, string method = null, string requestUri = null, string version = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage ContainerRegistryWebhookEventResponseMessage(string content = null, System.Collections.Generic.IReadOnlyDictionary<string, string> headers = null, string reasonPhrase = null, string statusCode = null, string version = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource ContainerRegistryWebhookEventSource(string addr = null, string instanceID = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget ContainerRegistryWebhookEventTarget(string mediaType = null, long? size = default(long?), string digest = null, long? length = default(long?), string repository = null, string uri = null, string tag = null, string name = null, string version = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch ContainerRegistryWebhookPatch(System.Collections.Generic.IDictionary<string, string> tags = null, string serviceUri = null, System.Collections.Generic.IDictionary<string, string> customHeaders = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus? status = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus?), string scope = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction> actions = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ExportPipelineData ExportPipelineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineProperties properties = null, string location = null, Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties identity = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineProperties ExportPipelineProperties(Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineTargetProperties target = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.PipelineOptions> options = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties IdentityProperties(string principalId = null, string tenantId = null, Azure.ResourceManager.ContainerRegistry.Models.ResourceIdentityType? type = default(Azure.ResourceManager.ContainerRegistry.Models.ResourceIdentityType?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ContainerRegistry.Models.UserIdentityProperties> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ImportPipelineData ImportPipelineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineProperties properties = null, string location = null, Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties identity = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineProperties ImportPipelineProperties(Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineSourceProperties source = null, Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerProperties trigger = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.PipelineOptions> options = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.OperationDefinition OperationDefinition(string origin = null, string name = null, Azure.ResourceManager.ContainerRegistry.Models.OperationDisplayDefinition display = null, Azure.ResourceManager.ContainerRegistry.Models.OperationServiceSpecificationDefinition serviceSpecification = null, bool? isDataAction = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.OperationDisplayDefinition OperationDisplayDefinition(string provider = null, string resource = null, string operation = null, string description = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.OperationLogSpecificationDefinition OperationLogSpecificationDefinition(string name = null, string displayName = null, string blobDuration = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.OperationMetricSpecificationDefinition OperationMetricSpecificationDefinition(string name = null, string displayName = null, string displayDescription = null, string unit = null, string aggregationType = null, string internalMetricName = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.OperationServiceSpecificationDefinition OperationServiceSpecificationDefinition(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.OperationMetricSpecificationDefinition> metricSpecifications = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.OperationLogSpecificationDefinition> logSpecifications = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.PipelineRunData PipelineRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerRegistry.Models.PipelineRunProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.PipelineRunProperties PipelineRunProperties(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?), Azure.ResourceManager.ContainerRegistry.Models.PipelineRunRequest request = null, Azure.ResourceManager.ContainerRegistry.Models.PipelineRunResponse response = null, string forceUpdateTag = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.PipelineRunRequest PipelineRunRequest(string pipelineResourceId = null, System.Collections.Generic.IEnumerable<string> artifacts = null, Azure.ResourceManager.ContainerRegistry.Models.PipelineRunSourceProperties source = null, Azure.ResourceManager.ContainerRegistry.Models.PipelineRunTargetProperties target = null, string catalogDigest = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.PipelineRunResponse PipelineRunResponse(string status = null, System.Collections.Generic.IEnumerable<string> importedArtifacts = null, string progressPercentage = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? finishOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineSourceProperties source = null, Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineTargetProperties target = null, string catalogDigest = null, Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerDescriptor trigger = null, string pipelineRunErrorMessage = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerDescriptor PipelineTriggerDescriptor(System.DateTimeOffset? sourceTriggerTimestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.PrivateEndpointConnectionProperties PrivateEndpointConnectionProperties(string privateEndpointId = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ReplicationProperties ReplicationProperties(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus status = null, bool? regionEndpointEnabled = default(bool?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy? zoneRedundancy = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ScopeMapData ScopeMapData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerRegistry.Models.ScopeMapProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ScopeMapProperties ScopeMapProperties(string description = null, string type = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?), System.Collections.Generic.IEnumerable<string> actions = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.SoftDeletePolicy SoftDeletePolicy(int? retentionDays = default(int?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus? status = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.TokenProperties TokenProperties(System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?), string scopeMapId = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials credentials = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus? status = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.UserIdentityProperties UserIdentityProperties(string principalId = null, string clientId = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.WebhookCreateParameters WebhookCreateParameters(System.Collections.Generic.IDictionary<string, string> tags = null, string location = null, string serviceUri = null, System.Collections.Generic.IDictionary<string, string> customHeaders = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus? status = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus?), string scope = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction> actions = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.WebhookProperties WebhookProperties(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus? status = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus?), string scope = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction> actions = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoGeneratedDomainNameLabelScope : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoGeneratedDomainNameLabelScope(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope NoReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope ResourceGroupReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope SubscriptionReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope TenantReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope Unsecure { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectedRegistryActivationStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectedRegistryActivationStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus Active { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus left, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus left, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectedRegistryAuditLogStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryAuditLogStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectedRegistryAuditLogStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryAuditLogStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryAuditLogStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryAuditLogStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryAuditLogStatus left, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryAuditLogStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryAuditLogStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryAuditLogStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryAuditLogStatus left, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryAuditLogStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectedRegistryConnectionState : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectedRegistryConnectionState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState Offline { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState Online { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState Syncing { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState Unhealthy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState left, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState left, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectedRegistryLogging : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging>
    {
        public ConnectedRegistryLogging() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryAuditLogStatus? AuditLogStatus { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel? LogLevel { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedRegistryLoginServer : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer>
    {
        public ConnectedRegistryLoginServer() { }
        public string Host { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties Tls { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectedRegistryLogLevel : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectedRegistryLogLevel(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel Debug { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel Error { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel Information { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel None { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel left, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel left, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectedRegistryMode : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectedRegistryMode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode Mirror { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode ReadWrite { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode Registry { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode left, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode left, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectedRegistryParent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent>
    {
        public ConnectedRegistryParent(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties syncProperties) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties SyncProperties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedRegistryPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch>
    {
        public ConnectedRegistryPatch() { }
        public System.Collections.Generic.IList<string> ClientTokenIds { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties GarbageCollection { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging Logging { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NotificationsList { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncUpdateProperties SyncProperties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedRegistryStatusDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail>
    {
        internal ConnectedRegistryStatusDetail() { }
        public string Code { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string Description { get { throw null; } }
        public string StatusDetailType { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedRegistrySyncProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties>
    {
        public ConnectedRegistrySyncProperties(string tokenId, System.TimeSpan messageTtl) { }
        public string GatewayEndpoint { get { throw null; } }
        public System.DateTimeOffset? LastSyncOn { get { throw null; } }
        public System.TimeSpan MessageTtl { get { throw null; } set { } }
        public string Schedule { get { throw null; } set { } }
        public System.TimeSpan? SyncWindow { get { throw null; } set { } }
        public string TokenId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedRegistrySyncUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncUpdateProperties>
    {
        public ConnectedRegistrySyncUpdateProperties() { }
        public System.TimeSpan? MessageTtl { get { throw null; } set { } }
        public string Schedule { get { throw null; } set { } }
        public System.TimeSpan? SyncWindow { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryAuthCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential>
    {
        public ContainerRegistryAuthCredential() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth CredentialHealth { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialName? Name { get { throw null; } set { } }
        public string PasswordSecretIdentifier { get { throw null; } set { } }
        public string UsernameSecretIdentifier { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryCacheRulePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch>
    {
        public ContainerRegistryCacheRulePatch() { }
        public string CredentialSetResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryCertificateType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCertificateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryCertificateType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCertificateType LocalDirectory { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCertificateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCertificateType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCertificateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCertificateType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCertificateType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCertificateType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCertificateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryCredentialHealth : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth>
    {
        internal ContainerRegistryCredentialHealth() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryCredentialHealthStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryCredentialHealthStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus Unhealthy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryCredentialName : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryCredentialName(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialName Credential1 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialName left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialName left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryCredentialRegenerateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent>
    {
        public ContainerRegistryCredentialRegenerateContent(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPasswordName name) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPasswordName Name { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryCredentialSetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch>
    {
        public ContainerRegistryCredentialSetPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential> AuthCredentials { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties Identity { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption>
    {
        public ContainerRegistryEncryption() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryptionStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryEncryptionStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryEncryptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryptionStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryptionStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryptionStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryptionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryptionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryptionStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryExportPolicyStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryExportPolicyStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryExportPolicyStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryExportPolicyStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryExportPolicyStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryExportPolicyStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryExportPolicyStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryExportPolicyStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryExportPolicyStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryExportPolicyStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryExportPolicyStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryExportPolicyStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryGenerateCredentialsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent>
    {
        public ContainerRegistryGenerateCredentialsContent() { }
        public System.DateTimeOffset? Expiry { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName? Name { get { throw null; } set { } }
        public string TokenId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryGenerateCredentialsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult>
    {
        internal ContainerRegistryGenerateCredentialsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword> Passwords { get { throw null; } }
        public string Username { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryImportImageParameters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageParameters>
    {
        public ContainerRegistryImportImageParameters(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource source) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode? Mode { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource Source { get { throw null; } }
        public System.Collections.Generic.IList<string> TargetTags { get { throw null; } }
        public System.Collections.Generic.IList<string> UntaggedTargetRepositories { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageParameters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageParameters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryImportMode : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryImportMode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode Force { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode NoForce { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryImportSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource>
    {
        public ContainerRegistryImportSource(string sourceImage) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials Credentials { get { throw null; } set { } }
        public string RegistryAddress { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string SourceImage { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryImportSourceCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials>
    {
        public ContainerRegistryImportSourceCredentials(string password) { }
        public string Password { get { throw null; } }
        public string Username { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryIPRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRule>
    {
        public ContainerRegistryIPRule(string ipAddressOrRange) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRuleAction? Action { get { throw null; } set { } }
        public string IPAddressOrRange { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryIPRuleAction : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRuleAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryIPRuleAction(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRuleAction Allow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRuleAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRuleAction left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRuleAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRuleAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRuleAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRuleAction left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRuleAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryKeyVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties>
    {
        public ContainerRegistryKeyVaultProperties() { }
        public string Identity { get { throw null; } set { } }
        public bool? IsKeyRotationEnabled { get { throw null; } }
        public string KeyIdentifier { get { throw null; } set { } }
        public System.DateTimeOffset? LastKeyRotationTimestamp { get { throw null; } }
        public string VersionedKeyIdentifier { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryListCredentialsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult>
    {
        internal ContainerRegistryListCredentialsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword> Passwords { get { throw null; } }
        public string Username { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent>
    {
        public ContainerRegistryNameAvailabilityContent(string name, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType type) { }
        public Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope? AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string ResourceGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType Type { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryNameAvailableResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult>
    {
        internal ContainerRegistryNameAvailableResult() { }
        public string AvailableLoginServerName { get { throw null; } }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryNetworkRuleBypassOption : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryNetworkRuleBypassOption(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption AzureServices { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryNetworkRuleDefaultAction : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryNetworkRuleDefaultAction(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction Allow { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryNetworkRuleSet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet>
    {
        public ContainerRegistryNetworkRuleSet(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction defaultAction) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRule> IpRules { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryPassword : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword>
    {
        internal ContainerRegistryPassword() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPasswordName? Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ContainerRegistryPasswordName
    {
        Password = 0,
        Password2 = 1,
    }
    public partial class ContainerRegistryPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch>
    {
        public ContainerRegistryPatch() { }
        public bool? AdminUserEnabled { get { throw null; } set { } }
        public bool? AnonymousPullEnabled { get { throw null; } set { } }
        public bool? DataEndpointEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.MetadataSearch? MetadataSearch { get { throw null; } set { } }
        public bool? NetworkRuleBypassAllowedForTasks { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption? NetworkRuleBypassOptions { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies Policies { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode? RoleAssignmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryPolicies : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies>
    {
        public ContainerRegistryPolicies() { }
        public Azure.ResourceManager.ContainerRegistry.Models.AadAuthenticationAsArmPolicyStatus? AzureADAuthenticationAsArmStatus { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryExportPolicyStatus? ExportStatus { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus? QuarantineStatus { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.SoftDeletePolicy SoftDeletePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicy TrustPolicy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryPolicyStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryPolicyStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryPrivateLinkResource : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResource>
    {
        internal ContainerRegistryPrivateLinkResource() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResourceProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResourceProperties>
    {
        internal ContainerRegistryPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState>
    {
        public ContainerRegistryPrivateLinkServiceConnectionState() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ActionsRequiredForPrivateLinkServiceConsumer? ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryPrivateLinkServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryPrivateLinkServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryReplicationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch>
    {
        public ContainerRegistryReplicationPatch() { }
        public bool? RegionEndpointEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryResourceStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus>
    {
        internal ContainerRegistryResourceStatus() { }
        public string DisplayStatus { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ContainerRegistryResourceType
    {
        MicrosoftContainerRegistryRegistries = 0,
    }
    public partial class ContainerRegistryRetentionPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy>
    {
        public ContainerRegistryRetentionPolicy() { }
        public int? Days { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryRoleAssignmentMode : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryRoleAssignmentMode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode AbacRepositoryPermissions { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode LegacyRegistryPermissions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistrySku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku>
    {
        public ContainerRegistrySku(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName name) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier? Tier { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistrySkuName : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistrySkuName(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName Classic { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName Premium { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistrySkuTier : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistrySkuTier(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier Basic { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier Classic { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier Premium { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryTlsCertificateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties>
    {
        internal ContainerRegistryTlsCertificateProperties() { }
        public string CertificateLocation { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCertificateType? Type { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTlsProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties>
    {
        internal ContainerRegistryTlsProperties() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties Certificate { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTlsStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTlsStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryTokenCertificate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificate>
    {
        public ContainerRegistryTokenCertificate() { }
        public string EncodedPemCertificate { get { throw null; } set { } }
        public System.DateTimeOffset? Expiry { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificateName? Name { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTokenCertificateName : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificateName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTokenCertificateName(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificateName Certificate1 { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificateName Certificate2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificateName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificateName left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificateName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificateName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificateName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificateName left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificateName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryTokenCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials>
    {
        public ContainerRegistryTokenCredentials() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificate> Certificates { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword> Passwords { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTokenPassword : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword>
    {
        public ContainerRegistryTokenPassword() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public System.DateTimeOffset? Expiry { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName? Name { get { throw null; } set { } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTokenPasswordName : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTokenPasswordName(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName Password1 { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName Password2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryTokenPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch>
    {
        public ContainerRegistryTokenPatch() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials Credentials { get { throw null; } set { } }
        public string ScopeMapId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTokenStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTokenStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTriggerStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTriggerStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryTrustPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicy>
    {
        public ContainerRegistryTrustPolicy() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicyType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTrustPolicyType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTrustPolicyType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicyType Notary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicyType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicyType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicyType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicyType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage>
    {
        internal ContainerRegistryUsage() { }
        public long? CurrentValue { get { throw null; } }
        public long? Limit { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit? Unit { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryUsageListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageListResult>
    {
        internal ContainerRegistryUsageListResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryUsageUnit : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryUsageUnit(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit Bytes { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryWebhookAction : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryWebhookAction(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction ChartDelete { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction ChartPush { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction Delete { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction Push { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction Quarantine { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryWebhookCallbackConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig>
    {
        internal ContainerRegistryWebhookCallbackConfig() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> CustomHeaders { get { throw null; } }
        public string ServiceUri { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryWebhookEvent : Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent>
    {
        internal ContainerRegistryWebhookEvent() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage EventRequestMessage { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage EventResponseMessage { get { throw null; } }
        protected override Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryWebhookEventContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent>
    {
        internal ContainerRegistryWebhookEventContent() { }
        public string Action { get { throw null; } }
        public string ActorName { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent Request { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource Source { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget Target { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryWebhookEventInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo>
    {
        internal ContainerRegistryWebhookEventInfo() { }
        public string Id { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryWebhookEventRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent>
    {
        internal ContainerRegistryWebhookEventRequestContent() { }
        public string Addr { get { throw null; } }
        public string Host { get { throw null; } }
        public string Id { get { throw null; } }
        public string Method { get { throw null; } }
        public string Useragent { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryWebhookEventRequestMessage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage>
    {
        internal ContainerRegistryWebhookEventRequestMessage() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Headers { get { throw null; } }
        public string Method { get { throw null; } }
        public string RequestUri { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryWebhookEventResponseMessage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage>
    {
        internal ContainerRegistryWebhookEventResponseMessage() { }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Headers { get { throw null; } }
        public string ReasonPhrase { get { throw null; } }
        public string StatusCode { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryWebhookEventSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource>
    {
        internal ContainerRegistryWebhookEventSource() { }
        public string Addr { get { throw null; } }
        public string InstanceID { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryWebhookEventTarget : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget>
    {
        internal ContainerRegistryWebhookEventTarget() { }
        public string Digest { get { throw null; } }
        public long? Length { get { throw null; } }
        public string MediaType { get { throw null; } }
        public string Name { get { throw null; } }
        public string Repository { get { throw null; } }
        public long? Size { get { throw null; } }
        public string Tag { get { throw null; } }
        public string Uri { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryWebhookPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch>
    {
        public ContainerRegistryWebhookPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction> Actions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> CustomHeaders { get { throw null; } }
        public string Scope { get { throw null; } set { } }
        public string ServiceUri { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryWebhookStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryWebhookStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryZoneRedundancy : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryZoneRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExportPipelineProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineProperties>
    {
        public ExportPipelineProperties(Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineTargetProperties target) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.PipelineOptions> Options { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineTargetProperties Target { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportPipelineTargetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineTargetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineTargetProperties>
    {
        public ExportPipelineTargetProperties() { }
        public string KeyVaultUri { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.StorageAccessMode? StorageAccessMode { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineTargetProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineTargetProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineTargetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineTargetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineTargetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineTargetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineTargetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineTargetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineTargetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GarbageCollectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties>
    {
        public GarbageCollectionProperties() { }
        public bool? Enabled { get { throw null; } set { } }
        public string Schedule { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IdentityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties>
    {
        public IdentityProperties() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ResourceIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ContainerRegistry.Models.UserIdentityProperties> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImportPipelineProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineProperties>
    {
        public ImportPipelineProperties(Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineSourceProperties source) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.PipelineOptions> Options { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineSourceProperties Source { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerProperties Trigger { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImportPipelineSourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineSourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineSourceProperties>
    {
        public ImportPipelineSourceProperties() { }
        public string KeyVaultUri { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.StorageAccessMode? StorageAccessMode { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.PipelineSourceType? Type { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineSourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineSourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineSourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineSourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineSourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineSourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineSourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineSourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineSourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetadataSearch : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.MetadataSearch>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetadataSearch(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.MetadataSearch Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.MetadataSearch Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.MetadataSearch other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.MetadataSearch left, Azure.ResourceManager.ContainerRegistry.Models.MetadataSearch right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.MetadataSearch (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.MetadataSearch? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.MetadataSearch left, Azure.ResourceManager.ContainerRegistry.Models.MetadataSearch right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.OperationDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.OperationDefinition>
    {
        internal OperationDefinition() { }
        public Azure.ResourceManager.ContainerRegistry.Models.OperationDisplayDefinition Display { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        public string Origin { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.OperationServiceSpecificationDefinition ServiceSpecification { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.OperationDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.OperationDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.OperationDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.OperationDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.OperationDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.OperationDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.OperationDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.OperationDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.OperationDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationDisplayDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.OperationDisplayDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.OperationDisplayDefinition>
    {
        internal OperationDisplayDefinition() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.OperationDisplayDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.OperationDisplayDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.OperationDisplayDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.OperationDisplayDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.OperationDisplayDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.OperationDisplayDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.OperationDisplayDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.OperationDisplayDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.OperationDisplayDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationLogSpecificationDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.OperationLogSpecificationDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.OperationLogSpecificationDefinition>
    {
        internal OperationLogSpecificationDefinition() { }
        public string BlobDuration { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.OperationLogSpecificationDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.OperationLogSpecificationDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.OperationLogSpecificationDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.OperationLogSpecificationDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.OperationLogSpecificationDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.OperationLogSpecificationDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.OperationLogSpecificationDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.OperationLogSpecificationDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.OperationLogSpecificationDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationMetricSpecificationDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.OperationMetricSpecificationDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.OperationMetricSpecificationDefinition>
    {
        internal OperationMetricSpecificationDefinition() { }
        public string AggregationType { get { throw null; } }
        public string DisplayDescription { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string InternalMetricName { get { throw null; } }
        public string Name { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.OperationMetricSpecificationDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.OperationMetricSpecificationDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.OperationMetricSpecificationDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.OperationMetricSpecificationDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.OperationMetricSpecificationDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.OperationMetricSpecificationDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.OperationMetricSpecificationDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.OperationMetricSpecificationDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.OperationMetricSpecificationDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationServiceSpecificationDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.OperationServiceSpecificationDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.OperationServiceSpecificationDefinition>
    {
        internal OperationServiceSpecificationDefinition() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.OperationLogSpecificationDefinition> LogSpecifications { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.OperationMetricSpecificationDefinition> MetricSpecifications { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.OperationServiceSpecificationDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.OperationServiceSpecificationDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.OperationServiceSpecificationDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.OperationServiceSpecificationDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.OperationServiceSpecificationDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.OperationServiceSpecificationDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.OperationServiceSpecificationDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.OperationServiceSpecificationDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.OperationServiceSpecificationDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PackageSourceType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.PackageSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PackageSourceType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.PackageSourceType Remote { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.PackageSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.PackageSourceType left, Azure.ResourceManager.ContainerRegistry.Models.PackageSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.PackageSourceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.PackageSourceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.PackageSourceType left, Azure.ResourceManager.ContainerRegistry.Models.PackageSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PipelineOptions : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.PipelineOptions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PipelineOptions(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.PipelineOptions ContinueOnErrors { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.PipelineOptions DeleteSourceBlobOnSuccess { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.PipelineOptions OverwriteBlobs { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.PipelineOptions OverwriteTags { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.PipelineOptions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.PipelineOptions left, Azure.ResourceManager.ContainerRegistry.Models.PipelineOptions right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.PipelineOptions (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.PipelineOptions? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.PipelineOptions left, Azure.ResourceManager.ContainerRegistry.Models.PipelineOptions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PipelineRunProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunProperties>
    {
        public PipelineRunProperties() { }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.PipelineRunRequest Request { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.PipelineRunResponse Response { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.PipelineRunProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.PipelineRunProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.PipelineRunProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.PipelineRunProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineRunRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunRequest>
    {
        public PipelineRunRequest() { }
        public System.Collections.Generic.IList<string> Artifacts { get { throw null; } }
        public string CatalogDigest { get { throw null; } set { } }
        public string PipelineResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.PipelineRunSourceProperties Source { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.PipelineRunTargetProperties Target { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.PipelineRunRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.PipelineRunRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.PipelineRunRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.PipelineRunRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineRunResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunResponse>
    {
        internal PipelineRunResponse() { }
        public string CatalogDigest { get { throw null; } }
        public System.DateTimeOffset? FinishOn { get { throw null; } }
        public System.Collections.Generic.IList<string> ImportedArtifacts { get { throw null; } }
        public string PipelineRunErrorMessage { get { throw null; } }
        public string ProgressPercentage { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ImportPipelineSourceProperties Source { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ExportPipelineTargetProperties Target { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerDescriptor Trigger { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.PipelineRunResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.PipelineRunResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.PipelineRunResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.PipelineRunResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineRunSourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunSourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunSourceProperties>
    {
        public PipelineRunSourceProperties() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.PipelineRunSourceType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.PipelineRunSourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.PipelineRunSourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.PipelineRunSourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunSourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunSourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.PipelineRunSourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunSourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunSourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunSourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PipelineRunSourceType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PipelineRunSourceType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.PipelineRunSourceType AzureStorageBlob { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.PipelineRunSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.PipelineRunSourceType left, Azure.ResourceManager.ContainerRegistry.Models.PipelineRunSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.PipelineRunSourceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.PipelineRunSourceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.PipelineRunSourceType left, Azure.ResourceManager.ContainerRegistry.Models.PipelineRunSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PipelineRunTargetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunTargetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunTargetProperties>
    {
        public PipelineRunTargetProperties() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.PipelineRunTargetType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.PipelineRunTargetProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.PipelineRunTargetProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.PipelineRunTargetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunTargetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunTargetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.PipelineRunTargetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunTargetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunTargetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunTargetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PipelineRunTargetType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.PipelineRunTargetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PipelineRunTargetType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.PipelineRunTargetType AzureStorageBlob { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.PipelineRunTargetType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.PipelineRunTargetType left, Azure.ResourceManager.ContainerRegistry.Models.PipelineRunTargetType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.PipelineRunTargetType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.PipelineRunTargetType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.PipelineRunTargetType left, Azure.ResourceManager.ContainerRegistry.Models.PipelineRunTargetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PipelineSourceType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.PipelineSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PipelineSourceType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.PipelineSourceType AzureStorageBlobContainer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.PipelineSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.PipelineSourceType left, Azure.ResourceManager.ContainerRegistry.Models.PipelineSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.PipelineSourceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.PipelineSourceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.PipelineSourceType left, Azure.ResourceManager.ContainerRegistry.Models.PipelineSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PipelineTriggerDescriptor : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerDescriptor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerDescriptor>
    {
        internal PipelineTriggerDescriptor() { }
        public System.DateTimeOffset? SourceTriggerTimestamp { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerDescriptor JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerDescriptor PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerDescriptor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerDescriptor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerDescriptor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerDescriptor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerDescriptor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerDescriptor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerDescriptor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineTriggerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerProperties>
    {
        public PipelineTriggerProperties() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus? SourceTriggerStatus { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PipelineTriggerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PrivateEndpointConnectionProperties>
    {
        public PrivateEndpointConnectionProperties() { }
        public string PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.PrivateEndpointConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.PrivateEndpointConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.PrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.PrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReplicationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ReplicationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ReplicationProperties>
    {
        public ReplicationProperties() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public bool? RegionEndpointEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus Status { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy? ZoneRedundancy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ReplicationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ReplicationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ReplicationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ReplicationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ReplicationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ReplicationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ReplicationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ReplicationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ReplicationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ResourceIdentityType
    {
        SystemAssigned = 0,
        UserAssigned = 1,
        SystemAssignedUserAssigned = 2,
        None = 3,
    }
    public partial class ScopeMapPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch>
    {
        public ScopeMapPatch() { }
        public System.Collections.Generic.IList<string> Actions { get { throw null; } }
        public string Description { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScopeMapProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ScopeMapProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ScopeMapProperties>
    {
        public ScopeMapProperties(System.Collections.Generic.IEnumerable<string> actions) { }
        public System.Collections.Generic.IList<string> Actions { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ScopeMapProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.ScopeMapProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.ScopeMapProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ScopeMapProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ScopeMapProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ScopeMapProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ScopeMapProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ScopeMapProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ScopeMapProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SoftDeletePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SoftDeletePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SoftDeletePolicy>
    {
        public SoftDeletePolicy() { }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.SoftDeletePolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.SoftDeletePolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.SoftDeletePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SoftDeletePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SoftDeletePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SoftDeletePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SoftDeletePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SoftDeletePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SoftDeletePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccessMode : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.StorageAccessMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccessMode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.StorageAccessMode ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.StorageAccessMode SasToken { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.StorageAccessMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.StorageAccessMode left, Azure.ResourceManager.ContainerRegistry.Models.StorageAccessMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.StorageAccessMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.StorageAccessMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.StorageAccessMode left, Azure.ResourceManager.ContainerRegistry.Models.StorageAccessMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TokenProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.TokenProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.TokenProperties>
    {
        public TokenProperties() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public string ScopeMapId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.TokenProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.TokenProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.TokenProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.TokenProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.TokenProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.TokenProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.TokenProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.TokenProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.TokenProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserIdentityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.UserIdentityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.UserIdentityProperties>
    {
        public UserIdentityProperties() { }
        public string ClientId { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.UserIdentityProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.UserIdentityProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.UserIdentityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.UserIdentityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.UserIdentityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.UserIdentityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.UserIdentityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.UserIdentityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.UserIdentityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebhookCreateParameters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.WebhookCreateParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.WebhookCreateParameters>
    {
        public WebhookCreateParameters(string location) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction> Actions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> CustomHeaders { get { throw null; } }
        public string Location { get { throw null; } }
        public string Scope { get { throw null; } set { } }
        public string ServiceUri { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.WebhookCreateParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.WebhookCreateParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.WebhookCreateParameters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.WebhookCreateParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.WebhookCreateParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.WebhookCreateParameters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.WebhookCreateParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.WebhookCreateParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.WebhookCreateParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebhookProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.WebhookProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.WebhookProperties>
    {
        internal WebhookProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction> Actions { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public string Scope { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.WebhookProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Models.WebhookProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Models.WebhookProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.WebhookProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.WebhookProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.WebhookProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.WebhookProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.WebhookProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.WebhookProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
