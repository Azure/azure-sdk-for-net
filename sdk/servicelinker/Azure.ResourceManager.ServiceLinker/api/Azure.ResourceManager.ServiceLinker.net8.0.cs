namespace Azure.ResourceManager.ServiceLinker
{
    public partial class AzureResourceManagerServiceLinkerContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerServiceLinkerContext() { }
        public static Azure.ResourceManager.ServiceLinker.AzureResourceManagerServiceLinkerContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ConnectorDryrunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource>, System.Collections.IEnumerable
    {
        protected ConnectorDryrunCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dryrunName, Azure.ResourceManager.ServiceLinker.LinkerDryrunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dryrunName, Azure.ResourceManager.ServiceLinker.LinkerDryrunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource> Get(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource>> GetAsync(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource> GetIfExists(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource>> GetIfExistsAsync(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConnectorDryrunResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.LinkerDryrunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerDryrunData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConnectorDryrunResource() { }
        public virtual Azure.ResourceManager.ServiceLinker.LinkerDryrunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string location, string dryrunName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ServiceLinker.LinkerDryrunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.LinkerDryrunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.LinkerDryrunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.LinkerDryrunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerDryrunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerDryrunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerDryrunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceLinker.Models.DryrunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceLinker.Models.DryrunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LinkerConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceLinker.LinkerConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceLinker.LinkerConnectorResource>, System.Collections.IEnumerable
    {
        protected LinkerConnectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.LinkerConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.ServiceLinker.LinkerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.LinkerConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.ServiceLinker.LinkerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerConnectorResource> Get(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceLinker.LinkerConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceLinker.LinkerConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerConnectorResource>> GetAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ServiceLinker.LinkerConnectorResource> GetIfExists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ServiceLinker.LinkerConnectorResource>> GetIfExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceLinker.LinkerConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceLinker.LinkerConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceLinker.LinkerConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceLinker.LinkerConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LinkerConnectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.LinkerResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LinkerConnectorResource() { }
        public virtual Azure.ResourceManager.ServiceLinker.LinkerResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string location, string connectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceLinker.Models.SourceConfigurationResult> GenerateConfigurations(Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationInfo content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.Models.SourceConfigurationResult>> GenerateConfigurationsAsync(Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationInfo content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ServiceLinker.LinkerResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.LinkerResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.LinkerResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.LinkerResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.LinkerConnectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceLinker.Models.LinkerResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.LinkerConnectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceLinker.Models.LinkerResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.Models.LinkerValidateOperationResult> Validate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.Models.LinkerValidateOperationResult>> ValidateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LinkerDryrunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceLinker.LinkerDryrunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceLinker.LinkerDryrunResource>, System.Collections.IEnumerable
    {
        protected LinkerDryrunCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.LinkerDryrunResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dryrunName, Azure.ResourceManager.ServiceLinker.LinkerDryrunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.LinkerDryrunResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dryrunName, Azure.ResourceManager.ServiceLinker.LinkerDryrunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerDryrunResource> Get(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceLinker.LinkerDryrunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceLinker.LinkerDryrunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerDryrunResource>> GetAsync(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ServiceLinker.LinkerDryrunResource> GetIfExists(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ServiceLinker.LinkerDryrunResource>> GetIfExistsAsync(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceLinker.LinkerDryrunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceLinker.LinkerDryrunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceLinker.LinkerDryrunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceLinker.LinkerDryrunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LinkerDryrunData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.LinkerDryrunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerDryrunData>
    {
        public LinkerDryrunData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ServiceLinker.Models.DryrunOperationPreview> OperationPreviews { get { throw null; } }
        public Azure.ResourceManager.ServiceLinker.Models.DryrunContent Parameters { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ServiceLinker.Models.DryrunPrerequisiteResult> PrerequisiteResults { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.LinkerDryrunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.LinkerDryrunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.LinkerDryrunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.LinkerDryrunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerDryrunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerDryrunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerDryrunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LinkerDryrunResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.LinkerDryrunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerDryrunData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LinkerDryrunResource() { }
        public virtual Azure.ResourceManager.ServiceLinker.LinkerDryrunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string dryrunName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerDryrunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerDryrunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ServiceLinker.LinkerDryrunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.LinkerDryrunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.LinkerDryrunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.LinkerDryrunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerDryrunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerDryrunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerDryrunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.LinkerDryrunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceLinker.Models.DryrunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.LinkerDryrunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceLinker.Models.DryrunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LinkerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.LinkerResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LinkerResource() { }
        public virtual Azure.ResourceManager.ServiceLinker.LinkerResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string linkerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceLinker.Models.SourceConfigurationResult> GenerateConfigurations(Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationInfo content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.Models.SourceConfigurationResult>> GenerateConfigurationsAsync(Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationInfo content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceLinker.Models.SourceConfigurationResult> GetConfigurations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.Models.SourceConfigurationResult>> GetConfigurationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ServiceLinker.LinkerResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.LinkerResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.LinkerResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.LinkerResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.LinkerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceLinker.Models.LinkerResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.LinkerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceLinker.Models.LinkerResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.Models.LinkerValidateOperationResult> Validate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.Models.LinkerValidateOperationResult>> ValidateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LinkerResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceLinker.LinkerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceLinker.LinkerResource>, System.Collections.IEnumerable
    {
        protected LinkerResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.LinkerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string linkerName, Azure.ResourceManager.ServiceLinker.LinkerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.LinkerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string linkerName, Azure.ResourceManager.ServiceLinker.LinkerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource> Get(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceLinker.LinkerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceLinker.LinkerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource>> GetAsync(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ServiceLinker.LinkerResource> GetIfExists(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ServiceLinker.LinkerResource>> GetIfExistsAsync(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceLinker.LinkerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceLinker.LinkerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceLinker.LinkerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceLinker.LinkerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LinkerResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.LinkerResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerResourceData>
    {
        public LinkerResourceData() { }
        public Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo AuthInfo { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerClientType? ClientType { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationInfo ConfigurationInfo { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public string KeyVaultSecretName { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerPublicNetworkSolution PublicNetworkSolution { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SecretStoreKeyVaultId { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType? SolutionType { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo TargetService { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.LinkerResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.LinkerResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.LinkerResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.LinkerResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.LinkerResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ServiceLinkerExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationNameItem> GetAll(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationNameItem> GetAllAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource> GetConnectorDryrun(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string location, string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource>> GetConnectorDryrunAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string location, string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource GetConnectorDryrunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.ConnectorDryrunCollection GetConnectorDryruns(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string location) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceLinker.Models.DaprConfiguration> GetDaprConfigurations(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceLinker.Models.DaprConfiguration> GetDaprConfigurationsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerConnectorResource> GetLinkerConnector(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string location, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerConnectorResource>> GetLinkerConnectorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string location, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.LinkerConnectorResource GetLinkerConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.LinkerConnectorCollection GetLinkerConnectors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerDryrunResource> GetLinkerDryrun(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerDryrunResource>> GetLinkerDryrunAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.LinkerDryrunResource GetLinkerDryrunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.LinkerDryrunCollection GetLinkerDryruns(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.LinkerResource GetLinkerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource> GetLinkerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource> GetLinkerResource(this Azure.ResourceManager.ArmResource armResource, string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource>> GetLinkerResourceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource>> GetLinkerResourceAsync(this Azure.ResourceManager.ArmResource armResource, string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.LinkerResourceCollection GetLinkerResources(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.LinkerResourceCollection GetLinkerResources(this Azure.ResourceManager.ArmResource armResource) { throw null; }
    }
}
namespace Azure.ResourceManager.ServiceLinker.Mocking
{
    public partial class MockableServiceLinkerArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableServiceLinkerArmClient() { }
        public virtual Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource GetConnectorDryrunResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceLinker.Models.DaprConfiguration> GetDaprConfigurations(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceLinker.Models.DaprConfiguration> GetDaprConfigurationsAsync(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceLinker.LinkerConnectorResource GetLinkerConnectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerDryrunResource> GetLinkerDryrun(Azure.Core.ResourceIdentifier scope, string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerDryrunResource>> GetLinkerDryrunAsync(Azure.Core.ResourceIdentifier scope, string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceLinker.LinkerDryrunResource GetLinkerDryrunResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ServiceLinker.LinkerDryrunCollection GetLinkerDryruns(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.ServiceLinker.LinkerResource GetLinkerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource> GetLinkerResource(Azure.Core.ResourceIdentifier scope, string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource>> GetLinkerResourceAsync(Azure.Core.ResourceIdentifier scope, string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceLinker.LinkerResourceCollection GetLinkerResources(Azure.Core.ResourceIdentifier scope) { throw null; }
    }
    public partial class MockableServiceLinkerArmResource : Azure.ResourceManager.ArmResource
    {
        protected MockableServiceLinkerArmResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource> GetLinkerResource(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource>> GetLinkerResourceAsync(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceLinker.LinkerResourceCollection GetLinkerResources() { throw null; }
    }
    public partial class MockableServiceLinkerResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableServiceLinkerResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource> GetConnectorDryrun(string location, string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.ConnectorDryrunResource>> GetConnectorDryrunAsync(string location, string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceLinker.ConnectorDryrunCollection GetConnectorDryruns(string location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerConnectorResource> GetLinkerConnector(string location, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerConnectorResource>> GetLinkerConnectorAsync(string location, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceLinker.LinkerConnectorCollection GetLinkerConnectors(string location) { throw null; }
    }
    public partial class MockableServiceLinkerTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableServiceLinkerTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationNameItem> GetAll(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationNameItem> GetAllAsync(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ServiceLinker.Models
{
    public partial class AccessKeyInfoBase : Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.AccessKeyInfoBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AccessKeyInfoBase>
    {
        public AccessKeyInfoBase() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceLinker.Models.AccessKeyPermissions> Permissions { get { throw null; } }
        protected override Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.AccessKeyInfoBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.AccessKeyInfoBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.AccessKeyInfoBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.AccessKeyInfoBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AccessKeyInfoBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AccessKeyInfoBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AccessKeyInfoBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessKeyPermissions : System.IEquatable<Azure.ResourceManager.ServiceLinker.Models.AccessKeyPermissions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessKeyPermissions(string value) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.AccessKeyPermissions Listen { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.AccessKeyPermissions Manage { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.AccessKeyPermissions Read { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.AccessKeyPermissions Send { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.AccessKeyPermissions Write { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceLinker.Models.AccessKeyPermissions other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceLinker.Models.AccessKeyPermissions left, Azure.ResourceManager.ServiceLinker.Models.AccessKeyPermissions right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.AccessKeyPermissions (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.AccessKeyPermissions? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceLinker.Models.AccessKeyPermissions left, Azure.ResourceManager.ServiceLinker.Models.AccessKeyPermissions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmServiceLinkerModelFactory
    {
        public static Azure.ResourceManager.ServiceLinker.Models.AccessKeyInfoBase AccessKeyInfoBase(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode? authMode = default(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceLinker.Models.AccessKeyPermissions> permissions = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo AuthBaseInfo(string authType = null, Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode? authMode = default(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode?)) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.AzureAppConfigProperties AzureAppConfigProperties(bool? isConnectedWithKubernetesExtension = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.AzureKeyVaultProperties AzureKeyVaultProperties(bool? doesConnectAsKubernetesCsiDriver = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.AzureResourceBaseProperties AzureResourceBaseProperties(string type = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.AzureResourceInfo AzureResourceInfo(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.ServiceLinker.Models.AzureResourceBaseProperties resourceProperties = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.BasicErrorDryrunPrerequisiteResult BasicErrorDryrunPrerequisiteResult(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.ConfluentBootstrapServerInfo ConfluentBootstrapServerInfo(string endpoint = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.ConfluentSchemaRegistryInfo ConfluentSchemaRegistryInfo(string endpoint = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.CreateOrUpdateDryrunContent CreateOrUpdateDryrunContent(Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo targetService = null, Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo authInfo = null, Azure.ResourceManager.ServiceLinker.Models.LinkerClientType? clientType = default(Azure.ResourceManager.ServiceLinker.Models.LinkerClientType?), string provisioningState = null, Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType? solutionType = default(Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType?), Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior? deleteOrUpdateBehavior = default(Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior?), Azure.Core.ResourceIdentifier secretStoreKeyVaultId = null, string keyVaultSecretName = null, string scope = null, Azure.ResourceManager.ServiceLinker.Models.LinkerPublicNetworkSolution publicNetworkSolution = null, Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationInfo configurationInfo = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.DaprConfiguration DaprConfiguration(string targetType = null, Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType? authType = default(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType?), Azure.ResourceManager.ServiceLinker.Models.DaprProperties daprProperties = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.DaprMetadata DaprMetadata(string name = null, string value = null, string secretRef = null, string description = null, Azure.ResourceManager.ServiceLinker.Models.DaprMetadataRequired? required = default(Azure.ResourceManager.ServiceLinker.Models.DaprMetadataRequired?)) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.DaprProperties DaprProperties(string version = null, string componentType = null, string secretStoreComponent = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceLinker.Models.DaprMetadata> metadata = null, System.Collections.Generic.IEnumerable<string> scopes = null, string runtimeVersion = null, Azure.ResourceManager.ServiceLinker.Models.DaprBindingComponentDirection? bindingComponentDirection = default(Azure.ResourceManager.ServiceLinker.Models.DaprBindingComponentDirection?)) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.DryrunContent DryrunContent(string actionName = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.DryrunOperationPreview DryrunOperationPreview(string name = null, Azure.ResourceManager.ServiceLinker.Models.DryrunPreviewOperationType? operationType = default(Azure.ResourceManager.ServiceLinker.Models.DryrunPreviewOperationType?), string description = null, string action = null, string scope = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.DryrunPatch DryrunPatch(Azure.ResourceManager.ServiceLinker.Models.DryrunContent parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceLinker.Models.DryrunPrerequisiteResult> prerequisiteResults = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceLinker.Models.DryrunOperationPreview> operationPreviews = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.DryrunPrerequisiteResult DryrunPrerequisiteResult(string type = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.EasyAuthMicrosoftEntraIdAuthInfo EasyAuthMicrosoftEntraIdAuthInfo(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode? authMode = default(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode?), string clientId = null, string secret = null, Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior? deleteOrUpdateBehavior = default(Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior?)) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.FabricPlatformTargetService FabricPlatformTargetService(string endpoint = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.KeyVaultSecretReferenceSecretInfo KeyVaultSecretReferenceSecretInfo(string name = null, string version = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.KeyVaultSecretUriSecretInfo KeyVaultSecretUriSecretInfo(string value = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationInfo LinkerConfigurationInfo(Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior? deleteOrUpdateBehavior = default(Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior?), Azure.ResourceManager.ServiceLinker.Models.LinkerActionType? action = default(Azure.ResourceManager.ServiceLinker.Models.LinkerActionType?), System.Collections.Generic.IDictionary<string, string> customizedKeys = null, Azure.ResourceManager.ServiceLinker.Models.DaprProperties daprProperties = null, System.Collections.Generic.IDictionary<string, string> additionalConfigurations = null, System.Collections.Generic.IDictionary<string, string> additionalConnectionStringProperties = null, string appConfigurationId = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationName LinkerConfigurationName(string value = null, string description = null, bool? isRequired = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationNameItem LinkerConfigurationNameItem(string targetService = null, Azure.ResourceManager.ServiceLinker.Models.LinkerClientType? clientType = default(Azure.ResourceManager.ServiceLinker.Models.LinkerClientType?), Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType? authType = default(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType?), Azure.ResourceManager.ServiceLinker.Models.LinkerSecretSourceType? secretType = default(Azure.ResourceManager.ServiceLinker.Models.LinkerSecretSourceType?), Azure.ResourceManager.ServiceLinker.Models.DaprProperties daprProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationName> names = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.LinkerDryrunData LinkerDryrunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ServiceLinker.Models.DryrunContent parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceLinker.Models.DryrunPrerequisiteResult> prerequisiteResults = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceLinker.Models.DryrunOperationPreview> operationPreviews = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerFirewallRules LinkerFirewallRules(System.Collections.Generic.IEnumerable<string> ipRanges = null, Azure.ResourceManager.ServiceLinker.Models.LinkerAllowType? azureServices = default(Azure.ResourceManager.ServiceLinker.Models.LinkerAllowType?), Azure.ResourceManager.ServiceLinker.Models.LinkerAllowType? callerClientIP = default(Azure.ResourceManager.ServiceLinker.Models.LinkerAllowType?)) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerPublicNetworkSolution LinkerPublicNetworkSolution(Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior? deleteOrUpdateBehavior = default(Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior?), Azure.ResourceManager.ServiceLinker.Models.LinkerActionType? action = default(Azure.ResourceManager.ServiceLinker.Models.LinkerActionType?), Azure.ResourceManager.ServiceLinker.Models.LinkerFirewallRules firewallRules = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.LinkerResourceData LinkerResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo targetService = null, Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo authInfo = null, Azure.ResourceManager.ServiceLinker.Models.LinkerClientType? clientType = default(Azure.ResourceManager.ServiceLinker.Models.LinkerClientType?), string provisioningState = null, Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType? solutionType = default(Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType?), Azure.Core.ResourceIdentifier secretStoreKeyVaultId = null, string scope = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.LinkerResourceData LinkerResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo targetService = null, Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo authInfo = null, Azure.ResourceManager.ServiceLinker.Models.LinkerClientType? clientType = default(Azure.ResourceManager.ServiceLinker.Models.LinkerClientType?), string provisioningState = null, string scope = null, Azure.ResourceManager.ServiceLinker.Models.LinkerPublicNetworkSolution publicNetworkSolution = null, Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationInfo configurationInfo = null, Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType? solutionType = default(Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType?), Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior? deleteOrUpdateBehavior = default(Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior?), Azure.Core.ResourceIdentifier secretStoreKeyVaultId = null, string keyVaultSecretName = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerResourcePatch LinkerResourcePatch(Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo targetService = null, Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo authInfo = null, Azure.ResourceManager.ServiceLinker.Models.LinkerClientType? clientType = default(Azure.ResourceManager.ServiceLinker.Models.LinkerClientType?), string provisioningState = null, Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType? solutionType = default(Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType?), Azure.Core.ResourceIdentifier secretStoreKeyVaultId = null, string scope = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerResourcePatch LinkerResourcePatch(Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo targetService = null, Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo authInfo = null, Azure.ResourceManager.ServiceLinker.Models.LinkerClientType? clientType = default(Azure.ResourceManager.ServiceLinker.Models.LinkerClientType?), string provisioningState = null, string scope = null, Azure.ResourceManager.ServiceLinker.Models.LinkerPublicNetworkSolution publicNetworkSolution = null, Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationInfo configurationInfo = null, Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType? solutionType = default(Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType?), Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior? deleteOrUpdateBehavior = default(Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior?), Azure.Core.ResourceIdentifier secretStoreKeyVaultId = null, string keyVaultSecretName = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerValidateOperationResult LinkerValidateOperationResult(Azure.Core.ResourceIdentifier resourceId = null, string status = null, string linkerName = null, bool? isConnectionAvailable = default(bool?), System.DateTimeOffset? reportStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? reportEndOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier sourceId = null, Azure.Core.ResourceIdentifier targetId = null, Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType? authType = default(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultItemInfo> validationDetail = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultItemInfo LinkerValidationResultItemInfo(string name = null, string description = null, Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus? result = default(Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus?), string errorMessage = null, string errorCode = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.PermissionsMissingDryrunPrerequisiteResult PermissionsMissingDryrunPrerequisiteResult(string scope = null, System.Collections.Generic.IEnumerable<string> permissions = null, string recommendedRole = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.RawValueSecretInfo RawValueSecretInfo(string value = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.SecretAuthInfo SecretAuthInfo(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode? authMode = default(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode?), string name = null, Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo secretInfo = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo SecretBaseInfo(string secretType = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.SelfHostedServerTargetService SelfHostedServerTargetService(string endpoint = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.ServicePrincipalCertificateAuthInfo ServicePrincipalCertificateAuthInfo(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode? authMode = default(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode?), string clientId = null, System.Guid principalId = default(System.Guid), string certificate = null, Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior? deleteOrUpdateBehavior = default(Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior?), System.Collections.Generic.IEnumerable<string> roles = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.ServicePrincipalSecretAuthInfo ServicePrincipalSecretAuthInfo(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode? authMode = default(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode?), string userName = null, string clientId = null, System.Guid principalId = default(System.Guid), string secret = null, Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior? deleteOrUpdateBehavior = default(Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior?), System.Collections.Generic.IEnumerable<string> roles = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.SourceConfiguration SourceConfiguration(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.SourceConfiguration SourceConfiguration(string name = null, string value = null, Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationType? configType = default(Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationType?), string keyVaultReferenceIdentity = null, string description = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.SourceConfigurationResult SourceConfigurationResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceLinker.Models.SourceConfiguration> configurations = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.SystemAssignedIdentityAuthInfo SystemAssignedIdentityAuthInfo(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode? authMode = default(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode?), string userName = null, Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior? deleteOrUpdateBehavior = default(Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior?), System.Collections.Generic.IEnumerable<string> roles = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo TargetServiceBaseInfo(string type = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.UserAccountAuthInfo UserAccountAuthInfo(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode? authMode = default(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode?), string userName = null, string principalId = null, Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior? deleteOrUpdateBehavior = default(Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior?), System.Collections.Generic.IEnumerable<string> roles = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.UserAssignedIdentityAuthInfo UserAssignedIdentityAuthInfo(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode? authMode = default(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode?), string userName = null, string clientId = null, string subscriptionId = null, Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior? deleteOrUpdateBehavior = default(Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior?), System.Collections.Generic.IEnumerable<string> roles = null) { throw null; }
    }
    public abstract partial class AuthBaseInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo>
    {
        protected AuthBaseInfo() { }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode? AuthMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAppConfigProperties : Azure.ResourceManager.ServiceLinker.Models.AzureResourceBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.AzureAppConfigProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AzureAppConfigProperties>
    {
        public AzureAppConfigProperties() { }
        public bool? IsConnectedWithKubernetesExtension { get { throw null; } set { } }
        protected override Azure.ResourceManager.ServiceLinker.Models.AzureResourceBaseProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ServiceLinker.Models.AzureResourceBaseProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.AzureAppConfigProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.AzureAppConfigProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.AzureAppConfigProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.AzureAppConfigProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AzureAppConfigProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AzureAppConfigProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AzureAppConfigProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureKeyVaultProperties : Azure.ResourceManager.ServiceLinker.Models.AzureResourceBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.AzureKeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AzureKeyVaultProperties>
    {
        public AzureKeyVaultProperties() { }
        public bool? DoesConnectAsKubernetesCsiDriver { get { throw null; } set { } }
        protected override Azure.ResourceManager.ServiceLinker.Models.AzureResourceBaseProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ServiceLinker.Models.AzureResourceBaseProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.AzureKeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.AzureKeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.AzureKeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.AzureKeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AzureKeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AzureKeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AzureKeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AzureResourceBaseProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.AzureResourceBaseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AzureResourceBaseProperties>
    {
        protected AzureResourceBaseProperties() { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.AzureResourceBaseProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.AzureResourceBaseProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.AzureResourceBaseProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.AzureResourceBaseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.AzureResourceBaseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.AzureResourceBaseProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AzureResourceBaseProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AzureResourceBaseProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AzureResourceBaseProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureResourceInfo : Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.AzureResourceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AzureResourceInfo>
    {
        public AzureResourceInfo() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.AzureResourceBaseProperties ResourceProperties { get { throw null; } set { } }
        protected override Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.AzureResourceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.AzureResourceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.AzureResourceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.AzureResourceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AzureResourceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AzureResourceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.AzureResourceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BasicErrorDryrunPrerequisiteResult : Azure.ResourceManager.ServiceLinker.Models.DryrunPrerequisiteResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.BasicErrorDryrunPrerequisiteResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.BasicErrorDryrunPrerequisiteResult>
    {
        internal BasicErrorDryrunPrerequisiteResult() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected override Azure.ResourceManager.ServiceLinker.Models.DryrunPrerequisiteResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ServiceLinker.Models.DryrunPrerequisiteResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.BasicErrorDryrunPrerequisiteResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.BasicErrorDryrunPrerequisiteResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.BasicErrorDryrunPrerequisiteResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.BasicErrorDryrunPrerequisiteResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.BasicErrorDryrunPrerequisiteResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.BasicErrorDryrunPrerequisiteResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.BasicErrorDryrunPrerequisiteResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfluentBootstrapServerInfo : Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.ConfluentBootstrapServerInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.ConfluentBootstrapServerInfo>
    {
        public ConfluentBootstrapServerInfo() { }
        public string Endpoint { get { throw null; } set { } }
        protected override Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.ConfluentBootstrapServerInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.ConfluentBootstrapServerInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.ConfluentBootstrapServerInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.ConfluentBootstrapServerInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.ConfluentBootstrapServerInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.ConfluentBootstrapServerInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.ConfluentBootstrapServerInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfluentSchemaRegistryInfo : Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.ConfluentSchemaRegistryInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.ConfluentSchemaRegistryInfo>
    {
        public ConfluentSchemaRegistryInfo() { }
        public string Endpoint { get { throw null; } set { } }
        protected override Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.ConfluentSchemaRegistryInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.ConfluentSchemaRegistryInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.ConfluentSchemaRegistryInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.ConfluentSchemaRegistryInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.ConfluentSchemaRegistryInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.ConfluentSchemaRegistryInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.ConfluentSchemaRegistryInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateOrUpdateDryrunContent : Azure.ResourceManager.ServiceLinker.Models.DryrunContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.CreateOrUpdateDryrunContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.CreateOrUpdateDryrunContent>
    {
        public CreateOrUpdateDryrunContent() { }
        public Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo AuthInfo { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerClientType? ClientType { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationInfo ConfigurationInfo { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public string KeyVaultSecretName { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerPublicNetworkSolution PublicNetworkSolution { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SecretStoreKeyVaultId { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType? SolutionType { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo TargetService { get { throw null; } set { } }
        protected override Azure.ResourceManager.ServiceLinker.Models.DryrunContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ServiceLinker.Models.DryrunContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.CreateOrUpdateDryrunContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.CreateOrUpdateDryrunContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.CreateOrUpdateDryrunContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.CreateOrUpdateDryrunContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.CreateOrUpdateDryrunContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.CreateOrUpdateDryrunContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.CreateOrUpdateDryrunContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DaprBindingComponentDirection : System.IEquatable<Azure.ResourceManager.ServiceLinker.Models.DaprBindingComponentDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DaprBindingComponentDirection(string value) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.DaprBindingComponentDirection Input { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.DaprBindingComponentDirection Output { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceLinker.Models.DaprBindingComponentDirection other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceLinker.Models.DaprBindingComponentDirection left, Azure.ResourceManager.ServiceLinker.Models.DaprBindingComponentDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.DaprBindingComponentDirection (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.DaprBindingComponentDirection? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceLinker.Models.DaprBindingComponentDirection left, Azure.ResourceManager.ServiceLinker.Models.DaprBindingComponentDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DaprConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.DaprConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DaprConfiguration>
    {
        internal DaprConfiguration() { }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType? AuthType { get { throw null; } }
        public Azure.ResourceManager.ServiceLinker.Models.DaprProperties DaprProperties { get { throw null; } }
        public string TargetType { get { throw null; } }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.DaprConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.DaprConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.DaprConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.DaprConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.DaprConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.DaprConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DaprConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DaprConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DaprConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DaprMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.DaprMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DaprMetadata>
    {
        public DaprMetadata() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.DaprMetadataRequired? Required { get { throw null; } set { } }
        public string SecretRef { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.DaprMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.DaprMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.DaprMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.DaprMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.DaprMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.DaprMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DaprMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DaprMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DaprMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DaprMetadataRequired : System.IEquatable<Azure.ResourceManager.ServiceLinker.Models.DaprMetadataRequired>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DaprMetadataRequired(string value) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.DaprMetadataRequired False { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.DaprMetadataRequired True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceLinker.Models.DaprMetadataRequired other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceLinker.Models.DaprMetadataRequired left, Azure.ResourceManager.ServiceLinker.Models.DaprMetadataRequired right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.DaprMetadataRequired (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.DaprMetadataRequired? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceLinker.Models.DaprMetadataRequired left, Azure.ResourceManager.ServiceLinker.Models.DaprMetadataRequired right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DaprProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.DaprProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DaprProperties>
    {
        public DaprProperties() { }
        public Azure.ResourceManager.ServiceLinker.Models.DaprBindingComponentDirection? BindingComponentDirection { get { throw null; } }
        public string ComponentType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceLinker.Models.DaprMetadata> Metadata { get { throw null; } }
        public string RuntimeVersion { get { throw null; } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        public string SecretStoreComponent { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.DaprProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.DaprProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.DaprProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.DaprProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.DaprProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.DaprProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DaprProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DaprProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DaprProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DryrunContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.DryrunContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DryrunContent>
    {
        internal DryrunContent() { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.DryrunContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.DryrunContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.DryrunContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.DryrunContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.DryrunContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.DryrunContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DryrunContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DryrunContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DryrunContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DryrunOperationPreview : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.DryrunOperationPreview>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DryrunOperationPreview>
    {
        internal DryrunOperationPreview() { }
        public string Action { get { throw null; } }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ServiceLinker.Models.DryrunPreviewOperationType? OperationType { get { throw null; } }
        public string Scope { get { throw null; } }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.DryrunOperationPreview JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.DryrunOperationPreview PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.DryrunOperationPreview System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.DryrunOperationPreview>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.DryrunOperationPreview>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.DryrunOperationPreview System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DryrunOperationPreview>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DryrunOperationPreview>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DryrunOperationPreview>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DryrunPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.DryrunPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DryrunPatch>
    {
        public DryrunPatch() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ServiceLinker.Models.DryrunOperationPreview> OperationPreviews { get { throw null; } }
        public Azure.ResourceManager.ServiceLinker.Models.DryrunContent Parameters { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ServiceLinker.Models.DryrunPrerequisiteResult> PrerequisiteResults { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.DryrunPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.DryrunPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.DryrunPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.DryrunPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.DryrunPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.DryrunPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DryrunPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DryrunPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DryrunPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DryrunPrerequisiteResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.DryrunPrerequisiteResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DryrunPrerequisiteResult>
    {
        internal DryrunPrerequisiteResult() { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.DryrunPrerequisiteResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.DryrunPrerequisiteResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.DryrunPrerequisiteResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.DryrunPrerequisiteResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.DryrunPrerequisiteResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.DryrunPrerequisiteResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DryrunPrerequisiteResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DryrunPrerequisiteResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.DryrunPrerequisiteResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DryrunPreviewOperationType : System.IEquatable<Azure.ResourceManager.ServiceLinker.Models.DryrunPreviewOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DryrunPreviewOperationType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.DryrunPreviewOperationType ConfigAuth { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.DryrunPreviewOperationType ConfigConnection { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.DryrunPreviewOperationType ConfigNetwork { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceLinker.Models.DryrunPreviewOperationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceLinker.Models.DryrunPreviewOperationType left, Azure.ResourceManager.ServiceLinker.Models.DryrunPreviewOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.DryrunPreviewOperationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.DryrunPreviewOperationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceLinker.Models.DryrunPreviewOperationType left, Azure.ResourceManager.ServiceLinker.Models.DryrunPreviewOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EasyAuthMicrosoftEntraIdAuthInfo : Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.EasyAuthMicrosoftEntraIdAuthInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.EasyAuthMicrosoftEntraIdAuthInfo>
    {
        public EasyAuthMicrosoftEntraIdAuthInfo() { }
        public string ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public string Secret { get { throw null; } set { } }
        protected override Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.EasyAuthMicrosoftEntraIdAuthInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.EasyAuthMicrosoftEntraIdAuthInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.EasyAuthMicrosoftEntraIdAuthInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.EasyAuthMicrosoftEntraIdAuthInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.EasyAuthMicrosoftEntraIdAuthInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.EasyAuthMicrosoftEntraIdAuthInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.EasyAuthMicrosoftEntraIdAuthInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FabricPlatformTargetService : Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.FabricPlatformTargetService>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.FabricPlatformTargetService>
    {
        public FabricPlatformTargetService() { }
        public string Endpoint { get { throw null; } set { } }
        protected override Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.FabricPlatformTargetService System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.FabricPlatformTargetService>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.FabricPlatformTargetService>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.FabricPlatformTargetService System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.FabricPlatformTargetService>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.FabricPlatformTargetService>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.FabricPlatformTargetService>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultSecretReferenceSecretInfo : Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.KeyVaultSecretReferenceSecretInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.KeyVaultSecretReferenceSecretInfo>
    {
        public KeyVaultSecretReferenceSecretInfo() { }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected override Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.KeyVaultSecretReferenceSecretInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.KeyVaultSecretReferenceSecretInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.KeyVaultSecretReferenceSecretInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.KeyVaultSecretReferenceSecretInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.KeyVaultSecretReferenceSecretInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.KeyVaultSecretReferenceSecretInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.KeyVaultSecretReferenceSecretInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultSecretUriSecretInfo : Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.KeyVaultSecretUriSecretInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.KeyVaultSecretUriSecretInfo>
    {
        public KeyVaultSecretUriSecretInfo() { }
        public string Value { get { throw null; } set { } }
        protected override Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.KeyVaultSecretUriSecretInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.KeyVaultSecretUriSecretInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.KeyVaultSecretUriSecretInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.KeyVaultSecretUriSecretInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.KeyVaultSecretUriSecretInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.KeyVaultSecretUriSecretInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.KeyVaultSecretUriSecretInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkerActionType : System.IEquatable<Azure.ResourceManager.ServiceLinker.Models.LinkerActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkerActionType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerActionType Enable { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerActionType OptOut { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceLinker.Models.LinkerActionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceLinker.Models.LinkerActionType left, Azure.ResourceManager.ServiceLinker.Models.LinkerActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.LinkerActionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.LinkerActionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceLinker.Models.LinkerActionType left, Azure.ResourceManager.ServiceLinker.Models.LinkerActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkerAllowType : System.IEquatable<Azure.ResourceManager.ServiceLinker.Models.LinkerAllowType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkerAllowType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerAllowType False { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerAllowType True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceLinker.Models.LinkerAllowType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceLinker.Models.LinkerAllowType left, Azure.ResourceManager.ServiceLinker.Models.LinkerAllowType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.LinkerAllowType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.LinkerAllowType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceLinker.Models.LinkerAllowType left, Azure.ResourceManager.ServiceLinker.Models.LinkerAllowType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkerAuthMode : System.IEquatable<Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkerAuthMode(string value) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode OptInAllAuth { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode OptOutAllAuth { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode left, Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode left, Azure.ResourceManager.ServiceLinker.Models.LinkerAuthMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkerAuthType : System.IEquatable<Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkerAuthType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType AccessKey { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType EasyAuthMicrosoftEntraID { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType Secret { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType ServicePrincipalCertificate { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType ServicePrincipalSecret { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType SystemAssignedIdentity { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType UserAccount { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType UserAssignedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType left, Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType left, Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkerClientType : System.IEquatable<Azure.ResourceManager.ServiceLinker.Models.LinkerClientType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkerClientType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerClientType Dapr { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerClientType Django { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerClientType Dotnet { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerClientType Go { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerClientType Java { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerClientType JmsSpringBoot { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerClientType KafkaSpringBoot { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerClientType Nodejs { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerClientType None { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerClientType Php { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerClientType Python { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerClientType Ruby { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerClientType SpringBoot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceLinker.Models.LinkerClientType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceLinker.Models.LinkerClientType left, Azure.ResourceManager.ServiceLinker.Models.LinkerClientType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.LinkerClientType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.LinkerClientType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceLinker.Models.LinkerClientType left, Azure.ResourceManager.ServiceLinker.Models.LinkerClientType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinkerConfigurationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationInfo>
    {
        public LinkerConfigurationInfo() { }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerActionType? Action { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> AdditionalConfigurations { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> AdditionalConnectionStringProperties { get { throw null; } }
        public string AppConfigurationId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> CustomizedKeys { get { throw null; } }
        public Azure.ResourceManager.ServiceLinker.Models.DaprProperties DaprProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LinkerConfigurationName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationName>
    {
        internal LinkerConfigurationName() { }
        public string Description { get { throw null; } }
        public bool? IsRequired { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationName JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationName PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LinkerConfigurationNameItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationNameItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationNameItem>
    {
        internal LinkerConfigurationNameItem() { }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType? AuthType { get { throw null; } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerClientType? ClientType { get { throw null; } }
        public Azure.ResourceManager.ServiceLinker.Models.DaprProperties DaprProperties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationName> Names { get { throw null; } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerSecretSourceType? SecretType { get { throw null; } }
        public string TargetService { get { throw null; } }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationNameItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationNameItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationNameItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationNameItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationNameItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationNameItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationNameItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationNameItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationNameItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkerConfigurationType : System.IEquatable<Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkerConfigurationType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationType Default { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationType KeyVaultSecret { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationType left, Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationType left, Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkerDeleteOrUpdateBehavior : System.IEquatable<Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkerDeleteOrUpdateBehavior(string value) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior Default { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior ForcedCleanup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior left, Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior left, Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinkerFirewallRules : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerFirewallRules>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerFirewallRules>
    {
        public LinkerFirewallRules() { }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerAllowType? AzureServices { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerAllowType? CallerClientIP { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> IPRanges { get { throw null; } }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.LinkerFirewallRules JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.LinkerFirewallRules PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.LinkerFirewallRules System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerFirewallRules>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerFirewallRules>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.LinkerFirewallRules System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerFirewallRules>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerFirewallRules>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerFirewallRules>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LinkerPublicNetworkSolution : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerPublicNetworkSolution>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerPublicNetworkSolution>
    {
        public LinkerPublicNetworkSolution() { }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerActionType? Action { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerFirewallRules FirewallRules { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.LinkerPublicNetworkSolution JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.LinkerPublicNetworkSolution PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.LinkerPublicNetworkSolution System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerPublicNetworkSolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerPublicNetworkSolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.LinkerPublicNetworkSolution System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerPublicNetworkSolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerPublicNetworkSolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerPublicNetworkSolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LinkerResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerResourcePatch>
    {
        public LinkerResourcePatch() { }
        public Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo AuthInfo { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerClientType? ClientType { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationInfo ConfigurationInfo { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public string KeyVaultSecretName { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerPublicNetworkSolution PublicNetworkSolution { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SecretStoreKeyVaultId { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType? SolutionType { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo TargetService { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.LinkerResourcePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.LinkerResourcePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.LinkerResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.LinkerResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkerSecretSourceType : System.IEquatable<Azure.ResourceManager.ServiceLinker.Models.LinkerSecretSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkerSecretSourceType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerSecretSourceType KeyVaultSecret { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerSecretSourceType RawValue { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceLinker.Models.LinkerSecretSourceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceLinker.Models.LinkerSecretSourceType left, Azure.ResourceManager.ServiceLinker.Models.LinkerSecretSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.LinkerSecretSourceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.LinkerSecretSourceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceLinker.Models.LinkerSecretSourceType left, Azure.ResourceManager.ServiceLinker.Models.LinkerSecretSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinkerValidateOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerValidateOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerValidateOperationResult>
    {
        internal LinkerValidateOperationResult() { }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType? AuthType { get { throw null; } }
        public bool? IsConnectionAvailable { get { throw null; } }
        public string LinkerName { get { throw null; } }
        public System.DateTimeOffset? ReportEndOn { get { throw null; } }
        public System.DateTimeOffset? ReportStartOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceId { get { throw null; } }
        public string Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultItemInfo> ValidationDetail { get { throw null; } }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.LinkerValidateOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.LinkerValidateOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.LinkerValidateOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerValidateOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerValidateOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.LinkerValidateOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerValidateOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerValidateOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerValidateOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LinkerValidationResultItemInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultItemInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultItemInfo>
    {
        internal LinkerValidationResultItemInfo() { }
        public string Description { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus? Result { get { throw null; } }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultItemInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultItemInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultItemInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultItemInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultItemInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultItemInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultItemInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultItemInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultItemInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkerValidationResultStatus : System.IEquatable<Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkerValidationResultStatus(string value) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus Failure { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus Success { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus left, Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus left, Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PermissionsMissingDryrunPrerequisiteResult : Azure.ResourceManager.ServiceLinker.Models.DryrunPrerequisiteResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.PermissionsMissingDryrunPrerequisiteResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.PermissionsMissingDryrunPrerequisiteResult>
    {
        internal PermissionsMissingDryrunPrerequisiteResult() { }
        public System.Collections.Generic.IList<string> Permissions { get { throw null; } }
        public string RecommendedRole { get { throw null; } }
        public string Scope { get { throw null; } }
        protected override Azure.ResourceManager.ServiceLinker.Models.DryrunPrerequisiteResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ServiceLinker.Models.DryrunPrerequisiteResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.PermissionsMissingDryrunPrerequisiteResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.PermissionsMissingDryrunPrerequisiteResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.PermissionsMissingDryrunPrerequisiteResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.PermissionsMissingDryrunPrerequisiteResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.PermissionsMissingDryrunPrerequisiteResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.PermissionsMissingDryrunPrerequisiteResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.PermissionsMissingDryrunPrerequisiteResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RawValueSecretInfo : Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.RawValueSecretInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.RawValueSecretInfo>
    {
        public RawValueSecretInfo() { }
        public string Value { get { throw null; } set { } }
        protected override Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.RawValueSecretInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.RawValueSecretInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.RawValueSecretInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.RawValueSecretInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.RawValueSecretInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.RawValueSecretInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.RawValueSecretInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecretAuthInfo : Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.SecretAuthInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SecretAuthInfo>
    {
        public SecretAuthInfo() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo SecretInfo { get { throw null; } set { } }
        protected override Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.SecretAuthInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.SecretAuthInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.SecretAuthInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.SecretAuthInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SecretAuthInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SecretAuthInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SecretAuthInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class SecretBaseInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo>
    {
        protected SecretBaseInfo() { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SelfHostedServerTargetService : Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.SelfHostedServerTargetService>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SelfHostedServerTargetService>
    {
        public SelfHostedServerTargetService() { }
        public string Endpoint { get { throw null; } set { } }
        protected override Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.SelfHostedServerTargetService System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.SelfHostedServerTargetService>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.SelfHostedServerTargetService>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.SelfHostedServerTargetService System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SelfHostedServerTargetService>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SelfHostedServerTargetService>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SelfHostedServerTargetService>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServicePrincipalCertificateAuthInfo : Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.ServicePrincipalCertificateAuthInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.ServicePrincipalCertificateAuthInfo>
    {
        public ServicePrincipalCertificateAuthInfo(string clientId, System.Guid principalId, string certificate) { }
        public string Certificate { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public System.Guid PrincipalId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        protected override Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.ServicePrincipalCertificateAuthInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.ServicePrincipalCertificateAuthInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.ServicePrincipalCertificateAuthInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.ServicePrincipalCertificateAuthInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.ServicePrincipalCertificateAuthInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.ServicePrincipalCertificateAuthInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.ServicePrincipalCertificateAuthInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServicePrincipalSecretAuthInfo : Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.ServicePrincipalSecretAuthInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.ServicePrincipalSecretAuthInfo>
    {
        public ServicePrincipalSecretAuthInfo(string clientId, System.Guid principalId, string secret) { }
        public string ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public System.Guid PrincipalId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        public string Secret { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
        protected override Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.ServicePrincipalSecretAuthInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.ServicePrincipalSecretAuthInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.ServicePrincipalSecretAuthInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.ServicePrincipalSecretAuthInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.ServicePrincipalSecretAuthInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.ServicePrincipalSecretAuthInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.ServicePrincipalSecretAuthInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SourceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.SourceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SourceConfiguration>
    {
        internal SourceConfiguration() { }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerConfigurationType? ConfigType { get { throw null; } }
        public string Description { get { throw null; } }
        public string KeyVaultReferenceIdentity { get { throw null; } }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.SourceConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.SourceConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.SourceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.SourceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.SourceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.SourceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SourceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SourceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SourceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SourceConfigurationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.SourceConfigurationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SourceConfigurationResult>
    {
        internal SourceConfigurationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ServiceLinker.Models.SourceConfiguration> Configurations { get { throw null; } }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.SourceConfigurationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.SourceConfigurationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.SourceConfigurationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.SourceConfigurationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.SourceConfigurationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.SourceConfigurationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SourceConfigurationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SourceConfigurationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SourceConfigurationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SystemAssignedIdentityAuthInfo : Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.SystemAssignedIdentityAuthInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SystemAssignedIdentityAuthInfo>
    {
        public SystemAssignedIdentityAuthInfo() { }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        public string UserName { get { throw null; } set { } }
        protected override Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.SystemAssignedIdentityAuthInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.SystemAssignedIdentityAuthInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.SystemAssignedIdentityAuthInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.SystemAssignedIdentityAuthInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SystemAssignedIdentityAuthInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SystemAssignedIdentityAuthInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.SystemAssignedIdentityAuthInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TargetServiceBaseInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo>
    {
        protected TargetServiceBaseInfo() { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserAccountAuthInfo : Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.UserAccountAuthInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.UserAccountAuthInfo>
    {
        public UserAccountAuthInfo() { }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        public string UserName { get { throw null; } set { } }
        protected override Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.UserAccountAuthInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.UserAccountAuthInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.UserAccountAuthInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.UserAccountAuthInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.UserAccountAuthInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.UserAccountAuthInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.UserAccountAuthInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserAssignedIdentityAuthInfo : Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.UserAssignedIdentityAuthInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.UserAssignedIdentityAuthInfo>
    {
        public UserAssignedIdentityAuthInfo() { }
        public string ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerDeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        public string SubscriptionId { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
        protected override Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceLinker.Models.UserAssignedIdentityAuthInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.UserAssignedIdentityAuthInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceLinker.Models.UserAssignedIdentityAuthInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceLinker.Models.UserAssignedIdentityAuthInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.UserAssignedIdentityAuthInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.UserAssignedIdentityAuthInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceLinker.Models.UserAssignedIdentityAuthInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VnetSolutionType : System.IEquatable<Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VnetSolutionType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType PrivateLink { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType ServiceEndpoint { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType left, Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType left, Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
