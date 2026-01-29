namespace Azure.ResourceManager.ResourceConnector
{
    public partial class AzureResourceManagerResourceConnectorContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerResourceConnectorContext() { }
        public static Azure.ResourceManager.ResourceConnector.AzureResourceManagerResourceConnectorContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ResourceConnectorApplianceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource>, System.Collections.IEnumerable
    {
        protected ResourceConnectorApplianceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceConnectorApplianceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceData>
    {
        public ResourceConnectorApplianceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ResourceConnector.Models.ApplianceDistro? Distro { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceConnector.Models.ApplianceEvent> Events { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceConnector.Models.ApplianceProvider? InfrastructureConfigProvider { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceConnector.Models.ApplianceNetworkProfile NetworkProfile { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string PublicKey { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus? Status { get { throw null; } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceConnectorApplianceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceConnectorApplianceResource() { }
        public virtual Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResult> GetClusterUserCredential(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResult>> GetClusterUserCredentialAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResult> GetKeys(string artifactType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResult>> GetKeysAsync(string artifactType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraph> GetUpgradeGraph(string upgradeGraph, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraph>> GetUpgradeGraphAsync(string upgradeGraph, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> Update(Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorAppliancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource>> UpdateAsync(Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorAppliancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ResourceConnectorExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceTelemetryConfigResult> GetApplianceTelemetryConfig(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceTelemetryConfigResult>> GetApplianceTelemetryConfigAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> GetResourceConnectorAppliance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource>> GetResourceConnectorApplianceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource GetResourceConnectorApplianceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceCollection GetResourceConnectorAppliances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> GetResourceConnectorAppliances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> GetResourceConnectorAppliancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ResourceConnector.Mocking
{
    public partial class MockableResourceConnectorArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableResourceConnectorArmClient() { }
        public virtual Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource GetResourceConnectorApplianceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableResourceConnectorResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourceConnectorResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> GetResourceConnectorAppliance(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource>> GetResourceConnectorApplianceAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceCollection GetResourceConnectorAppliances() { throw null; }
    }
    public partial class MockableResourceConnectorSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourceConnectorSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceTelemetryConfigResult> GetApplianceTelemetryConfig(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceTelemetryConfigResult>> GetApplianceTelemetryConfigAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> GetResourceConnectorAppliances(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> GetResourceConnectorAppliancesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ResourceConnector.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessProfileType : System.IEquatable<Azure.ResourceManager.ResourceConnector.Models.AccessProfileType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessProfileType(string value) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.AccessProfileType ClusterCustomerUser { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.AccessProfileType ClusterUser { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceConnector.Models.AccessProfileType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceConnector.Models.AccessProfileType left, Azure.ResourceManager.ResourceConnector.Models.AccessProfileType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceConnector.Models.AccessProfileType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceConnector.Models.AccessProfileType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceConnector.Models.AccessProfileType left, Azure.ResourceManager.ResourceConnector.Models.AccessProfileType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplianceArtifactProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceArtifactProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceArtifactProfile>
    {
        internal ApplianceArtifactProfile() { }
        public string Endpoint { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceArtifactProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceArtifactProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceArtifactProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceArtifactProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceArtifactProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceArtifactProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceArtifactProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceArtifactProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceArtifactProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplianceCredentialKubeconfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig>
    {
        internal ApplianceCredentialKubeconfig() { }
        public Azure.ResourceManager.ResourceConnector.Models.AccessProfileType? Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplianceDistro : System.IEquatable<Azure.ResourceManager.ResourceConnector.Models.ApplianceDistro>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplianceDistro(string value) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceDistro AksEdge { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceConnector.Models.ApplianceDistro other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceConnector.Models.ApplianceDistro left, Azure.ResourceManager.ResourceConnector.Models.ApplianceDistro right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceConnector.Models.ApplianceDistro (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceConnector.Models.ApplianceDistro? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceConnector.Models.ApplianceDistro left, Azure.ResourceManager.ResourceConnector.Models.ApplianceDistro right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplianceEvent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceEvent>
    {
        internal ApplianceEvent() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Severity { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceEvent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceEvent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceEvent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceEvent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplianceListCredentialResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResult>
    {
        internal ApplianceListCredentialResult() { }
        public Azure.ResourceManager.ResourceConnector.Models.HybridConnectionConfig HybridConnectionConfig { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig> Kubeconfigs { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplianceListKeysResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResult>
    {
        internal ApplianceListKeysResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.ResourceConnector.Models.ApplianceArtifactProfile> ArtifactProfiles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig> Kubeconfigs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.ResourceConnector.Models.ApplianceSshKey> SshKeys { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplianceNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceNetworkProfile>
    {
        public ApplianceNetworkProfile() { }
        public string DnsVersion { get { throw null; } set { } }
        public string GatewayVersion { get { throw null; } set { } }
        public string ProxyVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceNetworkProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceNetworkProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplianceProvider : System.IEquatable<Azure.ResourceManager.ResourceConnector.Models.ApplianceProvider>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplianceProvider(string value) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceProvider Hci { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceProvider Scvmm { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceProvider VMware { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceConnector.Models.ApplianceProvider other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceConnector.Models.ApplianceProvider left, Azure.ResourceManager.ResourceConnector.Models.ApplianceProvider right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceConnector.Models.ApplianceProvider (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceConnector.Models.ApplianceProvider? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceConnector.Models.ApplianceProvider left, Azure.ResourceManager.ResourceConnector.Models.ApplianceProvider right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplianceSshKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSshKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSshKey>
    {
        internal ApplianceSshKey() { }
        public string Certificate { get { throw null; } }
        public long? CreationTimeStamp { get { throw null; } }
        public long? ExpirationTimeStamp { get { throw null; } }
        public string PrivateKey { get { throw null; } }
        public string PublicKey { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceSshKey JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceSshKey PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceSshKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSshKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSshKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceSshKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSshKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSshKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSshKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplianceStatus : System.IEquatable<Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplianceStatus(string value) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus ArcGatewayUpdateComplete { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus ArcGatewayUpdateFailed { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus ArcGatewayUpdatePreparing { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus ArcGatewayUpdating { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus Connected { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus Connecting { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus EtcdSnapshotFailed { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus ImageDeprovisioning { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus ImageDownloaded { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus ImageDownloading { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus ImagePending { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus ImageProvisioned { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus ImageProvisioning { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus ImageUnknown { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus NetworkDnsUpdateComplete { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus NetworkDnsUpdateFailed { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus NetworkDnsUpdatePreparing { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus NetworkDnsUpdating { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus NetworkProxyUpdateComplete { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus NetworkProxyUpdateFailed { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus NetworkProxyUpdatePreparing { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus NetworkProxyUpdating { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus None { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus PostUpgrade { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus PreparingForUpgrade { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus PreUpgrade { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus Running { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus UpdatingCapi { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus UpdatingCloudOperator { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus UpdatingCluster { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus UpgradeClusterExtensionFailedToDelete { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus UpgradeComplete { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus UpgradeFailed { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus UpgradePrerequisitesCompleted { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus UpgradingKvaio { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus Validating { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus ValidatingEtcdHealth { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus ValidatingImageDownload { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus ValidatingImageUpload { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus ValidatingSFSConnectivity { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus WaitingForCloudOperator { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus WaitingForHeartbeat { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus WaitingForKvaio { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus left, Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus left, Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplianceSupportedVersion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersion>
    {
        internal ApplianceSupportedVersion() { }
        public Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersion MetadataCatalogVersion { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplianceSupportedVersionCatalogVersion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersion>
    {
        internal ApplianceSupportedVersionCatalogVersion() { }
        public Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersionProperties Data { get { throw null; } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplianceSupportedVersionCatalogVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersionProperties>
    {
        internal ApplianceSupportedVersionCatalogVersionProperties() { }
        public string Audience { get { throw null; } }
        public string Catalog { get { throw null; } }
        public string Offer { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplianceTelemetryConfigResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceTelemetryConfigResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceTelemetryConfigResult>
    {
        internal ApplianceTelemetryConfigResult() { }
        public string TelemetryInstrumentationKey { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceTelemetryConfigResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceTelemetryConfigResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceTelemetryConfigResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceTelemetryConfigResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceTelemetryConfigResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceTelemetryConfigResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceTelemetryConfigResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceTelemetryConfigResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceTelemetryConfigResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplianceUpgradeGraph : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraph>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraph>
    {
        internal ApplianceUpgradeGraph() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraphProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraph JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraph PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraph System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraph>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraph>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraph System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraph>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraph>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraph>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplianceUpgradeGraphProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraphProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraphProperties>
    {
        internal ApplianceUpgradeGraphProperties() { }
        public string ApplianceVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersion> SupportedVersions { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraphProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraphProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraphProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraphProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraphProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraphProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraphProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraphProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraphProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmResourceConnectorModelFactory
    {
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceArtifactProfile ApplianceArtifactProfile(string endpoint = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig ApplianceCredentialKubeconfig(Azure.ResourceManager.ResourceConnector.Models.AccessProfileType? name = default(Azure.ResourceManager.ResourceConnector.Models.AccessProfileType?), string value = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceEvent ApplianceEvent(string type = null, string code = null, string status = null, string message = null, string severity = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResult ApplianceListCredentialResult(Azure.ResourceManager.ResourceConnector.Models.HybridConnectionConfig hybridConnectionConfig = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig> kubeconfigs = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResult ApplianceListKeysResult(System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.ResourceConnector.Models.ApplianceArtifactProfile> artifactProfiles = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig> kubeconfigs = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.ResourceConnector.Models.ApplianceSshKey> sshKeys = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceSshKey ApplianceSshKey(string certificate = null, long? creationTimeStamp = default(long?), long? expirationTimeStamp = default(long?), string privateKey = null, string publicKey = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersion ApplianceSupportedVersion(Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersion metadataCatalogVersion = null, string version = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersion ApplianceSupportedVersionCatalogVersion(Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersionProperties data = null, string name = null, string @namespace = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersionProperties ApplianceSupportedVersionCatalogVersionProperties(string audience = null, string catalog = null, string offer = null, string version = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceTelemetryConfigResult ApplianceTelemetryConfigResult(string telemetryInstrumentationKey = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraph ApplianceUpgradeGraph(string id = null, string name = null, Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraphProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraphProperties ApplianceUpgradeGraphProperties(string applianceVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersion> supportedVersions = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.HybridConnectionConfig HybridConnectionConfig(long? expirationTime = default(long?), string hybridConnectionName = null, string relay = null, string token = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceData ResourceConnectorApplianceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ResourceConnector.Models.ApplianceDistro? distro = default(Azure.ResourceManager.ResourceConnector.Models.ApplianceDistro?), string provisioningState = null, string publicKey = null, Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus? status = default(Azure.ResourceManager.ResourceConnector.Models.ApplianceStatus?), string version = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceConnector.Models.ApplianceEvent> events = null, Azure.ResourceManager.ResourceConnector.Models.ApplianceNetworkProfile networkProfile = null, Azure.ResourceManager.ResourceConnector.Models.ApplianceProvider? infrastructureConfigProvider = default(Azure.ResourceManager.ResourceConnector.Models.ApplianceProvider?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorAppliancePatch ResourceConnectorAppliancePatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
    }
    public partial class HybridConnectionConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.HybridConnectionConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.HybridConnectionConfig>
    {
        internal HybridConnectionConfig() { }
        public long? ExpirationTime { get { throw null; } }
        public string HybridConnectionName { get { throw null; } }
        public string Relay { get { throw null; } }
        public string Token { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.HybridConnectionConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.HybridConnectionConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.HybridConnectionConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.HybridConnectionConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.HybridConnectionConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.HybridConnectionConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.HybridConnectionConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.HybridConnectionConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.HybridConnectionConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceConnectorAppliancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorAppliancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorAppliancePatch>
    {
        public ResourceConnectorAppliancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorAppliancePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorAppliancePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorAppliancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorAppliancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorAppliancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorAppliancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorAppliancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorAppliancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorAppliancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
