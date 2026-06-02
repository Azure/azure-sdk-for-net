namespace Azure.ResourceManager.Chaos
{
    public partial class AzureResourceManagerChaosContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerChaosContext() { }
        public static Azure.ResourceManager.Chaos.AzureResourceManagerChaosContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ChaosActionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosActionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosActionResource>, System.Collections.IEnumerable
    {
        protected ChaosActionCollection() { }
        public virtual Azure.Response<bool> Exists(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosActionResource> Get(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosActionResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosActionResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosActionResource>> GetAsync(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosActionResource> GetIfExists(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosActionResource>> GetIfExistsAsync(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosActionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosActionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosActionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosActionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosActionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosActionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosActionData>
    {
        internal ChaosActionData() { }
        public string ActionName { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosActionKind? ActionType { get { throw null; } }
        public string CanonicalId { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosActionParametersSchema ParametersSchema { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Guid> RecommendedRoles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosActionSupportedTargetType> SupportedTargetTypes { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.ChaosActionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosActionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosActionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosActionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosActionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosActionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosActionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosActionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosActionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosActionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosActionResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosActionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string actionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosActionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosActionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosActionVersionResource> GetChaosActionVersion(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosActionVersionResource>> GetChaosActionVersionAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosActionVersionCollection GetChaosActionVersions() { throw null; }
        Azure.ResourceManager.Chaos.ChaosActionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosActionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosActionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosActionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosActionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosActionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosActionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosActionVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosActionVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosActionVersionResource>, System.Collections.IEnumerable
    {
        protected ChaosActionVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosActionVersionResource> Get(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosActionVersionResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosActionVersionResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosActionVersionResource>> GetAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosActionVersionResource> GetIfExists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosActionVersionResource>> GetIfExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosActionVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosActionVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosActionVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosActionVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosActionVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosActionVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosActionVersionData>
    {
        internal ChaosActionVersionData() { }
        public string ActionName { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosActionKind? ActionType { get { throw null; } }
        public string CanonicalId { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosActionParametersSchema ParametersSchema { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Guid> RecommendedRoles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosActionSupportedTargetType> SupportedTargetTypes { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.ChaosActionVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosActionVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosActionVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosActionVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosActionVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosActionVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosActionVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosActionVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosActionVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosActionVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosActionVersionResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosActionVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string actionName, string versionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosActionVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosActionVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Chaos.ChaosActionVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosActionVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosActionVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosActionVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosActionVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosActionVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosActionVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosCapabilityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosCapabilityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosCapabilityResource>, System.Collections.IEnumerable
    {
        protected ChaosCapabilityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosCapabilityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string capabilityName, Azure.ResourceManager.Chaos.ChaosCapabilityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosCapabilityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string capabilityName, Azure.ResourceManager.Chaos.ChaosCapabilityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityResource> Get(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosCapabilityResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosCapabilityResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityResource>> GetAsync(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosCapabilityResource> GetIfExists(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosCapabilityResource>> GetIfExistsAsync(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosCapabilityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosCapabilityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosCapabilityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosCapabilityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosCapabilityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosCapabilityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityData>
    {
        public ChaosCapabilityData() { }
        public string Description { get { throw null; } }
        public string ParametersSchema { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } }
        public string TargetType { get { throw null; } }
        public string Urn { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.ChaosCapabilityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosCapabilityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosCapabilityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosCapabilityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosCapabilityMetadataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataResource>, System.Collections.IEnumerable
    {
        protected ChaosCapabilityMetadataCollection() { }
        public virtual Azure.Response<bool> Exists(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataResource> Get(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataResource>> GetAsync(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataResource> GetIfExists(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataResource>> GetIfExistsAsync(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosCapabilityMetadataData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataData>
    {
        internal ChaosCapabilityMetadataData() { }
        public System.Collections.Generic.IReadOnlyList<string> AzureRbacActions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AzureRbacDataActions { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Kind { get { throw null; } }
        public string ParametersSchema { get { throw null; } }
        public string Publisher { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredAzureRoleDefinitionIds { get { throw null; } }
        public string RuntimeKind { get { throw null; } }
        public string TargetType { get { throw null; } }
        public string Urn { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.ChaosCapabilityMetadataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosCapabilityMetadataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosCapabilityMetadataResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosCapabilityMetadataResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosCapabilityMetadataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string targetTypeName, string capabilityTypeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Chaos.ChaosCapabilityMetadataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosCapabilityMetadataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosCapabilityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosCapabilityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosCapabilityResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosCapabilityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName, string capabilityName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Chaos.ChaosCapabilityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosCapabilityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosCapabilityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosCapabilityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosCapabilityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.ChaosCapabilityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosCapabilityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.ChaosCapabilityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `ChaosCapabilityMetadataCollection` moving forward.")]
    public partial class ChaosCapabilityTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource>, System.Collections.IEnumerable
    {
        protected ChaosCapabilityTypeCollection() { }
        public virtual Azure.Response<bool> Exists(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource> Get(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource>> GetAsync(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource> GetIfExists(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource>> GetIfExistsAsync(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `ChaosCapabilityMetadataData` moving forward.")]
    public partial class ChaosCapabilityTypeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosCapabilityTypeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityTypeData>
    {
        public ChaosCapabilityTypeData() { }
        public System.Collections.Generic.IList<string> AzureRbacActions { get { throw null; } }
        public System.Collections.Generic.IList<string> AzureRbacDataActions { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string ParametersSchema { get { throw null; } }
        public string Publisher { get { throw null; } }
        public string RuntimeKind { get { throw null; } }
        public string TargetType { get { throw null; } }
        public string Urn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosCapabilityTypeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosCapabilityTypeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosCapabilityTypeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosCapabilityTypeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityTypeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityTypeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityTypeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `ChaosCapabilityMetadataResource` moving forward.")]
    public partial class ChaosCapabilityTypeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosCapabilityTypeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityTypeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosCapabilityTypeResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosCapabilityTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string locationName, string targetTypeName, string capabilityTypeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Chaos.ChaosCapabilityTypeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosCapabilityTypeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosCapabilityTypeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosCapabilityTypeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityTypeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityTypeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosCapabilityTypeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosDiscoveredCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosDiscoveredResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosDiscoveredResource>, System.Collections.IEnumerable
    {
        protected ChaosDiscoveredCollection() { }
        public virtual Azure.Response<bool> Exists(string discoveredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string discoveredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosDiscoveredResource> Get(string discoveredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosDiscoveredResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosDiscoveredResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosDiscoveredResource>> GetAsync(string discoveredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosDiscoveredResource> GetIfExists(string discoveredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosDiscoveredResource>> GetIfExistsAsync(string discoveredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosDiscoveredResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosDiscoveredResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosDiscoveredResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosDiscoveredResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosDiscoveredData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosDiscoveredData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosDiscoveredData>
    {
        internal ChaosDiscoveredData() { }
        public Azure.ResourceManager.Chaos.Models.ChaosDiscoveredResourceProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.ChaosDiscoveredData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosDiscoveredData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosDiscoveredData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosDiscoveredData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosDiscoveredData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosDiscoveredData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosDiscoveredData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosDiscoveredResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosDiscoveredData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosDiscoveredData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosDiscoveredResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosDiscoveredData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string discoveredResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosDiscoveredResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosDiscoveredResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Chaos.ChaosDiscoveredData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosDiscoveredData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosDiscoveredData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosDiscoveredData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosDiscoveredData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosDiscoveredData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosDiscoveredData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosExperimentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosExperimentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosExperimentResource>, System.Collections.IEnumerable
    {
        protected ChaosExperimentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosExperimentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string experimentName, Azure.ResourceManager.Chaos.ChaosExperimentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosExperimentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string experimentName, Azure.ResourceManager.Chaos.ChaosExperimentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource> Get(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetAll(bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetAllAsync(bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource>> GetAsync(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetIfExists(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosExperimentResource>> GetIfExistsAsync(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosExperimentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosExperimentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosExperimentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosExperimentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosExperimentData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosExperimentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosExperimentData>
    {
        public ChaosExperimentData(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep> steps, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosTargetSelector> selectors) { }
        public Azure.ResourceManager.Chaos.Models.ChaosCustomerDataStorageProperties CustomerDataStorage { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosTargetSelector> Selectors { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep> Steps { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.ChaosExperimentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosExperimentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosExperimentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosExperimentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosExperimentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosExperimentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosExperimentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosExperimentExecutionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource>, System.Collections.IEnumerable
    {
        protected ChaosExperimentExecutionCollection() { }
        public virtual Azure.Response<bool> Exists(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource> Get(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource>> GetAsync(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource> GetIfExists(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource>> GetIfExistsAsync(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosExperimentExecutionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosExperimentExecutionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosExperimentExecutionData>
    {
        internal ChaosExperimentExecutionData() { }
        public Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? StoppedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.ChaosExperimentExecutionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosExperimentExecutionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosExperimentExecutionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosExperimentExecutionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosExperimentExecutionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosExperimentExecutionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosExperimentExecutionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosExperimentExecutionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosExperimentExecutionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosExperimentExecutionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosExperimentExecutionResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosExperimentExecutionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string experimentName, string executionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails> ExecutionDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails>> ExecutionDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Chaos.ChaosExperimentExecutionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosExperimentExecutionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosExperimentExecutionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosExperimentExecutionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosExperimentExecutionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosExperimentExecutionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosExperimentExecutionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosExperimentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosExperimentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosExperimentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosExperimentResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosExperimentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string experimentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource> GetChaosExperimentExecution(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource>> GetChaosExperimentExecutionAsync(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosExperimentExecutionCollection GetChaosExperimentExecutions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Chaos.ChaosExperimentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosExperimentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosExperimentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosExperimentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosExperimentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosExperimentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosExperimentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosExperimentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.Models.ChaosExperimentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosExperimentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.Models.ChaosExperimentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ChaosExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> Get(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetMetadataCollection GetAllChaosTargetMetadata(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.ChaosActionResource> GetChaosAction(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosActionResource>> GetChaosActionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosActionResource GetChaosActionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosActionCollection GetChaosActions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosActionVersionResource GetChaosActionVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosCapabilityCollection GetChaosCapabilities(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityResource> GetChaosCapability(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityResource>> GetChaosCapabilityAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosCapabilityMetadataResource GetChaosCapabilityMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosCapabilityResource GetChaosCapabilityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public static Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource GetChaosCapabilityTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosDiscoveredResource GetChaosDiscoveredResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetChaosExperiment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource>> GetChaosExperimentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource GetChaosExperimentExecutionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentResource GetChaosExperimentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentCollection GetChaosExperiments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetChaosExperiments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetChaosExperimentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> GetChaosOperationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetChaosOperationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource> GetChaosPrivateAccess(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource>> GetChaosPrivateAccessAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosPrivateAccessCollection GetChaosPrivateAccesses(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosPrivateAccessResource GetChaosPrivateAccessResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionResource GetChaosPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource GetChaosScenarioConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosScenarioResource GetChaosScenarioResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosScenarioRunResource GetChaosScenarioRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource> GetChaosTarget(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource> GetChaosTarget(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource>> GetChaosTargetAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource>> GetChaosTargetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource> GetChaosTargetMetadata(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource>> GetChaosTargetMetadataAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetMetadataResource GetChaosTargetMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetResource GetChaosTargetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetCollection GetChaosTargets(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetCollection GetChaosTargets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentProviderNamespace, string parentResourceType, string parentResourceName) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public static Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetTypeResource> GetChaosTargetType(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetTypeResource>> GetChaosTargetTypeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public static Azure.ResourceManager.Chaos.ChaosTargetTypeResource GetChaosTargetTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public static Azure.ResourceManager.Chaos.ChaosTargetTypeCollection GetChaosTargetTypes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> GetChaosWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceResource>> GetChaosWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosWorkspaceResource GetChaosWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosWorkspaceCollection GetChaosWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource> GetPrivateAccesses(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource> GetPrivateAccessesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> GetWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> GetWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChaosPrivateAccessCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource>, System.Collections.IEnumerable
    {
        protected ChaosPrivateAccessCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateAccessName, Azure.ResourceManager.Chaos.ChaosPrivateAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateAccessName, Azure.ResourceManager.Chaos.ChaosPrivateAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource> Get(string privateAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource>> GetAsync(string privateAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource> GetIfExists(string privateAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource>> GetIfExistsAsync(string privateAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosPrivateAccessData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosPrivateAccessData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosPrivateAccessData>
    {
        public ChaosPrivateAccessData(Azure.Core.AzureLocation location, Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessProperties properties) { }
        public Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.ChaosPrivateAccessData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosPrivateAccessData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosPrivateAccessData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosPrivateAccessData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosPrivateAccessData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosPrivateAccessData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosPrivateAccessData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosPrivateAccessResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosPrivateAccessData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosPrivateAccessData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosPrivateAccessResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosPrivateAccessData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateAccessName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionResource> GetChaosPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionResource>> GetChaosPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionCollection GetChaosPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceListResult> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceListResult>> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Chaos.ChaosPrivateAccessData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosPrivateAccessData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosPrivateAccessData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosPrivateAccessData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosPrivateAccessData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosPrivateAccessData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosPrivateAccessData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChaosPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected ChaosPrivateEndpointConnectionCollection() { }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData>
    {
        internal ChaosPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointConnectionProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateAccessName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosScenarioCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosScenarioResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosScenarioResource>, System.Collections.IEnumerable
    {
        protected ChaosScenarioCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosScenarioResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scenarioName, Azure.ResourceManager.Chaos.ChaosScenarioData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosScenarioResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scenarioName, Azure.ResourceManager.Chaos.ChaosScenarioData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scenarioName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scenarioName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioResource> Get(string scenarioName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosScenarioResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosScenarioResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioResource>> GetAsync(string scenarioName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosScenarioResource> GetIfExists(string scenarioName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosScenarioResource>> GetIfExistsAsync(string scenarioName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosScenarioResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosScenarioResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosScenarioResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosScenarioResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosScenarioConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource>, System.Collections.IEnumerable
    {
        protected ChaosScenarioConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scenarioConfigurationName, Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scenarioConfigurationName, Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scenarioConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scenarioConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource> Get(string scenarioConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource>> GetAsync(string scenarioConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource> GetIfExists(string scenarioConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource>> GetIfExistsAsync(string scenarioConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosScenarioConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData>
    {
        public ChaosScenarioConfigurationData() { }
        public Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosScenarioConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosScenarioConfigurationResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string scenarioName, string scenarioConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosScenarioRunResource> Execute(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosScenarioRunResource>> ExecuteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixData> FixResourcePermissions(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.Models.ChaosFixResourcePermissionsRequestContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixData>> FixResourcePermissionsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.Models.ChaosFixResourcePermissionsRequestContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationData> Validate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationData>> ValidateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChaosScenarioData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioData>
    {
        public ChaosScenarioData() { }
        public Azure.ResourceManager.Chaos.Models.ChaosScenarioProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.ChaosScenarioData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosScenarioData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosScenarioResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosScenarioResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosScenarioData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string scenarioName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource> GetChaosScenarioConfiguration(string scenarioConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource>> GetChaosScenarioConfigurationAsync(string scenarioConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosScenarioConfigurationCollection GetChaosScenarioConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioRunResource> GetChaosScenarioRun(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioRunResource>> GetChaosScenarioRunAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosScenarioRunCollection GetChaosScenarioRuns() { throw null; }
        Azure.ResourceManager.Chaos.ChaosScenarioData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosScenarioData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosScenarioResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.ChaosScenarioData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosScenarioResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.ChaosScenarioData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChaosScenarioRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosScenarioRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosScenarioRunResource>, System.Collections.IEnumerable
    {
        protected ChaosScenarioRunCollection() { }
        public virtual Azure.Response<bool> Exists(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioRunResource> Get(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosScenarioRunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosScenarioRunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioRunResource>> GetAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosScenarioRunResource> GetIfExists(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosScenarioRunResource>> GetIfExistsAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosScenarioRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosScenarioRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosScenarioRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosScenarioRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosScenarioRunData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioRunData>
    {
        internal ChaosScenarioRunData() { }
        public Azure.ResourceManager.Chaos.Models.ChaosScenarioRunProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.ChaosScenarioRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosScenarioRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosScenarioRunResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioRunData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosScenarioRunResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosScenarioRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosScenarioRunResource> Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosScenarioRunResource>> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string scenarioName, string runId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Chaos.ChaosScenarioRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosScenarioRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosTargetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosTargetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosTargetResource>, System.Collections.IEnumerable
    {
        protected ChaosTargetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosTargetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string targetName, Azure.ResourceManager.Chaos.ChaosTargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosTargetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string targetName, Azure.ResourceManager.Chaos.ChaosTargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource> Get(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosTargetResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosTargetResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource>> GetAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosTargetResource> GetIfExists(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosTargetResource>> GetIfExistsAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosTargetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosTargetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosTargetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosTargetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosTargetData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosTargetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetData>
    {
        public ChaosTargetData(System.Collections.Generic.IDictionary<string, System.BinaryData> properties) { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.ChaosTargetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosTargetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosTargetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosTargetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosTargetMetadataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource>, System.Collections.IEnumerable
    {
        protected ChaosTargetMetadataCollection() { }
        public virtual Azure.Response<bool> Exists(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource> Get(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource>> GetAsync(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource> GetIfExists(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource>> GetIfExistsAsync(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosTargetMetadataData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosTargetMetadataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetMetadataData>
    {
        internal ChaosTargetMetadataData() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string PropertiesSchema { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ResourceTypes { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.ChaosTargetMetadataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosTargetMetadataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosTargetMetadataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosTargetMetadataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetMetadataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetMetadataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetMetadataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosTargetMetadataResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosTargetMetadataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetMetadataData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosTargetMetadataResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetMetadataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string targetTypeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosCapabilityMetadataCollection GetAllChaosCapabilityMetadata() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataResource> GetChaosCapabilityMetadata(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityMetadataResource>> GetChaosCapabilityMetadataAsync(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Chaos.ChaosTargetMetadataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosTargetMetadataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosTargetMetadataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosTargetMetadataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetMetadataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetMetadataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetMetadataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosTargetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosTargetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosTargetResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosCapabilityCollection GetChaosCapabilities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityResource> GetChaosCapability(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityResource>> GetChaosCapabilityAsync(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Chaos.ChaosTargetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosTargetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosTargetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosTargetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosTargetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.ChaosTargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosTargetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.ChaosTargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `ChaosTargetMetadataCollection` moving forward.")]
    public partial class ChaosTargetTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosTargetTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosTargetTypeResource>, System.Collections.IEnumerable
    {
        protected ChaosTargetTypeCollection() { }
        public virtual Azure.Response<bool> Exists(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetTypeResource> Get(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosTargetTypeResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosTargetTypeResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetTypeResource>> GetAsync(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosTargetTypeResource> GetIfExists(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosTargetTypeResource>> GetIfExistsAsync(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosTargetTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosTargetTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosTargetTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosTargetTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `ChaosTargetMetadataData` moving forward.")]
    public partial class ChaosTargetTypeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosTargetTypeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetTypeData>
    {
        public ChaosTargetTypeData() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string PropertiesSchema { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ResourceTypes { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosTargetTypeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosTargetTypeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosTargetTypeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosTargetTypeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetTypeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetTypeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetTypeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `ChaosTargetMetadataResource` moving forward.")]
    public partial class ChaosTargetTypeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosTargetTypeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetTypeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosTargetTypeResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string locationName, string targetTypeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource> GetChaosCapabilityType(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource>> GetChaosCapabilityTypeAsync(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosCapabilityTypeCollection GetChaosCapabilityTypes() { throw null; }
        Azure.ResourceManager.Chaos.ChaosTargetTypeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosTargetTypeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosTargetTypeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosTargetTypeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetTypeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetTypeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosTargetTypeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosWorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosWorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosWorkspaceResource>, System.Collections.IEnumerable
    {
        protected ChaosWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Chaos.ChaosWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Chaos.ChaosWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> GetIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosWorkspaceResource>> GetIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosWorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosWorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosWorkspaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosWorkspaceData>
    {
        public ChaosWorkspaceData(Azure.Core.AzureLocation location, Azure.ResourceManager.Chaos.Models.ChaosWorkspaceProperties properties) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.ChaosWorkspaceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.ChaosWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosWorkspaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosWorkspaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosWorkspaceResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosWorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosDiscoveredResource> GetChaosDiscovered(string discoveredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosDiscoveredResource>> GetChaosDiscoveredAsync(string discoveredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosDiscoveredCollection GetChaosDiscovereds() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioResource> GetChaosScenario(string scenarioName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioResource>> GetChaosScenarioAsync(string scenarioName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosScenarioCollection GetChaosScenarios() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationData> RefreshRecommendations(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationData>> RefreshRecommendationsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Chaos.ChaosWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.Models.ChaosWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosWorkspaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.Models.ChaosWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Chaos.Mocking
{
    public partial class MockableChaosArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableChaosArmClient() { }
        public virtual Azure.ResourceManager.Chaos.ChaosActionResource GetChaosActionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosActionVersionResource GetChaosActionVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosCapabilityCollection GetChaosCapabilities(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityResource> GetChaosCapability(Azure.Core.ResourceIdentifier scope, string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityResource>> GetChaosCapabilityAsync(Azure.Core.ResourceIdentifier scope, string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosCapabilityMetadataResource GetChaosCapabilityMetadataResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosCapabilityResource GetChaosCapabilityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public virtual Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource GetChaosCapabilityTypeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosDiscoveredResource GetChaosDiscoveredResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource GetChaosExperimentExecutionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosExperimentResource GetChaosExperimentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosPrivateAccessResource GetChaosPrivateAccessResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionResource GetChaosPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource GetChaosScenarioConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosScenarioResource GetChaosScenarioResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosScenarioRunResource GetChaosScenarioRunResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource> GetChaosTarget(Azure.Core.ResourceIdentifier scope, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource>> GetChaosTargetAsync(Azure.Core.ResourceIdentifier scope, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetMetadataResource GetChaosTargetMetadataResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetResource GetChaosTargetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetCollection GetChaosTargets(Azure.Core.ResourceIdentifier scope) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public virtual Azure.ResourceManager.Chaos.ChaosTargetTypeResource GetChaosTargetTypeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosWorkspaceResource GetChaosWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableChaosResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableChaosResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetChaosExperiment(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource>> GetChaosExperimentAsync(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosExperimentCollection GetChaosExperiments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource> GetChaosPrivateAccess(string privateAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource>> GetChaosPrivateAccessAsync(string privateAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosPrivateAccessCollection GetChaosPrivateAccesses() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource> GetChaosTarget(string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource>> GetChaosTargetAsync(string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetCollection GetChaosTargets(string parentProviderNamespace, string parentResourceType, string parentResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> GetChaosWorkspace(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceResource>> GetChaosWorkspaceAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosWorkspaceCollection GetChaosWorkspaces() { throw null; }
    }
    public partial class MockableChaosSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableChaosSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> Get(string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetMetadataCollection GetAllChaosTargetMetadata(Azure.Core.AzureLocation location) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetAsync(string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosActionResource> GetChaosAction(Azure.Core.AzureLocation location, string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosActionResource>> GetChaosActionAsync(Azure.Core.AzureLocation location, string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosActionCollection GetChaosActions(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetChaosExperiments(bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetChaosExperimentsAsync(bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> GetChaosOperationStatus(Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetChaosOperationStatusAsync(Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource> GetChaosTargetMetadata(Azure.Core.AzureLocation location, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource>> GetChaosTargetMetadataAsync(Azure.Core.AzureLocation location, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetTypeResource> GetChaosTargetType(string locationName, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetTypeResource>> GetChaosTargetTypeAsync(string locationName, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public virtual Azure.ResourceManager.Chaos.ChaosTargetTypeCollection GetChaosTargetTypes(string locationName) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource> GetPrivateAccesses(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosPrivateAccessResource> GetPrivateAccessesAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> GetWorkspaces(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> GetWorkspacesAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Chaos.Models
{
    public static partial class ArmChaosModelFactory
    {
        public static Azure.ResourceManager.Chaos.ChaosActionData ChaosActionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string canonicalId = null, string displayName = null, string description = null, string actionName = null, string version = null, Azure.ResourceManager.Chaos.Models.ChaosActionKind? actionType = default(Azure.ResourceManager.Chaos.Models.ChaosActionKind?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosActionSupportedTargetType> supportedTargetTypes = null, Azure.ResourceManager.Chaos.Models.ChaosActionParametersSchema parametersSchema = null, System.Collections.Generic.IEnumerable<System.Guid> recommendedRoles = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosActionSupportedTargetType ChaosActionSupportedTargetType(string targetType = null, System.Collections.Generic.IEnumerable<string> requiredPermissions = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosActionVersionData ChaosActionVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string canonicalId = null, string displayName = null, string description = null, string actionName = null, string version = null, Azure.ResourceManager.Chaos.Models.ChaosActionKind? actionType = default(Azure.ResourceManager.Chaos.Models.ChaosActionKind?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosActionSupportedTargetType> supportedTargetTypes = null, Azure.ResourceManager.Chaos.Models.ChaosActionParametersSchema parametersSchema = null, System.Collections.Generic.IEnumerable<System.Guid> recommendedRoles = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosCapabilityData ChaosCapabilityData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string publisher, string targetType, string description, string parametersSchema, string urn) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosCapabilityData ChaosCapabilityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string publisher = null, string targetType = null, string description = null, string parametersSchema = null, string urn = null, Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosCapabilityMetadataData ChaosCapabilityMetadataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string publisher = null, string targetType = null, string displayName = null, string description = null, string parametersSchema = null, string urn = null, string kind = null, System.Collections.Generic.IEnumerable<string> azureRbacActions = null, System.Collections.Generic.IEnumerable<string> azureRbacDataActions = null, System.Collections.Generic.IEnumerable<string> requiredAzureRoleDefinitionIds = null, string runtimeKind = null) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public static Azure.ResourceManager.Chaos.ChaosCapabilityTypeData ChaosCapabilityTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string publisher = null, string targetType = null, string displayName = null, string description = null, string parametersSchema = null, string urn = null, string kind = null, System.Collections.Generic.IEnumerable<string> azureRbacActions = null, System.Collections.Generic.IEnumerable<string> azureRbacDataActions = null, string runtimeKind = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosContinuousAction ChaosContinuousAction(string name = null, System.TimeSpan duration = default(System.TimeSpan), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> parameters = null, string selectorId = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosDiscoveredData ChaosDiscoveredData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.ChaosDiscoveredResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosDiscoveredResourceProperties ChaosDiscoveredResourceProperties(string resourceNamespace = null, string resourceName = null, string resourceType = null, string fullyQualifiedIdentifier = null, System.DateTimeOffset discoveredOn = default(System.DateTimeOffset), string scope = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosDiscreteAction ChaosDiscreteAction(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> parameters = null, string selectorId = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosEntraIdentity ChaosEntraIdentity(System.Guid objectId = default(System.Guid), System.Guid tenantId = default(System.Guid)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosExperimentBranch ChaosExperimentBranch(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentAction> actions = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentData ChaosExperimentData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep> steps, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosTargetSelector> selectors) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentData ChaosExperimentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep> steps = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosTargetSelector> selectors = null, Azure.ResourceManager.Chaos.Models.ChaosCustomerDataStorageProperties customerDataStorage = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentExecutionData ChaosExperimentExecutionData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string status, System.DateTimeOffset? startedOn, System.DateTimeOffset? stoppedOn) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentExecutionData ChaosExperimentExecutionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string status = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? stoppedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosExperimentPatch ChaosExperimentPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosExperimentRunActionStatus ChaosExperimentRunActionStatus(string actionName = null, string actionId = null, string status = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties> targets = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosExperimentRunBranchStatus ChaosExperimentRunBranchStatus(string branchName = null, string branchId = null, string status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunActionStatus> actions = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosExperimentRunStepStatus ChaosExperimentRunStepStatus(string stepName = null, string stepId = null, string status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunBranchStatus> branches = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosExperimentStep ChaosExperimentStep(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentBranch> branches = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosOperationError ChaosOperationError(string errorCode = null, string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosPermissionError ChaosPermissionError(Azure.Core.ResourceIdentifier resourceId = null, System.Collections.Generic.IEnumerable<string> missingPermissions = null, System.Collections.Generic.IEnumerable<string> requiredPermissions = null, System.Collections.Generic.IEnumerable<string> recommendedRoles = null, Azure.ResourceManager.Chaos.Models.ChaosEntraIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixData ChaosPermissionsFixData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixProperties ChaosPermissionsFixProperties(Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixState state = default(Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixState), System.DateTimeOffset startedOn = default(System.DateTimeOffset), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), bool isWhatIfMode = false, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentResult> roleAssignments = null, Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixSummary summary = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixSummary ChaosPermissionsFixSummary(int totalRequired = 0, int succeeded = 0, int failed = 0, int skipped = 0) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosPhysicalToLogicalZoneMapping ChaosPhysicalToLogicalZoneMapping(string physicalZone = null, string logicalZone = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosPrivateAccessData ChaosPrivateAccessData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPatch ChaosPrivateAccessPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessProperties ChaosPrivateAccessProperties(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPublicNetworkAccessOption? publicNetworkAccess = default(Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPublicNetworkAccessOption?)) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData ChaosPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointConnectionProperties ChaosPrivateEndpointConnectionProperties(System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResource ChaosPrivateLinkResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceListResult ChaosPrivateLinkResourceListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResource> value = null, System.Uri nextLink = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceProperties ChaosPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null, Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkServiceConnectionState ChaosPrivateLinkServiceConnectionState(Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointServiceConnectionStatus? status = default(Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointServiceConnectionStatus?), string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosResourceStateError ChaosResourceStateError(Azure.Core.ResourceIdentifier resourceId = null, int errorCode = 0, string errorMessage = null, string remediationUri = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentError ChaosRoleAssignmentError(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentResult ChaosRoleAssignmentResult(Azure.Core.ResourceIdentifier targetResourceId = null, System.Guid principalId = default(System.Guid), string roleDefinitionId = null, string roleDefinitionName = null, string scope = null, Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentStatus status = default(Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentStatus), Azure.Core.ResourceIdentifier roleAssignmentId = null, Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentError error = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosRunAfter ChaosRunAfter(Azure.ResourceManager.Chaos.Models.ChaosRunAfterBehavior? behavior = default(Azure.ResourceManager.Chaos.Models.ChaosRunAfterBehavior?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependency> items = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioAction ChaosScenarioAction(string name = null, string actionId = null, string description = null, string duration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> parameters = null, Azure.ResourceManager.Chaos.Models.ChaosRunAfter runAfter = null, string waitBefore = null, string timeout = null, Azure.Core.ResourceIdentifier resourceId = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData ChaosScenarioConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationExclusions ChaosScenarioConfigurationExclusions(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> tags = null, System.Collections.Generic.IEnumerable<string> types = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationFilters ChaosScenarioConfigurationFilters(System.Collections.Generic.IEnumerable<string> locations = null, System.Collections.Generic.IEnumerable<string> zones = null, System.Collections.Generic.IEnumerable<string> physicalZones = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationProperties ChaosScenarioConfigurationProperties(Azure.Core.ResourceIdentifier scenarioId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> parameters = null, Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationExclusions exclusions = null, Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?), Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationFilters filters = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosScenarioData ChaosScenarioData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.ChaosScenarioProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioErrors ChaosScenarioErrors(string errorCode = null, string errorMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosPermissionError> permission = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosResourceStateError> resource = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioEvaluationResultItem ChaosScenarioEvaluationResultItem(string scenarioName = null, Azure.ResourceManager.Chaos.Models.ChaosRecommendationStatus evaluationResult = default(Azure.ResourceManager.Chaos.Models.ChaosRecommendationStatus)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioProperties ChaosScenarioProperties(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?), string createdFrom = null, string version = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterInfo> parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosScenarioAction> actions = null, Azure.ResourceManager.Chaos.Models.ChaosScenarioRecommendation recommendation = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioRecommendation ChaosScenarioRecommendation(Azure.ResourceManager.Chaos.Models.ChaosRecommendationStatus recommendationStatus = default(Azure.ResourceManager.Chaos.Models.ChaosRecommendationStatus), System.DateTimeOffset? evaluationRunOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosScenarioRunData ChaosScenarioRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.ChaosScenarioRunProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioRunProperties ChaosScenarioRunProperties(string workspaceName = null, string scenarioName = null, string scenarioConfigurationName = null, System.Guid managedIdentityPrincipalId = default(System.Guid), Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState status = default(Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunResourceInfo> resources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosOperationError> errors = null, Azure.ResourceManager.Chaos.Models.ChaosScenarioErrors executionErrors = null, string scenarioRunJson = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunSummaryAction> scenarioRunSummary = null, System.DateTimeOffset startOn = default(System.DateTimeOffset), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionInfo zoneResolution = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioRunResourceInfo ChaosScenarioRunResourceInfo(Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioRunSummaryAction ChaosScenarioRunSummaryAction(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunResourceInfo> resources = null, string actionUrn = null, Azure.ResourceManager.Chaos.Models.ChaosScenarioSummaryState state = default(Azure.ResourceManager.Chaos.Models.ChaosScenarioSummaryState), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationData ChaosScenarioValidationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationProperties ChaosScenarioValidationProperties(Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationState status = default(Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationState), System.DateTimeOffset startOn = default(System.DateTimeOffset), string executionPlanJson = null, System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosOperationError> errors = null, Azure.ResourceManager.Chaos.Models.ChaosScenarioErrors validationErrors = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetData ChaosTargetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, System.BinaryData> properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public static Azure.ResourceManager.Chaos.ChaosTargetData ChaosTargetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IDictionary<string, System.BinaryData> properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosTargetListSelector ChaosTargetListSelector(string id = null, Azure.ResourceManager.Chaos.Models.ChaosTargetFilter filter = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosTargetReference> targets = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetMetadataData ChaosTargetMetadataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, string description = null, string propertiesSchema = null, System.Collections.Generic.IEnumerable<string> resourceTypes = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosTargetQuerySelector ChaosTargetQuerySelector(string id = null, Azure.ResourceManager.Chaos.Models.ChaosTargetFilter filter = null, string queryString = null, System.Collections.Generic.IEnumerable<string> subscriptionIds = null) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public static Azure.ResourceManager.Chaos.ChaosTargetTypeData ChaosTargetTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string displayName = null, string description = null, string propertiesSchema = null, System.Collections.Generic.IEnumerable<string> resourceTypes = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosWorkspaceData ChaosWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Chaos.Models.ChaosWorkspaceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationData ChaosWorkspaceEvaluationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationProperties ChaosWorkspaceEvaluationProperties(Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationStatus status = default(Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationStatus), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosOperationError> errors = null, Azure.Core.ResourceIdentifier workspaceId = null, int? numScenariosToEvaluate = default(int?), int? numScenariosEvaluatedSucceeded = default(int?), int? numScenariosEvaluatedFailed = default(int?), int? numScenariosEvaluatedCancelled = default(int?), Azure.ResourceManager.Chaos.Models.ChaosRecommendationStatus? evaluationResult = default(Azure.ResourceManager.Chaos.Models.ChaosRecommendationStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosScenarioEvaluationResultItem> results = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosWorkspacePatch ChaosWorkspacePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosWorkspaceProperties ChaosWorkspaceProperties(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?), string communicationEndpoint = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> scopes = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionInfo ChaosZoneResolutionInfo(Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMode mode = default(Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMode), System.Collections.Generic.IEnumerable<string> requestedPhysicalZones = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMapping> subscriptionZoneMappings = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMapping ChaosZoneResolutionMapping(string subscriptionId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosPhysicalToLogicalZoneMapping> zoneMappings = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError ExperimentExecutionActionTargetDetailsError(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties ExperimentExecutionActionTargetDetailsProperties(string status = null, string target = null, System.DateTimeOffset? targetFailedOn = default(System.DateTimeOffset?), System.DateTimeOffset? targetCompletedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError error = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails ExperimentExecutionDetails(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string status = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? stoppedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?), string failureReason = null, System.DateTimeOffset? lastActionOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunStepStatus> runInformationSteps = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails ExperimentExecutionDetails(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string status, System.DateTimeOffset? startedOn, System.DateTimeOffset? stoppedOn, string failureReason, System.DateTimeOffset? lastActionOn, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunStepStatus> runInformationSteps) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChaosActionKind : System.IEquatable<Azure.ResourceManager.Chaos.Models.ChaosActionKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChaosActionKind(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosActionKind Cancelable { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosActionKind Continuous { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosActionKind Discrete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ChaosActionKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ChaosActionKind left, Azure.ResourceManager.Chaos.Models.ChaosActionKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosActionKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosActionKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ChaosActionKind left, Azure.ResourceManager.Chaos.Models.ChaosActionKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChaosActionLifecycle : System.IEquatable<Azure.ResourceManager.Chaos.Models.ChaosActionLifecycle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChaosActionLifecycle(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosActionLifecycle AnyTerminal { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosActionLifecycle Failure { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosActionLifecycle Running { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosActionLifecycle Skipped { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosActionLifecycle Start { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosActionLifecycle Success { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ChaosActionLifecycle other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ChaosActionLifecycle left, Azure.ResourceManager.Chaos.Models.ChaosActionLifecycle right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosActionLifecycle (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosActionLifecycle? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ChaosActionLifecycle left, Azure.ResourceManager.Chaos.Models.ChaosActionLifecycle right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChaosActionParametersSchema : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosActionParametersSchema>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosActionParametersSchema>
    {
        internal ChaosActionParametersSchema() { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosActionParametersSchema JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosActionParametersSchema PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosActionParametersSchema System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosActionParametersSchema>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosActionParametersSchema>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosActionParametersSchema System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosActionParametersSchema>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosActionParametersSchema>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosActionParametersSchema>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosActionSupportedTargetType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosActionSupportedTargetType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosActionSupportedTargetType>
    {
        internal ChaosActionSupportedTargetType() { }
        public System.Collections.Generic.IList<string> RequiredPermissions { get { throw null; } }
        public string TargetType { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosActionSupportedTargetType JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosActionSupportedTargetType PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosActionSupportedTargetType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosActionSupportedTargetType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosActionSupportedTargetType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosActionSupportedTargetType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosActionSupportedTargetType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosActionSupportedTargetType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosActionSupportedTargetType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosContinuousAction : Azure.ResourceManager.Chaos.Models.ChaosExperimentAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosContinuousAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosContinuousAction>
    {
        public ChaosContinuousAction(string name, System.TimeSpan duration, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> parameters, string selectorId) : base (default(string)) { }
        public System.TimeSpan Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> Parameters { get { throw null; } }
        public string SelectorId { get { throw null; } set { } }
        protected override Azure.ResourceManager.Chaos.Models.ChaosExperimentAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Chaos.Models.ChaosExperimentAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosContinuousAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosContinuousAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosContinuousAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosContinuousAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosContinuousAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosContinuousAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosContinuousAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosCustomerDataStorageProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosCustomerDataStorageProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosCustomerDataStorageProperties>
    {
        public ChaosCustomerDataStorageProperties() { }
        public string BlobContainerName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosCustomerDataStorageProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosCustomerDataStorageProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosCustomerDataStorageProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosCustomerDataStorageProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosCustomerDataStorageProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosCustomerDataStorageProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosCustomerDataStorageProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosCustomerDataStorageProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosCustomerDataStorageProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosDelayAction : Azure.ResourceManager.Chaos.Models.ChaosExperimentAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosDelayAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosDelayAction>
    {
        public ChaosDelayAction(string name, System.TimeSpan duration) : base (default(string)) { }
        public System.TimeSpan Duration { get { throw null; } set { } }
        protected override Azure.ResourceManager.Chaos.Models.ChaosExperimentAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Chaos.Models.ChaosExperimentAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosDelayAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosDelayAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosDelayAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosDelayAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosDelayAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosDelayAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosDelayAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosDiscoveredResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosDiscoveredResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosDiscoveredResourceProperties>
    {
        internal ChaosDiscoveredResourceProperties() { }
        public System.DateTimeOffset DiscoveredOn { get { throw null; } }
        public string FullyQualifiedIdentifier { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ResourceNamespace { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public string Scope { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosDiscoveredResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosDiscoveredResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosDiscoveredResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosDiscoveredResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosDiscoveredResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosDiscoveredResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosDiscoveredResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosDiscoveredResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosDiscoveredResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosDiscreteAction : Azure.ResourceManager.Chaos.Models.ChaosExperimentAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosDiscreteAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosDiscreteAction>
    {
        public ChaosDiscreteAction(string name, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> parameters, string selectorId) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> Parameters { get { throw null; } }
        public string SelectorId { get { throw null; } set { } }
        protected override Azure.ResourceManager.Chaos.Models.ChaosExperimentAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Chaos.Models.ChaosExperimentAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosDiscreteAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosDiscreteAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosDiscreteAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosDiscreteAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosDiscreteAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosDiscreteAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosDiscreteAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosEntraIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosEntraIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosEntraIdentity>
    {
        internal ChaosEntraIdentity() { }
        public System.Guid ObjectId { get { throw null; } }
        public System.Guid TenantId { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosEntraIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosEntraIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosEntraIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosEntraIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosEntraIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosEntraIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosEntraIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosEntraIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosEntraIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ChaosExperimentAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentAction>
    {
        protected ChaosExperimentAction(string name) { }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosExperimentAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosExperimentAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosExperimentAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosExperimentAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosExperimentBranch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentBranch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentBranch>
    {
        public ChaosExperimentBranch(string name, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentAction> actions) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosExperimentAction> Actions { get { throw null; } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosExperimentBranch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosExperimentBranch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosExperimentBranch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentBranch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentBranch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosExperimentBranch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentBranch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentBranch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentBranch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosExperimentPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentPatch>
    {
        public ChaosExperimentPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosExperimentPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosExperimentPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosExperimentPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosExperimentPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosExperimentRunActionStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunActionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunActionStatus>
    {
        internal ChaosExperimentRunActionStatus() { }
        public string ActionId { get { throw null; } }
        public string ActionName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties> Targets { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosExperimentRunActionStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosExperimentRunActionStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosExperimentRunActionStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunActionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunActionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosExperimentRunActionStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunActionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunActionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunActionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosExperimentRunBranchStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunBranchStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunBranchStatus>
    {
        internal ChaosExperimentRunBranchStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunActionStatus> Actions { get { throw null; } }
        public string BranchId { get { throw null; } }
        public string BranchName { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosExperimentRunBranchStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosExperimentRunBranchStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosExperimentRunBranchStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunBranchStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunBranchStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosExperimentRunBranchStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunBranchStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunBranchStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunBranchStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosExperimentRunStepStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunStepStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunStepStatus>
    {
        internal ChaosExperimentRunStepStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunBranchStatus> Branches { get { throw null; } }
        public string Status { get { throw null; } }
        public string StepId { get { throw null; } }
        public string StepName { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosExperimentRunStepStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosExperimentRunStepStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosExperimentRunStepStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunStepStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunStepStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosExperimentRunStepStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunStepStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunStepStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunStepStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosExperimentStep : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep>
    {
        public ChaosExperimentStep(string name, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentBranch> branches) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosExperimentBranch> Branches { get { throw null; } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosExperimentStep JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosExperimentStep PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosExperimentStep System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosExperimentStep System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosFixResourcePermissionsRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosFixResourcePermissionsRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosFixResourcePermissionsRequestContent>
    {
        public ChaosFixResourcePermissionsRequestContent() { }
        public bool? IsWhatIf { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosFixResourcePermissionsRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosFixResourcePermissionsRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosFixResourcePermissionsRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosFixResourcePermissionsRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosFixResourcePermissionsRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosFixResourcePermissionsRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosFixResourcePermissionsRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosFixResourcePermissionsRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosFixResourcePermissionsRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosKeyValuePair : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair>
    {
        public ChaosKeyValuePair(string key, string value) { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosOperationError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosOperationError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosOperationError>
    {
        internal ChaosOperationError() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosOperationError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosOperationError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosOperationError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosOperationError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosOperationError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosOperationError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosOperationError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosOperationError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosOperationError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosPermissionError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionError>
    {
        internal ChaosPermissionError() { }
        public Azure.ResourceManager.Chaos.Models.ChaosEntraIdentity Identity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> MissingPermissions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RecommendedRoles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredPermissions { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosPermissionError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosPermissionError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosPermissionError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosPermissionError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosPermissionsFixData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixData>
    {
        internal ChaosPermissionsFixData() { }
        public Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosPermissionsFixProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixProperties>
    {
        internal ChaosPermissionsFixProperties() { }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public bool IsWhatIfMode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentResult> RoleAssignments { get { throw null; } }
        public System.DateTimeOffset StartedOn { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixState State { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixSummary Summary { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChaosPermissionsFixState : System.IEquatable<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChaosPermissionsFixState(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixState Failed { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixState NotStarted { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixState WhatIfCompleted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixState left, Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixState left, Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChaosPermissionsFixSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixSummary>
    {
        internal ChaosPermissionsFixSummary() { }
        public int Failed { get { throw null; } }
        public int Skipped { get { throw null; } }
        public int Succeeded { get { throw null; } }
        public int TotalRequired { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosPhysicalToLogicalZoneMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPhysicalToLogicalZoneMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPhysicalToLogicalZoneMapping>
    {
        internal ChaosPhysicalToLogicalZoneMapping() { }
        public string LogicalZone { get { throw null; } }
        public string PhysicalZone { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosPhysicalToLogicalZoneMapping JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosPhysicalToLogicalZoneMapping PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosPhysicalToLogicalZoneMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPhysicalToLogicalZoneMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPhysicalToLogicalZoneMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosPhysicalToLogicalZoneMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPhysicalToLogicalZoneMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPhysicalToLogicalZoneMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPhysicalToLogicalZoneMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosPrivateAccessPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPatch>
    {
        public ChaosPrivateAccessPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosPrivateAccessProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessProperties>
    {
        public ChaosPrivateAccessProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPublicNetworkAccessOption? PublicNetworkAccess { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChaosPrivateAccessPublicNetworkAccessOption : System.IEquatable<Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPublicNetworkAccessOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChaosPrivateAccessPublicNetworkAccessOption(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPublicNetworkAccessOption Disabled { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPublicNetworkAccessOption Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPublicNetworkAccessOption other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPublicNetworkAccessOption left, Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPublicNetworkAccessOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPublicNetworkAccessOption (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPublicNetworkAccessOption? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPublicNetworkAccessOption left, Azure.ResourceManager.Chaos.Models.ChaosPrivateAccessPublicNetworkAccessOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChaosPrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointConnectionProperties>
    {
        internal ChaosPrivateEndpointConnectionProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChaosPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChaosPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointServiceConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointServiceConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChaosPrivateLinkResource : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResource>
    {
        internal ChaosPrivateLinkResource() { }
        public Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosPrivateLinkResourceListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceListResult>
    {
        internal ChaosPrivateLinkResourceListResult() { }
        public System.Uri NextLink { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResource> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceProperties>
    {
        internal ChaosPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkServiceConnectionState>
    {
        internal ChaosPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointServiceConnectionStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkServiceConnectionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkServiceConnectionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChaosProvisioningState : System.IEquatable<Azure.ResourceManager.Chaos.Models.ChaosProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChaosProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState left, Azure.ResourceManager.Chaos.Models.ChaosProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState left, Azure.ResourceManager.Chaos.Models.ChaosProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChaosRecommendationStatus : System.IEquatable<Azure.ResourceManager.Chaos.Models.ChaosRecommendationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChaosRecommendationStatus(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosRecommendationStatus Evaluating { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosRecommendationStatus EvaluationCancelled { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosRecommendationStatus EvaluationFailed { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosRecommendationStatus NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosRecommendationStatus NotEvaluated { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosRecommendationStatus Recommended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ChaosRecommendationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ChaosRecommendationStatus left, Azure.ResourceManager.Chaos.Models.ChaosRecommendationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosRecommendationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosRecommendationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ChaosRecommendationStatus left, Azure.ResourceManager.Chaos.Models.ChaosRecommendationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChaosResourceStateError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosResourceStateError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosResourceStateError>
    {
        internal ChaosResourceStateError() { }
        public int ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string RemediationUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosResourceStateError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosResourceStateError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosResourceStateError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosResourceStateError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosResourceStateError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosResourceStateError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosResourceStateError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosResourceStateError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosResourceStateError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosRoleAssignmentError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentError>
    {
        internal ChaosRoleAssignmentError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosRoleAssignmentResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentResult>
    {
        internal ChaosRoleAssignmentResult() { }
        public Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentError Error { get { throw null; } }
        public System.Guid PrincipalId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleAssignmentId { get { throw null; } }
        public string RoleDefinitionId { get { throw null; } }
        public string RoleDefinitionName { get { throw null; } }
        public string Scope { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentStatus Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChaosRoleAssignmentStatus : System.IEquatable<Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChaosRoleAssignmentStatus(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentStatus Skipped { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentStatus left, Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentStatus left, Azure.ResourceManager.Chaos.Models.ChaosRoleAssignmentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChaosRunAfter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosRunAfter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosRunAfter>
    {
        public ChaosRunAfter(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependency> items) { }
        public Azure.ResourceManager.Chaos.Models.ChaosRunAfterBehavior? Behavior { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependency> Items { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosRunAfter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosRunAfter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosRunAfter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosRunAfter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosRunAfter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosRunAfter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosRunAfter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosRunAfter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosRunAfter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChaosRunAfterBehavior : System.IEquatable<Azure.ResourceManager.Chaos.Models.ChaosRunAfterBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChaosRunAfterBehavior(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosRunAfterBehavior All { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosRunAfterBehavior Any { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosRunAfterBehavior AtLeastOne { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ChaosRunAfterBehavior other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ChaosRunAfterBehavior left, Azure.ResourceManager.Chaos.Models.ChaosRunAfterBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosRunAfterBehavior (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosRunAfterBehavior? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ChaosRunAfterBehavior left, Azure.ResourceManager.Chaos.Models.ChaosRunAfterBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChaosScenarioAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioAction>
    {
        public ChaosScenarioAction(string name, string actionId, string duration) { }
        public string ActionId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Duration { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> Parameters { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.ChaosRunAfter RunAfter { get { throw null; } set { } }
        public string Timeout { get { throw null; } set { } }
        public string WaitBefore { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosScenarioActionDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependency>
    {
        public ChaosScenarioActionDependency(Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependencyType type, string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.ChaosActionLifecycle? OnActionLifecycle { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependencyType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependency JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependency PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChaosScenarioActionDependencyType : System.IEquatable<Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependencyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChaosScenarioActionDependencyType(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependencyType Action { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependencyType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependencyType left, Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependencyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependencyType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependencyType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependencyType left, Azure.ResourceManager.Chaos.Models.ChaosScenarioActionDependencyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChaosScenarioConfigurationExclusions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationExclusions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationExclusions>
    {
        public ChaosScenarioConfigurationExclusions() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> Resources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> Tags { get { throw null; } }
        public System.Collections.Generic.IList<string> Types { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationExclusions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationExclusions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationExclusions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationExclusions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationExclusions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationExclusions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationExclusions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationExclusions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationExclusions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosScenarioConfigurationFilters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationFilters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationFilters>
    {
        public ChaosScenarioConfigurationFilters() { }
        public System.Collections.Generic.IList<string> Locations { get { throw null; } }
        public System.Collections.Generic.IList<string> PhysicalZones { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationFilters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationFilters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationFilters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationFilters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationFilters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationFilters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationFilters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationFilters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationFilters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosScenarioConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationProperties>
    {
        public ChaosScenarioConfigurationProperties(Azure.Core.ResourceIdentifier scenarioId) { }
        public Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationExclusions Exclusions { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationFilters Filters { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> Parameters { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ScenarioId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosScenarioErrors : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioErrors>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioErrors>
    {
        internal ChaosScenarioErrors() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosPermissionError> Permission { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosResourceStateError> Resource { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioErrors JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioErrors PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioErrors System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioErrors>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioErrors>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioErrors System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioErrors>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioErrors>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioErrors>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosScenarioEvaluationResultItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioEvaluationResultItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioEvaluationResultItem>
    {
        internal ChaosScenarioEvaluationResultItem() { }
        public Azure.ResourceManager.Chaos.Models.ChaosRecommendationStatus EvaluationResult { get { throw null; } }
        public string ScenarioName { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioEvaluationResultItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioEvaluationResultItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioEvaluationResultItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioEvaluationResultItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioEvaluationResultItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioEvaluationResultItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioEvaluationResultItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioEvaluationResultItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioEvaluationResultItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosScenarioParameterInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterInfo>
    {
        public ChaosScenarioParameterInfo(string name, Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterType type) { }
        public string Default { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? IsRequired { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChaosScenarioParameterType : System.IEquatable<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChaosScenarioParameterType(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterType Array { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterType Boolean { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterType Number { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterType Object { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterType left, Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterType left, Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChaosScenarioProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioProperties>
    {
        public ChaosScenarioProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterInfo> parameters, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosScenarioAction> actions) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosScenarioAction> Actions { get { throw null; } }
        public string CreatedFrom { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterInfo> Parameters { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosScenarioRecommendation Recommendation { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosScenarioRecommendation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRecommendation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRecommendation>
    {
        internal ChaosScenarioRecommendation() { }
        public System.DateTimeOffset? EvaluationRunOn { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosRecommendationStatus RecommendationStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioRecommendation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioRecommendation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioRecommendation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRecommendation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRecommendation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioRecommendation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRecommendation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRecommendation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRecommendation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosScenarioRunProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunProperties>
    {
        internal ChaosScenarioRunProperties() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosOperationError> Errors { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosScenarioErrors ExecutionErrors { get { throw null; } }
        public System.Guid ManagedIdentityPrincipalId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunResourceInfo> Resources { get { throw null; } }
        public string ScenarioConfigurationName { get { throw null; } }
        public string ScenarioName { get { throw null; } }
        public string ScenarioRunJson { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunSummaryAction> ScenarioRunSummary { get { throw null; } }
        public System.DateTimeOffset StartOn { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState Status { get { throw null; } }
        public string WorkspaceName { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionInfo ZoneResolution { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioRunProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioRunProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioRunProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioRunProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosScenarioRunResourceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunResourceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunResourceInfo>
    {
        internal ChaosScenarioRunResourceInfo() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioRunResourceInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioRunResourceInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioRunResourceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunResourceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunResourceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioRunResourceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunResourceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunResourceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunResourceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChaosScenarioRunState : System.IEquatable<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChaosScenarioRunState(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState Canceling { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState CleaningUp { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState Failed { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState Generating { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState Preparing { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState Queued { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState Resolving { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState Running { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState Starting { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState Validating { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState ValidationSucceeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState left, Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState left, Azure.ResourceManager.Chaos.Models.ChaosScenarioRunState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChaosScenarioRunSummaryAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunSummaryAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunSummaryAction>
    {
        internal ChaosScenarioRunSummaryAction() { }
        public string ActionUrn { get { throw null; } }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunResourceInfo> Resources { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosScenarioSummaryState State { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioRunSummaryAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioRunSummaryAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioRunSummaryAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunSummaryAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunSummaryAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioRunSummaryAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunSummaryAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunSummaryAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRunSummaryAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChaosScenarioSummaryState : System.IEquatable<Azure.ResourceManager.Chaos.Models.ChaosScenarioSummaryState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChaosScenarioSummaryState(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioSummaryState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioSummaryState Canceling { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioSummaryState Failed { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioSummaryState FailingOnError { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioSummaryState Pending { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioSummaryState Running { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioSummaryState Skipped { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioSummaryState Starting { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioSummaryState Stopping { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioSummaryState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ChaosScenarioSummaryState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ChaosScenarioSummaryState left, Azure.ResourceManager.Chaos.Models.ChaosScenarioSummaryState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosScenarioSummaryState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosScenarioSummaryState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ChaosScenarioSummaryState left, Azure.ResourceManager.Chaos.Models.ChaosScenarioSummaryState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChaosScenarioValidationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationData>
    {
        internal ChaosScenarioValidationData() { }
        public Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosScenarioValidationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationProperties>
    {
        internal ChaosScenarioValidationProperties() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosOperationError> Errors { get { throw null; } }
        public string ExecutionPlanJson { get { throw null; } }
        public System.DateTimeOffset StartOn { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationState Status { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosScenarioErrors ValidationErrors { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChaosScenarioValidationState : System.IEquatable<Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChaosScenarioValidationState(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationState Generating { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationState NoResolvedResources { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationState NotStarted { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationState RequiresAttention { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationState Resolving { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationState Validating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationState left, Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationState left, Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ChaosTargetFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosTargetFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetFilter>
    {
        protected ChaosTargetFilter() { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosTargetFilter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosTargetFilter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosTargetFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosTargetFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosTargetFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosTargetFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosTargetListSelector : Azure.ResourceManager.Chaos.Models.ChaosTargetSelector, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosTargetListSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetListSelector>
    {
        public ChaosTargetListSelector(string id, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosTargetReference> targets) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosTargetReference> Targets { get { throw null; } }
        protected override Azure.ResourceManager.Chaos.Models.ChaosTargetSelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Chaos.Models.ChaosTargetSelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosTargetListSelector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosTargetListSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosTargetListSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosTargetListSelector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetListSelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetListSelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetListSelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosTargetQuerySelector : Azure.ResourceManager.Chaos.Models.ChaosTargetSelector, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosTargetQuerySelector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetQuerySelector>
    {
        public ChaosTargetQuerySelector(string id, string queryString, System.Collections.Generic.IEnumerable<string> subscriptionIds) : base (default(string)) { }
        public string QueryString { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SubscriptionIds { get { throw null; } }
        protected override Azure.ResourceManager.Chaos.Models.ChaosTargetSelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Chaos.Models.ChaosTargetSelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosTargetQuerySelector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosTargetQuerySelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosTargetQuerySelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosTargetQuerySelector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetQuerySelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetQuerySelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetQuerySelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosTargetReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosTargetReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetReference>
    {
        public ChaosTargetReference(Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType referenceType, Azure.Core.ResourceIdentifier id) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType ReferenceType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosTargetReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosTargetReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosTargetReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosTargetReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosTargetReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosTargetReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChaosTargetReferenceType : System.IEquatable<Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChaosTargetReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType ChaosTarget { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType left, Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType left, Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ChaosTargetSelector : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosTargetSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetSelector>
    {
        protected ChaosTargetSelector(string id) { }
        [System.ObsoleteAttribute("This property is no longer supported in all API versions.", false)]
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosTargetFilter Filter { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosTargetSelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosTargetSelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosTargetSelector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosTargetSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosTargetSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosTargetSelector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetSelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetSelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetSelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosTargetSimpleFilter : Azure.ResourceManager.Chaos.Models.ChaosTargetFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosTargetSimpleFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetSimpleFilter>
    {
        public ChaosTargetSimpleFilter() { }
        public System.Collections.Generic.IList<string> ParametersZones { get { throw null; } }
        protected override Azure.ResourceManager.Chaos.Models.ChaosTargetFilter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Chaos.Models.ChaosTargetFilter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosTargetSimpleFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosTargetSimpleFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosTargetSimpleFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosTargetSimpleFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetSimpleFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetSimpleFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetSimpleFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosWorkspaceEvaluationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationData>
    {
        internal ChaosWorkspaceEvaluationData() { }
        public Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosWorkspaceEvaluationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationProperties>
    {
        internal ChaosWorkspaceEvaluationProperties() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosOperationError> Errors { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosRecommendationStatus? EvaluationResult { get { throw null; } }
        public int? NumScenariosEvaluatedCancelled { get { throw null; } }
        public int? NumScenariosEvaluatedFailed { get { throw null; } }
        public int? NumScenariosEvaluatedSucceeded { get { throw null; } }
        public int? NumScenariosToEvaluate { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosScenarioEvaluationResultItem> Results { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationStatus Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier WorkspaceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChaosWorkspaceEvaluationStatus : System.IEquatable<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChaosWorkspaceEvaluationStatus(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationStatus PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationStatus left, Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationStatus left, Azure.ResourceManager.Chaos.Models.ChaosWorkspaceEvaluationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChaosWorkspacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspacePatch>
    {
        public ChaosWorkspacePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosWorkspacePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosWorkspacePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosWorkspacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosWorkspacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosWorkspaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceProperties>
    {
        public ChaosWorkspaceProperties(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> scopes) { }
        public string CommunicationEndpoint { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> Scopes { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosWorkspaceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosWorkspaceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosWorkspaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosWorkspaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosZoneResolutionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionInfo>
    {
        internal ChaosZoneResolutionInfo() { }
        public Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMode Mode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequestedPhysicalZones { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMapping> SubscriptionZoneMappings { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosZoneResolutionMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMapping>
    {
        internal ChaosZoneResolutionMapping() { }
        public string SubscriptionId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosPhysicalToLogicalZoneMapping> ZoneMappings { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMapping JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMapping PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChaosZoneResolutionMode : System.IEquatable<Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChaosZoneResolutionMode(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMode Logical { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMode Physical { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMode left, Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMode left, Azure.ResourceManager.Chaos.Models.ChaosZoneResolutionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExperimentExecutionActionTargetDetailsError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError>
    {
        internal ExperimentExecutionActionTargetDetailsError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExperimentExecutionActionTargetDetailsProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties>
    {
        internal ExperimentExecutionActionTargetDetailsProperties() { }
        public Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError Error { get { throw null; } }
        public string Status { get { throw null; } }
        public string Target { get { throw null; } }
        public System.DateTimeOffset? TargetCompletedOn { get { throw null; } }
        public System.DateTimeOffset? TargetFailedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExperimentExecutionDetails : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails>
    {
        internal ExperimentExecutionDetails() { }
        public string FailureReason { get { throw null; } }
        public System.DateTimeOffset? LastActionOn { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunStepStatus> RunInformationSteps { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? StoppedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
