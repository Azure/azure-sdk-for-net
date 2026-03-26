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
        public static Azure.ResourceManager.Chaos.ChaosCapabilityMetadataResource GetChaosCapabilityMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosCapabilityResource GetChaosCapabilityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public static Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource GetChaosCapabilityTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetChaosExperiment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource>> GetChaosExperimentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource GetChaosExperimentExecutionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentResource GetChaosExperimentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentCollection GetChaosExperiments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetChaosExperiments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetChaosExperimentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource GetChaosScenarioConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosScenarioResource GetChaosScenarioResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosScenarioRunResource GetChaosScenarioRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource> GetChaosTarget(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource>> GetChaosTargetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource> GetChaosTargetMetadata(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource>> GetChaosTargetMetadataAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetMetadataResource GetChaosTargetMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetResource GetChaosTargetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public static Azure.Pageable<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> GetChaosWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> GetChaosWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Chaos.DiscoveredResource GetDiscoveredResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.PermissionsFixResource GetPermissionsFixResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.PrivateAccessResource> GetPrivateAccess(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.PrivateAccessResource>> GetPrivateAccessAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Chaos.PrivateAccessCollection GetPrivateAccesses(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Chaos.PrivateAccessResource> GetPrivateAccesses(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Chaos.PrivateAccessResource> GetPrivateAccessesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Chaos.PrivateAccessResource GetPrivateAccessResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.PrivateEndpointConnectionResource GetPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ValidationResource GetValidationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> GetWorkspaceOperationResult(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceResource>> GetWorkspaceOperationResultAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChaosPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData>
    {
        internal ChaosPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Chaos.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } }
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
        public virtual Azure.Response Execute(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExecuteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.PermissionsFixResource> FixResourcePermissions(Azure.ResourceManager.Chaos.Models.ChaosFixResourcePermissionsRequestContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.PermissionsFixResource>> FixResourcePermissionsAsync(Azure.ResourceManager.Chaos.Models.ChaosFixResourcePermissionsRequestContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.PermissionsFixResource GetPermissionsFix() { throw null; }
        public virtual Azure.ResourceManager.Chaos.ValidationResource GetValidation() { throw null; }
        Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ValidationResource> Validate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ValidationResource>> ValidateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioResource> GetChaosScenario(string scenarioName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosScenarioResource>> GetChaosScenarioAsync(string scenarioName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosScenarioCollection GetChaosScenarios() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.DiscoveredResource> GetDiscoveredResource(string discoveredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.DiscoveredResource>> GetDiscoveredResourceAsync(string discoveredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.DiscoveredResourceCollection GetDiscoveredResources() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsResult> RefreshRecommendations(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsResult>> RefreshRecommendationsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class DiscoveredResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.DiscoveredResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.DiscoveredResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiscoveredResource() { }
        public virtual Azure.ResourceManager.Chaos.DiscoveredResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string discoveredResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.DiscoveredResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.DiscoveredResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Chaos.DiscoveredResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.DiscoveredResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.DiscoveredResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.DiscoveredResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.DiscoveredResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.DiscoveredResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.DiscoveredResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveredResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.DiscoveredResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.DiscoveredResource>, System.Collections.IEnumerable
    {
        protected DiscoveredResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string discoveredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string discoveredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.DiscoveredResource> Get(string discoveredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.DiscoveredResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.DiscoveredResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.DiscoveredResource>> GetAsync(string discoveredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.DiscoveredResource> GetIfExists(string discoveredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.DiscoveredResource>> GetIfExistsAsync(string discoveredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.DiscoveredResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.DiscoveredResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.DiscoveredResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.DiscoveredResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiscoveredResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.DiscoveredResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.DiscoveredResourceData>
    {
        internal DiscoveredResourceData() { }
        public Azure.ResourceManager.Chaos.Models.DiscoveredResourceProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.DiscoveredResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.DiscoveredResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.DiscoveredResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.DiscoveredResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.DiscoveredResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.DiscoveredResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.DiscoveredResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PermissionsFixData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.PermissionsFixData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.PermissionsFixData>
    {
        internal PermissionsFixData() { }
        public Azure.ResourceManager.Chaos.Models.PermissionsFixProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.PermissionsFixData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.PermissionsFixData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.PermissionsFixData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.PermissionsFixData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.PermissionsFixData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.PermissionsFixData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.PermissionsFixData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PermissionsFixResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.PermissionsFixData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.PermissionsFixData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PermissionsFixResource() { }
        public virtual Azure.ResourceManager.Chaos.PermissionsFixData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string scenarioName, string scenarioConfigurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.PermissionsFixResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.PermissionsFixResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Chaos.PermissionsFixData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.PermissionsFixData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.PermissionsFixData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.PermissionsFixData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.PermissionsFixData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.PermissionsFixData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.PermissionsFixData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateAccessCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.PrivateAccessResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.PrivateAccessResource>, System.Collections.IEnumerable
    {
        protected PrivateAccessCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.PrivateAccessResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateAccessName, Azure.ResourceManager.Chaos.PrivateAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.PrivateAccessResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateAccessName, Azure.ResourceManager.Chaos.PrivateAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.PrivateAccessResource> Get(string privateAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.PrivateAccessResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.PrivateAccessResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.PrivateAccessResource>> GetAsync(string privateAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.PrivateAccessResource> GetIfExists(string privateAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.PrivateAccessResource>> GetIfExistsAsync(string privateAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.PrivateAccessResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.PrivateAccessResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.PrivateAccessResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.PrivateAccessResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateAccessData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.PrivateAccessData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.PrivateAccessData>
    {
        public PrivateAccessData(Azure.Core.AzureLocation location, Azure.ResourceManager.Chaos.Models.PrivateAccessProperties properties) { }
        public Azure.ResourceManager.Chaos.Models.PrivateAccessProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.PrivateAccessData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.PrivateAccessData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.PrivateAccessData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.PrivateAccessData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.PrivateAccessData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.PrivateAccessData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.PrivateAccessData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateAccessResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.PrivateAccessData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.PrivateAccessData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateAccessResource() { }
        public virtual Azure.ResourceManager.Chaos.PrivateAccessData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.PrivateAccessResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.PrivateAccessResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateAccessName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.PrivateAccessResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.PrivateAccessResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.PrivateEndpointConnectionResource> GetPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.PrivateEndpointConnectionResource>> GetPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceListResult> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceListResult>> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.PrivateAccessResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.PrivateAccessResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.PrivateAccessResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.PrivateAccessResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Chaos.PrivateAccessData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.PrivateAccessData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.PrivateAccessData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.PrivateAccessData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.PrivateAccessData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.PrivateAccessData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.PrivateAccessData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.PrivateAccessResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.Models.PrivateAccessPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.PrivateAccessResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.Models.PrivateAccessPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.PrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.PrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.PrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.PrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.PrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.PrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.PrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.PrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.PrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.PrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.PrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.PrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateAccessName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.PrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.PrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ValidationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ValidationData>
    {
        internal ValidationData() { }
        public Azure.ResourceManager.Chaos.Models.ValidationProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.ValidationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ValidationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ValidationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ValidationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ValidationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ValidationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ValidationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ValidationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ValidationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ValidationResource() { }
        public virtual Azure.ResourceManager.Chaos.ValidationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string scenarioName, string scenarioConfigurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ValidationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ValidationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Chaos.ValidationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ValidationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.ValidationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.ValidationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ValidationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ValidationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.ValidationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.Chaos.Mocking
{
    public partial class MockableChaosArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableChaosArmClient() { }
        public virtual Azure.ResourceManager.Chaos.ChaosCapabilityMetadataResource GetChaosCapabilityMetadataResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosCapabilityResource GetChaosCapabilityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public virtual Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource GetChaosCapabilityTypeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource GetChaosExperimentExecutionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosExperimentResource GetChaosExperimentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosScenarioConfigurationResource GetChaosScenarioConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosScenarioResource GetChaosScenarioResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosScenarioRunResource GetChaosScenarioRunResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetMetadataResource GetChaosTargetMetadataResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetResource GetChaosTargetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public virtual Azure.ResourceManager.Chaos.ChaosTargetTypeResource GetChaosTargetTypeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosWorkspaceResource GetChaosWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.DiscoveredResource GetDiscoveredResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.PermissionsFixResource GetPermissionsFixResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.PrivateAccessResource GetPrivateAccessResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.PrivateEndpointConnectionResource GetPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ValidationResource GetValidationResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Chaos.PrivateAccessResource> GetPrivateAccess(string privateAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.PrivateAccessResource>> GetPrivateAccessAsync(string privateAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.PrivateAccessCollection GetPrivateAccesses() { throw null; }
    }
    public partial class MockableChaosSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableChaosSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> Get(string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetMetadataCollection GetAllChaosTargetMetadata(Azure.Core.AzureLocation location) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetAsync(string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetChaosExperiments(bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetChaosExperimentsAsync(bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource> GetChaosTargetMetadata(Azure.Core.AzureLocation location, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetMetadataResource>> GetChaosTargetMetadataAsync(Azure.Core.AzureLocation location, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetTypeResource> GetChaosTargetType(string locationName, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetTypeResource>> GetChaosTargetTypeAsync(string locationName, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public virtual Azure.ResourceManager.Chaos.ChaosTargetTypeCollection GetChaosTargetTypes(string locationName) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> GetChaosWorkspaces(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> GetChaosWorkspacesAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.PrivateAccessResource> GetPrivateAccesses(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.PrivateAccessResource> GetPrivateAccessesAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceResource> GetWorkspaceOperationResult(string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosWorkspaceResource>> GetWorkspaceOperationResultAsync(string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public static partial class ArmChaosModelFactory
    {
        public static Azure.ResourceManager.Chaos.ChaosCapabilityData ChaosCapabilityData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string publisher, string targetType, string description, string parametersSchema, string urn) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosCapabilityData ChaosCapabilityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string publisher = null, string targetType = null, string description = null, string parametersSchema = null, string urn = null, Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosCapabilityMetadataData ChaosCapabilityMetadataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string publisher = null, string targetType = null, string displayName = null, string description = null, string parametersSchema = null, string urn = null, string kind = null, System.Collections.Generic.IEnumerable<string> azureRbacActions = null, System.Collections.Generic.IEnumerable<string> azureRbacDataActions = null, System.Collections.Generic.IEnumerable<string> requiredAzureRoleDefinitionIds = null, string runtimeKind = null) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public static Azure.ResourceManager.Chaos.ChaosCapabilityTypeData ChaosCapabilityTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string publisher = null, string targetType = null, string displayName = null, string description = null, string parametersSchema = null, string urn = null, string kind = null, System.Collections.Generic.IEnumerable<string> azureRbacActions = null, System.Collections.Generic.IEnumerable<string> azureRbacDataActions = null, string runtimeKind = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosContinuousAction ChaosContinuousAction(string name = null, System.TimeSpan duration = default(System.TimeSpan), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> parameters = null, string selectorId = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosDiscreteAction ChaosDiscreteAction(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> parameters = null, string selectorId = null) { throw null; }
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
        public static Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData ChaosPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResource ChaosPrivateLinkResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceListResult ChaosPrivateLinkResourceListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResource> value = null, System.Uri nextLink = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkResourceProperties ChaosPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null, Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkServiceConnectionState ChaosPrivateLinkServiceConnectionState(Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointServiceConnectionStatus? status = default(Azure.ResourceManager.Chaos.Models.ChaosPrivateEndpointServiceConnectionStatus?), string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosScenarioConfigurationData ChaosScenarioConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.ScenarioConfigurationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosScenarioData ChaosScenarioData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.ScenarioProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosScenarioRunData ChaosScenarioRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.ScenarioRunProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetData ChaosTargetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, System.BinaryData> properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public static Azure.ResourceManager.Chaos.ChaosTargetData ChaosTargetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IDictionary<string, System.BinaryData> properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosTargetListSelector ChaosTargetListSelector(string id = null, Azure.ResourceManager.Chaos.Models.ChaosTargetFilter filter = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosTargetReference> targets = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetMetadataData ChaosTargetMetadataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, string description = null, string propertiesSchema = null, System.Collections.Generic.IEnumerable<string> resourceTypes = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosTargetQuerySelector ChaosTargetQuerySelector(string id = null, Azure.ResourceManager.Chaos.Models.ChaosTargetFilter filter = null, string queryString = null, System.Collections.Generic.IEnumerable<string> subscriptionIds = null) { throw null; }
        [System.ObsoleteAttribute("This method no longer works in all API versions.", false)]
        public static Azure.ResourceManager.Chaos.ChaosTargetTypeData ChaosTargetTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string displayName = null, string description = null, string propertiesSchema = null, System.Collections.Generic.IEnumerable<string> resourceTypes = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosWorkspaceData ChaosWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Chaos.Models.WorkspaceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosWorkspacePatch ChaosWorkspacePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ConfigurationExclusions ConfigurationExclusions(System.Collections.Generic.IEnumerable<string> resources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> tags = null, System.Collections.Generic.IEnumerable<string> types = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ConfigurationFilters ConfigurationFilters(System.Collections.Generic.IEnumerable<string> locations = null, System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.Chaos.DiscoveredResourceData DiscoveredResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.DiscoveredResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.DiscoveredResourceProperties DiscoveredResourceProperties(string resourceNamespace = null, string resourceName = null, string resourceType = null, string fullyQualifiedIdentifier = null, System.DateTimeOffset discoveredOn = default(System.DateTimeOffset), string scope = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.EntraIdentity EntraIdentity(string objectId = null, string tenantId = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError ExperimentExecutionActionTargetDetailsError(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties ExperimentExecutionActionTargetDetailsProperties(string status = null, string target = null, System.DateTimeOffset? targetFailedOn = default(System.DateTimeOffset?), System.DateTimeOffset? targetCompletedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError error = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails ExperimentExecutionDetails(Azure.Core.ResourceIdentifier id = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string name = null, string status = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? stoppedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?), string failureReason = null, System.DateTimeOffset? lastActionOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunStepStatus> runInformationSteps = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails ExperimentExecutionDetails(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string status, System.DateTimeOffset? startedOn, System.DateTimeOffset? stoppedOn, string failureReason, System.DateTimeOffset? lastActionOn, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentRunStepStatus> runInformationSteps) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.PermissionError PermissionError(string resourceId = null, System.Collections.Generic.IEnumerable<string> missingPermissions = null, System.Collections.Generic.IEnumerable<string> requiredPermissions = null, System.Collections.Generic.IEnumerable<string> recommendedRoles = null, Azure.ResourceManager.Chaos.Models.EntraIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Chaos.PermissionsFixData PermissionsFixData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.PermissionsFixProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.PermissionsFixProperties PermissionsFixProperties(Azure.ResourceManager.Chaos.Models.PermissionsFixState state = default(Azure.ResourceManager.Chaos.Models.PermissionsFixState), System.DateTimeOffset startedOn = default(System.DateTimeOffset), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), bool whatIfMode = false, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.RoleAssignmentResult> roleAssignments = null, Azure.ResourceManager.Chaos.Models.PermissionsFixSummary summary = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.PermissionsFixSummary PermissionsFixSummary(int totalRequired = 0, int succeeded = 0, int failed = 0, int skipped = 0) { throw null; }
        public static Azure.ResourceManager.Chaos.PrivateAccessData PrivateAccessData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Chaos.Models.PrivateAccessProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.PrivateAccessPatch PrivateAccessPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.PrivateAccessProperties PrivateAccessProperties(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Chaos.Models.PublicNetworkAccessOption? publicNetworkAccess = default(Azure.ResourceManager.Chaos.Models.PublicNetworkAccessOption?)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.PrivateEndpointConnectionProperties PrivateEndpointConnectionProperties(System.Collections.Generic.IEnumerable<string> groupIds = null, string privateEndpointId = null, Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.Recommendation Recommendation(Azure.ResourceManager.Chaos.Models.RecommendationStatus recommendationStatus = default(Azure.ResourceManager.Chaos.Models.RecommendationStatus), System.DateTimeOffset? evaluationRunOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.RefreshRecommendationsResult RefreshRecommendationsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTask> tasks = null, System.DateTimeOffset? completedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTask RefreshRecommendationsTask(Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskKind kind = default(Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskKind), string operationId = null, string status = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskError> errors = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskError RefreshRecommendationsTaskError(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ResourceStateError ResourceStateError(string resourceId = null, int errorCode = 0, string errorMessage = null, string remediationUri = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.RoleAssignmentError RoleAssignmentError(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.RoleAssignmentResult RoleAssignmentResult(string targetResourceId = null, string principalId = null, string roleDefinitionId = null, string roleDefinitionName = null, string scope = null, Azure.ResourceManager.Chaos.Models.RoleAssignmentStatus status = default(Azure.ResourceManager.Chaos.Models.RoleAssignmentStatus), string roleAssignmentId = null, Azure.ResourceManager.Chaos.Models.RoleAssignmentError error = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.RunAfter RunAfter(Azure.ResourceManager.Chaos.Models.RunAfterBehavior? behavior = default(Azure.ResourceManager.Chaos.Models.RunAfterBehavior?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ActionDependency> items = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioAction ScenarioAction(string name = null, string urn = null, System.Collections.Generic.IEnumerable<string> targetTypes = null, string description = null, System.TimeSpan duration = default(System.TimeSpan), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterContent> parameters = null, Azure.ResourceManager.Chaos.Models.RunAfter runAfter = null, System.TimeSpan? waitBefore = default(System.TimeSpan?), System.TimeSpan? timeout = default(System.TimeSpan?), string resourceId = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioConfigurationProperties ScenarioConfigurationProperties(string scenarioId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> parameters = null, Azure.ResourceManager.Chaos.Models.ConfigurationExclusions exclusions = null, Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?), Azure.ResourceManager.Chaos.Models.ConfigurationFilters filters = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioErrors ScenarioErrors(string errorCode = null, string errorMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.PermissionError> permission = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ResourceStateError> resource = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioProperties ScenarioProperties(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?), string createdFrom = null, string version = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterContent> parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ScenarioAction> actions = null, Azure.ResourceManager.Chaos.Models.Recommendation recommendation = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunProperties ScenarioRunProperties(string workspaceName = null, string scenarioName = null, string scenarioConfigurationName = null, string managedIdentityPrincipalId = null, Azure.ResourceManager.Chaos.Models.ScenarioRunState state = default(Azure.ResourceManager.Chaos.Models.ScenarioRunState), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ScenarioRunResource> resources = null, Azure.ResourceManager.Chaos.Models.ScenarioErrors errors = null, string scenarioRunJson = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryAction> scenarioRunSummary = null, System.DateTimeOffset startedOn = default(System.DateTimeOffset), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunResource ScenarioRunResource(string id = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryAction ScenarioRunSummaryAction(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ScenarioRunResource> resources = null, string actionUrn = null, Azure.ResourceManager.Chaos.Models.ScenarioSummaryState state = default(Azure.ResourceManager.Chaos.Models.ScenarioSummaryState), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Chaos.ValidationData ValidationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Chaos.Models.ValidationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ValidationProperties ValidationProperties(Azure.ResourceManager.Chaos.Models.ScenarioValidationState state = default(Azure.ResourceManager.Chaos.Models.ScenarioValidationState), System.DateTimeOffset startedOn = default(System.DateTimeOffset), string executionPlanJson = null, System.DateTimeOffset completedOn = default(System.DateTimeOffset), Azure.ResourceManager.Chaos.Models.ScenarioErrors errors = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.WorkspaceProperties WorkspaceProperties(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ChaosProvisioningState?), System.Collections.Generic.IEnumerable<string> scopes = null) { throw null; }
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
        public bool? WhatIf { get { throw null; } set { } }
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
    public partial class ChaosScenarioParameterContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterContent>
    {
        public ChaosScenarioParameterContent(string name, Azure.ResourceManager.Chaos.Models.ParameterType type) { }
        public string Default { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? Required { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.ParameterType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ConfigurationExclusions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ConfigurationExclusions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ConfigurationExclusions>
    {
        public ConfigurationExclusions() { }
        public System.Collections.Generic.IList<string> Resources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> Tags { get { throw null; } }
        public System.Collections.Generic.IList<string> Types { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ConfigurationExclusions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ConfigurationExclusions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ConfigurationExclusions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ConfigurationExclusions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ConfigurationExclusions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ConfigurationExclusions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ConfigurationExclusions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ConfigurationExclusions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ConfigurationExclusions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfigurationFilters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ConfigurationFilters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ConfigurationFilters>
    {
        public ConfigurationFilters() { }
        public System.Collections.Generic.IList<string> Locations { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.ConfigurationFilters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.ConfigurationFilters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.ConfigurationFilters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ConfigurationFilters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ConfigurationFilters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.ConfigurationFilters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ConfigurationFilters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ConfigurationFilters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ConfigurationFilters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public string ResourceName { get { throw null; } }
        public string ResourceNamespace { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public string Scope { get { throw null; } }
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
    public readonly partial struct ParameterType : System.IEquatable<Azure.ResourceManager.Chaos.Models.ParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParameterType(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ParameterType Array { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ParameterType Boolean { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ParameterType Number { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ParameterType Object { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ParameterType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ParameterType left, Azure.ResourceManager.Chaos.Models.ParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ParameterType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ParameterType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ParameterType left, Azure.ResourceManager.Chaos.Models.ParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PermissionError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.PermissionError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PermissionError>
    {
        internal PermissionError() { }
        public Azure.ResourceManager.Chaos.Models.EntraIdentity Identity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> MissingPermissions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RecommendedRoles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredPermissions { get { throw null; } }
        public string ResourceId { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.RoleAssignmentResult> RoleAssignments { get { throw null; } }
        public System.DateTimeOffset StartedOn { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.PermissionsFixState State { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.PermissionsFixSummary Summary { get { throw null; } }
        public bool WhatIfMode { get { throw null; } }
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
    public partial class PrivateAccessPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.PrivateAccessPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PrivateAccessPatch>
    {
        public PrivateAccessPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.PrivateAccessPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.PrivateAccessPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.PrivateAccessPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.PrivateAccessPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.PrivateAccessPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.PrivateAccessPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PrivateAccessPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PrivateAccessPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PrivateAccessPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateAccessProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.PrivateAccessProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PrivateAccessProperties>
    {
        public PrivateAccessProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.ChaosPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.PublicNetworkAccessOption? PublicNetworkAccess { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Chaos.Models.PrivateAccessProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.PrivateAccessProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.PrivateAccessProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.PrivateAccessProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.PrivateAccessProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.PrivateAccessProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PrivateAccessProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PrivateAccessProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PrivateAccessProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.PrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PrivateEndpointConnectionProperties>
    {
        internal PrivateEndpointConnectionProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public string PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.PrivateEndpointConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.PrivateEndpointConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.PrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.PrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.PrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccessOption : System.IEquatable<Azure.ResourceManager.Chaos.Models.PublicNetworkAccessOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccessOption(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.PublicNetworkAccessOption Disabled { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.PublicNetworkAccessOption Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.PublicNetworkAccessOption other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.PublicNetworkAccessOption left, Azure.ResourceManager.Chaos.Models.PublicNetworkAccessOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.PublicNetworkAccessOption (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.PublicNetworkAccessOption? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.PublicNetworkAccessOption left, Azure.ResourceManager.Chaos.Models.PublicNetworkAccessOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Recommendation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.Recommendation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.Recommendation>
    {
        internal Recommendation() { }
        public System.DateTimeOffset? EvaluationRunOn { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.RecommendationStatus RecommendationStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.Recommendation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.Recommendation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.Recommendation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.Recommendation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.Recommendation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.Recommendation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.Recommendation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.Recommendation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.Recommendation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendationStatus : System.IEquatable<Azure.ResourceManager.Chaos.Models.RecommendationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendationStatus(string value) { throw null; }
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
    public partial class RefreshRecommendationsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsResult>
    {
        internal RefreshRecommendationsResult() { }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTask> Tasks { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.RefreshRecommendationsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.RefreshRecommendationsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.RefreshRecommendationsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.RefreshRecommendationsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RefreshRecommendationsTask : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTask>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTask>
    {
        internal RefreshRecommendationsTask() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskError> Errors { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskKind Kind { get { throw null; } }
        public string OperationId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTask JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTask PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTask System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTask>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTask>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTask System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTask>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTask>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTask>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RefreshRecommendationsTaskError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskError>
    {
        internal RefreshRecommendationsTaskError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RefreshRecommendationsTaskKind : System.IEquatable<Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RefreshRecommendationsTaskKind(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskKind ResourceDiscovery { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskKind ScenarioEvaluation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskKind left, Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskKind left, Azure.ResourceManager.Chaos.Models.RefreshRecommendationsTaskKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceStateError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ResourceStateError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ResourceStateError>
    {
        internal ResourceStateError() { }
        public int ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string RemediationUri { get { throw null; } }
        public string ResourceId { get { throw null; } }
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
        public string RoleAssignmentId { get { throw null; } }
        public string RoleDefinitionId { get { throw null; } }
        public string RoleDefinitionName { get { throw null; } }
        public string Scope { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.RoleAssignmentStatus Status { get { throw null; } }
        public string TargetResourceId { get { throw null; } }
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
        public ScenarioAction(string name, string urn, System.Collections.Generic.IEnumerable<string> targetTypes, System.TimeSpan duration) { }
        public string Description { get { throw null; } set { } }
        public System.TimeSpan Duration { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterContent> Parameters { get { throw null; } }
        public string ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.RunAfter RunAfter { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TargetTypes { get { throw null; } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
        public string Urn { get { throw null; } set { } }
        public System.TimeSpan? WaitBefore { get { throw null; } set { } }
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
    public partial class ScenarioConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioConfigurationProperties>
    {
        public ScenarioConfigurationProperties(string scenarioId) { }
        public Azure.ResourceManager.Chaos.Models.ConfigurationExclusions Exclusions { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.ConfigurationFilters Filters { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosKeyValuePair> Parameters { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? ProvisioningState { get { throw null; } }
        public string ScenarioId { get { throw null; } set { } }
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
    public partial class ScenarioProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioProperties>
    {
        public ScenarioProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterContent> parameters, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ScenarioAction> actions) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ScenarioAction> Actions { get { throw null; } }
        public string CreatedFrom { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosScenarioParameterContent> Parameters { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.Recommendation Recommendation { get { throw null; } }
        public string Version { get { throw null; } }
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
    public partial class ScenarioRunProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ScenarioRunProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ScenarioRunProperties>
    {
        internal ScenarioRunProperties() { }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ScenarioErrors Errors { get { throw null; } }
        public string ManagedIdentityPrincipalId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ScenarioRunResource> Resources { get { throw null; } }
        public string ScenarioConfigurationName { get { throw null; } }
        public string ScenarioName { get { throw null; } }
        public string ScenarioRunJson { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ScenarioRunSummaryAction> ScenarioRunSummary { get { throw null; } }
        public System.DateTimeOffset StartedOn { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ScenarioRunState State { get { throw null; } }
        public string WorkspaceName { get { throw null; } }
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
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunState Failed { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunState Generating { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunState Resolving { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunState Running { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunState Starting { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ScenarioRunState Validating { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ScenarioRunResource> Resources { get { throw null; } }
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
    public partial class ValidationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.ValidationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.ValidationProperties>
    {
        internal ValidationProperties() { }
        public System.DateTimeOffset CompletedOn { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ScenarioErrors Errors { get { throw null; } }
        public string ExecutionPlanJson { get { throw null; } }
        public System.DateTimeOffset StartedOn { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ScenarioValidationState State { get { throw null; } }
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
    public partial class WorkspaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Chaos.Models.WorkspaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Chaos.Models.WorkspaceProperties>
    {
        public WorkspaceProperties(System.Collections.Generic.IEnumerable<string> scopes) { }
        public Azure.ResourceManager.Chaos.Models.ChaosProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
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
}
