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
        public Azure.ResourceManager.Chaos.Models.ActionPropertiesParametersSchema ParametersSchema { get { throw null; } }
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
        public Azure.ResourceManager.Chaos.Models.ActionPropertiesParametersSchema ParametersSchema { get { throw null; } }
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
    public partial class ChaosConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosConnectionResource>, System.Collections.IEnumerable
    {
        protected ChaosConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectionName, Azure.ResourceManager.Chaos.ChaosConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectionName, Azure.ResourceManager.Chaos.ChaosConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosConnectionResource> Get(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosConnectionResource>> GetAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosConnectionResource> GetIfExists(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosConnectionResource>> GetIfExistsAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosConnectionData>
    {
        public ChaosConnectionData() { }
        public Azure.ResourceManager.Chaos.Models.ChaosConnectionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.ChaosConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosConnectionResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string connectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Chaos.ChaosConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.ChaosConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.ChaosConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.Chaos.Models.DiscoveredResourceProperties Properties { get { throw null; } }
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
        public Azure.ResourceManager.Chaos.Models.CustomerDataStorageProperties CustomerDataStorage { get { throw null; } set { } }
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
        public static Azure.ResourceManager.Chaos.ChaosConnectionResource GetChaosConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public static Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource GetChaosScenarioConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosScenarioResource GetChaosScenarioResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosScenarioRunResource GetChaosScenarioRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioTemplateResource> GetChaosScenarioTemplate(this Azure.ResourceManager.Resources.TenantResource tenantResource, string scenarioTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioTemplateResource>> GetChaosScenarioTemplateAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string scenarioTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosScenarioTemplateResource GetChaosScenarioTemplateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosScenarioTemplateCollection GetChaosScenarioTemplates(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionResource GetChaosScenarioTemplateVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public static Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationDataResource GetChaosWorkspaceTemplateEvaluationDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.WorkspaceDiscoveryResource GetWorkspaceDiscoveryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> GetWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> GetWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChaosScenarioCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosScenarioResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosScenarioResource>, System.Collections.IEnumerable
    {
        protected ChaosScenarioCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosScenarioResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scenarioName, Azure.ResourceManager.Chaos.ChaosScenarioData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosScenarioResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scenarioName, Azure.ResourceManager.Chaos.ChaosScenarioData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scenarioConfigurationName, Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scenarioConfigurationName, Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.Chaos.Models.ScenarioConfigurationProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationData> Validate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationData>> ValidateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChaosScenarioData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioData>
    {
        public ChaosScenarioData() { }
        public Azure.ResourceManager.Chaos.Models.ScenarioProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosScenarioResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.ChaosScenarioData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosScenarioResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.ChaosScenarioData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.Chaos.Models.ScenarioRunProperties Properties { get { throw null; } }
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
    public partial class ChaosScenarioTemplateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosScenarioTemplateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosScenarioTemplateResource>, System.Collections.IEnumerable
    {
        protected ChaosScenarioTemplateCollection() { }
        public virtual Azure.Response<bool> Exists(string scenarioTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scenarioTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioTemplateResource> Get(string scenarioTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosScenarioTemplateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosScenarioTemplateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioTemplateResource>> GetAsync(string scenarioTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosScenarioTemplateResource> GetIfExists(string scenarioTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosScenarioTemplateResource>> GetIfExistsAsync(string scenarioTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosScenarioTemplateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosScenarioTemplateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosScenarioTemplateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosScenarioTemplateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosScenarioTemplateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateData>
    {
        internal ChaosScenarioTemplateData() { }
        public Azure.ResourceManager.Chaos.Models.ScenarioTemplateProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.ChaosScenarioTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosScenarioTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosScenarioTemplateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosScenarioTemplateResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosScenarioTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scenarioTemplateName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioTemplateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioTemplateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionResource> GetChaosScenarioTemplateVersion(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionResource>> GetChaosScenarioTemplateVersionAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionCollection GetChaosScenarioTemplateVersions() { throw null; }
        Azure.ResourceManager.Chaos.ChaosScenarioTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosScenarioTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosScenarioTemplateVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionResource>, System.Collections.IEnumerable
    {
        protected ChaosScenarioTemplateVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionResource> GetIfExists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionResource>> GetIfExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosScenarioTemplateVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionData>
    {
        internal ChaosScenarioTemplateVersionData() { }
        public Azure.ResourceManager.Chaos.Models.ScenarioTemplateVersionProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosScenarioTemplateVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosScenarioTemplateVersionResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scenarioTemplateName, string version) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Chaos.ChaosWorkspaceData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Chaos.ChaosWorkspaceData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public ChaosWorkspaceData(Azure.Core.AzureLocation location, Azure.ResourceManager.Chaos.Models.WorkspaceProperties properties) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.WorkspaceProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.WorkspaceDiscoveryResource> Discover(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.WorkspaceDiscoveryResource>> DiscoverAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationDataResource> Evaluate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationDataResource>> EvaluateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationDataCollection GetAllChaosWorkspaceTemplateEvaluationData() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosConnectionResource> GetChaosConnection(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosConnectionResource>> GetChaosConnectionAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosConnectionCollection GetChaosConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosDiscoveredResource> GetChaosDiscovered(string discoveredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosDiscoveredResource>> GetChaosDiscoveredAsync(string discoveredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosDiscoveredCollection GetChaosDiscovereds() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioResource> GetChaosScenario(string scenarioName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioResource>> GetChaosScenarioAsync(string scenarioName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosScenarioCollection GetChaosScenarios() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationDataResource> GetChaosWorkspaceTemplateEvaluationData(string evaluationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationDataResource>> GetChaosWorkspaceTemplateEvaluationDataAsync(string evaluationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.WorkspaceDiscoveryCollection GetWorkspaceDiscoveries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.WorkspaceDiscoveryResource> GetWorkspaceDiscovery(string discoveryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.WorkspaceDiscoveryResource>> GetWorkspaceDiscoveryAsync(string discoveryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ChaosWorkspaceTemplateEvaluationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationData>
    {
        internal ChaosWorkspaceTemplateEvaluationData() { }
        public Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosWorkspaceTemplateEvaluationDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationDataResource>, System.Collections.IEnumerable
    {
        protected ChaosWorkspaceTemplateEvaluationDataCollection() { }
        public virtual Azure.Response<bool> Exists(string evaluationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string evaluationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationDataResource> Get(string evaluationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationDataResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationDataResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationDataResource>> GetAsync(string evaluationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationDataResource> GetIfExists(string evaluationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationDataResource>> GetIfExistsAsync(string evaluationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosWorkspaceTemplateEvaluationDataResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosWorkspaceTemplateEvaluationDataResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string evaluationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceDiscoveryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.WorkspaceDiscoveryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.WorkspaceDiscoveryResource>, System.Collections.IEnumerable
    {
        protected WorkspaceDiscoveryCollection() { }
        public virtual Azure.Response<bool> Exists(string discoveryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string discoveryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.WorkspaceDiscoveryResource> Get(string discoveryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.WorkspaceDiscoveryResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.WorkspaceDiscoveryResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.WorkspaceDiscoveryResource>> GetAsync(string discoveryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.WorkspaceDiscoveryResource> GetIfExists(string discoveryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.WorkspaceDiscoveryResource>> GetIfExistsAsync(string discoveryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.WorkspaceDiscoveryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.WorkspaceDiscoveryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.WorkspaceDiscoveryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.WorkspaceDiscoveryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkspaceDiscoveryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.WorkspaceDiscoveryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.WorkspaceDiscoveryData>
    {
        internal WorkspaceDiscoveryData() { }
        public Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.WorkspaceDiscoveryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.WorkspaceDiscoveryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.WorkspaceDiscoveryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.WorkspaceDiscoveryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.WorkspaceDiscoveryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.WorkspaceDiscoveryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.WorkspaceDiscoveryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceDiscoveryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.WorkspaceDiscoveryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.WorkspaceDiscoveryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkspaceDiscoveryResource() { }
        public virtual Azure.ResourceManager.Chaos.WorkspaceDiscoveryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string discoveryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.WorkspaceDiscoveryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.WorkspaceDiscoveryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Chaos.WorkspaceDiscoveryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.WorkspaceDiscoveryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.WorkspaceDiscoveryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.WorkspaceDiscoveryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.WorkspaceDiscoveryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.WorkspaceDiscoveryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.WorkspaceDiscoveryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.ResourceManager.Chaos.ChaosConnectionResource GetChaosConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosDiscoveredResource GetChaosDiscoveredResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource GetChaosExperimentExecutionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosExperimentResource GetChaosExperimentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource GetChaosScenarioConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosScenarioResource GetChaosScenarioResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosScenarioRunResource GetChaosScenarioRunResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosScenarioTemplateResource GetChaosScenarioTemplateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionResource GetChaosScenarioTemplateVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource> GetChaosTarget(Azure.Core.ResourceIdentifier scope, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource>> GetChaosTargetAsync(Azure.Core.ResourceIdentifier scope, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetMetadataResource GetChaosTargetMetadataResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetResource GetChaosTargetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetCollection GetChaosTargets(Azure.Core.ResourceIdentifier scope) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public virtual Azure.ResourceManager.Chaos.ChaosTargetTypeResource GetChaosTargetTypeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosWorkspaceResource GetChaosWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationDataResource GetChaosWorkspaceTemplateEvaluationDataResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.WorkspaceDiscoveryResource GetWorkspaceDiscoveryResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableChaosResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableChaosResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetChaosExperiment(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource>> GetChaosExperimentAsync(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosExperimentCollection GetChaosExperiments() { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> GetWorkspaces(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> GetWorkspacesAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableChaosTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableChaosTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioTemplateResource> GetChaosScenarioTemplate(string scenarioTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioTemplateResource>> GetChaosScenarioTemplateAsync(string scenarioTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosScenarioTemplateCollection GetChaosScenarioTemplates() { throw null; }
    }
}
namespace Azure.ResourceManager.Chaos.Models
{
    public partial class ActionDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ActionDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ActionDependency>
    {
        public ActionDependency(Azure.ResourceManager.Chaos.Models.ActionDependencyType type, string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.ActionLifecycle? OnActionLifecycle { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.ActionDependencyType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.ActionDependency JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ActionDependency PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ActionDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ActionDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ActionDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ActionDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ActionDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ActionDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ActionDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionDependencyType : System.IEquatable<Azure.ResourceManager.Chaos.Models.ActionDependencyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionDependencyType(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ActionDependencyType Action { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ActionDependencyType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ActionDependencyType left, Azure.ResourceManager.Chaos.Models.ActionDependencyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ActionDependencyType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ActionDependencyType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ActionDependencyType left, Azure.ResourceManager.Chaos.Models.ActionDependencyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ActionError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ActionError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ActionError>
    {
        internal ActionError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ActionErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ActionError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ActionError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ActionError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ActionError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ActionError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ActionError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ActionError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ActionError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ActionError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ActionErrorDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ActionErrorDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ActionErrorDetail>
    {
        internal ActionErrorDetail() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ActionErrorDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ActionErrorDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ActionErrorDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ActionErrorDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ActionErrorDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ActionErrorDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ActionErrorDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ActionErrorDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ActionErrorDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionLifecycle : System.IEquatable<Azure.ResourceManager.Chaos.Models.ActionLifecycle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionLifecycle(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ActionLifecycle AnyTerminal { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ActionLifecycle Failure { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ActionLifecycle Running { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ActionLifecycle Skipped { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ActionLifecycle Start { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ActionLifecycle Success { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ActionLifecycle other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ActionLifecycle left, Azure.ResourceManager.Chaos.Models.ActionLifecycle right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ActionLifecycle (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ActionLifecycle? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ActionLifecycle left, Azure.ResourceManager.Chaos.Models.ActionLifecycle right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ActionPropertiesParametersSchema : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ActionPropertiesParametersSchema>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ActionPropertiesParametersSchema>
    {
        internal ActionPropertiesParametersSchema() { }
        protected virtual Azure.ResourceManager.Chaos.Models.ActionPropertiesParametersSchema JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ActionPropertiesParametersSchema PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ActionPropertiesParametersSchema System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ActionPropertiesParametersSchema>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ActionPropertiesParametersSchema>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ActionPropertiesParametersSchema System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ActionPropertiesParametersSchema>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ActionPropertiesParametersSchema>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ActionPropertiesParametersSchema>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmChaosModelFactory
    {
        public static Azure.ResourceManager.Chaos.Models.ActionDependency ActionDependency(Azure.ResourceManager.Chaos.Models.ActionDependencyType type = default(Azure.ResourceManager.Chaos.Models.ActionDependencyType), string name = null, Azure.ResourceManager.Chaos.Models.ActionLifecycle? onActionLifecycle = default(Azure.ResourceManager.Chaos.Models.ActionLifecycle?)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ActionError ActionError(string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ActionErrorDetail> details = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ActionErrorDetail ActionErrorDetail(string code = null, string message = null, string target = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ActionPropertiesParametersSchema ActionPropertiesParametersSchema() { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosActionData ChaosActionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string canonicalId = null, string displayName = null, string description = null, string actionName = null, string version = null, Azure.ResourceManager.Chaos.Models.ChaosActionKind? actionType = default(Azure.ResourceManager.Chaos.Models.ChaosActionKind?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosActionSupportedTargetType> supportedTargetTypes = null, Azure.ResourceManager.Chaos.Models.ActionPropertiesParametersSchema parametersSchema = null, System.Collections.Generic.IEnumerable<System.Guid> recommendedRoles = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosActionSupportedTargetType ChaosActionSupportedTargetType(string targetType = null, System.Collections.Generic.IEnumerable<string> requiredPermissions = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosActionVersionData ChaosActionVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string canonicalId = null, string displayName = null, string description = null, string actionName = null, string version = null, Azure.ResourceManager.Chaos.Models.ChaosActionKind? actionType = default(Azure.ResourceManager.Chaos.Models.ChaosActionKind?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosActionSupportedTargetType> supportedTargetTypes = null, Azure.ResourceManager.Chaos.Models.ActionPropertiesParametersSchema parametersSchema = null, System.Collections.Generic.IEnumerable<System.Guid> recommendedRoles = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosCapabilityData ChaosCapabilityData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string publisher, string targetType, string description, string parametersSchema, string urn) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosCapabilityData ChaosCapabilityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string publisher = null, string targetType = null, string description = null, string parametersSchema = null, string urn = null, Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosCapabilityMetadataData ChaosCapabilityMetadataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string publisher = null, string targetType = null, string displayName = null, string description = null, string parametersSchema = null, string urn = null, string kind = null, System.Collections.Generic.IEnumerable<string> azureRbacActions = null, System.Collections.Generic.IEnumerable<string> azureRbacDataActions = null, System.Collections.Generic.IEnumerable<string> requiredAzureRoleDefinitionIds = null, string runtimeKind = null) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public static Azure.ResourceManager.Chaos.ChaosCapabilityTypeData ChaosCapabilityTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string publisher = null, string targetType = null, string displayName = null, string description = null, string parametersSchema = null, string urn = null, string kind = null, System.Collections.Generic.IEnumerable<string> azureRbacActions = null, System.Collections.Generic.IEnumerable<string> azureRbacDataActions = null, string runtimeKind = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosConnectionData ChaosConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.ChaosConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosConnectionProperties ChaosConnectionProperties(Azure.ResourceManager.Chaos.Models.ChaosConnectionKind kind = default(Azure.ResourceManager.Chaos.Models.ChaosConnectionKind), Azure.Core.ResourceIdentifier targetResourceId = null, System.Guid? principalId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?), string certificateSubjectName = null, string certificateIssuer = null, System.Uri dataPlaneEndpoint = null, Azure.ResourceManager.Chaos.Models.ChaosConnectionStatus? status = default(Azure.ResourceManager.Chaos.Models.ChaosConnectionStatus?), Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosContinuousAction ChaosContinuousAction(string name = null, System.TimeSpan duration = default(System.TimeSpan), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> parameters = null, string selectorId = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosDelayAction ChaosDelayAction(string name = null, System.TimeSpan duration = default(System.TimeSpan)) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosDiscoveredData ChaosDiscoveredData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.DiscoveredResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosDiscreteAction ChaosDiscreteAction(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> parameters = null, string selectorId = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosExperimentAction ChaosExperimentAction(string name = null, string type = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosExperimentBranch ChaosExperimentBranch(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentAction> actions = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentData ChaosExperimentData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep> steps, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosTargetSelector> selectors) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentData ChaosExperimentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep> steps = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosTargetSelector> selectors = null, Azure.ResourceManager.Chaos.Models.CustomerDataStorageProperties customerDataStorage = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentExecutionData ChaosExperimentExecutionData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string status, System.DateTimeOffset? startedOn, System.DateTimeOffset? stoppedOn) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentExecutionData ChaosExperimentExecutionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string status = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? stoppedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosExperimentPatch ChaosExperimentPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosExperimentRunActionStatus ChaosExperimentRunActionStatus(string actionName = null, string actionId = null, string status = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties> targets = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosExperimentRunBranchStatus ChaosExperimentRunBranchStatus(string branchName = null, string branchId = null, string status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunActionStatus> actions = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosExperimentRunStepStatus ChaosExperimentRunStepStatus(string stepName = null, string stepId = null, string status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunBranchStatus> branches = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosExperimentStep ChaosExperimentStep(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentBranch> branches = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosFixResourcePermissionsRequestContent ChaosFixResourcePermissionsRequestContent(bool? isWhatIf = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair ChaosKeyValuePair(string key = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosOperationError ChaosOperationError(string errorCode = null, string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixData ChaosPermissionsFixData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.PermissionsFixProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData ChaosScenarioConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.ScenarioConfigurationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosScenarioData ChaosScenarioData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.ScenarioProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterInfo ChaosScenarioParameterInfo(string name = null, Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterType type = default(Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterType), string @default = null, bool? isRequired = default(bool?), string description = null, Azure.ResourceManager.Chaos.Models.ScenarioParameterFormat format = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioRecommendation ChaosScenarioRecommendation(Azure.ResourceManager.Chaos.Models.RecommendationStatus recommendationStatus = default(Azure.ResourceManager.Chaos.Models.RecommendationStatus), System.DateTimeOffset? evaluationRunOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosScenarioRunData ChaosScenarioRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.ScenarioRunProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosScenarioTemplateData ChaosScenarioTemplateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.ScenarioTemplateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosScenarioTemplateVersionData ChaosScenarioTemplateVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.ScenarioTemplateVersionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationData ChaosScenarioValidationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.ValidationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetData ChaosTargetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, System.BinaryData> properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public static Azure.ResourceManager.Chaos.ChaosTargetData ChaosTargetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IDictionary<string, System.BinaryData> properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosTargetFilter ChaosTargetFilter(string type = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosTargetListSelector ChaosTargetListSelector(string id = null, Azure.ResourceManager.Chaos.Models.ChaosTargetFilter filter = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosTargetReference> targets = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetMetadataData ChaosTargetMetadataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, string description = null, string propertiesSchema = null, System.Collections.Generic.IEnumerable<string> resourceTypes = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosTargetQuerySelector ChaosTargetQuerySelector(string id = null, Azure.ResourceManager.Chaos.Models.ChaosTargetFilter filter = null, string queryString = null, System.Collections.Generic.IEnumerable<string> subscriptionIds = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosTargetReference ChaosTargetReference(Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType referenceType = default(Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType), Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosTargetSelector ChaosTargetSelector(string id = null, string type = null, Azure.ResourceManager.Chaos.Models.ChaosTargetFilter filter = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosTargetSimpleFilter ChaosTargetSimpleFilter(System.Collections.Generic.IEnumerable<string> parametersZones = null) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public static Azure.ResourceManager.Chaos.ChaosTargetTypeData ChaosTargetTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string displayName = null, string description = null, string propertiesSchema = null, System.Collections.Generic.IEnumerable<string> resourceTypes = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosWorkspaceData ChaosWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Chaos.Models.WorkspaceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosWorkspacePatch ChaosWorkspacePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryptionPatch workspaceUpdateCustomerManagedKeyEncryption = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosWorkspaceTemplateEvaluationData ChaosWorkspaceTemplateEvaluationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.CustomerDataStorageProperties CustomerDataStorageProperties(Azure.Core.ResourceIdentifier storageAccountResourceId = null, string blobContainerName = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.DiscoveredResourceProperties DiscoveredResourceProperties(string resourceNamespace = null, string resourceName = null, string resourceType = null, string fullyQualifiedIdentifier = null, System.DateTimeOffset discoveredOn = default(System.DateTimeOffset), string scope = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.EntraIdentity EntraIdentity(string objectId = null, string tenantId = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError ExperimentExecutionActionTargetDetailsError(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties ExperimentExecutionActionTargetDetailsProperties(string status = null, string target = null, System.DateTimeOffset? targetFailedOn = default(System.DateTimeOffset?), System.DateTimeOffset? targetCompletedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError error = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails ExperimentExecutionDetails(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string status = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? stoppedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?), string failureReason = null, System.DateTimeOffset? lastActionOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunStepStatus> runInformationSteps = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails ExperimentExecutionDetails(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string status, System.DateTimeOffset? startedOn, System.DateTimeOffset? stoppedOn, string failureReason, System.DateTimeOffset? lastActionOn, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunStepStatus> runInformationSteps) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.PermissionError PermissionError(Azure.Core.ResourceIdentifier resourceId = null, System.Collections.Generic.IEnumerable<string> missingPermissions = null, System.Collections.Generic.IEnumerable<string> requiredPermissions = null, System.Collections.Generic.IEnumerable<string> recommendedRoles = null, Azure.ResourceManager.Chaos.Models.EntraIdentity identity = null, string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.PermissionsFixProperties PermissionsFixProperties(Azure.ResourceManager.Chaos.Models.PermissionsFixState state = default(Azure.ResourceManager.Chaos.Models.PermissionsFixState), System.DateTimeOffset startedOn = default(System.DateTimeOffset), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), bool isWhatIfMode = false, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.RoleAssignmentResult> roleAssignments = null, Azure.ResourceManager.Chaos.Models.PermissionsFixSummary summary = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.PermissionsFixSummary PermissionsFixSummary(int totalRequired = 0, int succeeded = 0, int failed = 0, int skipped = 0) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.PhysicalToLogicalZoneMapping PhysicalToLogicalZoneMapping(string physicalZone = null, string logicalZone = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ResourceStateError ResourceStateError(Azure.Core.ResourceIdentifier resourceId = null, string errorCode = null, string errorMessage = null, string remediationUri = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ResourceTargeting ResourceTargeting(Azure.ResourceManager.Chaos.Models.ResourceTargetingCriteria include = null, Azure.ResourceManager.Chaos.Models.ResourceTargetingCriteria exclude = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ResourceTargetingCriteria ResourceTargetingCriteria(System.Collections.Generic.IEnumerable<string> locations = null, System.Collections.Generic.IEnumerable<string> zones = null, System.Collections.Generic.IEnumerable<string> physicalZones = null, System.Collections.Generic.IEnumerable<string> types = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> tags = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resources = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.RoleAssignmentError RoleAssignmentError(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.RoleAssignmentResult RoleAssignmentResult(Azure.Core.ResourceIdentifier targetResourceId = null, string principalId = null, string roleDefinitionId = null, string roleDefinitionName = null, string scope = null, Azure.ResourceManager.Chaos.Models.RoleAssignmentStatus status = default(Azure.ResourceManager.Chaos.Models.RoleAssignmentStatus), Azure.Core.ResourceIdentifier roleAssignmentId = null, Azure.ResourceManager.Chaos.Models.RoleAssignmentError error = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.RunAfter RunAfter(Azure.ResourceManager.Chaos.Models.RunAfterBehavior? behavior = default(Azure.ResourceManager.Chaos.Models.RunAfterBehavior?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ActionDependency> items = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioAction ScenarioAction(string name = null, string actionId = null, string description = null, string duration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ScenarioActionSelector> selectors = null, Azure.ResourceManager.Chaos.Models.RunAfter runAfter = null, string waitBefore = null, string timeout = null, Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.Chaos.Models.FailureBehavior? failureBehavior = default(Azure.ResourceManager.Chaos.Models.FailureBehavior?)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioActionSelector ScenarioActionSelector(Azure.ResourceManager.Chaos.Models.ScenarioActionSelectorName name = default(Azure.ResourceManager.Chaos.Models.ScenarioActionSelectorName), string value = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioConfigurationProperties ScenarioConfigurationProperties(Azure.Core.ResourceIdentifier scenarioId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> parameters = null, Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?), Azure.ResourceManager.Chaos.Models.ResourceTargeting resourceTargeting = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioErrors ScenarioErrors(string errorCode = null, string errorMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.PermissionError> permission = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ResourceStateError> resource = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioParameterFormat ScenarioParameterFormat(Azure.ResourceManager.Chaos.Models.ParameterFormatType? formatType = default(Azure.ResourceManager.Chaos.Models.ParameterFormatType?), System.Collections.Generic.IEnumerable<string> examples = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioProperties ScenarioProperties(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?), string createdFrom = null, string version = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterInfo> parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ScenarioAction> actions = null, Azure.ResourceManager.Chaos.Models.FailureBehavior? failureBehavior = default(Azure.ResourceManager.Chaos.Models.FailureBehavior?), Azure.ResourceManager.Chaos.Models.ChaosScenarioRecommendation recommendation = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunEffectiveTarget ScenarioRunEffectiveTarget(string id = null, Azure.ResourceManager.Chaos.Models.ScenarioRunTargetState state = default(Azure.ResourceManager.Chaos.Models.ScenarioRunTargetState), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunProperties ScenarioRunProperties(string workspaceName = null, string scenarioName = null, string scenarioConfigurationName = null, string managedIdentityPrincipalId = null, string resourceSnapshotId = null, Azure.ResourceManager.Chaos.Models.ScenarioRunState status = default(Azure.ResourceManager.Chaos.Models.ScenarioRunState), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ScenarioRunResource> resources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ScenarioRunResource> excludedResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosOperationError> errors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ScenarioRunWarning> warnings = null, Azure.ResourceManager.Chaos.Models.ScenarioErrors executionErrors = null, string scenarioRunJson = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryAction> scenarioRunSummary = null, System.DateTimeOffset startsOn = default(System.DateTimeOffset), System.DateTimeOffset? endsOn = default(System.DateTimeOffset?), Azure.ResourceManager.Chaos.Models.ZoneResolutionInfo zoneResolution = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunResource ScenarioRunResource(string id = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryAction ScenarioRunSummaryAction(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryResource> resources = null, string actionUrn = null, Azure.ResourceManager.Chaos.Models.ScenarioSummaryState state = default(Azure.ResourceManager.Chaos.Models.ScenarioSummaryState), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Chaos.Models.ActionError error = null, bool? failureSuppressed = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryResource ScenarioRunSummaryResource(string id = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ScenarioRunEffectiveTarget> affectedResources = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunWarning ScenarioRunWarning(string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ScenarioRunWarningDetail> details = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunWarningDetail ScenarioRunWarningDetail(string code = null, string message = null, string target = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioTemplateProperties ScenarioTemplateProperties(string latestVersion = null, string displayName = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterInfo> parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ScenarioAction> actions = null, Azure.ResourceManager.Chaos.Models.FailureBehavior? failureBehavior = default(Azure.ResourceManager.Chaos.Models.FailureBehavior?)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioTemplateVersionProperties ScenarioTemplateVersionProperties(string displayName = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterInfo> parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ScenarioAction> actions = null, Azure.ResourceManager.Chaos.Models.FailureBehavior? failureBehavior = default(Azure.ResourceManager.Chaos.Models.FailureBehavior?)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.TemplateEvaluationResultItem TemplateEvaluationResultItem(Azure.Core.ResourceIdentifier templateId = null, string templateName = null, Azure.ResourceManager.Chaos.Models.RecommendationStatus evaluationResult = default(Azure.ResourceManager.Chaos.Models.RecommendationStatus)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ValidationProperties ValidationProperties(Azure.ResourceManager.Chaos.Models.ScenarioValidationState status = default(Azure.ResourceManager.Chaos.Models.ScenarioValidationState), System.DateTimeOffset startsOn = default(System.DateTimeOffset), string executionPlanJson = null, System.DateTimeOffset? endsOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ScenarioRunResource> resources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ScenarioRunResource> excludedResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosOperationError> errors = null, Azure.ResourceManager.Chaos.Models.ScenarioErrors validationErrors = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryption WorkspaceCustomerManagedKeyEncryption(System.Uri keyEncryptionKeyUri = null, Azure.Core.ResourceIdentifier keyVaultResourceId = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryptionPatch WorkspaceCustomerManagedKeyEncryptionPatch(System.Uri keyEncryptionKeyUri = null, Azure.Core.ResourceIdentifier keyVaultResourceId = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryAccessWarning WorkspaceDiscoveryAccessWarning(Azure.Core.ResourceIdentifier scopeId = null, string scopeKind = null, string message = null, Azure.Core.ResourceIdentifier resourceId = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCoverageSummary WorkspaceDiscoveryCoverageSummary(Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryScopeCoverageSummary scopes = null, Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceCoverageSummary resources = null) { throw null; }
        public static Azure.ResourceManager.Chaos.WorkspaceDiscoveryData WorkspaceDiscoveryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryPermissionWarning WorkspaceDiscoveryPermissionWarning(Azure.Core.ResourceIdentifier scopeId = null, string scopeKind = null, string message = null, Azure.ResourceManager.Chaos.Models.PermissionError permission = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryProperties WorkspaceDiscoveryProperties(Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryStatus status = default(Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryStatus), System.DateTimeOffset? startsOn = default(System.DateTimeOffset?), System.DateTimeOffset? endsOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosOperationError> errors = null, Azure.Core.ResourceIdentifier workspaceId = null, string resourceSnapshotId = null, Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCompleteness? completeness = default(Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCompleteness?), Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCoverageSummary coverageSummary = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryWarning> warnings = null, long? warningsTotalCount = default(long?), bool? warningsTruncated = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceCoverageSummary WorkspaceDiscoveryResourceCoverageSummary(long expectedCount = (long)0, long classifiedCount = (long)0, long unclassifiedCount = (long)0, long coveredCount = (long)0) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceWarning WorkspaceDiscoveryResourceWarning(Azure.Core.ResourceIdentifier scopeId = null, string scopeKind = null, string message = null, Azure.Core.ResourceIdentifier resourceId = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryScopeCoverageSummary WorkspaceDiscoveryScopeCoverageSummary(long totalCount = (long)0, long knownExpectedSetCount = (long)0, long unknownExpectedSetCount = (long)0, long establishedCount = (long)0, long baselineUnknownCount = (long)0, long verificationIncompleteCount = (long)0, long knownPartialCount = (long)0) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryWarning WorkspaceDiscoveryWarning(Azure.Core.ResourceIdentifier scopeId = null, string scopeKind = null, string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceEncryption WorkspaceEncryption(Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryption customerManagedKeyEncryption = null, string customerManagedKeyOnboardingApplicationId = null, Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionStatus status = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionStatus WorkspaceEncryptionStatus(Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionState state = default(Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionState), Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionProtection? observedProtection = default(Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionProtection?), System.Uri observedKeyEncryptionKeyUri = null, System.DateTimeOffset? lastCheckedOn = default(System.DateTimeOffset?), Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationProperties WorkspaceEvaluationProperties(Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationStatus status = default(Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationStatus), System.DateTimeOffset? startsOn = default(System.DateTimeOffset?), System.DateTimeOffset? endsOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosOperationError> errors = null, Azure.Core.ResourceIdentifier workspaceId = null, string resourceSnapshotId = null, Azure.Core.ResourceIdentifier discoveryResultId = null, int numTemplatesToEvaluate = 0, int numTemplatesEvaluatedSucceeded = 0, int numTemplatesEvaluatedFailed = 0, int numTemplatesEvaluatedCancelled = 0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.TemplateEvaluationResultItem> results = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceProperties WorkspaceProperties(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> scopes = null, Azure.ResourceManager.Chaos.Models.WorkspaceEncryption encryption = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ZoneResolutionInfo ZoneResolutionInfo(Azure.ResourceManager.Chaos.Models.ZoneResolutionMode mode = default(Azure.ResourceManager.Chaos.Models.ZoneResolutionMode), System.Collections.Generic.IEnumerable<string> requestedPhysicalZones = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ZoneResolutionMapping> subscriptionZoneMappings = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ZoneResolutionMapping ZoneResolutionMapping(string subscriptionId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.PhysicalToLogicalZoneMapping> zoneMappings = null) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChaosConnectionKind : System.IEquatable<Azure.ResourceManager.Chaos.Models.ChaosConnectionKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChaosConnectionKind(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosConnectionKind AksExtension { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosConnectionKind ChaosAgent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ChaosConnectionKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ChaosConnectionKind left, Azure.ResourceManager.Chaos.Models.ChaosConnectionKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosConnectionKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosConnectionKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ChaosConnectionKind left, Azure.ResourceManager.Chaos.Models.ChaosConnectionKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChaosConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosConnectionProperties>
    {
        public ChaosConnectionProperties(Azure.ResourceManager.Chaos.Models.ChaosConnectionKind kind, Azure.Core.ResourceIdentifier targetResourceId) { }
        public string CertificateIssuer { get { throw null; } set { } }
        public string CertificateSubjectName { get { throw null; } set { } }
        public System.Uri DataPlaneEndpoint { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosConnectionKind Kind { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosConnectionStatus? Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChaosConnectionStatus : System.IEquatable<Azure.ResourceManager.Chaos.Models.ChaosConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChaosConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosConnectionStatus Connected { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosConnectionStatus Revoked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ChaosConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ChaosConnectionStatus left, Azure.ResourceManager.Chaos.Models.ChaosConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ChaosConnectionStatus left, Azure.ResourceManager.Chaos.Models.ChaosConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class ChaosPermissionsFixData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosPermissionsFixData>
    {
        internal ChaosPermissionsFixData() { }
        public Azure.ResourceManager.Chaos.Models.PermissionsFixProperties Properties { get { throw null; } }
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
    public partial class ChaosScenarioParameterInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterInfo>
    {
        public ChaosScenarioParameterInfo(string name, Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterType type) { }
        public string Default { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.ScenarioParameterFormat Format { get { throw null; } set { } }
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
    public partial class ChaosScenarioRecommendation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRecommendation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioRecommendation>
    {
        internal ChaosScenarioRecommendation() { }
        public System.DateTimeOffset? EvaluationRunOn { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.RecommendationStatus RecommendationStatus { get { throw null; } }
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
    public partial class ChaosScenarioValidationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioValidationData>
    {
        internal ChaosScenarioValidationData() { }
        public Azure.ResourceManager.Chaos.Models.ValidationProperties Properties { get { throw null; } }
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
    public partial class ChaosWorkspacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosWorkspacePatch>
    {
        public ChaosWorkspacePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryptionPatch WorkspaceUpdateCustomerManagedKeyEncryption { get { throw null; } set { } }
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
    public partial class CustomerDataStorageProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.CustomerDataStorageProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.CustomerDataStorageProperties>
    {
        public CustomerDataStorageProperties() { }
        public string BlobContainerName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.CustomerDataStorageProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.CustomerDataStorageProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.CustomerDataStorageProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.CustomerDataStorageProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.CustomerDataStorageProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.CustomerDataStorageProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.CustomerDataStorageProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.CustomerDataStorageProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.CustomerDataStorageProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveredResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.DiscoveredResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.DiscoveredResourceProperties>
    {
        internal DiscoveredResourceProperties() { }
        public System.DateTimeOffset DiscoveredOn { get { throw null; } }
        public string FullyQualifiedIdentifier { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ResourceNamespace { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public string Scope { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.DiscoveredResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.DiscoveredResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.DiscoveredResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.DiscoveredResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.DiscoveredResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.DiscoveredResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.DiscoveredResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.DiscoveredResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.DiscoveredResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntraIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.EntraIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.EntraIdentity>
    {
        internal EntraIdentity() { }
        public string ObjectId { get { throw null; } }
        public string TenantId { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.EntraIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.EntraIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.EntraIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.EntraIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.EntraIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.EntraIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.EntraIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.EntraIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.EntraIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FailureBehavior : System.IEquatable<Azure.ResourceManager.Chaos.Models.FailureBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FailureBehavior(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.FailureBehavior Continue { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.FailureBehavior Stop { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.FailureBehavior other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.FailureBehavior left, Azure.ResourceManager.Chaos.Models.FailureBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.FailureBehavior (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.FailureBehavior? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.FailureBehavior left, Azure.ResourceManager.Chaos.Models.FailureBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ParameterFormatType : System.IEquatable<Azure.ResourceManager.Chaos.Models.ParameterFormatType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParameterFormatType(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ParameterFormatType AzureRegion { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ParameterFormatType AzureResourceId { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ParameterFormatType AzureZone { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ParameterFormatType Duration { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ParameterFormatType Json { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ParameterFormatType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ParameterFormatType left, Azure.ResourceManager.Chaos.Models.ParameterFormatType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ParameterFormatType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ParameterFormatType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ParameterFormatType left, Azure.ResourceManager.Chaos.Models.ParameterFormatType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PermissionError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.PermissionError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PermissionError>
    {
        internal PermissionError() { }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.EntraIdentity Identity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> MissingPermissions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RecommendedRoles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredPermissions { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.PermissionError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.PermissionError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.PermissionError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.PermissionError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.PermissionError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.PermissionError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PermissionError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PermissionError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PermissionError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PermissionsFixProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.PermissionsFixProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PermissionsFixProperties>
    {
        internal PermissionsFixProperties() { }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public bool IsWhatIfMode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.RoleAssignmentResult> RoleAssignments { get { throw null; } }
        public System.DateTimeOffset StartedOn { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.PermissionsFixState State { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.PermissionsFixSummary Summary { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.PermissionsFixProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.PermissionsFixProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.PermissionsFixProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.PermissionsFixProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.PermissionsFixProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.PermissionsFixProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PermissionsFixProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PermissionsFixProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PermissionsFixProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PermissionsFixState : System.IEquatable<Azure.ResourceManager.Chaos.Models.PermissionsFixState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PermissionsFixState(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.PermissionsFixState Failed { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.PermissionsFixState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.PermissionsFixState NotStarted { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.PermissionsFixState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.PermissionsFixState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.PermissionsFixState WhatIfCompleted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.PermissionsFixState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.PermissionsFixState left, Azure.ResourceManager.Chaos.Models.PermissionsFixState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.PermissionsFixState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.PermissionsFixState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.PermissionsFixState left, Azure.ResourceManager.Chaos.Models.PermissionsFixState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PermissionsFixSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.PermissionsFixSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PermissionsFixSummary>
    {
        internal PermissionsFixSummary() { }
        public int Failed { get { throw null; } }
        public int Skipped { get { throw null; } }
        public int Succeeded { get { throw null; } }
        public int TotalRequired { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.PermissionsFixSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.PermissionsFixSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.PermissionsFixSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.PermissionsFixSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.PermissionsFixSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.PermissionsFixSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PermissionsFixSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PermissionsFixSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PermissionsFixSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PhysicalToLogicalZoneMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.PhysicalToLogicalZoneMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PhysicalToLogicalZoneMapping>
    {
        internal PhysicalToLogicalZoneMapping() { }
        public string LogicalZone { get { throw null; } }
        public string PhysicalZone { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.PhysicalToLogicalZoneMapping JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.PhysicalToLogicalZoneMapping PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.PhysicalToLogicalZoneMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.PhysicalToLogicalZoneMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.PhysicalToLogicalZoneMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.PhysicalToLogicalZoneMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PhysicalToLogicalZoneMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PhysicalToLogicalZoneMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PhysicalToLogicalZoneMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendationStatus : System.IEquatable<Azure.ResourceManager.Chaos.Models.RecommendationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendationStatus(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.RecommendationStatus Evaluating { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.RecommendationStatus EvaluationCancelled { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.RecommendationStatus EvaluationFailed { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.RecommendationStatus NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.RecommendationStatus NotEvaluated { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.RecommendationStatus Recommended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.RecommendationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.RecommendationStatus left, Azure.ResourceManager.Chaos.Models.RecommendationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.RecommendationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.RecommendationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.RecommendationStatus left, Azure.ResourceManager.Chaos.Models.RecommendationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceStateError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ResourceStateError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ResourceStateError>
    {
        internal ResourceStateError() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string RemediationUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ResourceStateError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ResourceStateError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ResourceStateError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ResourceStateError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ResourceStateError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ResourceStateError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ResourceStateError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ResourceStateError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ResourceStateError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceTargeting : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ResourceTargeting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ResourceTargeting>
    {
        public ResourceTargeting() { }
        public Azure.ResourceManager.Chaos.Models.ResourceTargetingCriteria Exclude { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.ResourceTargetingCriteria Include { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.ResourceTargeting JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ResourceTargeting PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ResourceTargeting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ResourceTargeting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ResourceTargeting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ResourceTargeting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ResourceTargeting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ResourceTargeting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ResourceTargeting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceTargetingCriteria : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ResourceTargetingCriteria>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ResourceTargetingCriteria>
    {
        public ResourceTargetingCriteria() { }
        public System.Collections.Generic.IList<string> Locations { get { throw null; } }
        public System.Collections.Generic.IList<string> PhysicalZones { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> Resources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> Tags { get { throw null; } }
        public System.Collections.Generic.IList<string> Types { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ResourceTargetingCriteria JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ResourceTargetingCriteria PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ResourceTargetingCriteria System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ResourceTargetingCriteria>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ResourceTargetingCriteria>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ResourceTargetingCriteria System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ResourceTargetingCriteria>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ResourceTargetingCriteria>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ResourceTargetingCriteria>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleAssignmentError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.RoleAssignmentError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RoleAssignmentError>
    {
        internal RoleAssignmentError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.RoleAssignmentError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.RoleAssignmentError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.RoleAssignmentError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.RoleAssignmentError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.RoleAssignmentError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.RoleAssignmentError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RoleAssignmentError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RoleAssignmentError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RoleAssignmentError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleAssignmentResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.RoleAssignmentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RoleAssignmentResult>
    {
        internal RoleAssignmentResult() { }
        public Azure.ResourceManager.Chaos.Models.RoleAssignmentError Error { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleAssignmentId { get { throw null; } }
        public string RoleDefinitionId { get { throw null; } }
        public string RoleDefinitionName { get { throw null; } }
        public string Scope { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.RoleAssignmentStatus Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.RoleAssignmentResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.RoleAssignmentResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.RoleAssignmentResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.RoleAssignmentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.RoleAssignmentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.RoleAssignmentResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RoleAssignmentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RoleAssignmentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RoleAssignmentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleAssignmentStatus : System.IEquatable<Azure.ResourceManager.Chaos.Models.RoleAssignmentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleAssignmentStatus(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.RoleAssignmentStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.RoleAssignmentStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.RoleAssignmentStatus Skipped { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.RoleAssignmentStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.RoleAssignmentStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.RoleAssignmentStatus left, Azure.ResourceManager.Chaos.Models.RoleAssignmentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.RoleAssignmentStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.RoleAssignmentStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.RoleAssignmentStatus left, Azure.ResourceManager.Chaos.Models.RoleAssignmentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunAfter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.RunAfter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RunAfter>
    {
        public RunAfter(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ActionDependency> items) { }
        public Azure.ResourceManager.Chaos.Models.RunAfterBehavior? Behavior { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ActionDependency> Items { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.RunAfter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.RunAfter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.RunAfter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.RunAfter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.RunAfter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.RunAfter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RunAfter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RunAfter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RunAfter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunAfterBehavior : System.IEquatable<Azure.ResourceManager.Chaos.Models.RunAfterBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunAfterBehavior(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.RunAfterBehavior All { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.RunAfterBehavior Any { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.RunAfterBehavior AtLeastOne { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.RunAfterBehavior other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.RunAfterBehavior left, Azure.ResourceManager.Chaos.Models.RunAfterBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.RunAfterBehavior (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.RunAfterBehavior? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.RunAfterBehavior left, Azure.ResourceManager.Chaos.Models.RunAfterBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScenarioAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioAction>
    {
        public ScenarioAction(string name, string actionId, string duration) { }
        public string ActionId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Duration { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.FailureBehavior? FailureBehavior { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> Parameters { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.RunAfter RunAfter { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ScenarioActionSelector> Selectors { get { throw null; } }
        public string Timeout { get { throw null; } set { } }
        public string WaitBefore { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ScenarioAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ScenarioAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScenarioActionSelector : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioActionSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioActionSelector>
    {
        public ScenarioActionSelector(Azure.ResourceManager.Chaos.Models.ScenarioActionSelectorName name, string value) { }
        public Azure.ResourceManager.Chaos.Models.ScenarioActionSelectorName Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioActionSelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioActionSelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ScenarioActionSelector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioActionSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioActionSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ScenarioActionSelector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioActionSelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioActionSelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioActionSelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScenarioActionSelectorName : System.IEquatable<Azure.ResourceManager.Chaos.Models.ScenarioActionSelectorName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScenarioActionSelectorName(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioActionSelectorName Location { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioActionSelectorName LogicalZone { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioActionSelectorName PhysicalZone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ScenarioActionSelectorName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ScenarioActionSelectorName left, Azure.ResourceManager.Chaos.Models.ScenarioActionSelectorName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ScenarioActionSelectorName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ScenarioActionSelectorName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ScenarioActionSelectorName left, Azure.ResourceManager.Chaos.Models.ScenarioActionSelectorName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScenarioConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioConfigurationProperties>
    {
        public ScenarioConfigurationProperties(Azure.Core.ResourceIdentifier scenarioId) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> Parameters { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ResourceTargeting ResourceTargeting { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ScenarioId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ScenarioConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ScenarioConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScenarioErrors : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioErrors>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioErrors>
    {
        internal ScenarioErrors() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.PermissionError> Permission { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ResourceStateError> Resource { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioErrors JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioErrors PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ScenarioErrors System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioErrors>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioErrors>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ScenarioErrors System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioErrors>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioErrors>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioErrors>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScenarioParameterFormat : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioParameterFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioParameterFormat>
    {
        public ScenarioParameterFormat() { }
        public System.Collections.Generic.IList<string> Examples { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ParameterFormatType? FormatType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioParameterFormat JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioParameterFormat PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ScenarioParameterFormat System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioParameterFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioParameterFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ScenarioParameterFormat System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioParameterFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioParameterFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioParameterFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScenarioProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioProperties>
    {
        public ScenarioProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ScenarioAction> Actions { get { throw null; } }
        public string CreatedFrom { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.FailureBehavior? FailureBehavior { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterInfo> Parameters { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosScenarioRecommendation Recommendation { get { throw null; } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ScenarioProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ScenarioProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScenarioRunEffectiveTarget : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioRunEffectiveTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunEffectiveTarget>
    {
        internal ScenarioRunEffectiveTarget() { }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ScenarioRunTargetState State { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioRunEffectiveTarget JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioRunEffectiveTarget PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ScenarioRunEffectiveTarget System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioRunEffectiveTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioRunEffectiveTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ScenarioRunEffectiveTarget System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunEffectiveTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunEffectiveTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunEffectiveTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScenarioRunProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioRunProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunProperties>
    {
        internal ScenarioRunProperties() { }
        public System.DateTimeOffset? EndsOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosOperationError> Errors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ScenarioRunResource> ExcludedResources { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ScenarioErrors ExecutionErrors { get { throw null; } }
        public string ManagedIdentityPrincipalId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ScenarioRunResource> Resources { get { throw null; } }
        public string ResourceSnapshotId { get { throw null; } }
        public string ScenarioConfigurationName { get { throw null; } }
        public string ScenarioName { get { throw null; } }
        public string ScenarioRunJson { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryAction> ScenarioRunSummary { get { throw null; } }
        public System.DateTimeOffset StartsOn { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ScenarioRunState Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ScenarioRunWarning> Warnings { get { throw null; } }
        public string WorkspaceName { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ZoneResolutionInfo ZoneResolution { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioRunProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioRunProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ScenarioRunProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioRunProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioRunProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ScenarioRunProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScenarioRunResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioRunResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunResource>
    {
        internal ScenarioRunResource() { }
        public string Id { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioRunResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioRunResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ScenarioRunResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioRunResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioRunResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ScenarioRunResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScenarioRunState : System.IEquatable<Azure.ResourceManager.Chaos.Models.ScenarioRunState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScenarioRunState(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunState Canceling { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunState CleaningUp { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunState Failed { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunState Generating { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunState Preparing { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunState Queued { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunState Resolving { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunState Running { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunState Starting { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunState Validating { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunState ValidationSucceeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ScenarioRunState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ScenarioRunState left, Azure.ResourceManager.Chaos.Models.ScenarioRunState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ScenarioRunState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ScenarioRunState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ScenarioRunState left, Azure.ResourceManager.Chaos.Models.ScenarioRunState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScenarioRunSummaryAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryAction>
    {
        internal ScenarioRunSummaryAction() { }
        public string ActionUrn { get { throw null; } }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ActionError Error { get { throw null; } }
        public bool? FailureSuppressed { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryResource> Resources { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ScenarioSummaryState State { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScenarioRunSummaryResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryResource>
    {
        internal ScenarioRunSummaryResource() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ScenarioRunEffectiveTarget> AffectedResources { get { throw null; } }
        public string Id { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScenarioRunTargetState : System.IEquatable<Azure.ResourceManager.Chaos.Models.ScenarioRunTargetState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScenarioRunTargetState(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunTargetState Failed { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunTargetState NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunTargetState Skipped { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunTargetState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ScenarioRunTargetState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ScenarioRunTargetState left, Azure.ResourceManager.Chaos.Models.ScenarioRunTargetState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ScenarioRunTargetState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ScenarioRunTargetState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ScenarioRunTargetState left, Azure.ResourceManager.Chaos.Models.ScenarioRunTargetState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScenarioRunWarning : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioRunWarning>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunWarning>
    {
        internal ScenarioRunWarning() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ScenarioRunWarningDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioRunWarning JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioRunWarning PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ScenarioRunWarning System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioRunWarning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioRunWarning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ScenarioRunWarning System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunWarning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunWarning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunWarning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScenarioRunWarningDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioRunWarningDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunWarningDetail>
    {
        internal ScenarioRunWarningDetail() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioRunWarningDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioRunWarningDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ScenarioRunWarningDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioRunWarningDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioRunWarningDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ScenarioRunWarningDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunWarningDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunWarningDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunWarningDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScenarioSummaryState : System.IEquatable<Azure.ResourceManager.Chaos.Models.ScenarioSummaryState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScenarioSummaryState(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioSummaryState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioSummaryState Canceling { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioSummaryState Failed { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioSummaryState FailingOnError { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioSummaryState Pending { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioSummaryState Running { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioSummaryState Skipped { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioSummaryState Starting { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioSummaryState Stopping { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioSummaryState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ScenarioSummaryState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ScenarioSummaryState left, Azure.ResourceManager.Chaos.Models.ScenarioSummaryState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ScenarioSummaryState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ScenarioSummaryState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ScenarioSummaryState left, Azure.ResourceManager.Chaos.Models.ScenarioSummaryState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScenarioTemplateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioTemplateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioTemplateProperties>
    {
        internal ScenarioTemplateProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ScenarioAction> Actions { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.FailureBehavior? FailureBehavior { get { throw null; } }
        public string LatestVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterInfo> Parameters { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioTemplateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioTemplateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ScenarioTemplateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioTemplateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioTemplateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ScenarioTemplateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioTemplateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioTemplateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioTemplateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScenarioTemplateVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioTemplateVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioTemplateVersionProperties>
    {
        internal ScenarioTemplateVersionProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ScenarioAction> Actions { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.FailureBehavior? FailureBehavior { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterInfo> Parameters { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioTemplateVersionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ScenarioTemplateVersionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ScenarioTemplateVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioTemplateVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioTemplateVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ScenarioTemplateVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioTemplateVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioTemplateVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioTemplateVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScenarioValidationState : System.IEquatable<Azure.ResourceManager.Chaos.Models.ScenarioValidationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScenarioValidationState(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioValidationState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioValidationState Generating { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioValidationState NoResolvedResources { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioValidationState NotStarted { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioValidationState RequiresAttention { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioValidationState Resolving { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioValidationState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioValidationState Validating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ScenarioValidationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ScenarioValidationState left, Azure.ResourceManager.Chaos.Models.ScenarioValidationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ScenarioValidationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ScenarioValidationState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ScenarioValidationState left, Azure.ResourceManager.Chaos.Models.ScenarioValidationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TemplateEvaluationResultItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.TemplateEvaluationResultItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.TemplateEvaluationResultItem>
    {
        internal TemplateEvaluationResultItem() { }
        public Azure.ResourceManager.Chaos.Models.RecommendationStatus EvaluationResult { get { throw null; } }
        public Azure.Core.ResourceIdentifier TemplateId { get { throw null; } }
        public string TemplateName { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.TemplateEvaluationResultItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.TemplateEvaluationResultItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.TemplateEvaluationResultItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.TemplateEvaluationResultItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.TemplateEvaluationResultItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.TemplateEvaluationResultItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.TemplateEvaluationResultItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.TemplateEvaluationResultItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.TemplateEvaluationResultItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ValidationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ValidationProperties>
    {
        internal ValidationProperties() { }
        public System.DateTimeOffset? EndsOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosOperationError> Errors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ScenarioRunResource> ExcludedResources { get { throw null; } }
        public string ExecutionPlanJson { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ScenarioRunResource> Resources { get { throw null; } }
        public System.DateTimeOffset StartsOn { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ScenarioValidationState Status { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ScenarioErrors ValidationErrors { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ValidationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ValidationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ValidationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ValidationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ValidationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ValidationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ValidationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ValidationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ValidationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceCustomerManagedKeyEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryption>
    {
        public WorkspaceCustomerManagedKeyEncryption(System.Uri keyEncryptionKeyUri, Azure.Core.ResourceIdentifier keyVaultResourceId) { }
        public System.Uri KeyEncryptionKeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier KeyVaultResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryption JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryption PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceCustomerManagedKeyEncryptionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryptionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryptionPatch>
    {
        public WorkspaceCustomerManagedKeyEncryptionPatch() { }
        public System.Uri KeyEncryptionKeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier KeyVaultResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryptionPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryptionPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryptionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryptionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryptionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryptionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryptionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryptionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryptionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceDiscoveryAccessWarning : Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryWarning, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryAccessWarning>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryAccessWarning>
    {
        internal WorkspaceDiscoveryAccessWarning() { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected override Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryWarning JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryWarning PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryAccessWarning System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryAccessWarning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryAccessWarning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryAccessWarning System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryAccessWarning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryAccessWarning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryAccessWarning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkspaceDiscoveryCompleteness : System.IEquatable<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCompleteness>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkspaceDiscoveryCompleteness(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCompleteness BaselineUnknown { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCompleteness Established { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCompleteness KnownPartial { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCompleteness VerificationIncomplete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCompleteness other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCompleteness left, Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCompleteness right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCompleteness (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCompleteness? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCompleteness left, Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCompleteness right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkspaceDiscoveryCoverageSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCoverageSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCoverageSummary>
    {
        internal WorkspaceDiscoveryCoverageSummary() { }
        public Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceCoverageSummary Resources { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryScopeCoverageSummary Scopes { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCoverageSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCoverageSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCoverageSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCoverageSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCoverageSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCoverageSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCoverageSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCoverageSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCoverageSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceDiscoveryPermissionWarning : Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryWarning, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryPermissionWarning>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryPermissionWarning>
    {
        internal WorkspaceDiscoveryPermissionWarning() { }
        public Azure.ResourceManager.Chaos.Models.PermissionError Permission { get { throw null; } }
        protected override Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryWarning JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryWarning PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryPermissionWarning System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryPermissionWarning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryPermissionWarning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryPermissionWarning System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryPermissionWarning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryPermissionWarning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryPermissionWarning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceDiscoveryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryProperties>
    {
        internal WorkspaceDiscoveryProperties() { }
        public Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCompleteness? Completeness { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryCoverageSummary CoverageSummary { get { throw null; } }
        public System.DateTimeOffset? EndsOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosOperationError> Errors { get { throw null; } }
        public string ResourceSnapshotId { get { throw null; } }
        public System.DateTimeOffset? StartsOn { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryWarning> Warnings { get { throw null; } }
        public long? WarningsTotalCount { get { throw null; } }
        public bool? WarningsTruncated { get { throw null; } }
        public Azure.Core.ResourceIdentifier WorkspaceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceDiscoveryResourceCoverageSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceCoverageSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceCoverageSummary>
    {
        internal WorkspaceDiscoveryResourceCoverageSummary() { }
        public long ClassifiedCount { get { throw null; } }
        public long CoveredCount { get { throw null; } }
        public long ExpectedCount { get { throw null; } }
        public long UnclassifiedCount { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceCoverageSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceCoverageSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceCoverageSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceCoverageSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceCoverageSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceCoverageSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceCoverageSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceCoverageSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceCoverageSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceDiscoveryResourceWarning : Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryWarning, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceWarning>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceWarning>
    {
        internal WorkspaceDiscoveryResourceWarning() { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected override Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryWarning JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryWarning PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceWarning System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceWarning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceWarning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceWarning System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceWarning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceWarning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryResourceWarning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceDiscoveryScopeCoverageSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryScopeCoverageSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryScopeCoverageSummary>
    {
        internal WorkspaceDiscoveryScopeCoverageSummary() { }
        public long BaselineUnknownCount { get { throw null; } }
        public long EstablishedCount { get { throw null; } }
        public long KnownExpectedSetCount { get { throw null; } }
        public long KnownPartialCount { get { throw null; } }
        public long TotalCount { get { throw null; } }
        public long UnknownExpectedSetCount { get { throw null; } }
        public long VerificationIncompleteCount { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryScopeCoverageSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryScopeCoverageSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryScopeCoverageSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryScopeCoverageSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryScopeCoverageSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryScopeCoverageSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryScopeCoverageSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryScopeCoverageSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryScopeCoverageSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkspaceDiscoveryStatus : System.IEquatable<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkspaceDiscoveryStatus(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryStatus PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryStatus left, Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryStatus left, Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class WorkspaceDiscoveryWarning : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryWarning>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryWarning>
    {
        internal WorkspaceDiscoveryWarning() { }
        public string Message { get { throw null; } }
        public Azure.Core.ResourceIdentifier ScopeId { get { throw null; } }
        public string ScopeKind { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryWarning JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryWarning PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryWarning System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryWarning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryWarning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryWarning System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryWarning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryWarning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceDiscoveryWarning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceEncryption>
    {
        public WorkspaceEncryption() { }
        public Azure.ResourceManager.Chaos.Models.WorkspaceCustomerManagedKeyEncryption CustomerManagedKeyEncryption { get { throw null; } set { } }
        public string CustomerManagedKeyOnboardingApplicationId { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.WorkspaceEncryption JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.WorkspaceEncryption PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.WorkspaceEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.WorkspaceEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkspaceEncryptionProtection : System.IEquatable<Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionProtection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkspaceEncryptionProtection(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionProtection CustomerManaged { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionProtection MicrosoftManaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionProtection other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionProtection left, Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionProtection right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionProtection (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionProtection? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionProtection left, Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionProtection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkspaceEncryptionState : System.IEquatable<Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkspaceEncryptionState(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionState Applied { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionState Failed { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionState NotConfigured { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionState Pending { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionState left, Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionState left, Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkspaceEncryptionStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionStatus>
    {
        internal WorkspaceEncryptionStatus() { }
        public Azure.ResponseError Error { get { throw null; } }
        public System.DateTimeOffset? LastCheckedOn { get { throw null; } }
        public System.Uri ObservedKeyEncryptionKeyUri { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionProtection? ObservedProtection { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionState State { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceEncryptionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceEvaluationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationProperties>
    {
        internal WorkspaceEvaluationProperties() { }
        public Azure.Core.ResourceIdentifier DiscoveryResultId { get { throw null; } }
        public System.DateTimeOffset? EndsOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosOperationError> Errors { get { throw null; } }
        public int NumTemplatesEvaluatedCancelled { get { throw null; } }
        public int NumTemplatesEvaluatedFailed { get { throw null; } }
        public int NumTemplatesEvaluatedSucceeded { get { throw null; } }
        public int NumTemplatesToEvaluate { get { throw null; } }
        public string ResourceSnapshotId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.TemplateEvaluationResultItem> Results { get { throw null; } }
        public System.DateTimeOffset? StartsOn { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationStatus Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier WorkspaceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkspaceEvaluationStatus : System.IEquatable<Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkspaceEvaluationStatus(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationStatus PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationStatus left, Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationStatus left, Azure.ResourceManager.Chaos.Models.WorkspaceEvaluationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkspaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceProperties>
    {
        public WorkspaceProperties(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> scopes) { }
        public Azure.ResourceManager.Chaos.Models.WorkspaceEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> Scopes { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.WorkspaceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.WorkspaceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.WorkspaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.WorkspaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ZoneResolutionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ZoneResolutionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ZoneResolutionInfo>
    {
        internal ZoneResolutionInfo() { }
        public Azure.ResourceManager.Chaos.Models.ZoneResolutionMode Mode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequestedPhysicalZones { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ZoneResolutionMapping> SubscriptionZoneMappings { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ZoneResolutionInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ZoneResolutionInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ZoneResolutionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ZoneResolutionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ZoneResolutionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ZoneResolutionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ZoneResolutionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ZoneResolutionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ZoneResolutionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ZoneResolutionMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ZoneResolutionMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ZoneResolutionMapping>
    {
        internal ZoneResolutionMapping() { }
        public string SubscriptionId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.PhysicalToLogicalZoneMapping> ZoneMappings { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ZoneResolutionMapping JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ZoneResolutionMapping PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ZoneResolutionMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ZoneResolutionMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ZoneResolutionMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ZoneResolutionMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ZoneResolutionMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ZoneResolutionMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ZoneResolutionMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ZoneResolutionMode : System.IEquatable<Azure.ResourceManager.Chaos.Models.ZoneResolutionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ZoneResolutionMode(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ZoneResolutionMode Logical { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ZoneResolutionMode Physical { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ZoneResolutionMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ZoneResolutionMode left, Azure.ResourceManager.Chaos.Models.ZoneResolutionMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ZoneResolutionMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ZoneResolutionMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ZoneResolutionMode left, Azure.ResourceManager.Chaos.Models.ZoneResolutionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
}
