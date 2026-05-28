namespace Azure.ResourceManager.Chaos
{
    public partial class AzureResourceManagerChaosContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerChaosContext() { }
        public static Azure.ResourceManager.Chaos.AzureResourceManagerChaosContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
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
        public string Publisher { get { throw null; } }
        public string TargetType { get { throw null; } }
        public string Urn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
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
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
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
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
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
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosTargetSelector> Selectors { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep> Steps { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? StoppedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static Azure.ResourceManager.Chaos.ChaosTargetMetadataCollection GetAllChaosTargetMetadata(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosCapabilityMetadataResource GetChaosCapabilityMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosCapabilityResource GetChaosCapabilityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public static Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource GetChaosCapabilityTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetChaosExperiment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource>> GetChaosExperimentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource GetChaosExperimentExecutionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentResource GetChaosExperimentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentCollection GetChaosExperiments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetChaosExperiments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetChaosExperimentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource> GetChaosTarget(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource>> GetChaosTargetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource> GetChaosTargetMetadata(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource>> GetChaosTargetMetadataAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetMetadataResource GetChaosTargetMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetResource GetChaosTargetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetCollection GetChaosTargets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentProviderNamespace, string parentResourceType, string parentResourceName) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public static Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetTypeResource> GetChaosTargetType(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetTypeResource>> GetChaosTargetTypeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public static Azure.ResourceManager.Chaos.ChaosTargetTypeResource GetChaosTargetTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public static Azure.ResourceManager.Chaos.ChaosTargetTypeCollection GetChaosTargetTypes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
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
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
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
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
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
}
namespace Azure.ResourceManager.Chaos.Mocking
{
    public partial class MockableChaosArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableChaosArmClient() { }
        public virtual Azure.ResourceManager.Chaos.ChaosCapabilityMetadataResource GetChaosCapabilityMetadataResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosCapabilityResource GetChaosCapabilityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public virtual Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource GetChaosCapabilityTypeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource GetChaosExperimentExecutionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosExperimentResource GetChaosExperimentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetMetadataResource GetChaosTargetMetadataResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetResource GetChaosTargetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public virtual Azure.ResourceManager.Chaos.ChaosTargetTypeResource GetChaosTargetTypeResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
    }
    public partial class MockableChaosSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableChaosSubscriptionResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetMetadataCollection GetAllChaosTargetMetadata(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetChaosExperiments(bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetChaosExperimentsAsync(bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource> GetChaosTargetMetadata(Azure.Core.AzureLocation location, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource>> GetChaosTargetMetadataAsync(Azure.Core.AzureLocation location, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetTypeResource> GetChaosTargetType(string locationName, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetTypeResource>> GetChaosTargetTypeAsync(string locationName, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public virtual Azure.ResourceManager.Chaos.ChaosTargetTypeCollection GetChaosTargetTypes(string locationName) { throw null; }
    }
}
namespace Azure.ResourceManager.Chaos.Models
{
    public static partial class ArmChaosModelFactory
    {
        public static Azure.ResourceManager.Chaos.ChaosCapabilityData ChaosCapabilityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string publisher = null, string targetType = null, string description = null, string parametersSchema = null, string urn = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosCapabilityMetadataData ChaosCapabilityMetadataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string publisher = null, string targetType = null, string displayName = null, string description = null, string parametersSchema = null, string urn = null, string kind = null, System.Collections.Generic.IEnumerable<string> azureRbacActions = null, System.Collections.Generic.IEnumerable<string> azureRbacDataActions = null, System.Collections.Generic.IEnumerable<string> requiredAzureRoleDefinitionIds = null, string runtimeKind = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public static Azure.ResourceManager.Chaos.ChaosCapabilityTypeData ChaosCapabilityTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string publisher = null, string targetType = null, string displayName = null, string description = null, string parametersSchema = null, string urn = null, string kind = null, System.Collections.Generic.IEnumerable<string> azureRbacActions = null, System.Collections.Generic.IEnumerable<string> azureRbacDataActions = null, string runtimeKind = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentData ChaosExperimentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep> steps = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosTargetSelector> selectors = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentExecutionData ChaosExperimentExecutionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string status = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? stoppedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosExperimentRunActionStatus ChaosExperimentRunActionStatus(string actionName = null, string actionId = null, string status = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties> targets = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosExperimentRunBranchStatus ChaosExperimentRunBranchStatus(string branchName = null, string branchId = null, string status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunActionStatus> actions = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosExperimentRunStepStatus ChaosExperimentRunStepStatus(string stepName = null, string stepId = null, string status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunBranchStatus> branches = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetData ChaosTargetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, System.BinaryData> properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public static Azure.ResourceManager.Chaos.ChaosTargetData ChaosTargetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IDictionary<string, System.BinaryData> properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetMetadataData ChaosTargetMetadataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, string description = null, string propertiesSchema = null, System.Collections.Generic.IEnumerable<string> resourceTypes = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public static Azure.ResourceManager.Chaos.ChaosTargetTypeData ChaosTargetTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string displayName = null, string description = null, string propertiesSchema = null, System.Collections.Generic.IEnumerable<string> resourceTypes = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError ExperimentExecutionActionTargetDetailsError(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties ExperimentExecutionActionTargetDetailsProperties(string status = null, string target = null, System.DateTimeOffset? targetFailedOn = default(System.DateTimeOffset?), System.DateTimeOffset? targetCompletedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError error = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails ExperimentExecutionDetails(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string status = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? stoppedOn = default(System.DateTimeOffset?), string failureReason = null, System.DateTimeOffset? lastActionOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunStepStatus> runInformationSteps = null) { throw null; }
    }
    public partial class ChaosContinuousAction : Azure.ResourceManager.Chaos.Models.ChaosExperimentAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosContinuousAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosContinuousAction>
    {
        public ChaosContinuousAction(string name, System.TimeSpan duration, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> parameters, string selectorId) : base (default(string)) { }
        public System.TimeSpan Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> Parameters { get { throw null; } }
        public string SelectorId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosExperimentStep System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosExperimentStep System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChaosKeyValuePair : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair>
    {
        public ChaosKeyValuePair(string key, string value) { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.ResourceManager.Chaos.Models.ChaosProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ChaosProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState left, Azure.ResourceManager.Chaos.Models.ChaosProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState left, Azure.ResourceManager.Chaos.Models.ChaosProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ChaosTargetFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosTargetFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetFilter>
    {
        protected ChaosTargetFilter() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType left, Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType left, Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ChaosTargetSelector : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosTargetSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetSelector>
    {
        protected ChaosTargetSelector(string id) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is no longer supported in all API versions.", false)]
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosTargetFilter Filter { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosTargetSimpleFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosTargetSimpleFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosTargetSimpleFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosTargetSimpleFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetSimpleFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetSimpleFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosTargetSimpleFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExperimentExecutionActionTargetDetailsError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError>
    {
        internal ExperimentExecutionActionTargetDetailsError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunStepStatus> RunInformationSteps { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? StoppedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
