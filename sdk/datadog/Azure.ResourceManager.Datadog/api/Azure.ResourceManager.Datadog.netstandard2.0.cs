namespace Azure.ResourceManager.Datadog
{
    public partial class AzureResourceManagerDatadogContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDatadogContext() { }
        public static Azure.ResourceManager.Datadog.AzureResourceManagerDatadogContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class DatadogExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.Datadog.Models.ConfigurationNameItem> GetConfigurationNames(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.ConfigurationNameItem> GetConfigurationNamesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Datadog.Models.DaprConfigurationResource> GetDaprConfigurationsLinkers(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.DaprConfigurationResource> GetDaprConfigurationsLinkersAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Datadog.DryrunResource> GetDryrun(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DryrunResource>> GetDryrunAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Datadog.DryrunResource GetDryrunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Datadog.DryrunCollection GetDryruns(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Datadog.LinkerResource> GetLinker(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.LinkerResource>> GetLinkerAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Datadog.LinkerResource GetLinkerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Datadog.LinkerCollection GetLinkers(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Datadog.LocationConnectorResource> GetLocationConnector(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.LocationConnectorResource>> GetLocationConnectorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Datadog.LocationConnectorResource GetLocationConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Datadog.LocationConnectorCollection GetLocationConnectors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Datadog.LocationDryrunResource> GetLocationDryrun(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.LocationDryrunResource>> GetLocationDryrunAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Datadog.LocationDryrunResource GetLocationDryrunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Datadog.LocationDryrunCollection GetLocationDryruns(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location) { throw null; }
    }
    public partial class DryrunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Datadog.DryrunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.DryrunResource>, System.Collections.IEnumerable
    {
        protected DryrunCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DryrunResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dryrunName, Azure.ResourceManager.Datadog.DryrunResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DryrunResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dryrunName, Azure.ResourceManager.Datadog.DryrunResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DryrunResource> Get(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.DryrunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.DryrunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DryrunResource>> GetAsync(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Datadog.DryrunResource> GetIfExists(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Datadog.DryrunResource>> GetIfExistsAsync(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Datadog.DryrunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Datadog.DryrunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Datadog.DryrunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.DryrunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DryrunResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DryrunResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DryrunResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DryrunResource() { }
        public virtual Azure.ResourceManager.Datadog.DryrunResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string dryrunName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DryrunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DryrunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Datadog.DryrunResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DryrunResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DryrunResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.DryrunResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DryrunResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DryrunResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DryrunResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DryrunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.Models.DryrunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DryrunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.Models.DryrunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DryrunResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DryrunResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DryrunResourceData>
    {
        public DryrunResourceData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Datadog.Models.DryrunOperationPreview> OperationPreviews { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.DatadogDryrunParametersContent Parameters { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Datadog.Models.DryrunPrerequisiteResult> PrerequisiteResults { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.DryrunResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DryrunResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DryrunResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.DryrunResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DryrunResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DryrunResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DryrunResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LinkerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Datadog.LinkerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.LinkerResource>, System.Collections.IEnumerable
    {
        protected LinkerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.LinkerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string linkerName, Azure.ResourceManager.Datadog.LinkerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.LinkerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string linkerName, Azure.ResourceManager.Datadog.LinkerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.LinkerResource> Get(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.LinkerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.LinkerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.LinkerResource>> GetAsync(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Datadog.LinkerResource> GetIfExists(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Datadog.LinkerResource>> GetIfExistsAsync(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Datadog.LinkerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Datadog.LinkerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Datadog.LinkerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.LinkerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LinkerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.LinkerResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.LinkerResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LinkerResource() { }
        public virtual Azure.ResourceManager.Datadog.LinkerResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string linkerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.Models.ConfigurationResult> GenerateConfigurations(Azure.ResourceManager.Datadog.Models.ConfigurationInfo info = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.Models.ConfigurationResult>> GenerateConfigurationsAsync(Azure.ResourceManager.Datadog.Models.ConfigurationInfo info = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.LinkerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.LinkerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.Models.ConfigurationResult> GetConfigurations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.Models.ConfigurationResult>> GetConfigurationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Datadog.LinkerResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.LinkerResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.LinkerResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.LinkerResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.LinkerResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.LinkerResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.LinkerResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.LinkerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.Models.LinkerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.LinkerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.Models.LinkerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.Models.ValidateOperationResult> Validate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.Models.ValidateOperationResult>> ValidateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LinkerResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.LinkerResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.LinkerResourceData>
    {
        public LinkerResourceData() { }
        public Azure.ResourceManager.Datadog.Models.AuthInfoBase AuthInfo { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.ClientType? ClientType { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.ConfigurationInfo ConfigurationInfo { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.PublicNetworkSolution PublicNetworkSolution { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.SecretStore SecretStore { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.TargetServiceBase TargetService { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.VNetSolution VNetSolution { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.LinkerResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.LinkerResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.LinkerResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.LinkerResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.LinkerResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.LinkerResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.LinkerResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LocationConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Datadog.LocationConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.LocationConnectorResource>, System.Collections.IEnumerable
    {
        protected LocationConnectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.LocationConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.Datadog.LinkerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.LocationConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.Datadog.LinkerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.LocationConnectorResource> Get(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.LocationConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.LocationConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.LocationConnectorResource>> GetAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Datadog.LocationConnectorResource> GetIfExists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Datadog.LocationConnectorResource>> GetIfExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Datadog.LocationConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Datadog.LocationConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Datadog.LocationConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.LocationConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LocationConnectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.LinkerResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.LinkerResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LocationConnectorResource() { }
        public virtual Azure.ResourceManager.Datadog.LinkerResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, Azure.Core.AzureLocation location, string connectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.Models.ConfigurationResult> GenerateConfigurations(Azure.ResourceManager.Datadog.Models.ConfigurationInfo info = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.Models.ConfigurationResult>> GenerateConfigurationsAsync(Azure.ResourceManager.Datadog.Models.ConfigurationInfo info = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.LocationConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.LocationConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Datadog.LinkerResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.LinkerResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.LinkerResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.LinkerResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.LinkerResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.LinkerResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.LinkerResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.LocationConnectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.Models.LinkerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.LocationConnectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.Models.LinkerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.Models.ValidateOperationResult> Validate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.Models.ValidateOperationResult>> ValidateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LocationDryrunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Datadog.LocationDryrunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.LocationDryrunResource>, System.Collections.IEnumerable
    {
        protected LocationDryrunCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.LocationDryrunResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dryrunName, Azure.ResourceManager.Datadog.DryrunResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.LocationDryrunResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dryrunName, Azure.ResourceManager.Datadog.DryrunResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.LocationDryrunResource> Get(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.LocationDryrunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.LocationDryrunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.LocationDryrunResource>> GetAsync(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Datadog.LocationDryrunResource> GetIfExists(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Datadog.LocationDryrunResource>> GetIfExistsAsync(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Datadog.LocationDryrunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Datadog.LocationDryrunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Datadog.LocationDryrunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.LocationDryrunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LocationDryrunResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DryrunResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DryrunResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LocationDryrunResource() { }
        public virtual Azure.ResourceManager.Datadog.DryrunResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, Azure.Core.AzureLocation location, string dryrunName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.LocationDryrunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.LocationDryrunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Datadog.DryrunResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DryrunResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DryrunResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.DryrunResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DryrunResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DryrunResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DryrunResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.LocationDryrunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.Models.DryrunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.LocationDryrunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.Models.DryrunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Datadog.Mocking
{
    public partial class MockableDatadogArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDatadogArmClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.Models.DaprConfigurationResource> GetDaprConfigurationsLinkers(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.DaprConfigurationResource> GetDaprConfigurationsLinkersAsync(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DryrunResource> GetDryrun(Azure.Core.ResourceIdentifier scope, string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DryrunResource>> GetDryrunAsync(Azure.Core.ResourceIdentifier scope, string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Datadog.DryrunResource GetDryrunResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Datadog.DryrunCollection GetDryruns(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.LinkerResource> GetLinker(Azure.Core.ResourceIdentifier scope, string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.LinkerResource>> GetLinkerAsync(Azure.Core.ResourceIdentifier scope, string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Datadog.LinkerResource GetLinkerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Datadog.LinkerCollection GetLinkers(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Datadog.LocationConnectorResource GetLocationConnectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Datadog.LocationDryrunResource GetLocationDryrunResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDatadogResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDatadogResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.LocationConnectorResource> GetLocationConnector(Azure.Core.AzureLocation location, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.LocationConnectorResource>> GetLocationConnectorAsync(Azure.Core.AzureLocation location, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Datadog.LocationConnectorCollection GetLocationConnectors(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.LocationDryrunResource> GetLocationDryrun(Azure.Core.AzureLocation location, string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.LocationDryrunResource>> GetLocationDryrunAsync(Azure.Core.AzureLocation location, string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Datadog.LocationDryrunCollection GetLocationDryruns(Azure.Core.AzureLocation location) { throw null; }
    }
    public partial class MockableDatadogTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDatadogTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.Models.ConfigurationNameItem> GetConfigurationNames(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.ConfigurationNameItem> GetConfigurationNamesAsync(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Datadog.Models
{
    public partial class AccessKeyInfoBase : Azure.ResourceManager.Datadog.Models.AuthInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.AccessKeyInfoBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AccessKeyInfoBase>
    {
        public AccessKeyInfoBase() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Datadog.Models.AccessKeyPermission> Permissions { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.AccessKeyInfoBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.AccessKeyInfoBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.AccessKeyInfoBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.AccessKeyInfoBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AccessKeyInfoBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AccessKeyInfoBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AccessKeyInfoBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessKeyPermission : System.IEquatable<Azure.ResourceManager.Datadog.Models.AccessKeyPermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessKeyPermission(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.AccessKeyPermission Listen { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.AccessKeyPermission Manage { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.AccessKeyPermission Read { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.AccessKeyPermission Send { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.AccessKeyPermission Write { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.AccessKeyPermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.AccessKeyPermission left, Azure.ResourceManager.Datadog.Models.AccessKeyPermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.AccessKeyPermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.AccessKeyPermission left, Azure.ResourceManager.Datadog.Models.AccessKeyPermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionType : System.IEquatable<Azure.ResourceManager.Datadog.Models.ActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionType(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.ActionType Enable { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ActionType Internal { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ActionType OptOut { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.ActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.ActionType left, Azure.ResourceManager.Datadog.Models.ActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.ActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.ActionType left, Azure.ResourceManager.Datadog.Models.ActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllowType : System.IEquatable<Azure.ResourceManager.Datadog.Models.AllowType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllowType(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.AllowType False { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.AllowType True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.AllowType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.AllowType left, Azure.ResourceManager.Datadog.Models.AllowType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.AllowType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.AllowType left, Azure.ResourceManager.Datadog.Models.AllowType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmDatadogModelFactory
    {
        public static Azure.ResourceManager.Datadog.Models.BasicErrorDryrunPrerequisiteResult BasicErrorDryrunPrerequisiteResult(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.ConfigurationName ConfigurationName(string value = null, string description = null, bool? required = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.ConfigurationNameItem ConfigurationNameItem(string targetService = null, Azure.ResourceManager.Datadog.Models.ClientType? clientType = default(Azure.ResourceManager.Datadog.Models.ClientType?), Azure.ResourceManager.Datadog.Models.AuthType? authType = default(Azure.ResourceManager.Datadog.Models.AuthType?), Azure.ResourceManager.Datadog.Models.SecretSourceType? secretType = default(Azure.ResourceManager.Datadog.Models.SecretSourceType?), Azure.ResourceManager.Datadog.Models.DaprProperties daprProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.Models.ConfigurationName> names = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.ConfigurationResult ConfigurationResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.Models.SourceConfiguration> configurations = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DaprConfigurationResource DaprConfigurationResource(string targetType = null, Azure.ResourceManager.Datadog.Models.AuthType? authType = default(Azure.ResourceManager.Datadog.Models.AuthType?), Azure.ResourceManager.Datadog.Models.DaprProperties daprProperties = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DaprProperties DaprProperties(string version = null, string componentType = null, string secretStoreComponent = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.Models.DaprMetadata> metadata = null, System.Collections.Generic.IEnumerable<string> scopes = null, string runtimeVersion = null, Azure.ResourceManager.Datadog.Models.DaprBindingComponentDirection? bindingComponentDirection = default(Azure.ResourceManager.Datadog.Models.DaprBindingComponentDirection?)) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogCreateOrUpdateDryrunParametersContent DatadogCreateOrUpdateDryrunParametersContent(Azure.ResourceManager.Datadog.Models.TargetServiceBase targetService = null, Azure.ResourceManager.Datadog.Models.AuthInfoBase authInfo = null, Azure.ResourceManager.Datadog.Models.ClientType? clientType = default(Azure.ResourceManager.Datadog.Models.ClientType?), string provisioningState = null, Azure.ResourceManager.Datadog.Models.VNetSolution vNetSolution = null, Azure.ResourceManager.Datadog.Models.SecretStore secretStore = null, string scope = null, Azure.ResourceManager.Datadog.Models.PublicNetworkSolution publicNetworkSolution = null, Azure.ResourceManager.Datadog.Models.ConfigurationInfo configurationInfo = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DryrunOperationPreview DryrunOperationPreview(string name = null, Azure.ResourceManager.Datadog.Models.DryrunPreviewOperationType? operationType = default(Azure.ResourceManager.Datadog.Models.DryrunPreviewOperationType?), string description = null, string action = null, string scope = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DryrunPatch DryrunPatch(Azure.ResourceManager.Datadog.Models.DatadogDryrunParametersContent parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.Models.DryrunPrerequisiteResult> prerequisiteResults = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.Models.DryrunOperationPreview> operationPreviews = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.Datadog.DryrunResourceData DryrunResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Datadog.Models.DatadogDryrunParametersContent parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.Models.DryrunPrerequisiteResult> prerequisiteResults = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.Models.DryrunOperationPreview> operationPreviews = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.LinkerPatch LinkerPatch(Azure.ResourceManager.Datadog.Models.TargetServiceBase targetService = null, Azure.ResourceManager.Datadog.Models.AuthInfoBase authInfo = null, Azure.ResourceManager.Datadog.Models.ClientType? clientType = default(Azure.ResourceManager.Datadog.Models.ClientType?), string provisioningState = null, Azure.ResourceManager.Datadog.Models.VNetSolution vNetSolution = null, Azure.ResourceManager.Datadog.Models.SecretStore secretStore = null, string scope = null, Azure.ResourceManager.Datadog.Models.PublicNetworkSolution publicNetworkSolution = null, Azure.ResourceManager.Datadog.Models.ConfigurationInfo configurationInfo = null) { throw null; }
        public static Azure.ResourceManager.Datadog.LinkerResourceData LinkerResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Datadog.Models.TargetServiceBase targetService = null, Azure.ResourceManager.Datadog.Models.AuthInfoBase authInfo = null, Azure.ResourceManager.Datadog.Models.ClientType? clientType = default(Azure.ResourceManager.Datadog.Models.ClientType?), string provisioningState = null, Azure.ResourceManager.Datadog.Models.VNetSolution vNetSolution = null, Azure.ResourceManager.Datadog.Models.SecretStore secretStore = null, string scope = null, Azure.ResourceManager.Datadog.Models.PublicNetworkSolution publicNetworkSolution = null, Azure.ResourceManager.Datadog.Models.ConfigurationInfo configurationInfo = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.PermissionsMissingDryrunPrerequisiteResult PermissionsMissingDryrunPrerequisiteResult(string scope = null, System.Collections.Generic.IEnumerable<string> permissions = null, string recommendedRole = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.SourceConfiguration SourceConfiguration(string name = null, string value = null, Azure.ResourceManager.Datadog.Models.LinkerConfigurationType? configType = default(Azure.ResourceManager.Datadog.Models.LinkerConfigurationType?), string keyVaultReferenceIdentity = null, string description = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.ValidateOperationResult ValidateOperationResult(string resourceId = null, string status = null, string linkerName = null, bool? isConnectionAvailable = default(bool?), System.DateTimeOffset? reportStartTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? reportEndTimeUtc = default(System.DateTimeOffset?), string sourceId = null, string targetId = null, Azure.ResourceManager.Datadog.Models.AuthType? authType = default(Azure.ResourceManager.Datadog.Models.AuthType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.Models.ValidationResultItem> validationDetail = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.ValidationResultItem ValidationResultItem(string name = null, string description = null, Azure.ResourceManager.Datadog.Models.ValidationResultStatus? result = default(Azure.ResourceManager.Datadog.Models.ValidationResultStatus?), string errorMessage = null, string errorCode = null) { throw null; }
    }
    public abstract partial class AuthInfoBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.AuthInfoBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AuthInfoBase>
    {
        protected AuthInfoBase() { }
        public Azure.ResourceManager.Datadog.Models.AuthMode? AuthMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.AuthInfoBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.AuthInfoBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.AuthInfoBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.AuthInfoBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AuthInfoBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AuthInfoBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AuthInfoBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthMode : System.IEquatable<Azure.ResourceManager.Datadog.Models.AuthMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthMode(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.AuthMode OptInAllAuth { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.AuthMode OptOutAllAuth { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.AuthMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.AuthMode left, Azure.ResourceManager.Datadog.Models.AuthMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.AuthMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.AuthMode left, Azure.ResourceManager.Datadog.Models.AuthMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthType : System.IEquatable<Azure.ResourceManager.Datadog.Models.AuthType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthType(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.AuthType AccessKey { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.AuthType EasyAuthMicrosoftEntraId { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.AuthType Secret { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.AuthType ServicePrincipalCertificate { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.AuthType ServicePrincipalSecret { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.AuthType SystemAssignedIdentity { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.AuthType UserAccount { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.AuthType UserAssignedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.AuthType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.AuthType left, Azure.ResourceManager.Datadog.Models.AuthType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.AuthType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.AuthType left, Azure.ResourceManager.Datadog.Models.AuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureAppConfigProperties : Azure.ResourceManager.Datadog.Models.AzureResourcePropertiesBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.AzureAppConfigProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AzureAppConfigProperties>
    {
        public AzureAppConfigProperties() { }
        public bool? ConnectWithKubernetesExtension { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.AzureAppConfigProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.AzureAppConfigProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.AzureAppConfigProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.AzureAppConfigProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AzureAppConfigProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AzureAppConfigProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AzureAppConfigProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureKeyVaultProperties : Azure.ResourceManager.Datadog.Models.AzureResourcePropertiesBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.AzureKeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AzureKeyVaultProperties>
    {
        public AzureKeyVaultProperties() { }
        public bool? ConnectAsKubernetesCsiDriver { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.AzureKeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.AzureKeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.AzureKeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.AzureKeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AzureKeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AzureKeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AzureKeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureResource : Azure.ResourceManager.Datadog.Models.TargetServiceBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.AzureResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AzureResource>
    {
        public AzureResource() { }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.AzureResourcePropertiesBase ResourceProperties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.AzureResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.AzureResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.AzureResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.AzureResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AzureResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AzureResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AzureResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AzureResourcePropertiesBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.AzureResourcePropertiesBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AzureResourcePropertiesBase>
    {
        protected AzureResourcePropertiesBase() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.AzureResourcePropertiesBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.AzureResourcePropertiesBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.AzureResourcePropertiesBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.AzureResourcePropertiesBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AzureResourcePropertiesBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AzureResourcePropertiesBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.AzureResourcePropertiesBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BasicErrorDryrunPrerequisiteResult : Azure.ResourceManager.Datadog.Models.DryrunPrerequisiteResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.BasicErrorDryrunPrerequisiteResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.BasicErrorDryrunPrerequisiteResult>
    {
        internal BasicErrorDryrunPrerequisiteResult() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.BasicErrorDryrunPrerequisiteResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.BasicErrorDryrunPrerequisiteResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.BasicErrorDryrunPrerequisiteResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.BasicErrorDryrunPrerequisiteResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.BasicErrorDryrunPrerequisiteResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.BasicErrorDryrunPrerequisiteResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.BasicErrorDryrunPrerequisiteResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClientType : System.IEquatable<Azure.ResourceManager.Datadog.Models.ClientType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClientType(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.ClientType Dapr { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ClientType Django { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ClientType Dotnet { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ClientType Go { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ClientType Java { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ClientType JmsSpringBoot { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ClientType KafkaSpringBoot { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ClientType Nodejs { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ClientType None { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ClientType Php { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ClientType Python { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ClientType Ruby { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ClientType SpringBoot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.ClientType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.ClientType left, Azure.ResourceManager.Datadog.Models.ClientType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.ClientType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.ClientType left, Azure.ResourceManager.Datadog.Models.ClientType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfigurationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ConfigurationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfigurationInfo>
    {
        public ConfigurationInfo() { }
        public Azure.ResourceManager.Datadog.Models.ActionType? Action { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> AdditionalConfigurations { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> AdditionalConnectionStringProperties { get { throw null; } }
        public string AppConfigurationId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> CustomizedKeys { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.DaprProperties DaprProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.DeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ConfigurationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ConfigurationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ConfigurationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ConfigurationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfigurationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfigurationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfigurationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfigurationName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ConfigurationName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfigurationName>
    {
        internal ConfigurationName() { }
        public string Description { get { throw null; } }
        public bool? Required { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ConfigurationName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ConfigurationName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ConfigurationName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ConfigurationName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfigurationName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfigurationName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfigurationName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfigurationNameItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ConfigurationNameItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfigurationNameItem>
    {
        internal ConfigurationNameItem() { }
        public Azure.ResourceManager.Datadog.Models.AuthType? AuthType { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.ClientType? ClientType { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.DaprProperties DaprProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Datadog.Models.ConfigurationName> Names { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.SecretSourceType? SecretType { get { throw null; } }
        public string TargetService { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ConfigurationNameItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ConfigurationNameItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ConfigurationNameItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ConfigurationNameItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfigurationNameItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfigurationNameItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfigurationNameItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfigurationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ConfigurationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfigurationResult>
    {
        internal ConfigurationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Datadog.Models.SourceConfiguration> Configurations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ConfigurationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ConfigurationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ConfigurationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ConfigurationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfigurationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfigurationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfigurationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfluentBootstrapServer : Azure.ResourceManager.Datadog.Models.TargetServiceBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ConfluentBootstrapServer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfluentBootstrapServer>
    {
        public ConfluentBootstrapServer() { }
        public string Endpoint { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ConfluentBootstrapServer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ConfluentBootstrapServer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ConfluentBootstrapServer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ConfluentBootstrapServer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfluentBootstrapServer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfluentBootstrapServer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfluentBootstrapServer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfluentSchemaRegistry : Azure.ResourceManager.Datadog.Models.TargetServiceBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ConfluentSchemaRegistry>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfluentSchemaRegistry>
    {
        public ConfluentSchemaRegistry() { }
        public string Endpoint { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ConfluentSchemaRegistry System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ConfluentSchemaRegistry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ConfluentSchemaRegistry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ConfluentSchemaRegistry System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfluentSchemaRegistry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfluentSchemaRegistry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ConfluentSchemaRegistry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DaprBindingComponentDirection : System.IEquatable<Azure.ResourceManager.Datadog.Models.DaprBindingComponentDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DaprBindingComponentDirection(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DaprBindingComponentDirection Input { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DaprBindingComponentDirection Output { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.DaprBindingComponentDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.DaprBindingComponentDirection left, Azure.ResourceManager.Datadog.Models.DaprBindingComponentDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.DaprBindingComponentDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.DaprBindingComponentDirection left, Azure.ResourceManager.Datadog.Models.DaprBindingComponentDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DaprConfigurationResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DaprConfigurationResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DaprConfigurationResource>
    {
        internal DaprConfigurationResource() { }
        public Azure.ResourceManager.Datadog.Models.AuthType? AuthType { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.DaprProperties DaprProperties { get { throw null; } }
        public string TargetType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DaprConfigurationResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DaprConfigurationResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DaprConfigurationResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DaprConfigurationResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DaprConfigurationResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DaprConfigurationResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DaprConfigurationResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DaprMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DaprMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DaprMetadata>
    {
        public DaprMetadata() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.DaprMetadataRequired? Required { get { throw null; } set { } }
        public string SecretRef { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DaprMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DaprMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DaprMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DaprMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DaprMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DaprMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DaprMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DaprMetadataRequired : System.IEquatable<Azure.ResourceManager.Datadog.Models.DaprMetadataRequired>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DaprMetadataRequired(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DaprMetadataRequired False { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DaprMetadataRequired True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.DaprMetadataRequired other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.DaprMetadataRequired left, Azure.ResourceManager.Datadog.Models.DaprMetadataRequired right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.DaprMetadataRequired (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.DaprMetadataRequired left, Azure.ResourceManager.Datadog.Models.DaprMetadataRequired right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DaprProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DaprProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DaprProperties>
    {
        public DaprProperties() { }
        public Azure.ResourceManager.Datadog.Models.DaprBindingComponentDirection? BindingComponentDirection { get { throw null; } }
        public string ComponentType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Datadog.Models.DaprMetadata> Metadata { get { throw null; } }
        public string RuntimeVersion { get { throw null; } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        public string SecretStoreComponent { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DaprProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DaprProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DaprProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DaprProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DaprProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DaprProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DaprProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogCreateOrUpdateDryrunParametersContent : Azure.ResourceManager.Datadog.Models.DatadogDryrunParametersContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogCreateOrUpdateDryrunParametersContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogCreateOrUpdateDryrunParametersContent>
    {
        public DatadogCreateOrUpdateDryrunParametersContent() { }
        public Azure.ResourceManager.Datadog.Models.AuthInfoBase AuthInfo { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.ClientType? ClientType { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.ConfigurationInfo ConfigurationInfo { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.PublicNetworkSolution PublicNetworkSolution { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.SecretStore SecretStore { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.TargetServiceBase TargetService { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.VNetSolution VNetSolution { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogCreateOrUpdateDryrunParametersContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogCreateOrUpdateDryrunParametersContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogCreateOrUpdateDryrunParametersContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogCreateOrUpdateDryrunParametersContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogCreateOrUpdateDryrunParametersContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogCreateOrUpdateDryrunParametersContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogCreateOrUpdateDryrunParametersContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DatadogDryrunParametersContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogDryrunParametersContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogDryrunParametersContent>
    {
        protected DatadogDryrunParametersContent() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogDryrunParametersContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogDryrunParametersContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogDryrunParametersContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogDryrunParametersContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogDryrunParametersContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogDryrunParametersContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogDryrunParametersContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeleteOrUpdateBehavior : System.IEquatable<Azure.ResourceManager.Datadog.Models.DeleteOrUpdateBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeleteOrUpdateBehavior(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DeleteOrUpdateBehavior Default { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DeleteOrUpdateBehavior ForcedCleanup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.DeleteOrUpdateBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.DeleteOrUpdateBehavior left, Azure.ResourceManager.Datadog.Models.DeleteOrUpdateBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.DeleteOrUpdateBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.DeleteOrUpdateBehavior left, Azure.ResourceManager.Datadog.Models.DeleteOrUpdateBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DryrunOperationPreview : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DryrunOperationPreview>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DryrunOperationPreview>
    {
        internal DryrunOperationPreview() { }
        public string Action { get { throw null; } }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.DryrunPreviewOperationType? OperationType { get { throw null; } }
        public string Scope { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DryrunOperationPreview System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DryrunOperationPreview>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DryrunOperationPreview>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DryrunOperationPreview System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DryrunOperationPreview>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DryrunOperationPreview>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DryrunOperationPreview>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DryrunPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DryrunPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DryrunPatch>
    {
        public DryrunPatch() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Datadog.Models.DryrunOperationPreview> OperationPreviews { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.DatadogDryrunParametersContent Parameters { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Datadog.Models.DryrunPrerequisiteResult> PrerequisiteResults { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DryrunPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DryrunPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DryrunPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DryrunPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DryrunPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DryrunPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DryrunPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DryrunPrerequisiteResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DryrunPrerequisiteResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DryrunPrerequisiteResult>
    {
        protected DryrunPrerequisiteResult() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DryrunPrerequisiteResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DryrunPrerequisiteResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DryrunPrerequisiteResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DryrunPrerequisiteResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DryrunPrerequisiteResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DryrunPrerequisiteResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DryrunPrerequisiteResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DryrunPreviewOperationType : System.IEquatable<Azure.ResourceManager.Datadog.Models.DryrunPreviewOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DryrunPreviewOperationType(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DryrunPreviewOperationType ConfigAuth { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DryrunPreviewOperationType ConfigConnection { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DryrunPreviewOperationType ConfigNetwork { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.DryrunPreviewOperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.DryrunPreviewOperationType left, Azure.ResourceManager.Datadog.Models.DryrunPreviewOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.DryrunPreviewOperationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.DryrunPreviewOperationType left, Azure.ResourceManager.Datadog.Models.DryrunPreviewOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EasyAuthMicrosoftEntraIdAuthInfo : Azure.ResourceManager.Datadog.Models.AuthInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.EasyAuthMicrosoftEntraIdAuthInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.EasyAuthMicrosoftEntraIdAuthInfo>
    {
        public EasyAuthMicrosoftEntraIdAuthInfo() { }
        public string ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.DeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public string Secret { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.EasyAuthMicrosoftEntraIdAuthInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.EasyAuthMicrosoftEntraIdAuthInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.EasyAuthMicrosoftEntraIdAuthInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.EasyAuthMicrosoftEntraIdAuthInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.EasyAuthMicrosoftEntraIdAuthInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.EasyAuthMicrosoftEntraIdAuthInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.EasyAuthMicrosoftEntraIdAuthInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FabricPlatform : Azure.ResourceManager.Datadog.Models.TargetServiceBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.FabricPlatform>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.FabricPlatform>
    {
        public FabricPlatform() { }
        public string Endpoint { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.FabricPlatform System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.FabricPlatform>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.FabricPlatform>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.FabricPlatform System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.FabricPlatform>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.FabricPlatform>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.FabricPlatform>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirewallRules : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.FirewallRules>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.FirewallRules>
    {
        public FirewallRules() { }
        public Azure.ResourceManager.Datadog.Models.AllowType? AzureServices { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.AllowType? CallerClientIP { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> IPRanges { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.FirewallRules System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.FirewallRules>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.FirewallRules>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.FirewallRules System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.FirewallRules>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.FirewallRules>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.FirewallRules>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultSecretReferenceSecretInfo : Azure.ResourceManager.Datadog.Models.SecretInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.KeyVaultSecretReferenceSecretInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.KeyVaultSecretReferenceSecretInfo>
    {
        public KeyVaultSecretReferenceSecretInfo() { }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.KeyVaultSecretReferenceSecretInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.KeyVaultSecretReferenceSecretInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.KeyVaultSecretReferenceSecretInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.KeyVaultSecretReferenceSecretInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.KeyVaultSecretReferenceSecretInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.KeyVaultSecretReferenceSecretInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.KeyVaultSecretReferenceSecretInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultSecretUriSecretInfo : Azure.ResourceManager.Datadog.Models.SecretInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.KeyVaultSecretUriSecretInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.KeyVaultSecretUriSecretInfo>
    {
        public KeyVaultSecretUriSecretInfo() { }
        public string Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.KeyVaultSecretUriSecretInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.KeyVaultSecretUriSecretInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.KeyVaultSecretUriSecretInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.KeyVaultSecretUriSecretInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.KeyVaultSecretUriSecretInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.KeyVaultSecretUriSecretInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.KeyVaultSecretUriSecretInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkerConfigurationType : System.IEquatable<Azure.ResourceManager.Datadog.Models.LinkerConfigurationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkerConfigurationType(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.LinkerConfigurationType Default { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.LinkerConfigurationType KeyVaultSecret { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.LinkerConfigurationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.LinkerConfigurationType left, Azure.ResourceManager.Datadog.Models.LinkerConfigurationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.LinkerConfigurationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.LinkerConfigurationType left, Azure.ResourceManager.Datadog.Models.LinkerConfigurationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinkerPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.LinkerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.LinkerPatch>
    {
        public LinkerPatch() { }
        public Azure.ResourceManager.Datadog.Models.AuthInfoBase AuthInfo { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.ClientType? ClientType { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.ConfigurationInfo ConfigurationInfo { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.PublicNetworkSolution PublicNetworkSolution { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.SecretStore SecretStore { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.TargetServiceBase TargetService { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.VNetSolution VNetSolution { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.LinkerPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.LinkerPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.LinkerPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.LinkerPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.LinkerPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.LinkerPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.LinkerPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PermissionsMissingDryrunPrerequisiteResult : Azure.ResourceManager.Datadog.Models.DryrunPrerequisiteResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.PermissionsMissingDryrunPrerequisiteResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.PermissionsMissingDryrunPrerequisiteResult>
    {
        internal PermissionsMissingDryrunPrerequisiteResult() { }
        public System.Collections.Generic.IReadOnlyList<string> Permissions { get { throw null; } }
        public string RecommendedRole { get { throw null; } }
        public string Scope { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.PermissionsMissingDryrunPrerequisiteResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.PermissionsMissingDryrunPrerequisiteResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.PermissionsMissingDryrunPrerequisiteResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.PermissionsMissingDryrunPrerequisiteResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.PermissionsMissingDryrunPrerequisiteResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.PermissionsMissingDryrunPrerequisiteResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.PermissionsMissingDryrunPrerequisiteResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicNetworkSolution : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.PublicNetworkSolution>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.PublicNetworkSolution>
    {
        public PublicNetworkSolution() { }
        public Azure.ResourceManager.Datadog.Models.ActionType? Action { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.DeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.FirewallRules FirewallRules { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.PublicNetworkSolution System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.PublicNetworkSolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.PublicNetworkSolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.PublicNetworkSolution System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.PublicNetworkSolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.PublicNetworkSolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.PublicNetworkSolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecretAuthInfo : Azure.ResourceManager.Datadog.Models.AuthInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.SecretAuthInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SecretAuthInfo>
    {
        public SecretAuthInfo() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.SecretInfoBase SecretInfo { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.SecretAuthInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.SecretAuthInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.SecretAuthInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.SecretAuthInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SecretAuthInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SecretAuthInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SecretAuthInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class SecretInfoBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.SecretInfoBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SecretInfoBase>
    {
        protected SecretInfoBase() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.SecretInfoBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.SecretInfoBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.SecretInfoBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.SecretInfoBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SecretInfoBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SecretInfoBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SecretInfoBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecretSourceType : System.IEquatable<Azure.ResourceManager.Datadog.Models.SecretSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecretSourceType(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.SecretSourceType KeyVaultSecret { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.SecretSourceType RawValue { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.SecretSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.SecretSourceType left, Azure.ResourceManager.Datadog.Models.SecretSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.SecretSourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.SecretSourceType left, Azure.ResourceManager.Datadog.Models.SecretSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecretStore : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.SecretStore>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SecretStore>
    {
        public SecretStore() { }
        public string KeyVaultId { get { throw null; } set { } }
        public string KeyVaultSecretName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.SecretStore System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.SecretStore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.SecretStore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.SecretStore System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SecretStore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SecretStore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SecretStore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SelfHostedServer : Azure.ResourceManager.Datadog.Models.TargetServiceBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.SelfHostedServer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SelfHostedServer>
    {
        public SelfHostedServer() { }
        public string Endpoint { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.SelfHostedServer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.SelfHostedServer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.SelfHostedServer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.SelfHostedServer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SelfHostedServer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SelfHostedServer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SelfHostedServer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServicePrincipalCertificateAuthInfo : Azure.ResourceManager.Datadog.Models.AuthInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ServicePrincipalCertificateAuthInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ServicePrincipalCertificateAuthInfo>
    {
        public ServicePrincipalCertificateAuthInfo(string clientId, string principalId, string certificate) { }
        public string Certificate { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.DeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ServicePrincipalCertificateAuthInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ServicePrincipalCertificateAuthInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ServicePrincipalCertificateAuthInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ServicePrincipalCertificateAuthInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ServicePrincipalCertificateAuthInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ServicePrincipalCertificateAuthInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ServicePrincipalCertificateAuthInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServicePrincipalSecretAuthInfo : Azure.ResourceManager.Datadog.Models.AuthInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ServicePrincipalSecretAuthInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ServicePrincipalSecretAuthInfo>
    {
        public ServicePrincipalSecretAuthInfo(string clientId, string principalId, string secret) { }
        public string ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.DeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        public string Secret { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ServicePrincipalSecretAuthInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ServicePrincipalSecretAuthInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ServicePrincipalSecretAuthInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ServicePrincipalSecretAuthInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ServicePrincipalSecretAuthInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ServicePrincipalSecretAuthInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ServicePrincipalSecretAuthInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SourceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.SourceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SourceConfiguration>
    {
        internal SourceConfiguration() { }
        public Azure.ResourceManager.Datadog.Models.LinkerConfigurationType? ConfigType { get { throw null; } }
        public string Description { get { throw null; } }
        public string KeyVaultReferenceIdentity { get { throw null; } }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.SourceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.SourceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.SourceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.SourceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SourceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SourceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SourceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SystemAssignedIdentityAuthInfo : Azure.ResourceManager.Datadog.Models.AuthInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.SystemAssignedIdentityAuthInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SystemAssignedIdentityAuthInfo>
    {
        public SystemAssignedIdentityAuthInfo() { }
        public Azure.ResourceManager.Datadog.Models.DeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        public string UserName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.SystemAssignedIdentityAuthInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.SystemAssignedIdentityAuthInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.SystemAssignedIdentityAuthInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.SystemAssignedIdentityAuthInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SystemAssignedIdentityAuthInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SystemAssignedIdentityAuthInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SystemAssignedIdentityAuthInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TargetServiceBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.TargetServiceBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.TargetServiceBase>
    {
        protected TargetServiceBase() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.TargetServiceBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.TargetServiceBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.TargetServiceBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.TargetServiceBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.TargetServiceBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.TargetServiceBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.TargetServiceBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserAccountAuthInfo : Azure.ResourceManager.Datadog.Models.AuthInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.UserAccountAuthInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.UserAccountAuthInfo>
    {
        public UserAccountAuthInfo() { }
        public Azure.ResourceManager.Datadog.Models.DeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        public string UserName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.UserAccountAuthInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.UserAccountAuthInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.UserAccountAuthInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.UserAccountAuthInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.UserAccountAuthInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.UserAccountAuthInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.UserAccountAuthInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserAssignedIdentityAuthInfo : Azure.ResourceManager.Datadog.Models.AuthInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.UserAssignedIdentityAuthInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.UserAssignedIdentityAuthInfo>
    {
        public UserAssignedIdentityAuthInfo() { }
        public string ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.DeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        public string SubscriptionId { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.UserAssignedIdentityAuthInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.UserAssignedIdentityAuthInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.UserAssignedIdentityAuthInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.UserAssignedIdentityAuthInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.UserAssignedIdentityAuthInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.UserAssignedIdentityAuthInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.UserAssignedIdentityAuthInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ValidateOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ValidateOperationResult>
    {
        internal ValidateOperationResult() { }
        public Azure.ResourceManager.Datadog.Models.AuthType? AuthType { get { throw null; } }
        public bool? IsConnectionAvailable { get { throw null; } }
        public string LinkerName { get { throw null; } }
        public System.DateTimeOffset? ReportEndTimeUtc { get { throw null; } }
        public System.DateTimeOffset? ReportStartTimeUtc { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string SourceId { get { throw null; } }
        public string Status { get { throw null; } }
        public string TargetId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Datadog.Models.ValidationResultItem> ValidationDetail { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ValidateOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ValidateOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ValidateOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ValidateOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ValidateOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ValidateOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ValidateOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationResultItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ValidationResultItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ValidationResultItem>
    {
        internal ValidationResultItem() { }
        public string Description { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.ValidationResultStatus? Result { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ValidationResultItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ValidationResultItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ValidationResultItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ValidationResultItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ValidationResultItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ValidationResultItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ValidationResultItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationResultStatus : System.IEquatable<Azure.ResourceManager.Datadog.Models.ValidationResultStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationResultStatus(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.ValidationResultStatus Failure { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ValidationResultStatus Success { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ValidationResultStatus Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.ValidationResultStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.ValidationResultStatus left, Azure.ResourceManager.Datadog.Models.ValidationResultStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.ValidationResultStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.ValidationResultStatus left, Azure.ResourceManager.Datadog.Models.ValidationResultStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ValueSecretInfo : Azure.ResourceManager.Datadog.Models.SecretInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ValueSecretInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ValueSecretInfo>
    {
        public ValueSecretInfo() { }
        public string Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ValueSecretInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ValueSecretInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ValueSecretInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ValueSecretInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ValueSecretInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ValueSecretInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ValueSecretInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VNetSolution : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.VNetSolution>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.VNetSolution>
    {
        public VNetSolution() { }
        public Azure.ResourceManager.Datadog.Models.DeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.VNetSolutionType? SolutionType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.VNetSolution System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.VNetSolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.VNetSolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.VNetSolution System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.VNetSolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.VNetSolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.VNetSolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VNetSolutionType : System.IEquatable<Azure.ResourceManager.Datadog.Models.VNetSolutionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VNetSolutionType(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.VNetSolutionType PrivateLink { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.VNetSolutionType ServiceEndpoint { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.VNetSolutionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.VNetSolutionType left, Azure.ResourceManager.Datadog.Models.VNetSolutionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.VNetSolutionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.VNetSolutionType left, Azure.ResourceManager.Datadog.Models.VNetSolutionType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
